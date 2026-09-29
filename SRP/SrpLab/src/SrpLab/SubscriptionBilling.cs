namespace SrpLab;

public sealed class SubscriptionBilling
{
    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }

    private readonly SubscriptionProrationCalculator _prorationCalculator = new();
    private readonly InvoiceNumberGenerator _invoiceGenerator = new();
    private readonly DunningEmailBuilder _dunningBuilder = new();
    private readonly SubscriptionLedgerExporter _ledgerExporter = new();

    public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom)
    {
        return _prorationCalculator.Calculate(MonthlyPrice, PeriodStart, PeriodEnd, activeFrom);
    }

    public string NextInvoiceNumber()
    {
        return _invoiceGenerator.Generate(PeriodStart);
    }

    public void RegisterFailedPayment() => FailedPayments++;

    public string DunningEmail(string customerName, DateOnly asOf)
    {
        var amount = Prorate(PeriodStart);
        var invoice = NextInvoiceNumber(); 
        return _dunningBuilder.Build(customerName, asOf, amount, invoice, FailedPayments);
    }

    public string LedgerJournalLine(DateOnly activeFrom)
    {
        var invoice = NextInvoiceNumber();
        var amount = Prorate(activeFrom);
        return _ledgerExporter.ExportLine(CustomerId, invoice, amount);
    }
}
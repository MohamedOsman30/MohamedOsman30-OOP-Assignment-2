namespace SrpLab;

public sealed class SubscriptionLedgerExporter
{
    public string ExportLine(string customerId, string invoiceNumber, decimal proratedAmount)
    {
        return $"{customerId},{invoiceNumber},{proratedAmount:0.00},AR-SUB";
    }
}
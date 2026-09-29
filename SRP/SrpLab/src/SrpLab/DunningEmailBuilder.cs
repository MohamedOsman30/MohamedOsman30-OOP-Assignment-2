namespace SrpLab;

public sealed class DunningEmailBuilder
{
    public string Build(string customerName, DateOnly asOf, decimal amount, string invoiceNumber, int failedPayments)
    {
        var severity = failedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };
        return $"Subject: {severity} {invoiceNumber}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
    }
}
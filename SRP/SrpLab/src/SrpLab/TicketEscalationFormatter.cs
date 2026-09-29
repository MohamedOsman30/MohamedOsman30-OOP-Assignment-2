namespace SrpLab;

public sealed class TicketEscalationFormatter
{
    public string FormatBlurb(string id, string priority, DateTimeOffset deadline)
    {
        return $"ESCALATE {id} priority={priority} breachAt={deadline:u} keywords-scanned=yes";
    }
}
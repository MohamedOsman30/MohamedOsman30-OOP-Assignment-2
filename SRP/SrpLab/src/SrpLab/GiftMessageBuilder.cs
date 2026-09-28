namespace SrpLab;

public sealed class GiftMessageBuilder
{
    public string BuildMessage(string fromName, IReadOnlyList<(string Sku, decimal Price, int Qty)> lines, decimal grandTotal)
    {
        var items = string.Join(", ", lines.Select(l => l.Sku));
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }
}
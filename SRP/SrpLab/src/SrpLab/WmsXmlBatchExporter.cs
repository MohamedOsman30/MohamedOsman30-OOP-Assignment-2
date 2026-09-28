namespace SrpLab;

public sealed class WmsXmlBatchExporter
{
    public string Export(string batchId, IReadOnlyList<(string Sku, int Allocated)> allocations)
    {
        var parts = allocations.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}
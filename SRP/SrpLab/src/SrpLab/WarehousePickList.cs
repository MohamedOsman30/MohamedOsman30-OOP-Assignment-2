namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

    private readonly WarehouseStockAllocator _stockAllocator = new();
    private readonly WarehouseWalkingPathPlanner _pathPlanner = new();
    private readonly PickerScriptBuilder _scriptBuilder = new();
    private readonly WmsXmlBatchExporter _xmlExporter = new();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        return _stockAllocator.Allocate(_lines);
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        return _pathPlanner.Plan(_lines);
    }

    public string PickerScript()
    {
        var order = WalkingOrder();
        var allocation = Allocate();
        return _scriptBuilder.Build(order, allocation, _lines);
    }

    public string WmsXmlBatch(string batchId)
    {
        var allocation = Allocate();
        return _xmlExporter.Export(batchId, allocation);
    }
}
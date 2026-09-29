namespace SrpLab;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    private readonly KitchenAllergenScanner _allergenScanner = new();
    private readonly KitchenEtaCalculator _etaCalculator = new();
    private readonly ThermalTicketRenderer _ticketRenderer = new();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenScanner.Scan(_items);
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        var allergensCount = DetectAllergens().Count;
        return _etaCalculator.Calculate(openStations, _items, allergensCount);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        var eta = EstimatedReadyMinutes(2);
        var allergens = DetectAllergens();
        return _ticketRenderer.Render(orderNumber, eta, _items, allergens);
    }

    public string ExpoLaneHint()
    {
        return DetectAllergens().Count > 0 ? "LANE-ALLERGY" : EstimatedReadyMinutes(2) > 20 ? "LANE-SLOW" : "LANE-FAST";
    }
}
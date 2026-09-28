namespace SrpLab;

public sealed class GradeCsvExporter
{
    public string Export(IReadOnlyDictionary<string, List<decimal>> scores, GradePolicyEvaluator policyEvaluator)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var id in scores.Keys.OrderBy(x => x))
        {
            var list = scores[id];
            var avg = list.Count == 0 ? 0m : Math.Round(list.Average(), 2);
            var letter = policyEvaluator.CalculateLetter(avg);
            var honor = policyEvaluator.MeetsHonorRoll(avg, letter);
            rows.Add($"{id},{avg},{letter},{(honor ? 1 : 0)}");
        }
        return string.Join('\n', rows);
    }
}
namespace SrpLab;

public sealed class LoanAnalyticsExporter
{
    public string ExportRow(string applicationId, int creditScore, int employmentMonths, bool hasCollateral, decimal riskScore, bool isEligible)
    {
        return $"{applicationId},{creditScore},{employmentMonths},{(hasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
    }
}
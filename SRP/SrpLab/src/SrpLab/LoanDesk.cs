namespace SrpLab;

public sealed class LoanDesk
{
    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    private readonly LoanRiskCalculator _riskCalculator = new();
    private readonly LoanDocumentChecklist _documentChecklist = new();
    private readonly LoanDecisionLetterBuilder _letterBuilder = new();
    private readonly LoanAnalyticsExporter _analyticsExporter = new();

    public LoanDesk(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskCalculator.CalculateRiskScore(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public bool IsEligible()
    {
        return _riskCalculator.CheckEligibility(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _documentChecklist.GetRequiredDocuments(RequestedAmount, EmploymentMonths, HasCollateral, IsEligible());
    }

    public string DecisionLetter(string applicantName)
    {
        return _letterBuilder.BuildLetter(applicantName, RequestedAmount, RiskScore(), IsEligible(), RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _analyticsExporter.ExportRow(applicationId, CreditScore, EmploymentMonths, HasCollateral, RiskScore(), IsEligible());
    }
}
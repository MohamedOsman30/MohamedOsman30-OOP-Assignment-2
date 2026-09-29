namespace LibrarySystem.Models.Items;

public class LibraryItem
{
    public string CatalogNumber { get; }
    public string Title { get; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; internal set; }
    public int LoanPeriodDays { get; }
    public decimal LateFeeMultiplier { get; }

    protected LibraryItem(string catalogNumber, string title, decimal baseLateFee, int loanPeriodDays, decimal lateFeeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber)) throw new ArgumentException("CatalogNumber required.");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required.");
        if (baseLateFee <= 0) throw new ArgumentException("Base late fee must be positive.");

        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        LoanPeriodDays = loanPeriodDays;
        LateFeeMultiplier = lateFeeMultiplier;
        IsWithdrawn = false;
        IsOnLoan = false;
    }

    public void UpdateBaseLateFee(decimal newFee)
    {
        if (newFee <= 0) throw new ArgumentException("Fee must be greater than zero.");
        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public decimal GetDailyLateFee()
    {
        return BaseLateFee * LateFeeMultiplier;
    }
}
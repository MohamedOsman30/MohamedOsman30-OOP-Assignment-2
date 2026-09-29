using LibrarySystem.Models;
namespace LibrarySystem.Models.Persons;

public class Member : Person
{
    private readonly List<Loan> _loans = new();
    public IReadOnlyList<Loan> Loans => _loans;
    public int MaxLoans { get; }
    public decimal DiscountPercentage { get; }

    protected Member(string personId, string fullName, string phone, int maxLoans, decimal discountPercentage)
        : base(personId, fullName, phone)
    {
        MaxLoans = maxLoans;
        DiscountPercentage = discountPercentage;
    }

    internal void AddLoan(Loan loan)
    {
        if (_loans.Count >= MaxLoans)
            throw new InvalidOperationException("Member has reached maximum loan limit.");
        _loans.Add(loan);
    }

    public virtual void RecordReturnAction()
    {
        
    }
}
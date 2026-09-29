namespace LibrarySystem.Models.Persons;

public class Librarian : Staff
{
    public Librarian(string personId, string fullName, string phone, DateOnly hireDate, decimal salary)
        : base(personId, fullName, phone, hireDate, salary, allowance: 0m)
    {
    }

    public void ProcessReturn(Loan loan)
    {
        loan.ReturnItem();
    }

    public void MarkAsLost(Loan loan)
    {
        loan.MarkLost();
    }
}
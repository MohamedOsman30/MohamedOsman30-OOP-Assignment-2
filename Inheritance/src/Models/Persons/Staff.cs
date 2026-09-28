namespace LibrarySystem.Models.Persons;

public class Staff : Person
{
    public DateOnly HireDate { get; }
    public decimal MonthlySalary { get; private set; }
    protected decimal Allowance { get; }

    protected Staff(string personId, string fullName, string phone, DateOnly hireDate, decimal initialSalary, decimal allowance)
        : base(personId, fullName, phone)
    {
        if (initialSalary <= 0) throw new ArgumentException("Salary must be positive.");
        HireDate = hireDate;
        MonthlySalary = initialSalary;
        Allowance = allowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0) throw new ArgumentException("Raise percentage must be greater than zero.");
        MonthlySalary += MonthlySalary * (percentage / 100m);
    }

    public decimal GetMonthlyPay()
    {
        return MonthlySalary + Allowance;
    }
}
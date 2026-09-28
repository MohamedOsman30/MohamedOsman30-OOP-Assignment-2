namespace LibrarySystem.Models.Persons;
using LibrarySystem.Models.Items;
public class HeadLibrarian : Staff
{
    public HeadLibrarian(string personId, string fullName, string phone, DateOnly hireDate, decimal salary)
        : base(personId, fullName, phone, hireDate, salary, allowance: 400m)
    {
    }

    public void ChangeItemPrice(LibraryItem item, decimal newFee)
    {
        item.UpdateBaseLateFee(newFee);
    }

    public void WithdrawItem(LibraryItem item)
    {
        item.Withdraw();
    }

    public void RestoreItem(LibraryItem item)
    {
        item.Restore();
    }
}
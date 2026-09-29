using LibrarySystem.Enums;
using LibrarySystem.Models.Items;
using LibrarySystem.Models.Persons;

namespace LibrarySystem.Models;

public class Loan
{
    public string LoanId { get; }
    public DateOnly BorrowDate { get; }
    public Member Borrower { get; }
    public LibraryItem Item { get; }
    public LoanStatus Status { get; private set; }
    public DateOnly? ReturnDate { get; private set; }

    public DateOnly DueDate => BorrowDate.AddDays(Item.LoanPeriodDays);

    public decimal LateFee
    {
        get
        {
            if (ReturnDate == null || ReturnDate <= DueDate)
                return 0m;

            int daysLate = ReturnDate.Value.DayNumber - DueDate.DayNumber;
            decimal rawFee = daysLate * Item.GetDailyLateFee();
            decimal discount = rawFee * (Borrower.DiscountPercentage / 100m);
            decimal finalFee = rawFee - discount;
            return finalFee < 0m ? 0m : finalFee;
        }
    }

    public Loan(string loanId, DateOnly borrowDate, Member borrower, LibraryItem item)
    {
        if (string.IsNullOrWhiteSpace(loanId)) throw new ArgumentException("LoanId required.");
        if (item.IsWithdrawn) throw new InvalidOperationException("Cannot borrow a withdrawn item.");
        if (item.IsOnLoan) throw new InvalidOperationException("Item is already on loan.");

        LoanId = loanId;
        BorrowDate = borrowDate;
        Borrower = borrower;
        Item = item;
        Status = LoanStatus.Borrowed;

        item.IsOnLoan = true;
        borrower.AddLoan(this);
    }

    public void ReturnItem()
    {
        ReturnItemAt(DateOnly.FromDateTime(DateTime.Now));
    }

    public void ReturnItemAt(DateOnly returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only active borrowed loans can be returned.");
        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be earlier than borrow date.");

        Status = LoanStatus.Returned;
        ReturnDate = returnDate;
        Item.IsOnLoan = false;

        
        if (Borrower is PremiumMember premium)
        {
            premium.AddReadingPoints(5);
        }
    }

    public void MarkLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only active borrowed loans can be marked as lost.");

        Status = LoanStatus.Lost;
        Item.IsOnLoan = false;
    }
}
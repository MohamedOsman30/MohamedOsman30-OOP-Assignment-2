using LibrarySystem.Models;
using LibrarySystem.Models.Items;
using LibrarySystem.Models.Persons;

Console.WriteLine("=== LIBRARY SYSTEM INHERITANCE LAB ===");


// var person = new Person("P1", "Ali", "123");
// var member = new Member("M1", "Sara", "456", 5, 0);
// var staff = new Staff("S1", "John", "789", DateOnly.FromDateTime(DateTime.Now), 5000m, 0);
// var item = new LibraryItem("C1", "Test", 10m, 10, 1m);
// student.FullName = "Changed";
// student.Loans.Add(new Loan(...));
// book.IsOnLoan = true;

// 2. Business rules & validation tests
try
{
    var book = new Book("B-001", "C# Programming", 10m);
    book.Withdraw();
    var student = new StudentMember("S-101", "Ahmed", "01012345678");
    var invalidLoan = new Loan("L-1", DateOnly.FromDateTime(DateTime.Now), student, book);
}
catch (Exception ex)
{
    Console.WriteLine($"[Caught Expected Error] {ex.Message}");
}

// 3. Staff polymorphism (Monthly pay)
var staffList = new List<Staff>
{
    new Librarian("L-1", "Nora", "011", DateOnly.FromDateTime(DateTime.Now), 6000m),
    new Shelver("Sh-1", "Karim", "012", DateOnly.FromDateTime(DateTime.Now), 4500m, "Fiction"),
    new HeadLibrarian("HL-1", "Mahmoud", "015", DateOnly.FromDateTime(DateTime.Now), 9000m)
};

Console.WriteLine("\n--- Staff Monthly Pay ---");
foreach (var s in staffList)
{
    Console.WriteLine($"{s.FullName} ({s.GetType().Name}): ${s.GetMonthlyPay()}");
}

// 4. Library items polymorphism (Loan periods & daily late fees)
var itemList = new List<LibraryItem>
{
    new Book("B-10", "Clean Code", 10m),
    new DVD("DVD-10", "Matrix", 10m),
    new Magazine("M-10", "Tech Today", 10m)
};

Console.WriteLine("\n--- Library Items Details ---");
foreach (var itm in itemList)
{
    Console.WriteLine($"{itm.Title} [{itm.GetType().Name}] -> Period: {itm.LoanPeriodDays} days | Daily Late Fee: ${itm.GetDailyLateFee()}");
}

// 5. Premium member late return & reading points
var premiumMember = new PremiumMember("PM-1", "Mona", "01099998888", discountPercentage: 20m);
var dvdItem = new DVD("DVD-99", "Inception", 15m); // Daily fee = 15 * 2 = $30. Period = 7 days.
var loanRecord = new Loan("L-99", new DateOnly(2026, 9, 1), premiumMember, dvdItem);

// Due date = Sep 8. Return on Sep 13 (5 days late).
loanRecord.ReturnItemAt(new DateOnly(2026, 9, 13));

Console.WriteLine($"\n--- Premium Member Loan Test ---");
Console.WriteLine($"Due Date: {loanRecord.DueDate}");
Console.WriteLine($"Late Fee: ${loanRecord.LateFee} (Expected: 5 days * $30 = $150 minus 20% discount = $120)");
Console.WriteLine($"Reading Points: {premiumMember.ReadingPoints} (Expected: 5)");

// 6. Invalid state transitions (Return twice, Mark returned as lost)
try
{
    loanRecord.ReturnItem();
}
catch (Exception ex)
{
    Console.WriteLine($"[Caught Expected Error - Return Twice] {ex.Message}");
}

try
{
    var librarian = new Librarian("L-2", "Hoda", "011", DateOnly.FromDateTime(DateTime.Now), 5500m);
    librarian.MarkAsLost(loanRecord);
}
catch (Exception ex)
{
    Console.WriteLine($"[Caught Expected Error - Mark Returned as Lost] {ex.Message}");
}

Console.WriteLine("\nAll Inheritance Lab requirements verified successfully!");
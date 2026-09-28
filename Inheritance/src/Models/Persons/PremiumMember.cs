namespace LibrarySystem.Models.Persons;

public class PremiumMember : Member
{
    public int ReadingPoints { get; private set; }

    public PremiumMember(string personId, string fullName, string phone, decimal discountPercentage)
        : base(personId, fullName, phone, maxLoans: 10, discountPercentage: discountPercentage)
    {
    }

    public void AddReadingPoints(int points)
    {
        ReadingPoints += points;
    }
}
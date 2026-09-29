namespace LibrarySystem.Models.Persons;

public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(string personId, string fullName, string phone, DateOnly hireDate, decimal salary, string section)
        : base(personId, fullName, phone, hireDate, salary, allowance: 0m)
    {
        if (string.IsNullOrWhiteSpace(section)) throw new ArgumentException("Section required.");
        Section = section;
    }

    public void Reassign(string newSection)
    {
        if (string.IsNullOrWhiteSpace(newSection)) throw new ArgumentException("New section required.");
        Section = newSection;
    }
}
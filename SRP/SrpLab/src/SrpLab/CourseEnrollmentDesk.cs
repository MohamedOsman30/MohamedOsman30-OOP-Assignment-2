namespace SrpLab;

public sealed class CourseEnrollmentDesk
{
    public int Capacity => _enrollmentManager.Capacity;
    public decimal Tuition { get; }
    public string CourseCode { get; }

    private readonly CourseEnrollmentManager _enrollmentManager;
    private readonly CourseWelcomePacketBuilder _packetBuilder = new();
    private readonly CourseInvoiceFormatter _invoiceFormatter = new();

    public CourseEnrollmentDesk(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Tuition = tuition;
        _enrollmentManager = new CourseEnrollmentManager(capacity);
    }

    public string Register(string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
        return _enrollmentManager.Register(studentEmail.Trim());
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _enrollmentManager.GetWaitlistPosition(studentEmail);
    }

    public string WelcomePacketMarkdown(string studentEmail, string studentName)
    {
        var isSeated = _enrollmentManager.IsSeated(studentEmail);
        var position = _enrollmentManager.GetWaitlistPosition(studentEmail);
        return _packetBuilder.BuildPacket(CourseCode, studentEmail, studentName, isSeated, position);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        var isSeated = _enrollmentManager.IsSeated(studentEmail);
        return _invoiceFormatter.FormatInvoiceLine(CourseCode, Tuition, isSeated);
    }

    public void PromoteFromWaitlist(int seats)
    {
        _enrollmentManager.Promote(seats);
    }
}
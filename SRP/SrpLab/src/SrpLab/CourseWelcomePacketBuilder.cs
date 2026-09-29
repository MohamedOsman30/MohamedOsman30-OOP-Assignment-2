namespace SrpLab;

public sealed class CourseWelcomePacketBuilder
{
    public string BuildPacket(string courseCode, string studentEmail, string studentName, bool isSeated, int waitlistPosition)
    {
        var status = isSeated ? "confirmed seat" : $"waitlist #{waitlistPosition}";
        return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}
namespace SrpLab;

public sealed class WardBoard
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();
    
    private readonly AcuityScorer _acuityScorer = new();
    private readonly WardAlertService _alertService = new();
    private readonly HandoffNoteBuilder _handoffBuilder = new();
    private readonly WardCensusExporter _censusExporter = new();

    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        
        var acuity = _acuityScorer.ScoreAcuity(heartRate, spo2);
        _vitalsScore[bed] = acuity;

        _alertService.CheckAndAlert(bed, acuity);
    }

    public int ScoreAcuity(int heartRate, int spo2)
    {
        return _acuityScorer.ScoreAcuity(heartRate, spo2);
    }

    public string BuildHandoffNote(int bed)
    {
        _bedPatient.TryGetValue(bed, out var patient);
        _vitalsScore.TryGetValue(bed, out var acuity);
        return _handoffBuilder.Build(bed, patient, acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _alertService.DrainPagerLog();
    }

    public string ExportCensusCsv()
    {
        return _censusExporter.ExportCsv(_bedPatient, _vitalsScore);
    }
}
namespace soul_whisper.Models.Private.Data;

public class Diagnosis
{
    public required Appointment appointment { get; set; }
    public required string diagnosisDetails { get; set; }
    public required string prescription { get; set; }
    public required string notes { get; set; }
}
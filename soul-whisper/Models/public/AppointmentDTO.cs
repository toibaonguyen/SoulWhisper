

namespace soul_whisper.Models.Public;

public class AppointmentDTO
{
    public Guid? id { get; set; }
    public required string type { get; set; }
    public required DateTime startTime { get; set; }
    public required DateTime endTime { get; set; }
    public string? diagnosis { get; set; }
    public string? prescription { get; set; }
    public string? notes { get; set; }
    public required Guid doctorId { get; set; }
    public required Guid patientId { get; set; }
    public string? status { get; set; }
}
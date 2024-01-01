
namespace soul_whisper.Models.Public;

public class AppointmentRegistrationDTO
{
    public Guid? id { get; set; }
    public required AppointmentDTO appointment { get; set; }
    public required Guid doctorId { get; set; }
    public required Guid patientId { get; set; }
    public string? status { get; set; }
    public required DateTime createdAt { get; set; }
}
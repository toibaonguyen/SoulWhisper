
namespace soul_whisper.Models.Public;

public class DoctorshipRegistrationDTO
{
    public Guid? id { get; set; }
    public required DoctorDTO doctor { get; set; }
    public string? status { get; set; }
    public required DateTime createdAt { get; set; }
    public required DateTime expiredAt { get; set; }
}
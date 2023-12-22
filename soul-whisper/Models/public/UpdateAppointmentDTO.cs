

namespace soul_whisper.Models.Public;

public class UpdateAppointmentDTO
{
    public required string type { get; set; }
    public string? diagnosis { get; set; }
    public string? prescription { get; set; }
    public string? notes { get; set; }
    public string? status { get; set; }
}
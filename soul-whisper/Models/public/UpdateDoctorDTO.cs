

namespace soul_whisper.Models.Public;

public class UpdateDoctorDTO
{
    public  string? password { get; set; }
    public  string? avatar { get; set; }
    public DateOnly? birthday { get; set; }
    public  string? gender { get; set; }
    public string? activationStatus { get; set; }
}
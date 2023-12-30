
namespace soul_whisper.Models.Public;

public class DoctorDTO
{
    public Guid? id { get; set; }
    //unique
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public string? avatar { get; set; }
    public required DateOnly birthday { get; set; }
    public required string gender { get; set; }
    public string? activationStatus { get; set; }
    public required string specialty { get; set; }
    public Decimal? wallet { get; set; }
}


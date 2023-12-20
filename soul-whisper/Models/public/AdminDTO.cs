

namespace soul_whisper.Models.Public;

public class AdminDTO
{
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required DateOnly birthday { get; set; }
    public required string gender { get; set; }
}
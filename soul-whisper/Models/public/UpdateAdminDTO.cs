

namespace soul_whisper.Models.Public;

public class UpdateAdminDTO
{
    public string? email { get; set; }
    public string? password { get; set; }
    public string? name { get; set; }
    public DateOnly? birthday { get; set; }
    public string? gender { get; set; }
}
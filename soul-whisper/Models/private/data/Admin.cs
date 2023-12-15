using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Admin
{
     public required string id { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required DateOnly birthday { get; set; }
    public required Gender gender { get; set; }
    public required ActivationStatus activationStatus { get; set; }
}

using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Doctor_Registration
{
    public required Doctor Registrant { get; set; }
    public required DateTime createdAt { get; set; }
    public required RegistrationStatus status{get;set;}
}

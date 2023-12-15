
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Doctor_Registration
{
    public required long id {get;set;}
    public required Doctor registrant { get; set; }
    public required RegistrationStatus status { get; set; }
    public required DateTime createdAt { get; set; }
}

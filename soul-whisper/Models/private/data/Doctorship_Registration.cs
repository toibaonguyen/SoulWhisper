
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Doctorship_Registration
{
    public required Guid id {get;set;}
    public required Doctor registrant { get; set; }
    public required RegistrationStatus status { get; set; }
    public required DateTime createdAt { get; set; }
}

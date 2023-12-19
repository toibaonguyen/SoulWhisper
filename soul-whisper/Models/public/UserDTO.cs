using soul_whisper.Models.Public.Enum;

namespace soul_whisper.Models.Public;

public class UserDTO
{
    public required Guid userId{get; set;}
    public required UserRole role{get;set;}
}
using soul_whisper.Models.Public.Enum;

namespace soul_whisper.Models.Public;

public class UserDTO
{
    public required string userId{get; set;}
    public required Role role{get;set;}
}
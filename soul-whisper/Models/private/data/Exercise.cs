using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public.Enum;

namespace soul_whisper.Models.Private.Data;

public class Exercise
{
    public required string id { get; set; }
    public required ExerciseType type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required TimeSpan duration { get; set; }
    public required Patient patient { get; set; }
    public required Role authorRole { get; set; }
    public required string authorId { get; set; }
    public required ExerciseStatus completion {get;set;}
}

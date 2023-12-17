using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Exercise
{
    public required Guid id { get; set; }
    public required ExerciseType type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required TimeSpan duration { get; set; }
}
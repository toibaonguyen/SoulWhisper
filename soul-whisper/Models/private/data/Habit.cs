using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Habit
{
    public required string id { get; set; }
    public required HabitType type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required Patient patient { get; set; }
}

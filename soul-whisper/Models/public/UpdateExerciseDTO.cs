


namespace soul_whisper.Models.Public;

public class UpdateExerciseDTO
{
    //unique
    public  string? type { get; set; }
    public  string? name { get; set; }
    public  string? description { get; set; }
    public  TimeSpan? duration { get; set; }
}
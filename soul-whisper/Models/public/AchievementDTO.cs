
namespace soul_whisper.Models.Public;

public class AchievementDTO
{
       public required Guid id { get; set; }
    public required List<string> images { get; set; }
    public required string type { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
    public required DateTime dateEarned { get; set; }
     public required string activationStatus { get; set; }
}
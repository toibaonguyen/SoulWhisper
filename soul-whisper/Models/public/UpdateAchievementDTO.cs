

namespace soul_whisper.Models.Public;

public class UpdateAchievementDTO
{
    public  List<string>? images { get; set; }
    public  string? type { get; set; }
    public  string? title { get; set; }
    public  string? description { get; set; }
    public  DateTime? dateEarned { get; set; }
     public string? activationStatus { get; set; }
}
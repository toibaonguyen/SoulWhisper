

using NuGet.Packaging.Signing;

namespace soul_whisper.Models.Public;

public class UpdateHabitDTO
{
    //unique
    public string? type { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
}
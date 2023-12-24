

using NuGet.Packaging.Signing;

namespace soul_whisper.Models.Public;

public class HabitDTO
{
    public Guid? id { get; set; }
    //unique
    public required string type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required Guid patientId { get; set; }
}
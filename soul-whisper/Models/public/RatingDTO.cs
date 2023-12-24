

namespace soul_whisper.Models.Public;

public class RatingDTO
{
    public Guid? id { get; set; }
    //unique
    public required Guid patientId { get; set; }
    public required Guid doctorId { get; set; }
    public required int value { get; set; }
    public required string comment { get; set; }
    public required DateTime? createAt { get; set; }
    public required DateTime? modifiedAt { get; set; }
}
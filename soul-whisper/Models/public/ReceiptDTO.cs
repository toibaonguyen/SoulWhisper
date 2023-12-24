

namespace soul_whisper.Models.Public;

public class ReceiptDTO
{
    public Guid? id { get; set; }
    //unique
    public required string type { get; set; }
    public required Guid userId { get; set; }
    public required decimal amount { get; set; }
    public required string details { get; set; }
    public  DateTime? createAt { get; set; }
}
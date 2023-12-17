using System.ComponentModel.DataAnnotations;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Rule
{
    [Key]
    public required Guid id { get; set; }
    public required RuleType type { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
}

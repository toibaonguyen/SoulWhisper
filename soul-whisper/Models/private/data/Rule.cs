using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Rule")]
public class Rule
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id { get; set; }
    public required RuleType type { get; set; }
    public required string title { get; set; }
    public required string description { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Exercise")]
public class Exercise
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    public required ExerciseType type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    [Column(TypeName ="TIME")]
    public required TimeSpan duration { get; set; }
}
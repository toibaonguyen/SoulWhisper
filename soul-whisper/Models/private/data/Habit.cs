using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Habit")]
public class Habit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    public required HabitType type { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }

    public required Patient patient { get; set; }
}

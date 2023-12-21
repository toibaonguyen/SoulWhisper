using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Rating")]
public class Rating
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id{get;set;}
    public required Patient patient { get; set; }
    public required Doctor doctor { get; set; }
    public required int value { get; set; }
    public required string comment { get; set; }
    public required DateTime createAt { get; set; }
    public DateTime? modifiedAt { get; set; }
}

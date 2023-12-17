
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soul_whisper.Models.Private.Data;

[Table("Achievement_Image")]
public class Achievement_Image
{
    [Key]
    public required Guid id { get; set; }
    public required Achievement belongTo {get;set;}
    public required string image { get; set; }
    
}

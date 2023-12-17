
using System.ComponentModel.DataAnnotations;

namespace soul_whisper.Models.Private.Data;

public class Achievement_Image
{
    [Key]
    public required Guid id { get; set; }
    public required Achievement belongTo {get;set;}
    public required string image { get; set; }
    
}

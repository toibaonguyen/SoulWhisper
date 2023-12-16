
namespace soul_whisper.Models.Private.Data;

public class Achievement_Image
{
    public required string id { get; set; }
    public required Achievement belongTo {get;set;}
    public required string image { get; set; }
    
}

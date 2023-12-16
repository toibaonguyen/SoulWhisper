
namespace soul_whisper.Models.Private.Data;

public class Doctor_Image
{
    public required string id { get; set; }
    public required Doctor belongTo {get;set;}
    public required string image { get; set; }
    
}

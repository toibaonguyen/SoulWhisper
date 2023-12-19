
namespace soul_whisper.Models.Public;

public class ContaineBothDataAndMessageResponseDTO:BaseResponseDTO
{
    public required string message{get;set;}
    public required object data{get;set;}
    
}

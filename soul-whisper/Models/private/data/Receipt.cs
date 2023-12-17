using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Receipt
{
    public required Guid id{get;set;}
    public required ReceiptType type {get;set;}
    public Doctor? doctor{get;set;}
    public Patient? patient{get;set;}
    public required long Amount {get;set;}
    public required string Details{get;set;}
}

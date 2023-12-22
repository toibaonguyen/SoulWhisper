using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Receipt")]
public class Receipt
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id{get;set;}
    public required ReceiptType type {get;set;}
    public Doctor? doctor{get;set;}
    public Patient? patient{get;set;}
    [Column(TypeName ="Money")]
    public required decimal Amount {get;set;}
    public required string Details{get;set;}
}

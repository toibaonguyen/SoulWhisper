using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;


[Table("Message")]
public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id { get; set; }

    public  Guid? sender { get; set; }

    public  Guid? receiver { get; set; }
    public required DateTime createdAt { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }

    public required Guid sender { get; set; }

    public required Guid receiver { get; set; }
    public required DateTime createdAt { get; set; }
}


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Doctorship_Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    [ForeignKey("id")]
    public required Doctor registrant { get; set; }
    public required RegistrationStatus status { get; set; }
    [DefaultValue("GETDATE()")]
    public required DateTime createdAt { get; set; }
}

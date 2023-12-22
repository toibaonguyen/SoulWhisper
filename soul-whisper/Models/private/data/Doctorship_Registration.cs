
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Doctorship_Registration")]
public class Doctorship_Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id { get; set; }
    [ForeignKey("id")]
    public required Doctor registrant { get; set; }
        [DefaultValue(RegistrationStatus.PENDING)]
    public required RegistrationStatus status { get; set; }
    [DefaultValue("GETDATE()")]
    public required DateTime createdAt { get; set; }
    public required DateTime expiredAt { get; set; }

}

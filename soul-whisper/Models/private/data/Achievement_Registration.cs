
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Achievement_Registration")]
public class Achievement_Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public  Guid? id { get; set; }
    public required Achievement registered { get; set; }
    [DefaultValue(RegistrationStatus.PENDING)]
    public required RegistrationStatus status { get; set; }
    [DefaultValue("GETDATE()")]
    public required DateTime createdAt { get; set; }
    public required DateTime expiredAt { get; set; }

}

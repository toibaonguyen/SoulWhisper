using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Appointment_Registration")]
public class Appointment_Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id { get; set; }

    public required Patient patient { get; set; }

    public required Doctor doctor { get; set; }
    public required ICollection<Appointment> appointments { get; set; }
        [DefaultValue(RegistrationStatus.PENDING)]
    public required RegistrationStatus status { get; set; }
    [DefaultValue("GETDATE()")]
    public required DateTime createdAt { get; set; }
    public required DateTime modifiedAt { get; set; }
}

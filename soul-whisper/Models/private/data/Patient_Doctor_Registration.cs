using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Patient_Doctor_Registration
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }

    public required Patient patient { get; set; }

    public required Doctor doctor { get; set; }
    public required ICollection<Appointment> appointments { get; set; }
    public required RegistrationStatus status { get; set; }
    public required DateTime createdAt { get; set; }
}

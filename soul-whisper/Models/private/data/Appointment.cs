using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Appointment
{
    [Key]
    public required Guid id { get; set; }
    public required AppointmentType type { get; set; }
    public required DateTime startTime { get; set; }
    public required DateTime endTime { get; set; }
    public Diagnosis? diagnosis { get; set; }
    public required Doctor doctor { get; set; }
    public required Patient patient { get; set; }
    public required AppoinmentStatus status { get; set; }
}

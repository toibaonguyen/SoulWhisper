using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Appointment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    public required AppointmentType type { get; set; }
    public required DateTime startTime { get; set; }
    public required DateTime endTime { get; set; }
    public  string? diagnosis { get; set; }
    public  string? prescription { get; set; }
    public  string? notes { get; set; }
    public required Doctor doctor { get; set; }
    public required Patient patient { get; set; }
    public required AppoinmentStatus status { get; set; }
}

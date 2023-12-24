using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

[Table("Patient")]
public class Patient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid? id { get; set; }
    //unique
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required string bloodType {get;set;}
    public required DateOnly birthday { get; set; }
    public required Gender gender { get; set; }
    public required ActivationStatus activationStatus { get; set; }
    public ICollection<Habit>? habits { get; set; }
    public ICollection<Appointment>? appointments { get; set; }
    public ICollection<Appointment_Registration>? appointmentRegistrations { get; set; }
    public ICollection<Rating>? doctorRatings { get; set; }
    public ICollection<Receipt>? receipts { get; set; }
}

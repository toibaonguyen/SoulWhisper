using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Doctor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid id { get; set; }
    //unique
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required string avatar { get; set; }
    public required DateOnly birthday { get; set; }
    public required Gender gender { get; set; }
    public required ActivationStatus activationStatus { get; set; }
    public required MedicalSpecialty specialty { get; set; }
    public required ICollection<Achievement> achievements { get; set; }
    [Column(TypeName = "Money")]
    public required decimal moneyInWallet { get; set; }
    public ICollection<Rating>? ratings { get; set; }
    public ICollection<Appointment>? appointments { get; set; }
    public ICollection<Patient_Doctor_Registration>? patientDoctorRegistrations { get; set; }
    public ICollection<Receipt>? receipts { get; set; }
    public ICollection<Exercise>? exercises { get; set; }
}

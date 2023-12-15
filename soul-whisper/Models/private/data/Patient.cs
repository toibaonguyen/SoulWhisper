using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Data;

public class Patient
{
    public required string id { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public required string name { get; set; }
    public required DateOnly birthday { get; set; }
    public required Gender gender { get; set; }
    public required ActivationStatus activationStatus { get; set; }
    public ICollection<Habit>? Habits { get; set; }
    public ICollection<Appointment>? appointments { get; set; }
    public ICollection<Patient_Doctor_Registration>? registrations { get; set; }
    public ICollection<Rating>? ratings { get; set; }
    public ICollection<MedicinePrescription>? medicinePrescriptions { get; set; }
    public ICollection<MedicalRecord>? medicalRecords { get; set; }
    public ICollection<Receipt>? receipts { get; set; }
    public ICollection<Exercise>? exercises { get; set; }
}

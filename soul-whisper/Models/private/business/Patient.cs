namespace soul_whisper.Models.Private.Business.Patient;
using soul_whisper.Models.Private.Business.User;
using soul_whisper.Models.Private.Business;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Private.Business.Medicine;
using soul_whisper.Models.Private.Business.Receipt;
using soul_whisper.Models.Private.Business.Appointment;
using soul_whisper.Models.Private.Business.Doctor;
using soul_whisper.Models.Private.Business.Registration;
using soul_whisper.Models.Private.Business.MedicalRecord;
using soul_whisper.Models.Private.Business.Habit;
using soul_whisper.Models.Private.Business.Exercise;
public class Patient : User
{
    public MedicalRecord? medicalRecord { get; set; }
    public List<Habit> habits { get; set; } 
    public List<Exercise> exercises {get;set;}
    public List<MedicinePrescription> prescriptions {get; set;}
    public List<Receipt> receipts {get; set;}
    public List<Appointment> appointments {get; set;}
    
    public List<Doctor> registeredDoctors {get; set;}
    public List<Registration> registrations {get; set;}
    public Patient(string id, string email, string password, string name, DateOnly birthday, Gender gender) : base(id, email, password, name, birthday, gender)
    {
        this.habits=[];
        this.habits=[];
        this.exercises=[];
        this.prescriptions=[];
        this.receipts=[];
        this.appointments=[];
        this.registeredDoctors=[];
        this.registrations=[];
    }
    public Patient(string id, string email, string password, string name, DateOnly birthday, Gender gender, ActivationStatus activationStatus, MedicalRecord medicalRecord, List<Habit> habits,List<Exercise> exercises,List<MedicinePrescription>prescriptions,List<Receipt> receipts,List<Appointment> appointments,List<Doctor> registeredDoctors,List<Registration> waitingRegistrations ) : base(id, email, password, name, birthday, gender, activationStatus)
    {
        this.medicalRecord = medicalRecord;
        this.habits = habits;
        this.exercises=exercises;
        this.prescriptions=prescriptions;
        this.receipts=receipts;
        this.appointments=appointments;
        this.registeredDoctors=registeredDoctors;
        this.registrations=waitingRegistrations;
    }
}



namespace soul_whisper.Models.Private.Business.Medicine;
using soul_whisper.Models.Private.Business.Doctor;
using soul_whisper.Models.Private.Business.Patient;

public class Medication
{
    public string name { get; set; }
    public float quantity { get; set; }
    public string unit { get; set; }
    public Medication(string name, float quantity, string unit)
    {
        this.name = name;
        this.quantity = quantity;
        this.unit = unit;
    }
}
public class MedicinePrescription
{

    public Patient patient { get; set; }
    public Doctor doctor { get; set; }
    public List<Medication> medications { get; set; }
    public string note { get; set; }
    public readonly DateTime createdTime;
    public MedicinePrescription(Patient patient, Doctor doctor, List<Medication> medications, string note)
    {
        this.patient = patient;
        this.doctor = doctor;
        this.medications = medications;
        this.note = note;
        this.createdTime = DateTime.Now;
    }
    public MedicinePrescription(Patient patient, Doctor doctor, List<Medication> medications, string note, DateTime createdTime)
    {
        this.patient = patient;
        this.doctor = doctor;
        this.medications = medications;
        this.note = note;
        this.createdTime = createdTime;
    }
}


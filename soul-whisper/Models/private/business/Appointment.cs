namespace soul_whisper.Models.Private.Business.Appointment;
using soul_whisper.Models.Private.Business.Doctor;
using soul_whisper.Models.Private.Business.Patient;

public abstract class Appointment
{
    public  Doctor doctor  {get;set;}
    public  Patient patient {get;set;}
    protected Appointment(Doctor doctor,Patient patient)
    {
        this.doctor=doctor;
        this.patient=patient;
    }
}

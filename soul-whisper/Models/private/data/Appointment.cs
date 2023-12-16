namespace soul_whisper.Models.Private.Data;

public class Appointment
{
    public required string id{get;set;}
    public required AppointmentType type{get;set;}
    public required DateTime startTime{get;set;}
    public required DateTime endTime{get;set;}
    public Diagnosis? diagnosis{get;set;}
    public required Doctor doctor{get;set;}
    public required Patient patient{get;set;}
}

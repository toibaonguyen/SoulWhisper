namespace soul_whisper.Models.Private.Data;

public class Patient_Doctor_Registration
{
    public required Patient patient { get; set; }
    public required Doctor doctor { get; set; }
    public required ICollection<Appointment> appointments { get; set; }
    public required DateTime createdAt { get; set; }
}



namespace soul_whisper.Models.Private.Business.Doctor;
using soul_whisper.Models.Private.Business.Achievement;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Private.Business.User;
using soul_whisper.Models.Private.Business.Receipt;
using soul_whisper.Models.Private.Business.Appointment;
using soul_whisper.Models.Private.Business.Registration;

public class Doctor : User
{
    public string bio { get; set; }
    public List<Achievement> achievements { get; set; }
    public List<Receipt>? receipts {get;set;}
    public List<Appointment>? appointments {get; set;}
    public List<Registration>? registrations {get; set;}
    public float? rating {get;set;}
    public Doctor(string id, string email, string password, string name, string bio, DateOnly birthday, Gender gender, ActivationStatus activationStatus, List<Achievement> achievements)
    : base(id, email, password, name, birthday, gender, activationStatus)
    {
        this.bio = bio;
        this.achievements = achievements;
    }
}


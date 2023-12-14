using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Business.User;

public abstract class User
{
    public string id { get; }
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public DateOnly birthday { get; set; }
    public Gender gender { get; set; }
    internal ActivationStatus activationStatus;

    public User(string id, string email, string password, string name, DateOnly birthday, Gender gender, ActivationStatus activationStatus)
    {
        this.id = id;
        this.email = email;
        this.password = password;
        this.name = name;
        this.birthday = birthday;
        this.gender = gender;
        this.activationStatus = activationStatus;
    }
    public User(string id, string email, string password, string name, DateOnly birthday, Gender gender)
    {
        this.id = id;
        this.email = email;
        this.password = password;
        this.name = name;
        this.birthday = birthday;
        this.gender = gender;
        this.activationStatus = ActivationStatus.PENDING;
    }
    
}
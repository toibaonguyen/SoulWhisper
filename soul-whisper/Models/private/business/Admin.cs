using soul_whisper.Models.Private.Enum;

namespace soul_whisper.Models.Private.Business.User;

public sealed class Admin : User
{
    public Admin(string id, string email, string password, string name, DateOnly birthday, Gender gender) : base(id, email, password, name, birthday, gender) { }
    public Admin(string id, string email, string password, string name, DateOnly birthday, Gender gender, ActivationStatus activationStatus) : base(id, email, password, name, birthday, gender, activationStatus) { }

}
using soul_whisper.Models.Public;

namespace soul_whisper.Service;

interface IUser{
    public  Task<AccessRightDTO> Login(); 
    public  Task Logout();
    public Task Register();
}
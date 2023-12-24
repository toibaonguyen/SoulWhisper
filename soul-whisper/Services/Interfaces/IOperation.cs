
using soul_whisper.Models.Public;

namespace soul_whisper.Service;

interface IOperation{
    public  Task<AccessRightDTO> Login(string email,string password); 
    public  void Logout(Guid userId);
}
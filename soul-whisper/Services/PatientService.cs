using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Data;
using soul_whisper.Helpers.TokenFactory;
using soul_whisper.Models.Private.Business.Token;
using soul_whisper.Models.Private.Business.User;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;


namespace soul_whisper.Service;

public class PatientService : IOperation
{

    private const string WRONG_EMAIL_OR_PASSWORD = "Wrong email or password";
    private const string ACCOUNT_IS_NOT_ACTIVE = "This account is not in active right now";
    public async Task<AccessRightDTO> Login(string email, string password)
    {
        using (FlatformContext context = new FlatformContext())
        {
            var admin = await context.admins.FirstAsync(a => a.email == email && a.password == password);
            if (admin == null)
            {
                throw new InvalidCredentialException(WRONG_EMAIL_OR_PASSWORD);
            }
            else if (admin.activationStatus != ActivationStatus.ACTIVE)
            {
                throw new InvalidOperationException(ACCOUNT_IS_NOT_ACTIVE);
            }
            else
            {
                AccessTokenFactory accessTokenFactory = new AccessTokenFactory();
                RefreshTokenFactory refreshTokenFactory = new RefreshTokenFactory();
                AccessToken accessToken = (AccessToken)accessTokenFactory.CreateToken(new UserDTO { userId = admin.id, role = UserRole.ADMIN });
                RefreshToken refreshToken = (RefreshToken)refreshTokenFactory.CreateToken(new UserDTO { userId = admin.id, role = UserRole.ADMIN });
                return new AccessRightDTO { accessToken = accessToken.ToString(), refreshToken = refreshToken.ToString() };
            }

        }
    }
    public async Task Logout(string accessToken)
    {

    }
    public async Task Register(Admin admin)
    {

    }
}
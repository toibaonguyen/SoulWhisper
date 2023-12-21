using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Configs;
using soul_whisper.Data;
using soul_whisper.Helpers.TokenFactory;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Token;
using soul_whisper.Models.Private.Business.User;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;

namespace soul_whisper.Service;
public class AdminService : IOperation
{
    private const string WRONG_EMAIL_OR_PASSWORD = "Wrong email or password";
    private const string ACCOUNT_IS_NOT_ACTIVE = "This account is not in active right now";
    public async Task<AccessRightDTO> Login(string email, string password)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var admin = await context.admins.FirstOrDefaultAsync(a => a.email == email && a.password == password);

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
                    TokenOperator.RemoveAccessToken(admin.id);
                    TokenOperator.RemoveRefreshToken(admin.id);
                    AccessTokenFactory accessTokenFactory = new AccessTokenFactory();
                    RefreshTokenFactory refreshTokenFactory = new RefreshTokenFactory();
                    AccessToken accessToken = (AccessToken)accessTokenFactory.CreateToken(new UserDTO { userId = admin.id, role = UserRole.ADMIN });
                    RefreshToken refreshToken = (RefreshToken)refreshTokenFactory.CreateToken(new UserDTO { userId = admin.id, role = UserRole.ADMIN });
                    string accessTokenS=accessToken.ToString();
                    string refreshTokenS=refreshToken.ToString();
                    TokenOperator.AddLegitAccessToken(admin.id,accessTokenS,DateTime.Now.AddSeconds(TokenConfig.ACCESS_TOKEN_EXPIRATION_IN_SECONDS));
                    TokenOperator.AddLegitRefreshToken(admin.id,refreshTokenS,DateTime.Now.AddSeconds(TokenConfig.REFRESH_TOKEN_EXPIRATION_IN_SECONDS));
                    return new AccessRightDTO { accessToken = accessTokenS, refreshToken = refreshTokenS };
                }

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task Logout(Guid userId)
    {
        TokenOperator.RemoveAccessToken(userId);
        TokenOperator.RemoveRefreshToken(userId);
    }
    public async Task Register(Admin admin)
    {

    }

}

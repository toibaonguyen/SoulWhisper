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
using System.Reflection;
using Microsoft.Identity.Client;
using soul_whisper.Models.Private.Data;

namespace soul_whisper.Service;
public class AdminService : IOperation
{
    private const string WRONG_EMAIL_OR_PASSWORD = "Wrong email or password";
    private const string ACCOUNT_IS_NOT_ACTIVE = "This account is not in active right now";
    private string ADMIN_NOT_EXIST = "This admin is not exist";
    private string ADMIN_ALREADY_EXIST = "This admin is already exist";

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
                    AccessToken accessToken = (AccessToken)accessTokenFactory.CreateToken(new UserDTO { userId = (Guid)admin.id, role = UserRole.ADMIN });
                    RefreshToken refreshToken = (RefreshToken)refreshTokenFactory.CreateToken(new UserDTO { userId = (Guid)admin.id, role = UserRole.ADMIN });
                    string accessTokenS = accessToken.ToString();
                    string refreshTokenS = refreshToken.ToString();
                    TokenOperator.AddLegitAccessToken(admin.id, accessTokenS, DateTime.Now.AddSeconds(TokenConfig.ACCESS_TOKEN_EXPIRATION_IN_SECONDS));
                    TokenOperator.AddLegitRefreshToken(admin.id, refreshTokenS, DateTime.Now.AddSeconds(TokenConfig.REFRESH_TOKEN_EXPIRATION_IN_SECONDS));
                    return new AccessRightDTO { accessToken = accessTokenS, accessTokenExpiredAt = DateTime.Now.AddSeconds(TokenConfig.ACCESS_TOKEN_EXPIRATION_IN_SECONDS), refreshToken = refreshTokenS, refreshTokenExpiredAt = DateTime.Now.AddSeconds(TokenConfig.REFRESH_TOKEN_EXPIRATION_IN_SECONDS) };
                }

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Logout(Guid userId)
    {
        TokenOperator.RemoveAccessToken(userId);
        TokenOperator.RemoveRefreshToken(userId);
    }
    public async Task Register(AdminDTO admin)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                if (await context.admins.CountAsync(a => a.email == admin.email) > 0)
                {
                    throw new BadHttpRequestException(ADMIN_ALREADY_EXIST);
                }
                await context.admins.AddAsync(new Models.Private.Data.Admin { email = admin.email, name = admin.name, password = admin.password, birthday = admin.birthday, gender = (Gender)Enum.Parse(typeof(Gender), admin.gender), activationStatus = ActivationStatus.ACTIVE });
                context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<AdminDTO>> GetAdminDTOs()
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var admins = await context.admins.ToListAsync();
                List<AdminDTO> publicStandardAdmins = [];
                admins.ForEach(a =>
                {
                    publicStandardAdmins.Add(ModelsConverterMachine.ConvertAdminToAdminDTO(a));
                });
                return publicStandardAdmins;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task UpdateAdmin(Guid adminId, UpdateAdminDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var admin = await context.admins.FirstOrDefaultAsync(a => a.id == adminId);
                if (admin == null)
                {
                    throw new TargetException(ADMIN_NOT_EXIST);
                }
                admin.birthday = (DateOnly)(update.birthday != null ? update.birthday : admin.birthday);
                admin.password = update.password != null ? update.password : admin.password;
                admin.name = update.name != null ? update.name : admin.name;
                admin.gender = update.gender != null ? (Gender)Enum.Parse(typeof(Gender), update.gender) : admin.gender;
                admin.activationStatus = update.activationStatus != null ? (ActivationStatus)Enum.Parse(typeof(ActivationStatus), update.activationStatus) : admin.activationStatus;
                context.SaveChanges();

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<AdminDTO> GetAdminDTOById(Guid adminId)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var admin = await context.admins.FirstOrDefaultAsync(a => a.id == adminId);
                if (admin == null)
                {
                    throw new TargetException(ADMIN_NOT_EXIST);
                }
                AdminDTO publicStandardAchievement = ModelsConverterMachine.ConvertAdminToAdminDTO(admin);

                return publicStandardAchievement;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

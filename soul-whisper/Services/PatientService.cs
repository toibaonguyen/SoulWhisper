using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using soul_whisper.Configs;
using soul_whisper.Data;
using soul_whisper.Helpers.TokenFactory;
using soul_whisper.Helpers;
using soul_whisper.Models.Private.Business.Token;
using soul_whisper.Models.Private.Enum;
using soul_whisper.Models.Public;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Models.Private.Data;

namespace soul_whisper.Service;
public class PatientService : IOperation
{
    private const string WRONG_EMAIL_OR_PASSWORD = "Wrong email or password";
    private const string ACCOUNT_IS_NOT_ACTIVE = "This account is not in active right now";
    public async Task UpdatePatient(Guid patientId, UpdatePatientDTO update)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {

                var patient=await context.patients.FirstOrDefaultAsync(p=> p.id == patientId);
                if (patient!=null)
                {
                    patient.password=update.password??patient.password;
                    patient.gender = update.gender!=null? (Gender)Enum.Parse(typeof(Gender), update.gender) : patient.gender;
                    patient.name=update.name??patient.name;
                    patient.birthday=update.birthday??patient.birthday;
                    patient.activationStatus=update.activationStatus!=null?(ActivationStatus)Enum.Parse(typeof(ActivationStatus),update.activationStatus):patient.activationStatus;
                    patient.bloodType=update.bloodType??patient.bloodType;
                    context.SaveChanges();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<AccessRightDTO> Login(string email, string password)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var patient = await context.patients.FirstOrDefaultAsync(a => a.email == email && a.password == password);

                if (patient == null)
                {
                    throw new InvalidCredentialException(WRONG_EMAIL_OR_PASSWORD);
                }
                else if (patient.activationStatus != ActivationStatus.ACTIVE)
                {
                    throw new InvalidOperationException(ACCOUNT_IS_NOT_ACTIVE);
                }
                else
                {
                    TokenOperator.RemoveAccessToken(patient.id);
                    TokenOperator.RemoveRefreshToken(patient.id);
                    AccessTokenFactory accessTokenFactory = new AccessTokenFactory();
                    RefreshTokenFactory refreshTokenFactory = new RefreshTokenFactory();
                    AccessToken accessToken = (AccessToken)accessTokenFactory.CreateToken(new UserDTO { userId = (Guid)patient.id, role = UserRole.PATIENT });
                    RefreshToken refreshToken = (RefreshToken)refreshTokenFactory.CreateToken(new UserDTO { userId = (Guid)patient.id, role = UserRole.PATIENT });
                    string accessTokenS = accessToken.ToString();
                    string refreshTokenS = refreshToken.ToString();
                    TokenOperator.AddLegitAccessToken(patient.id, accessTokenS, DateTime.Now.AddSeconds(TokenConfig.ACCESS_TOKEN_EXPIRATION_IN_SECONDS));
                    TokenOperator.AddLegitRefreshToken(patient.id, refreshTokenS, DateTime.Now.AddSeconds(TokenConfig.REFRESH_TOKEN_EXPIRATION_IN_SECONDS));
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
    public async Task Register(PatientDTO patient)
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {

                await context.patients.AddAsync(new Patient
                {
                    email = patient.email,
                    password = patient.password,
                    name = patient.name,
                    birthday = patient.birthday,
                    gender = (Gender)Enum.Parse(typeof(Gender), patient.gender),
                    activationStatus = ActivationStatus.PENDING,
                    bloodType = patient.bloodType
                });
                context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<PatientDTO>> GetPatientDTOs()
    {
        try
        {
            using (FlatformContext context = new FlatformContext())
            {
                var ds = await context.patients.ToListAsync();
                List<PatientDTO> publicStandardDs = [];
                ds.ForEach(a =>
                {
                    publicStandardDs.Add(ModelsConverterMachine.ConvertPatientToPatientDTO(a));
                });
                return publicStandardDs;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

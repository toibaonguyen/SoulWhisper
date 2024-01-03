
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using soul_whisper.Configs;
using System.IdentityModel.Tokens.Jwt;
using soul_whisper.Models.Public;
using System.Security.Claims;
using soul_whisper.Models.Public.Enum;
using soul_whisper.Models.Private.Business;

namespace soul_whisper.Helpers;

public interface TokenConverter
{
    public UserDTO ConvertAccessTokenToUserDTO(string accessToken);
    public UserDTO ConvertRefreshTokenToUserDTO(string refreshToken);
}

public class TokenConverterMachine : TokenConverter
{
    private Guid userID;
    private UserRole userRole;
    private RsaSecurityKey accessTokenKey;
    private RsaSecurityKey refreshTokenKey;
    private string INVALID_TOKEN = "Invalid Token";
    private string EXPIRED_TOKEN = "Expired Token";
    public TokenConverterMachine()
    {
        RSA Arsa = RSA.Create();
        string accessTokenKeyText = File.ReadAllText(KeyConfiguration.ACCESS_TOKEN_PUBLIC_KEY_FILE_PATH);
        Arsa.ImportFromPem(accessTokenKeyText);
        this.accessTokenKey = new RsaSecurityKey(Arsa);

        RSA Frsa = RSA.Create();
        string refreshTokenKeyText = File.ReadAllText(KeyConfiguration.REFRESH_TOKEN_PUBLIC_KEY_FILE_PATH);
        Frsa.ImportFromPem(refreshTokenKeyText);
        this.refreshTokenKey = new RsaSecurityKey(Frsa);
    }
    public UserDTO ConvertAccessTokenToUserDTO(string accessToken)
    {

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = this.accessTokenKey
            };
            SecurityToken pad;
            var token = tokenHandler.ValidateToken(accessToken, validationParameters, out pad);


            foreach (Claim claim in token.Claims.ToArray())
            {
                switch (claim.Type)
                {
                    case "userId":
                        userID = Guid.Parse(claim.Value);
                        if (TokenOperator.legitAccessTokens.Count(e => e.userId == userID) < 1)
                        {
                            throw new SecurityTokenInvalidLifetimeException(this.EXPIRED_TOKEN);
                        }

                        break;
                    case "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":
             
                        if (claim.Value == "ADMIN")
                        {
                            userRole = UserRole.ADMIN;
                        }
                        else if (claim.ValueType == "DOCTOR")
                        {
                            userRole = UserRole.DOCTOR;
                        }
                        else if (claim.ValueType == "PATIENT")
                        {
                            userRole = UserRole.PATIENT;
                        }
                        break;

                }
            }

            UserDTO user = new UserDTO { userId = userID, role = userRole };
            return user; // Token hợp lệ
        }
        catch (Exception e)
        {
            if (e is SecurityTokenInvalidLifetimeException)
            {
                throw new SecurityTokenInvalidLifetimeException(this.EXPIRED_TOKEN);
            }
            else if (e is ArgumentException)
            {
                throw new ArgumentException(this.INVALID_TOKEN);
            }
            throw; // Token không hợp lệ
        }

    }
    public UserDTO ConvertRefreshTokenToUserDTO(string refreshToken)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = this.refreshTokenKey
            };
            SecurityToken pad;
            var token = tokenHandler.ValidateToken(refreshToken, validationParameters, out pad);


            foreach (Claim claim in token.Claims.ToArray())
            {
                switch (claim.Type)
                {
                    case "userId":
                        userID = Guid.Parse(claim.Value);
                        if (TokenOperator.legitRefreshTokens.Count(e => e.userId == userID) < 1)
                        {
                            throw new SecurityTokenInvalidLifetimeException(this.EXPIRED_TOKEN);
                        }

                        break;
                    case "role":
                        if (claim.Value == "ADMIN")
                        {
                            userRole = UserRole.ADMIN;
                        }
                        else if (claim.ValueType == "DOCTOR")
                        {
                            userRole = UserRole.DOCTOR;
                        }
                        else if (claim.ValueType == "PATIENT")
                        {
                            userRole = UserRole.PATIENT;
                        }
                        break;

                }
            }

            UserDTO user = new UserDTO { userId = userID, role = userRole };
            return user; // Token hợp lệ


        }
        catch (Exception e)
        {
            if (e is SecurityTokenInvalidLifetimeException)
            {
                throw new SecurityTokenInvalidLifetimeException(this.EXPIRED_TOKEN);
            }
            else if (e is ArgumentException)
            {
                throw new ArgumentException(this.INVALID_TOKEN);
            }
            throw; // Token không hợp lệ
        }
    }

}
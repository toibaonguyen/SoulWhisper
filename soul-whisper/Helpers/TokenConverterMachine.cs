
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using soul_whisper.Configs.KeyConfiguration;
using System.IdentityModel.Tokens.Jwt;
using soul_whisper.Models.Public;

namespace soul_whisper.Helpers;

public class TokenConverterMachine
{
    private RsaSecurityKey accessTokenKey;
    private RsaSecurityKey refreshTokenKey;
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
    public bool ConvertAccessTokenToUserDTO(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true, // Kiểm tra thời gian sống của token
            ValidateAudience=false,
            ValidateIssuer=false,
            IssuerSigningKey = this.accessTokenKey
        };
        try
        {
            tokenHandler.ValidateToken(accessToken, validationParameters, out _);
            return true; // Token hợp lệ
        }
        catch (Exception e)
        {
            Console.WriteLine($"Mua it thoi: {e.Message}");

            return false; // Token không hợp lệ
        }

    }
    public bool ConvertRefreshTokenToUserDTO(string refreshToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true, // Kiểm tra thời gian sống của token
            ValidateAudience=false,
            ValidateIssuer=false,
            IssuerSigningKey = this.refreshTokenKey
        };
        try
        {
            tokenHandler.ValidateToken(refreshToken, validationParameters, out _);
            return true; // Token hợp lệ
        }
        catch (Exception)
        {
            return false; // Token không hợp lệ
        }
    }
}
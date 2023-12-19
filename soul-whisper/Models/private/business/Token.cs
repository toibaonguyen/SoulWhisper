
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using soul_whisper.Configs;
using soul_whisper.Utils;

namespace soul_whisper.Models.Private.Business.Token;

public abstract class Token
{
    public object payload { get; set; }
    protected Token(object payload)
    {
        this.payload = payload;
    }
}

public class AccessToken : Token
{
    private RsaSecurityKey privateKey { get; }
    public AccessToken(object payload) : base(payload)
    {
        RSA rsa = RSA.Create();
        string privateKeyText = File.ReadAllText(KeyConfiguration.ACCESS_TOKEN_PRIVATE_KEY_FILE_PATH);
        rsa.ImportFromPem(privateKeyText);
        this.privateKey = new RsaSecurityKey(rsa);
    }
    public override string ToString()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = new JwtSecurityToken
        (
            signingCredentials: new SigningCredentials(
                this.privateKey, SecurityAlgorithms.RsaSha256
            ),
            claims: MyTools.CreateClaimsFromObject(this.payload),
            expires: DateTime.Now
        );
        string accessToken = tokenHandler.WriteToken(token);
        return accessToken;
    }

}

public class RefreshToken : Token
{
    private RsaSecurityKey privateKey { get; }
    public RefreshToken(object payload) : base(payload)
    {
        RSA rsa = RSA.Create();
        string privateKeyText = File.ReadAllText(KeyConfiguration.ACCESS_TOKEN_PRIVATE_KEY_FILE_PATH);
        rsa.ImportFromPem(privateKeyText);
        this.privateKey = new RsaSecurityKey(rsa);
    }
    public override string ToString()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = new JwtSecurityToken
        (
            signingCredentials: new SigningCredentials(
                this.privateKey, SecurityAlgorithms.RsaSha256
            ),
            claims: MyTools.CreateClaimsFromObject(this.payload),
            expires: DateTime.Now
        );
        string refreshToken = tokenHandler.WriteToken(token);
        return refreshToken;
    }
}

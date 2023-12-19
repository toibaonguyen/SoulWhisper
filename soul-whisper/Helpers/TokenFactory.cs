namespace soul_whisper.Helpers.TokenFactory;

using soul_whisper.Models.Private.Business.Token;
using soul_whisper.Models.Public;

public interface TokenFactory<T>
{
    public Token CreateToken(T payload);
}

public class AccessTokenFactory : TokenFactory<UserDTO>
{

    public Token CreateToken(UserDTO payload)
    {
        return new AccessToken(payload);
    }
}

public class RefreshTokenFactory : TokenFactory<UserDTO>
{
    public Token CreateToken(UserDTO payload)
    {
        return new RefreshToken(payload);
    }
}


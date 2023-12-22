namespace soul_whisper.Helpers;

public struct SomethingDumas
{
    public Guid userId;
    public string token;
    public DateTime expiredAt;
    public SomethingDumas(Guid userId, string token, DateTime expiredAt)
    {
        this.userId = userId;
        this.token = token; this.expiredAt = expiredAt;
    }
}
public static class TokenOperator
{
    static public List<SomethingDumas> legitAccessTokens=[] ;
    static public List<SomethingDumas> legitRefreshTokens=[] ;
    static public void AddLegitAccessToken(Guid? userId, string accessToken, DateTime expiredAt)
    {
        if(userId==null)
        {
            throw new Exception();
        }
        SomethingDumas dumasItem = new SomethingDumas((Guid)userId, accessToken, expiredAt);
        legitAccessTokens.Add(dumasItem);
    }
    static public void RemoveAccessToken(Guid? userId)
    {

        legitAccessTokens.RemoveAll(e => e.userId == userId);
    }
    static public void AddLegitRefreshToken(Guid? userId, string refreshToken, DateTime expiredAt)
    {
        if(userId==null)
        {
            throw new Exception();
        }
        SomethingDumas dumasItem = new SomethingDumas((Guid)userId, refreshToken, expiredAt);
        legitRefreshTokens.Add(dumasItem);
    }
    static public void RemoveRefreshToken(Guid? userId)
    {
        legitRefreshTokens.RemoveAll(e => e.userId == userId);
    }
    static public void RemoveExpiredTokens()
    {
        legitAccessTokens.RemoveAll(t=>t.expiredAt<DateTime.Now);
        legitRefreshTokens.RemoveAll(t=>t.expiredAt<DateTime.Now);
    }
}
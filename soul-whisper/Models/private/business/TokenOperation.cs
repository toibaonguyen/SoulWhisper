namespace soul_whisper.Models.Private.Business;

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
public static class TokenOperation
{
    static public List<SomethingDumas> legitAccessTokens=[] ;
    static public List<SomethingDumas> legitRefreshTokens=[] ;
    static public void AddLegitAccessToken(Guid userId, string accessToken, DateTime expiredAt)
    {
        SomethingDumas dumasItem = new SomethingDumas(userId, accessToken, expiredAt);
        legitAccessTokens.Add(dumasItem);
    }
    static public void RemoveAccessToken(Guid userId)
    {

        legitAccessTokens.RemoveAll(e => e.userId == userId);
    }
    static public void AddLegitRefreshToken(Guid userId, string refreshToken, DateTime expiredAt)
    {
        SomethingDumas dumasItem = new SomethingDumas(userId, refreshToken, expiredAt);
        legitRefreshTokens.Add(dumasItem);
    }
    static public void RemoveRefreshToken(Guid userId)
    {
        legitRefreshTokens.RemoveAll(e => e.userId == userId);
    }
    static public void RemoveExpiredTokens()
    {
        legitAccessTokens.RemoveAll(t=>t.expiredAt<DateTime.Now);
        legitRefreshTokens.RemoveAll(t=>t.expiredAt<DateTime.Now);
    }
}
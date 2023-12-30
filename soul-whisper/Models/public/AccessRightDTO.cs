
namespace soul_whisper.Models.Public;

public class AccessRightDTO
{
    public required string accessToken { get; set; }
    public required DateTime accessTokenExpiredAt { get; set; }
    public required string refreshToken { get; set; }
    public required DateTime refreshTokenExpiredAt { get; set; }
    public required Guid userId { get; set; }
}
using System.Reflection;
using System.Security.Claims;

namespace soul_whisper.Utils;

public static class DataFormat
{
    public static IEnumerable<Claim> CreateClaimsFromObject(object obj)
    {
        var claims = new List<Claim>();

        // Duyệt qua các thuộc tính của đối tượng và thêm chúng vào danh sách claims
        var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj)?.ToString();
            if (value != null)
            {
                claims.Add(new Claim(property.Name, value));
            }
        }

        return claims;
    }

}
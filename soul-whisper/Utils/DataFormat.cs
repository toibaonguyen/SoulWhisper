using System.Reflection;
using System.Security.Claims;

namespace soul_whisper.Utils;

public static class DataFormat
{
    public static ClaimsIdentity CreateClaimsFromObject(object obj)
    {
        var claims = new List<Claim>();

        foreach (PropertyInfo property in obj.GetType().GetProperties())
        {
            var value = property.GetValue(obj);
            if (value != null)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                claims.Add(new Claim(property.Name, value.ToString()));
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        return new ClaimsIdentity(claims);
    }

}
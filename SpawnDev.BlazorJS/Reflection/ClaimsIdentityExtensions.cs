using System.Security.Claims;

namespace SpawnDev.BlazorJS.Reflection
{
    internal static class ClaimsIdentityExtensions
    {
        public static string ToBase64(this ClaimsIdentity claimsIdentity)
        {
            using var buffer = new System.IO.MemoryStream();
            using var writer = new System.IO.BinaryWriter(buffer);
            claimsIdentity.WriteTo(writer);
            var data = buffer.ToArray();
            return Convert.ToBase64String(data);
        }
        public static ClaimsIdentity Base64ToClaimsIdentity(this string claimsIdentity)
        {
            var data = Convert.FromBase64String(claimsIdentity);
            using var buffer = new System.IO.MemoryStream(data);
            using var reader = new System.IO.BinaryReader(buffer);
            return new ClaimsIdentity(reader);
        }
    }
}

using System.Reflection;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Adds some methods to the Assembly class
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns the Assembly's AssemblyInformationalVersion attribute value and optionally trims any versioning suffix like -alpha, -beta, etc<br/>
        /// </summary>
        public static string GetAssemblyInformationalVersion(this Assembly _this, bool trim = true)
        {
            var attr = _this.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            var ver = attr == null ? "" : attr.InformationalVersion;
            if (trim) ver = Regex.Match(ver, "^[.0-9]+").Value;
            return ver;
        }
        /// <summary>
        /// Returns the Assembly's AssemblyFileVersion attribute value
        /// </summary>
        public static string GetAssemblyFileVersion(this Assembly _this)
        {
            var attr = _this.GetCustomAttribute<AssemblyFileVersionAttribute>();
            return attr == null ? "" : attr.Version;
        }
    }
}

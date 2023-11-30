using System.Reflection;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS
{
public static class AssemblyExtensions
{
    public static string GetAssemblyInformationalVersion(this Assembly _this, bool trim = true)
    {
        var attr = _this.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        var ver = attr == null ? "" : attr.InformationalVersion;
        if (trim) ver = Regex.Match(ver, "^[.0-9]+").Value;
        return ver;
    }
    public static string GetAssemblyFileVersion(this Assembly _this)
    {
        var attr = _this.GetCustomAttribute<AssemblyFileVersionAttribute>();
        return attr == null ? "" : attr.Version;
    }
}
}

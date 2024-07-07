using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes whether an application invoking getDisplayMedia() would like the user agent to offer the user an option to dynamically switch the source display surface during the capture.<br/>
    /// https://www.w3.org/TR/screen-capture/#surfaceswitchingpreferenceenum
    /// </summary>
    public enum SurfaceSwitchingPreferenceEnum
    {
        /// <summary>
        /// The application prefers that an option to dynamically switch the source display surface during the capture be offered to the user.
        /// </summary>
        [JsonPropertyName("include")]
        Include,
        /// <summary>
        /// The application prefers that an option to dynamically switch the source display surface during the capture NOT be offered to the user.
        /// </summary>
        [JsonPropertyName("exclude")]
        Exclude,
    }
}

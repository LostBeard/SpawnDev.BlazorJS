using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes whether the application would like the user agent to offer the user the option to choose display surfaces whose type is monitor.<br/>
    /// https://www.w3.org/TR/screen-capture/#monitortypesurfacesenum
    /// </summary>
    public enum MonitorTypeSurfacesEnum
    {
        /// <summary>
        /// The application prefers that the display surfaces presented to the user include those of type monitor.
        /// </summary>
        [JsonPropertyName("include")]
        Include,
        /// <summary>
        /// The application prefers that the display surfaces presented to the user exclude those of type monitor.
        /// </summary>
        [JsonPropertyName("exclude")]
        Exclude,
    }
}

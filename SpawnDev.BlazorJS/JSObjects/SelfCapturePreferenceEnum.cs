using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes the different hints an application can provide about whether the display surface the application is in, should be among the choices offered to the user.<br/>
    /// https://www.w3.org/TR/screen-capture/#dom-selfcapturepreferenceenum
    /// </summary>
    public enum SelfCapturePreferenceEnum
    {
        /// <summary>
        /// The application prefers the surface be included among the choices offered.
        /// </summary>
        [JsonPropertyName("include")]
        Include,
        /// <summary>
        /// The application prefers the surface be excluded from the choices offered.
        /// </summary>
        [JsonPropertyName("exclude")]
        Exclude,
    }
}

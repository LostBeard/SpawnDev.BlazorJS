using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes whether an application invoking getDisplayMedia() would like the user agent to include system audio among the audio sources offered to the user.<br/>
    /// https://www.w3.org/TR/screen-capture/#systemaudiopreferenceenum
    /// </summary>
    public enum SystemAudioPreferenceEnum
    {
        /// <summary>
        /// The application prefers that options to share system audio be offered to the user for monitor display surfaces.
        /// </summary>
        [JsonPropertyName("include")]
        Include,
        /// <summary>
        /// The application prefers that options to share system audio not be offered to the user.
        /// </summary>
        [JsonPropertyName("exclude")]
        Exclude,
    }
}

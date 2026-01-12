using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaSessionActionDetails dictionary of the Media Session API is passed to the MediaSession.setActionHandler() callback function.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaSessionActionDetails
    /// </summary>
    public class MediaSessionActionDetails
    {
        /// <summary>
        /// The action that was triggered.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; } = "";
        /// <summary>
        /// The time, in seconds, to seek to.
        /// </summary>
        [JsonPropertyName("seekOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SeekOffset { get; set; }
        /// <summary>
        /// The playback rate to set.
        /// </summary>
        [JsonPropertyName("seekTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? SeekTime { get; set; }
        /// <summary>
        /// The fast forward/rewind amount.
        /// </summary>
        [JsonPropertyName("fastSeek")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FastSeek { get; set; }
    }
}

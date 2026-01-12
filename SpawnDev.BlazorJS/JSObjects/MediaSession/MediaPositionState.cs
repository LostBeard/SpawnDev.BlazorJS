using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaPositionState dictionary of the Media Session API provides the state of the media playback position.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaPositionState
    /// </summary>
    public class MediaPositionState
    {
        /// <summary>
        /// The duration of the media in seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Duration { get; set; }
        /// <summary>
        /// The playback rate of the media.
        /// </summary>
        [JsonPropertyName("playbackRate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PlaybackRate { get; set; }
        /// <summary>
        /// The current position of the media in seconds.
        /// </summary>
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Position { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used in constructing a new VideoFrame
    /// </summary>
    public class VideoFrameOptions
    {
        /// <summary>
        /// An integer representing the duration of the frame in microseconds.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Duration { get; set; }
        /// <summary>
        /// An integer representing the timestamp of the frame in microseconds.
        /// </summary>
        public double Timestamp { get; set; }

        /// <summary>
        /// A string, describing how the user agent should behave when dealing with alpha channels. The default value is "keep".<br/>
        /// "keep": Indicates that the user agent should preserve alpha channel data. <br/>
        /// "discard": Indicates that the user agent should ignore or remove alpha channel data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Alpha { get; set; }

        /// <summary>
        /// The width of the VideoFrame when displayed after applying aspect-ratio adjustments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayWidth { get; set; }

        /// <summary>
        /// The height of the VideoFrame when displayed after applying aspect-ratio adjustments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayHeight { get; set; }

        /// <summary>
        /// An object representing the visible rectangle of the VideoFrame, containing the following:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoFrameRect? VisibleRect { get; set; }
    }
}

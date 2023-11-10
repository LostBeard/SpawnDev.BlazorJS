using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Configuration object for a video media source. 
    /// </summary>
    public class EncodingConfigurationVideo
    {
        /// <summary>
        /// String containing a valid video MIME type, and (optionally) a codecs parameter.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentType { get; set; }
        /// <summary>
        /// The width of the video.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }
        /// <summary>
        /// The height of the video.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }
        /// <summary>
        /// The number of bits used to encode one second of the video file.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Bitrate { get; set; }
        /// <summary>
        /// The number of frames making up one second of video playback.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Framerate { get; set; }
    }
}

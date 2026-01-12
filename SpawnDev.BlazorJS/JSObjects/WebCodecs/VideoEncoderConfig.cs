using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the configuration for the VideoEncoder
    /// </summary>
    public class VideoEncoderConfig
    {
        /// <summary>
        /// A string containing the codec string.
        /// </summary>
        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// An integer representing the width of the video frame.
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        /// An integer representing the height of the video frame.
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }
        
        /// <summary>
        /// An integer representing the bitrate of the encoded video.
        /// </summary>
        [JsonPropertyName("bitrate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Bitrate { get; set; }
        
        /// <summary>
        /// A number representing the frame rate of the encoded video.
        /// </summary>
        [JsonPropertyName("framerate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Framerate { get; set; }

        /// <summary>
        /// A string representing the bitrate mode.
        /// </summary>
        [JsonPropertyName("bitrateMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BitrateMode { get; set; }
        
         /// <summary>
        /// A string representing the latency mode.
        /// </summary>
        [JsonPropertyName("latencyMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LatencyMode { get; set; }

        /// <summary>
        /// A string representing the hardware acceleration preference.
        /// </summary>
        [JsonPropertyName("hardwareAcceleration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HardwareAcceleration { get; set; }
        
        /// <summary>
        /// A string representing the alpha option.
        /// </summary>
        [JsonPropertyName("alpha")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Alpha { get; set; }
        
        /// <summary>
        /// A string representing the scalability mode.
        /// </summary>
        [JsonPropertyName("scalabilityMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ScalabilityMode { get; set; }
    }
}

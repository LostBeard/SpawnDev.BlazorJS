using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Result of VideoEncoder.isConfigSupported
    /// </summary>
    public class VideoEncoderSupport
    {
        /// <summary>
        /// If the configuration is supported.
        /// </summary>
        [JsonPropertyName("supported")]
        public bool Supported { get; set; }

        /// <summary>
        /// The configuration that is supported.
        /// </summary>
        [JsonPropertyName("config")]
        public VideoEncoderConfig Config { get; set; }
    }
}

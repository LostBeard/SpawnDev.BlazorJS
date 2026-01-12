using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Result of VideoDecoder.isConfigSupported
    /// </summary>
    public class VideoDecoderSupport
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
        public VideoDecoderConfig Config { get; set; }
    }
}

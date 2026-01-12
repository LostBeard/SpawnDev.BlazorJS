using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Result of AudioDecoder.isConfigSupported
    /// </summary>
    public class AudioDecoderSupport
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
        public AudioDecoderConfig Config { get; set; }
    }
}

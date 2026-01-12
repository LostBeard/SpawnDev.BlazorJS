using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Result of AudioEncoder.isConfigSupported
    /// </summary>
    public class AudioEncoderSupport
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
        public AudioEncoderConfig Config { get; set; }
    }
}

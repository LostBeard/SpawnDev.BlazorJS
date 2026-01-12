using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the configuration for the AudioEncoder
    /// </summary>
    public class AudioEncoderConfig
    {
        /// <summary>
        /// A string containing the codec string.
        /// </summary>
        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// An integer representing the partial delay.
        /// </summary>
        [JsonPropertyName("sampleRate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SampleRate { get; set; }

        /// <summary>
        /// An integer representing the number of audio channels.
        /// </summary>
        [JsonPropertyName("numberOfChannels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NumberOfChannels { get; set; }

        /// <summary>
        /// An integer representing the bitrate.
        /// </summary>
        [JsonPropertyName("bitrate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Bitrate { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the configuration for the AudioDecoder
    /// </summary>
    public class AudioDecoderConfig
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
        /// A string representing the description of the audio content.
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<ArrayBuffer, DataView, byte[]>? Description { get; set; }
    }
}

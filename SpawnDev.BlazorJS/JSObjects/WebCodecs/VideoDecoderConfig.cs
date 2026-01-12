using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the configuration for the VideoDecoder
    /// </summary>
    public class VideoDecoderConfig
    {
        /// <summary>
        /// A string containing the codec string.
        /// </summary>
        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        /// <summary>
        /// A string representing the description of the video content.
        /// </summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<ArrayBuffer, DataView, byte[]>? Description { get; set; }

        /// <summary>
        /// An integer representing the coded width of the video frame.
        /// </summary>
        [JsonPropertyName("codedWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CodedWidth { get; set; }

        /// <summary>
        /// An integer representing the coded height of the video frame.
        /// </summary>
        [JsonPropertyName("codedHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CodedHeight { get; set; }

        /// <summary>
        /// An integer representing the display aspect width of the video frame.
        /// </summary>
        [JsonPropertyName("displayAspectWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayAspectWidth { get; set; }

        /// <summary>
        /// An integer representing the display aspect height of the video frame.
        /// </summary>
        [JsonPropertyName("displayAspectHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayAspectHeight { get; set; }

        /// <summary>
        /// A string representing the hardware acceleration preference.
        /// </summary>
        [JsonPropertyName("hardwareAcceleration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HardwareAcceleration { get; set; }

        /// <summary>
        /// A boolean indicating if the config should be optimized for low latency.
        /// </summary>
        [JsonPropertyName("optimizeForLatency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OptimizeForLatency { get; set; }
    }
}

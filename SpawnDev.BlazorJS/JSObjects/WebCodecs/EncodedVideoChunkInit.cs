using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the init params for the EncodedVideoChunk
    /// </summary>
    public class EncodedVideoChunkInit
    {
        /// <summary>
        /// The type of the chunk.
        /// </summary>
        [JsonPropertyName("type")]
        public EncodedVideoChunkType Type { get; set; }

        /// <summary>
        /// The timestamp of the chunk in microseconds.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// The duration of the chunk in microseconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public long? Duration { get; set; }

        /// <summary>
        /// The binary data of the chunk.
        /// </summary>
        [JsonPropertyName("data")]
        public ArrayBuffer? Data { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the init params for the VideoEncoder
    /// </summary>
    public class VideoEncoderInit
    {
        /// <summary>
        /// A callback which takes a EncodedVideoChunk object as the first argument, and an optional metadata object dictionary as the second.
        /// </summary>
        [JsonPropertyName("output")]
        public ActionCallback<EncodedVideoChunk, EncodedVideoChunkMetadata> Output { get; set; }

        /// <summary>
        /// A callback which takes an Error object as the only argument.
        /// </summary>
        [JsonPropertyName("error")]
        public ActionCallback<DOMException> Error { get; set; }
    }
}

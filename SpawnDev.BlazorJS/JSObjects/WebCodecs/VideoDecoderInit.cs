using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the init params for the VideoDecoder
    /// </summary>
    public class VideoDecoderInit
    {
        /// <summary>
        /// A callback which takes a VideoFrame object as the first argument.
        /// </summary>
        [JsonPropertyName("output")]
        public ActionCallback<VideoFrame> Output { get; set; }

        /// <summary>
        /// A callback which takes an Error object as the only argument.
        /// </summary>
        [JsonPropertyName("error")]
        public ActionCallback<DOMException> Error { get; set; }
    }
}

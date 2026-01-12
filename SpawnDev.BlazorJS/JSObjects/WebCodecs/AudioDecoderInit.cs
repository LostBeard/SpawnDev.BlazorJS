using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing the init params for the AudioDecoder
    /// </summary>
    public class AudioDecoderInit
    {
        /// <summary>
        /// A callback which takes a AudioData object as the first argument.
        /// </summary>
        [JsonPropertyName("output")]
        public ActionCallback<AudioData> Output { get; set; }

        /// <summary>
        /// A callback which takes an Error object as the only argument.
        /// </summary>
        [JsonPropertyName("error")]
        public ActionCallback<DOMException> Error { get; set; }
    }
}

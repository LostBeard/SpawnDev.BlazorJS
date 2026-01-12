using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A dictionary object containing options for the encode method
    /// </summary>
    public class VideoEncoderEncodeOptions
    {
        /// <summary>
        /// A boolean indicating if the frame depends on the successful encoding of previous frames.
        /// </summary>
        [JsonPropertyName("keyFrame")]
        public bool? KeyFrame { get; set; }
    }
}

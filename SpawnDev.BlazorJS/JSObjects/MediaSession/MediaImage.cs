using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaImage dictionary of the Media Session API describes the images associated with a media resource.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaImage
    /// </summary>
    public class MediaImage
    {
        /// <summary>
        /// The URL from which the user agent fetches the image.
        /// </summary>
        [JsonPropertyName("src")]
        public string Src { get; set; } = "";
        /// <summary>
        /// A string specifying the size of the image, such as "96x96", "128x128", etc.
        /// </summary>
        [JsonPropertyName("sizes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Sizes { get; set; }
        /// <summary>
        /// A string specifying the MIME type of the image, such as "image/png" or "image/jpeg".
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
    }
}

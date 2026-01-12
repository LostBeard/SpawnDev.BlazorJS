using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaMetadataInit dictionary of the Media Session API provides initialization data for the MediaMetadata interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata/MediaMetadata
    /// </summary>
    public class MediaMetadataInit
    {
        /// <summary>
        /// The title of the media to be played.
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// The name of the artist, group, creator, etc., of the media to be played.
        /// </summary>
        [JsonPropertyName("artist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Artist { get; set; }
        /// <summary>
        /// The name of the album or collection containing the media to be played.
        /// </summary>
        [JsonPropertyName("album")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Album { get; set; }
        /// <summary>
        /// An array of MediaImage objects, each of which contains information about an image associated with the media.
        /// </summary>
        [JsonPropertyName("artwork")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MediaImage[]? Artwork { get; set; }
    }
}

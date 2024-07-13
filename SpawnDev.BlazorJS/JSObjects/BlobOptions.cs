using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when creating a new Blob<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Blob/Blob#options
    /// </summary>
    public class BlobOptions
    {
        /// <summary>
        /// The MIME type of the data that will be stored into the blob. The default value is the empty string, ("").
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; } = null;
        /// <summary>
        /// How to interpret newline characters (\n) within the contents, if the data is text. The default value, transparent, copies newline characters into the blob without changing them. To convert newlines to the host system's native convention, specify the value native.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Endings { get; set; } = null;
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An options object containing optional attributes used when creating a new File
    /// https://developer.mozilla.org/en-US/docs/Web/API/File/File
    /// </summary>
    public class FileOptions
    {
        /// <summary>
        /// A string representing the MIME type of the content that will be put into the file. Defaults to a value of ""
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
        /// <summary>
        /// A number representing the number of milliseconds between the Unix time epoch and when the file was last modified. Defaults to a value of Date.now().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? LastModified { get; set; }
        /// <summary>
        /// How to interpret newline characters (\n) within the contents, if the data is text. The default value, transparent, copies newline characters into the blob without changing them. To convert newlines to the host system's native convention, specify the value native.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Endings { get; set; }
    }
}

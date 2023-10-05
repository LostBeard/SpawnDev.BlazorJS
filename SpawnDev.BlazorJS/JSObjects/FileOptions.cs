using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
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
    }
}

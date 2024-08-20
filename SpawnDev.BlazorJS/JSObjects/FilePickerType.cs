using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#description
    /// </summary>
    public class FilePickerType
    {
        /// <summary>
        /// An optional description of the category of files types allowed. Defaults to an empty string.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }
        /// <summary>
        /// An Object with the keys set to the MIME type and the values an Array of file extensions (see below for an example).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, IEnumerable<string>>? Accept { get; set; }
    }
}

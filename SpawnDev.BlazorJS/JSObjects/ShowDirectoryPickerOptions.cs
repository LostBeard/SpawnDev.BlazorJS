using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ShowDirectoryPickerOptions
    {
        /// <summary>
        /// By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// A string that defaults to "read" for read-only access or "readwrite" for read and write access to the directory.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
        /// <summary>
        /// A FileSystemHandle or a well known directory ("desktop", "documents", "downloads", "music", "pictures", or "videos") to open the dialog in.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StartIn { get; set; }
    }
}

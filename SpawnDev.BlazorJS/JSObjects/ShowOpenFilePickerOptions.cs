using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window/showOpenFilePicker#options
    /// </summary>
    public class ShowOpenFilePickerOptions
    {
        /// <summary>
        /// A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeAcceptAllOption { get; set; }
        /// <summary>
        /// By specifying an ID, the browser can remember different directories for different IDs. If the same ID is used for another picker, the picker opens in the same directory.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }
        /// <summary>
        /// A boolean value that defaults to false. When set to true multiple files may be selected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Multiple { get; set; }
        /// <summary>
        /// An Array of allowed file types to pick. Each item is an object with the following options:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<FilePickerType>? Types { get; set; }
    }
}

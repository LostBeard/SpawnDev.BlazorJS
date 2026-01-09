using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used to set options for the file picker
    /// </summary>
    public class ShowSaveFilePickerOptions
    {
        /// <summary>
        /// A String. The suggested file name.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SuggestedName { get; set; }

        /// <summary>
        /// A boolean value that defaults to false. By default, the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeAcceptAllOption { get; set; }

        /// <summary>
        /// An Array of allowed file types to save. Each item is an object with the following options:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<FilePickerType>? Types { get; set; }
    }
}

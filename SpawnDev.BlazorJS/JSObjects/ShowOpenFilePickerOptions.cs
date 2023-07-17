using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ShowOpenFilePickerOptions
    {
        /// <summary>
        /// A boolean value that defaults to false. When set to true multiple files may be selected.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Multiple { get; set; }

        /// <summary>
        /// A boolean value that defaults to false. By default the picker should include an option to not apply any file type filters (instigated with the type option below). Setting this option to true means that option is not available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ExcludeAcceptAllOption { get; set; }

        /// <summary>
        /// An Array of allowed file types to pick. Each item is an object with the following options:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ShowOpenFilePickerType>? Types { get; set; }
    }
}

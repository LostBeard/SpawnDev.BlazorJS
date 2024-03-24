using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// FileSystemDirectory.RemoveEntry options
    /// </summary>
    public class RemoveEntryOptions
    {
        /// <summary>
        /// A boolean value, which defaults to false. When set to true entries will be removed recursively.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Recursive { get; set; }
    }
}

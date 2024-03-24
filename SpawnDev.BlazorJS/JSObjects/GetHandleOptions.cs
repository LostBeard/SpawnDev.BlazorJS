using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// FileSystemDirectory.GetHandle options
    /// </summary>
    public class GetHandleOptions
    {
        /// <summary>
        /// A boolean value, which defaults to false. When set to true if the directory is not found, one with the specified name will be created and returned.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Create { get; set; }
    }
}

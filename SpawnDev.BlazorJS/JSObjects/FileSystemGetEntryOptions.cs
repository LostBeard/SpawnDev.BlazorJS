using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used for FileSystemDirectoryEntry.GetDirectory method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry/getDirectory#options_parameter
    /// </summary>
    public class FileSystemGetEntryOptions
    {
        /// <summary>
        /// If this property is true, and the requested directory doesn't exist, the user agent should create it. The default is false. The parent directory must already exist.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Create { get; set; }
        /// <summary>
        /// If true, and the create option is also true, the directory must not exist prior to issuing the call. Instead, it must be possible for it to be created newly at call time. The default is false. This parameter is ignored if create is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Exclusive { get; set; }
    }
}

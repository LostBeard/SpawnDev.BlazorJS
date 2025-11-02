using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle/read#options
    /// </summary>
    public class FileSystemSyncReadWriteOptions
    {
        /// <summary>
        /// A number representing the offset in bytes that the file should be read from, or written to.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? At { get; set; }
    }
}

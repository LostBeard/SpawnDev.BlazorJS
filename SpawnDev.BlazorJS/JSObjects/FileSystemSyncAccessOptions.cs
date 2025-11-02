using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle/createSyncAccessHandle#options
    /// </summary>
    public class FileSystemSyncAccessOptions
    {
        /// <summary>
        /// A string specifying the locking mode for the access handle. The default value is "readwrite".<br/>
        /// Possible values are:<br/>
        /// "read-only" - Multiple FileSystemSyncAccessHandle objects can be opened simultaneously on a file (for example when using the same app in multiple tabs), provided they are all opened in "read-only" mode. Once opened, read-like methods can be called on the handles — read(), getSize(), and close().<br/>
        /// "readwrite" - Only one FileSystemSyncAccessHandle object can be opened on a file. Attempting to open subsequent handles before the first handle is closed results in a NoModificationAllowedError exception being thrown. Once opened, any available method can be called on the handle.<br/>
        /// "readwrite-unsafe" - Multiple FileSystemSyncAccessHandle objects can be opened simultaneously on a file, provided they are all opened in "readwrite-unsafe" mode. Once opened, any available method can be called on the handles.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class FileSystemWriteOptions
    {
        /// <summary>
        /// A string that is one of the following: "write", "seek", or "truncate"
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }

        /// <summary>
        /// The file data to write. Can be an ArrayBuffer, a TypedArray, a DataView, a Blob, a String object, or a string literal. This property is required if type is set to write
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<ArrayBuffer, TypedArray, DataView, Blob, string, byte[]> Data { get; set; }

        /// <summary>
        /// The byte position the current file cursor should move to if type seek is used. Can also be set with if type is write, in which case the write will start at the position.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Position { get; set; }

        /// <summary>
        /// An unsigned long value representing the amount of bytes the stream should contain. This property is required if type is set to truncate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Size { get; set; }
    }
}

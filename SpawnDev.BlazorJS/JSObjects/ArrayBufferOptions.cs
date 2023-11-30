using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when creating an ArrayBuffer
    /// </summary>
    public class ArrayBufferOptions
    {
        /// <summary>
        /// The maximum size, in bytes, that the array buffer can be resized to.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? MaxByteLength { get; set; }
    }
}

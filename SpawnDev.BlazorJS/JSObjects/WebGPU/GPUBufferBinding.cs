using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUBufferBinding describes a buffer and optional range to bind as a resource.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubufferbinding
    /// </summary>
    public class GPUBufferBinding 
    {
        /// <summary>
        /// The GPUBuffer to bind.
        /// </summary>
        public GPUBuffer Buffer { get; init; }

        /// <summary>
        /// The offset, in bytes, from the beginning of buffer to the beginning of the range exposed to the shader by the buffer binding.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUSize64? Offset { get; init; }

        /// <summary>
        /// The size, in bytes, of the buffer binding. If not provided, specifies the range starting at offset and ending at the end of buffer.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUSize64? Size { get; init; }
    }
}

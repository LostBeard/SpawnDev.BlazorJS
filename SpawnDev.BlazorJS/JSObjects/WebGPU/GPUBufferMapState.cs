using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUBuffer represents a block of memory that can be used in GPU operations. Data is stored in linear layout, meaning that each byte of the allocation can be addressed by its offset from the start of the GPUBuffer, subject to alignment restrictions depending on the operation. Some GPUBuffers can be mapped which makes the block of memory accessible via an ArrayBuffer called its mapping.<br/>
    /// GPUBuffers are created via createBuffer(). Buffers may be mappedAtCreation.<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpubuffermapstate
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUBufferMapState
    {
        /// <summary>
        /// The buffer is not mapped for use by this.getMappedRange().
        /// </summary>
        [JsonPropertyName("unmapped")]
        Unmapped,
        /// <summary>
        /// A mapping of the buffer has been requested, but is pending. It may succeed, or fail validation in mapAsync().
        /// </summary>
        [JsonPropertyName("pending")]
        Pending,
        /// <summary>
        /// The buffer is mapped and this.getMappedRange() may be used.
        /// </summary>
        [JsonPropertyName("mapped")]
        Mapped,
    }
}

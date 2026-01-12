using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Creates buffer descriptor<br/>
    /// https://www.w3.org/TR/webgpu/#gpubufferdescriptor
    /// </summary>
    public class GPUBufferDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// A boolean. If set to true, the buffer will be mapped upon creation, meaning that you can set the values inside the buffer immediately by calling GPUBuffer.getMappedRange(). The default value is false.<br/>
        /// Note that it is valid to set mappedAtCreation: true so you can set the buffer's initial data, even if the GPUBufferUsage.MAP_READ or GPUBufferUsage.MAP_WRITE usage flags are not set.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("mappedAtCreation")]
        public bool? MappedAtCreation { get; init; }
        /// <summary>
        /// A number representing the size of the buffer, in bytes.
        /// </summary>
        [JsonPropertyName("size")]
        public GPUSize64 Size { get; init; }
        /// <summary>
        /// The bitwise flags representing the allowed usages for the GPUBuffer. The possible values are in the GPUBuffer.usage value table.
        /// </summary>
        [JsonPropertyName("usage")]
        public GPUBufferUsage Usage { get; init; }
    }
}

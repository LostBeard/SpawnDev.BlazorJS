using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubindgroupdescriptor
    /// </summary>
    public class GPUBindGroupDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The GPUBindGroupLayout the entries of this bind group will conform to.
        /// </summary>
        [JsonPropertyName("layout")]
        public GPUBindGroupLayout Layout { get; init; }

        /// <summary>
        /// A list of entries describing the resources to expose to the shader for each binding described by the layout.
        /// </summary>
        [JsonPropertyName("entries")]
        public IEnumerable<GPUBindGroupEntry> Entries { get; init; }
    }
}

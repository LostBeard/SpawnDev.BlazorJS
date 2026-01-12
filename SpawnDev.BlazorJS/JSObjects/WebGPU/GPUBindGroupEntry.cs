using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUBindGroupEntry describes a single resource to be bound in a GPUBindGroup
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubindgroupentry
    /// </summary>
    public class GPUBindGroupEntry
    {
        /// <summary>
        /// A unique identifier for a resource binding within the GPUBindGroup, corresponding to a GPUBindGroupLayoutEntry.binding and a @binding attribute in the GPUShaderModule.
        /// </summary>
        [JsonPropertyName("binding")]
        public GPUIndex32 Binding { get; init; }

        /// <summary>
        /// The resource to bind, which may be a GPUSampler, GPUTexture, GPUTextureView, GPUBuffer, GPUBufferBinding, or GPUExternalTexture.
        /// </summary>
        [JsonPropertyName("resource")]
        public GPUBindingResource Resource { get; init; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes a single shader resource binding to be included in the GPUBindGroupLayout
    /// https://www.w3.org/TR/webgpu/#dictdef-gpubindgrouplayoutentry
    /// </summary>
    public class GPUBindGroupLayoutEntry
    {
        /// <summary>
        /// A number representing a unique identifier for this particular entry, which matches the binding 
        /// value of a corresponding GPUBindGroup entry. In addition, it matches the n index value of the 
        /// corresponding @binding(n) attribute in the shader (GPUShaderModule) used in the related pipeline.
        /// </summary>
        [JsonPropertyName("binding")]
        public GPUSize32 Binding { get; init; }

        /// <summary>
        /// A bitset of the members of GPUShaderStage. 
        /// Each set bit indicates that a GPUBindGroupLayoutEntry’s resource will be accessible from the associated shader stage.
        /// </summary>
        [JsonPropertyName("visibility")]
        public GPUShaderStageFlags Visibility { get; init; }

        /// <summary>
        /// Exactly one of these members must be set, indicating the binding type. The contents of the member specify options specific to that type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("buffer")]
        public GPUBufferBindingLayout? Buffer { get; init; }

        /// <summary>
        /// Exactly one of these members must be set, indicating the binding type. The contents of the member specify options specific to that type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sampler")]
        public GPUSamplerBindingLayout? Sampler { get; init; }

        /// <summary>
        /// Exactly one of these members must be set, indicating the binding type. The contents of the member specify options specific to that type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("texture")]
        public GPUTextureBindingLayout? Texture { get; init; }

        /// <summary>
        /// Exactly one of these members must be set, indicating the binding type. The contents of the member specify options specific to that type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("storageTexture")]
        public GPUStorageTextureBindingLayout? StorageTexture { get; init; }

        /// <summary>
        /// Exactly one of these members must be set, indicating the binding type. The contents of the member specify options specific to that type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("externalTexture")]
        public GPUExternalTextureBindingLayout? ExternalTexture { get; init; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpusamplerdescriptor
    /// </summary>
    public class GPUSamplerDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// Specifies the address modes for the texture width.
        /// </summary>
        public GPUAddressMode AddressModeU { get; set; } = GPUAddressMode.ClampToEdge;
        /// <summary>
        /// Specifies the address modes for the texture height.
        /// </summary>
        public GPUAddressMode AddressModeV { get; set; } = GPUAddressMode.ClampToEdge;
        /// <summary>
        /// Specifies the address modes for the texture depth.
        /// </summary>
        public GPUAddressMode AddressModeW { get; set; } = GPUAddressMode.ClampToEdge;
        /// <summary>
        /// Specifies the sampling behavior when the sampled area is smaller than or equal to one texel.
        /// </summary>
        public GPUFilterMode MagFilter { get; set; } = GPUFilterMode.Nearest;
        /// <summary>
        /// Specifies the sampling behavior when the sampled area is larger than one texel.
        /// </summary>
        public GPUFilterMode MinFilter { get; set; } = GPUFilterMode.Nearest;
        /// <summary>
        /// Specifies behavior for sampling between mipmap levels.
        /// </summary>
        public GPUMipmapFilterMode MipmapFilter { get; set; } = GPUMipmapFilterMode.Nearest;
        /// <summary>
        /// Specifies the minimum and maximum levels of detail, respectively, used internally when sampling a texture.
        /// </summary>
        public float LodMinClamp { get; set; } = 0;
        /// <summary>
        /// Specifies the minimum and maximum levels of detail, respectively, used internally when sampling a texture.
        /// </summary>
        public float LodMaxClamp = 32;
        /// <summary>
        /// When provided the sampler will be a comparison sampler with the specified GPUCompareFunction.<br/>
        /// Note: Comparison samplers may use filtering, but the sampling results will be implementation-dependent and may differ from the normal filtering rules.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUCompareFunction? Compare { get; set; }
        /// <summary>
        /// Specifies the maximum anisotropy value clamp used by the sampler. Anisotropic filtering is enabled when maxAnisotropy is > 1 and the implementation supports it.<br/>
        /// Anisotropic filtering improves the image quality of textures sampled at oblique viewing angles. Higher maxAnisotropy values indicate the maximum ratio of anisotropy supported when filtering.<br/>
        /// Note: Most implementations support maxAnisotropy values in range between 1 and 16, inclusive. The used value of maxAnisotropy will be clamped to the maximum value that the platform supports.
        /// </summary>
        public ushort MaxAnisotropy { get; set; } = 1;
    }
}

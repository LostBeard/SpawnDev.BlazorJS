using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// "GPUTexelCopyTextureInfo" describes the "info" (GPUTexture, etc.) about a "texture" source or destination of a "texel copy" operation. Together with the copySize, it describes a sub-region of a texture (spanning one or more contiguous texture subresources at the same mip-map level).<br/>
    /// https://www.w3.org/TR/webgpu/#gputexelcopytextureinfo
    /// </summary>
    public class GPUTexelCopyTextureInfo
    {
        /// <summary>
        /// Texture to copy to/from.
        /// </summary>
        public GPUTexture Texture { get; set; }
        /// <summary>
        /// Mip-map level of the texture to copy to/from.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUIntegerCoordinate? MipLevel { get; set; }
        /// <summary>
        /// Defines the origin of the copy - the minimum corner of the texture sub-region to copy to/from. Together with copySize, defines the full copy sub-region.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUOrigin3D? Origin { get; set; }
        /// <summary>
        /// Defines which aspects of the texture to copy to/from.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUTextureAspect? Aspect { get; set; }
    }
}

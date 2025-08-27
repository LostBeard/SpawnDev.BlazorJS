using System.Text.Json.Serialization;


namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// "GPUCopyExternalImageSourceInfo" describes the "info" about the "source" of a "copyExternalImageToTexture()" operation.<br/>
    /// https://www.w3.org/TR/webgpu/#gpucopyexternalimagesourceinfo
    /// </summary>
    public class GPUCopyExternalImageSourceInfo
    {
        /// <summary>
        /// The source of the texel copy. The copy source data is captured at the moment that copyExternalImageToTexture() is issued. Source size is determined as described by the external source dimensions table.
        /// </summary>
        public GPUCopyExternalImageSource Source { get; set; }

        /// <summary>
        /// Defines the origin of the copy - the minimum (top-left) corner of the source sub-region to copy from. Together with copySize, defines the full copy sub-region.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUOrigin2D? Origin { get; set; }

        /// <summary>
        /// Describes whether the source image is vertically flipped, or not.<br/>
        /// If this option is set to true, the copy is flipped vertically: the bottom row of the source region is copied into the first row of the destination region, and so on. The origin option is still relative to the top-left corner of the source image, increasing downward.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Flip { get; set; }
    }
}

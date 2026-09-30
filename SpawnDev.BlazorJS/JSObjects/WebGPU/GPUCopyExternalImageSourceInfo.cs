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
        public required GPUCopyExternalImageSource Source { get; set; }

        /// <summary>
        /// Defines the origin of the copy - the minimum (top-left) corner of the source sub-region to copy from. Together with copySize, defines the full copy sub-region.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUOrigin2D? Origin { get; set; }

        /// <summary>
        /// Describes whether the source image is vertically flipped, or not.<br/>
        /// If this option is set to true, the copy is flipped vertically: the bottom row of the source region is copied into the first row of the destination region, and so on. The origin option is still relative to the top-left corner of the source image, increasing downward.
        /// </summary>
        [JsonPropertyName("flipY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FlipY { get; set; }

        /// <summary>
        /// Obsolete alias of <see cref="FlipY"/>. It used to serialize as "flip", which is not a WebGPU member, so the
        /// browser ignored it and the copy was never flipped. It now forwards to <see cref="FlipY"/> and is not serialized.
        /// </summary>
        [Obsolete("Use FlipY. \"flip\" is not a GPUCopyExternalImageSourceInfo member; the browser ignored it.")]
        [JsonIgnore]
        public bool? Flip { get => FlipY; set => FlipY = value; }
    }
}

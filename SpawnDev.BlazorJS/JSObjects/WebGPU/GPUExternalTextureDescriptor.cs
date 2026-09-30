using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuexternaltexturedescriptor
    /// </summary>
    public class GPUExternalTextureDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The video source to import the external texture from. Source size is determined as described by the external source dimensions table.
        /// </summary>
        public required Union<HTMLVideoElement, VideoFrame> Source { get; set; }

        /// <summary>
        /// The color space the image contents of source will be converted into when reading.
        /// </summary>
        /// <remarks>Was a public FIELD, which System.Text.Json does not serialize, so a requested color space never
        /// reached the browser. Optional; the spec default is "srgb", so unset is omitted.</remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PredefinedColorSpace? ColorSpace { get; set; }
    }
}

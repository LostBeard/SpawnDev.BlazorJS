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
        public Union<HTMLVideoElement, VideoFrame> Source { get; init; }

        /// <summary>
        /// The color space the image contents of source will be converted into when reading.
        /// </summary>
        public PredefinedColorSpace ColorSpace = PredefinedColorSpace.Srgb;
    }
}

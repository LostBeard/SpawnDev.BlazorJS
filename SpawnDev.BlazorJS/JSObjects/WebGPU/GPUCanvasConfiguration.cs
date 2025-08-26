namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Configuration options for creating a GPUCanvasContext.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpucanvasconfiguration
    /// </summary>
    public class GPUCanvasConfiguration
    {
        /// <summary>
        /// The GPUDevice that the rendering information for the context will come from.
        /// </summary>
        public GPUDevice Device { get; init; }

        /// <summary>
        /// The format that textures returned by getCurrentTexture() will have. This can be bgra8unorm, rgba8unorm, or rgba16float. 
        /// The optimal canvas texture format for the current system can be returned by GPU.getPreferredCanvasFormat(). 
        /// Using this is recommended — if you don't use the preferred format when configuring the canvas context, 
        /// you may incur additional overhead, such as additional texture copies, depending on the platform.
        /// </summary>
        public string Format { get; init; }
    }
}
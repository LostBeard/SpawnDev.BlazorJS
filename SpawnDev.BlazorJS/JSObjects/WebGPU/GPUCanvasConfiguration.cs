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
        public GPUDevice Device { get; set; }

        /// <summary>
        /// The format that textures returned by getCurrentTexture() will have. This can be bgra8unorm, rgba8unorm, or rgba16float. 
        /// The optimal canvas texture format for the current system can be returned by GPU.getPreferredCanvasFormat(). 
        /// Using this is recommended — if you don't use the preferred format when configuring the canvas context, 
        /// you may incur additional overhead, such as additional texture copies, depending on the platform.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// The GPUTextureUsage flags for textures returned by getCurrentTexture().
        /// Defaults to GPUTextureUsage.RENDER_ATTACHMENT. Add GPUTextureUsage.COPY_SRC for screenshots/post-processing.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
        public GPUFlagsConstant? Usage { get; set; }

        /// <summary>
        /// A list of formats that views created from textures returned by getCurrentTexture() may use.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ViewFormats { get; set; }

        /// <summary>
        /// The color space that values written into textures returned by getCurrentTexture() should be displayed with. "srgb" or "display-p3".
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorSpace { get; set; }

        /// <summary>
        /// Determines the effect that alpha values will have on the content of textures returned by getCurrentTexture(). "opaque" or "premultiplied".
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]
        public string? AlphaMode { get; set; }
    }
}
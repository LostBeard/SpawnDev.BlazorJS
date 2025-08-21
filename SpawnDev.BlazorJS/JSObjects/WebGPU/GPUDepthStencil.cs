namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a depth-stencil state in WebGPU, which is used to configure depth and stencil testing for rendering operations.
    /// </summary>
    public class GPUDepthStencil
    {
        /// <summary>
        /// An enumerated value specifying the depthStencilAttachment format that the GPURenderPipeline will be compatible with. 
        /// See the specification's Texture Formats section for all the available format values.
        /// </summary>
        public string Format { get; set; }
    }
}

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpurenderbundleencoderdescriptor
    /// </summary>
    public class GPURenderBundleEncoderDescriptor : GPUPipelineDescriptorBase
    {
        /// <summary>
        /// If true, indicates that the render bundle does not modify the depth component of the GPURenderPassDepthStencilAttachment of any render pass the render bundle is executed in.
        /// </summary>
        public bool DepthReadOnly { get; set; }
        /// <summary>
        /// If true, indicates that the render bundle does not modify the stencil component of the GPURenderPassDepthStencilAttachment of any render pass the render bundle is executed in.
        /// </summary>
        public bool StencilReadOnly { get; set; }
    }
}

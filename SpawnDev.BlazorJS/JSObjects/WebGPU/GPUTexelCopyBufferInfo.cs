namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// "GPUTexelCopyBufferInfo" describes the "info" (GPUBuffer and GPUTexelCopyBufferLayout) about a "buffer" source or destination of a "texel copy" operation. Together with the copySize, it describes the footprint of a region of texels in a GPUBuffer.<br/>
    /// https://www.w3.org/TR/webgpu/#gputexelcopybufferinfo
    /// </summary>
    public class GPUTexelCopyBufferInfo : GPUTexelCopyBufferLayout
    {
        /// <summary>
        /// A buffer which either contains texel data to be copied or will store the texel data being copied, depending on the method it is being passed to.
        /// </summary>
        public GPUBuffer Buffer { get; set; }
    }
}

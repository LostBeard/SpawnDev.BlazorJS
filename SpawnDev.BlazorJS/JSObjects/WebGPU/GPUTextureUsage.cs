namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The bitwise flags representing the original usages set when the GPUTexture was first created. <br/>
    /// The returned number is the sum of decimal values representing the different flags, as seen in the table below.<br/>
    /// https://www.w3.org/TR/webgpu/#namespacedef-gputextureusage
    /// </summary>
    [Flags]
    public enum GPUTextureUsage : uint
    {
        /// <summary>
        /// The texture can be used as the source of a copy operation, for example the source argument of a copyTextureToBuffer() call.
        /// </summary>
        CopySrc = 0x01,
        /// <summary>
        /// The texture can be used as the destination of a copy/write operation, for example the destination argument of a copyBufferToTexture() call.
        /// </summary>
        CopyDst = 0x02,
        /// <summary>
        /// The texture can be bound for use as a sampled texture in a shader, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()), 
        /// which adheres to a GPUBindGroupLayout entry with a specified texture binding layout.
        /// </summary>
        TextureBinding = 0x04,
        /// <summary>
        /// The texture can be bound for use as a storage texture in a shader, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()),
        /// which adheres to a GPUBindGroupLayout entry with a specified storage texture binding layout.
        /// </summary>
        StorageBinding = 0x08,
        /// <summary>
        /// The texture can be used as a color or depth/stencil attachment in a render pass, for example as the view property of the descriptor object in a beginRenderPass() call.
        /// </summary>
        RenderAttachment = 0x10
    }
}

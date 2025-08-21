using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUCommandEncoder interface of the WebGPU API represents an encoder that collects a sequence of GPU commands to be issued to the GPU.
    /// A GPUCommandEncoder object instance is created via the GPUDevice.createCommandEncoder() property.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUCommandEncoder
    /// </summary>
    public class GPUCommandEncoder : JSObject
    {
        /// <inheritdoc/>
        public GPUCommandEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Begins a new render pass using the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor that defines the configuration and attachments for the render pass. This cannot be <see
        /// langword="null"/>.</param>
        /// <returns>A <see cref="GPURenderPassEncoder"/> that can be used to record rendering commands for the render pass.</returns>
        public GPURenderPassEncoder BeginRenderPass(GPURenderPassDescriptor descriptor) => JSRef!.Call<GPURenderPassEncoder>("beginRenderPass", descriptor);

        /// <summary>
        /// Completes the recording of commands in the current GPU command encoder and returns a command buffer.
        /// </summary>
        /// <returns>A <see cref="GPUCommandBuffer"/> containing the recorded commands. The command buffer can be submitted to a
        /// GPU queue for execution.</returns>
        public GPUCommandBuffer Finish() => JSRef!.Call<GPUCommandBuffer>("finish");
    }
}

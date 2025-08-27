using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUCommandEncoder interface of the WebGPU API represents an encoder that collects a sequence of GPU commands to be issued to the GPU.
    /// A GPUCommandEncoder object instance is created via the GPUDevice.createCommandEncoder() property.
    /// https://www.w3.org/TR/webgpu/#gpucommandencoder
    /// </summary>
    public class GPUCommandEncoder : GPUObjectBase
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

        /// <summary>
        /// Completes the recording of commands in the current GPU command encoder and returns a command buffer.
        /// </summary>
        /// <returns>A <see cref="GPUCommandBuffer"/> containing the recorded commands. The command buffer can be submitted to a
        /// GPU queue for execution.</returns>
        public GPUCommandBuffer Finish(GPUCommandBufferDescriptor descriptor) => JSRef!.Call<GPUCommandBuffer>("finish", descriptor);

        /// <summary>
        /// The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another.
        /// </summary>
        /// <param name="source">The GPUBuffer to copy from.</param>
        /// <param name="destination">The GPUBuffer to copy to.</param>
        /// <param name="size">Bytes to copy.</param>
        public void CopyBufferToBuffer(GPUBuffer source, GPUBuffer destination, GPUSize64 size) => JSRef!.CallVoid("copyBufferToBuffer", source, destination, size);

        /// <summary>
        /// The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another.
        /// </summary>
        /// <param name="source">The GPUBuffer to copy from.</param>
        /// <param name="destination">The GPUBuffer to copy to.</param>
        public void CopyBufferToBuffer(GPUBuffer source, GPUBuffer destination) => JSRef!.CallVoid("copyBufferToBuffer", source, destination);

        /// <summary>
        /// The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another.
        /// </summary>
        /// <param name="source">The GPUBuffer to copy from.</param>
        /// <param name="sourceOffset">Offset in bytes into source to begin copying from.</param>
        /// <param name="destination">The GPUBuffer to copy to.</param>
        /// <param name="destinationOffset">Offset in bytes into destination to place the copied data.</param>
        /// <param name="size">Bytes to copy.</param>
        public void CopyBufferToBuffer(GPUBuffer source, GPUSize64 sourceOffset, GPUBuffer destination, GPUSize64 destinationOffset, GPUSize64 size) => JSRef!.CallVoid("copyBufferToBuffer", source, sourceOffset, destination, destinationOffset, size);

        /// <summary>
        /// The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another.
        /// </summary>
        /// <param name="source">The GPUBuffer to copy from.</param>
        /// <param name="sourceOffset">Offset in bytes into source to begin copying from.</param>
        /// <param name="destination">The GPUBuffer to copy to.</param>
        /// <param name="destinationOffset">Offset in bytes into destination to place the copied data.</param>
        public void CopyBufferToBuffer(GPUBuffer source, GPUSize64 sourceOffset, GPUBuffer destination, GPUSize64 destinationOffset) => JSRef!.CallVoid("copyBufferToBuffer", source, sourceOffset, destination, destinationOffset);

        /// <summary>
        /// Encode a command into the GPUCommandEncoder that copies data from a sub-region of a GPUBuffer to a sub-region of one or multiple continuous texture subresources.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="copySize"></param>
        public void CopyBufferToTexture(GPUTexelCopyBufferInfo source, GPUTexelCopyTextureInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize) => JSRef!.CallVoid("copyBufferToTexture", source, destination, copySize);

        /// <summary>
        /// Encode a command into the GPUCommandEncoder that copies data from a sub-region of one or multiple continuous texture subresources to a sub-region of a GPUBuffer.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="copySize"></param>
        public void CopyTextureToBuffer(GPUTexelCopyTextureInfo source, GPUTexelCopyBufferInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize) => JSRef!.CallVoid("copyTextureToBuffer", source, destination, copySize);

        /// <summary>
        /// Encode a command into the GPUCommandEncoder that copies data from a sub-region of one or multiple contiguous texture subresources to another sub-region of one or multiple continuous texture subresources.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="copySize"></param>
        public void CopyTextureToTexture(GPUTexelCopyTextureInfo source, GPUTexelCopyTextureInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize) => JSRef!.CallVoid("copyTextureToTexture", source, destination, copySize);

        /// <summary>
        /// Encode a command into the GPUCommandEncoder that fills a sub-region of a GPUBuffer with zeros.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public void ClearBuffer(GPUBuffer buffer, GPUSize64 offset, GPUSize64 size) => JSRef!.CallVoid("clearBuffer", buffer, offset, size);

        /// <summary>
        /// Encode a command into the GPUCommandEncoder that fills a sub-region of a GPUBuffer with zeros.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        public void ClearBuffer(GPUBuffer buffer, GPUSize64 offset = 0) => JSRef!.CallVoid("clearBuffer", buffer, offset);

        /// <summary>
        /// Resolves query results from a GPUQuerySet out into a range of a GPUBuffer.
        /// </summary>
        /// <param name="querySet"></param>
        /// <param name="firstQuery"></param>
        /// <param name="queryCount"></param>
        /// <param name="destination"></param>
        /// <param name="destinationOffset"></param>
        public void ResolveQuerySet(GPUQuerySet querySet, GPUSize32 firstQuery, GPUSize32 queryCount, GPUBuffer destination, GPUSize64 destinationOffset) => JSRef!.CallVoid("resolveQuerySet", querySet, firstQuery, queryCount, destination, destinationOffset);

        /// <summary>
        /// Begins encoding a compute pass described by descriptor.
        /// </summary>
        /// <param name="descriptor"></param>
        public GPUComputePassEncoder BeginComputePass(GPUComputePassDescriptor? descriptor = null) => descriptor == null ? JSRef!.Call<GPUComputePassEncoder>("beginComputePass") : JSRef!.Call<GPUComputePassEncoder>("beginComputePass", descriptor);
    }
}

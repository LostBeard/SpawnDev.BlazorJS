using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents an encoder for recording commands within a GPU render pass.
    /// https://www.w3.org/TR/webgpu/#gpurenderpassencoder
    /// </summary>
    public class GPURenderPassEncoder : GPUObjectBase
    //TODO: Solve multiple inheritance
    //GPURenderPassEncoder includes GPUCommandsMixin;
    //GPURenderPassEncoder includes GPUDebugCommandsMixin;
    //GPURenderPassEncoder includes GPUBindingCommandsMixin;
    //GPURenderPassEncoder includes GPURenderCommandsMixin;
    {
        /// <inheritdoc/>
        public GPURenderPassEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Draw primitives based on the vertex buffers provided by setVertexBuffer().
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/draw
        /// </summary>
        /// <param name="vertexCount"></param>
        public void Draw(GPUSize32 vertexCount) => JSRef!.CallVoid("draw", vertexCount);

        /// <summary>
        /// Sets the GPU render pipeline to be used for subsequent rendering operations.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/setPipeline
        /// </summary>
        /// <param name="pipeline">The <see cref="GPURenderPipeline"/> to set as the active pipeline. This cannot be null.</param>
        public void SetPipeline(GPURenderPipeline pipeline) => JSRef!.CallVoid("setPipeline", pipeline);

        /// <summary>
        /// Completes recording of the current render pass command sequence.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/end
        /// </summary>
        public void End() => JSRef!.CallVoid("end");

        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bindGroup"></param>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup bindGroup) => JSRef!.CallVoid("setBindGroup", index, bindGroup);

        /// <summary>
        /// Sets the current vertex buffer for the given slot.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="buffer"></param>
        public void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer) => JSRef!.CallVoid("setVertexBuffer", slot, buffer);
    }
}

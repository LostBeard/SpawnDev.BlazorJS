using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents an encoder for recording commands within a GPU render pass.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder
    /// </summary>
    public class GPURenderPassEncoder : JSObject
    {
        /// <inheritdoc/>
        public GPURenderPassEncoder(IJSInProcessObjectReference _ref) : base(_ref) {  }

        /// <summary>
        /// Draw primitives based on the vertex buffers provided by setVertexBuffer().
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/draw
        /// </summary>
        /// <param name="vertexCount"></param>
        public void Draw(int vertexCount) => JSRef!.CallVoid("draw", vertexCount);

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

    }
}

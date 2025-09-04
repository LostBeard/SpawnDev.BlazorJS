using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents an encoder for recording commands within a GPU render pass.
    /// https://www.w3.org/TR/webgpu/#gpurenderpassencoder
    /// </summary>
    public class GPURenderPassEncoder : GPUObjectBase, GPUCommandsMixin, GPUDebugCommandsMixin, GPUBindingCommandsMixin, GPURenderCommandsMixin
    {
        /// <inheritdoc/>
        public GPURenderPassEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region GPUDebugCommandsMixin
        /// <inheritdoc/>
        public void PushDebugGroup(string groupLabel) => JSRef!.CallVoid("pushDebugGroup", groupLabel);

        /// <inheritdoc/>
        public void PopDebugGroup() => JSRef!.CallVoid("popDebugGroup");

        /// <inheritdoc/>
        public void InsertDebugMarker(string markerLabel) => JSRef!.CallVoid("insertDebugMarker", markerLabel);
        #endregion

        #region GPURenderCommandsMixin
        /// <inheritdoc/>
        public void SetPipeline(GPURenderPipeline pipeline) => JSRef!.CallVoid("setPipeline", pipeline);

        /// <inheritdoc/>
        public void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset = 0) 
            => JSRef!.CallVoid("setIndexBuffer", buffer, indexFormat, offset);

        /// <inheritdoc/>
        public void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size)
            => JSRef!.CallVoid("setIndexBuffer", buffer, indexFormat, offset, size);

        /// <inheritdoc/>
        public void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset = 0)
            => JSRef!.CallVoid("setVertexBuffer", slot, buffer, offset);

        /// <inheritdoc/>
        public void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size)
            => JSRef!.CallVoid("setVertexBuffer", slot, buffer, offset, size);

        /// <inheritdoc/>
        public void Draw(GPUSize32 vertexCount, GPUSize32 instanceCount = 1, GPUSize32 firstVertex = 0, GPUSize32 firstInstance = 0)
            => JSRef!.CallVoid("draw", vertexCount, instanceCount, firstVertex, firstInstance);

        /// <inheritdoc/>
        public void DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount = 1, GPUSize32 firstIndex = 0, GPUSignedOffset32 baseVertex = 0, GPUSize32 firstInstance = 0)
            => JSRef!.CallVoid("drawIndexed", indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

        /// <inheritdoc/>
        public void DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)
            => JSRef!.CallVoid("drawIndirect", indirectBuffer, indirectOffset);

        /// <inheritdoc/>
        public void DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)
            => JSRef!.CallVoid("drawIndexedIndirect", indirectBuffer, indirectOffset);
        #endregion

        #region GPUBindingCommandsMixin
        /// <inheritdoc/>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsets = null)
        {
            if (dynamicOffsets != null) JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsets);
            else JSRef!.CallVoid("setBindGroup", index, bindGroup);
        }

        /// <inheritdoc/>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength) 
            => JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsetsData, dynamicOffsetsDataStart, dynamicOffsetsDataLength);
        #endregion

        #region GPURenderPassEncoder
        /// <summary>
        /// Sets the viewport used during the rasterization stage to linearly map from normalized device coordinates to viewport coordinates.
        /// </summary>
        /// <param name="x">Minimum X value of the viewport in pixels.</param>
        /// <param name="y">Minimum Y value of the viewport in pixels.</param>
        /// <param name="width">Width of the viewport in pixels.</param>
        /// <param name="height">Height of the viewport in pixels.</param>
        /// <param name="minDepth">Minimum depth value of the viewport.</param>
        /// <param name="maxDepth">Maximum depth value of the viewport.</param>
        public void SetViewport(float x, float y, float width, float height, float minDepth, float maxDepth) 
            => JSRef!.CallVoid("setViewport", x, y, width, height, minDepth, maxDepth);

        /// <summary>
        /// Sets the scissor rectangle used during the rasterization stage. After transformation into viewport coordinates any fragments which fall outside the scissor rectangle will be discarded.
        /// </summary>
        /// <param name="x">Minimum X value of the scissor rectangle in pixels.</param>
        /// <param name="y">Minimum Y value of the scissor rectangle in pixels.</param>
        /// <param name="width">Width of the scissor rectangle in pixels.</param>
        /// <param name="height">Height of the scissor rectangle in pixels.</param>
        public void SetScissorRect(GPUIntegerCoordinate x, GPUIntegerCoordinate y, GPUIntegerCoordinate width, GPUIntegerCoordinate height)
            => JSRef!.CallVoid("setScissorRect", x, y, width, height);

        /// <summary>
        /// Sets the constant blend color and alpha values used with "constant" and "one-minus-constant" GPUBlendFactors.
        /// </summary>
        /// <param name="color">The color to use when blending.</param>
        public void SetBlendConstant(GPUColor color)
            => JSRef!.CallVoid("setBlendConstant", color);

        /// <summary>
        /// Sets the [[stencilReference]] value used during stencil tests with the "replace" GPUStencilOperation.
        /// </summary>
        /// <param name="reference">The new stencil reference value.</param>
        public void SetStencilReference(GPUStencilValue reference)
            => JSRef!.CallVoid("setStencilReference", reference);

        /// <summary>
        /// Begin occlusion query
        /// </summary>
        /// <param name="queryIndex">The index of the query in the query set.</param>
        public void BeginOcclusionQuery(GPUSize32 queryIndex)
            => JSRef!.CallVoid("beginOcclusionQuery", queryIndex);

        /// <summary>
        /// End occlusion query
        /// </summary>
        public void EndOcclusionQuery()
            => JSRef!.CallVoid("endOcclusionQuery");

        /// <summary>
        /// Executes the commands previously recorded into the given GPURenderBundles as part of this render pass.<br/>
        /// When a GPURenderBundle is executed, it does not inherit the render pass’s pipeline, bind groups, or vertex and index buffers. After a GPURenderBundle has executed, the render pass’s pipeline, bind group, and vertex/index buffer state is cleared (to the initial, empty values).<br/>
        /// </summary>
        /// <param name="bundles"></param>
        public void ExecuteBundles(IEnumerable<GPURenderBundle> bundles)
            => JSRef!.CallVoid("executeBundles",  bundles);

        /// <summary>
        /// Completes recording of the current render pass command sequence.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/end
        /// </summary>
        public void End() => JSRef!.CallVoid("end");
        #endregion
    }
}

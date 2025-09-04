using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpurenderbundleencoder
    /// </summary>
    public class GPURenderBundleEncoder : GPUObjectBase, GPUCommandsMixin, GPUDebugCommandsMixin, GPUBindingCommandsMixin, GPURenderCommandsMixin
    {
        /// <inheritdoc/>
        public GPURenderBundleEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

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

        #region GPURenderBundleEncoder
        /// <summary>
        /// Completes recording of the render bundle commands sequence.
        /// </summary>
        /// <param name="descriptor">optional options</param>
        /// <returns></returns>
        public GPURenderBundle Finish(GPURenderBundleDescriptor? descriptor = null)
            => descriptor == null ? JSRef!.Call<GPURenderBundle>("finish") : JSRef!.Call<GPURenderBundle>("finish", descriptor);
        #endregion
    }
}

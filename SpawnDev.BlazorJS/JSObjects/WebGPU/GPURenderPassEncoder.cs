using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents an encoder for recording commands within a GPU render pass.
    /// https://www.w3.org/TR/webgpu/#gpurenderpassencoder
    /// </summary>
    public class GPURenderPassEncoder : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPURenderPassEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Draws primitives. See § 23.2 Rendering for the detailed specification.
        /// </summary>
        /// <param name="vertexCount">The number of vertices to draw.</param>
        /// <param name="instanceCount">The number of instances to draw.</param>
        /// <param name="firstVertex">Offset into the vertex buffers, in vertices, to begin drawing from.</param>
        /// <param name="firstInstance">First instance to draw.</param>
        public void Draw(GPUSize32 vertexCount, GPUSize32 instanceCount = 1, GPUSize32 firstVertex = 0, GPUSize32 firstInstance = 0) 
            => JSRef!.CallVoid("draw", vertexCount, instanceCount, firstVertex, firstInstance);

        /// <summary>
        /// Draws indexed primitives. See § 23.2 Rendering for the detailed specification.
        /// </summary>
        /// <param name="indexCount">The number of indices to draw.</param>
        /// <param name="instanceCount">The number of instances to draw.</param>
        /// <param name="firstIndex">Offset into the index buffer, in indices, begin drawing from.</param>
        /// <param name="baseVertex">Added to each index value before indexing into the vertex buffers.</param>
        /// <param name="firstInstance">First instance to draw.</param>
        public void DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount = 1, GPUSize32 firstIndex = 0, GPUSignedOffset32 baseVertex = 0, GPUSize32 firstInstance = 0)
            => JSRef!.CallVoid("drawIndexed", indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

        /// <summary>
        /// Draws primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification.<br/>
        /// The indirect draw parameters encoded in the buffer must be a tightly packed block of four 32-bit unsigned integer values (16 bytes total), given in the same order as the arguments for draw(). For example:
        /// </summary>
        /// <param name="indirectBuffer">Buffer containing the indirect draw parameters.</param>
        /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
        public void DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)
            => JSRef!.CallVoid("drawIndirect", indirectBuffer, indirectOffset);

        /// <summary>
        /// Draws indexed primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification.<br/>
        /// The indirect drawIndexed parameters encoded in the buffer must be a tightly packed block of five 32-bit values (20 bytes total), given in the same order as the arguments for drawIndexed(). The value corresponding to baseVertex is a signed 32-bit integer, and all others are unsigned 32-bit integers. For example:
        /// </summary>
        /// <param name="indirectBuffer"></param>
        /// <param name="indirectOffset"></param>
        public void DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)
            => JSRef!.CallVoid("drawIndexedIndirect", indirectBuffer, indirectOffset);

        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index">The index to set the bind group at.</param>
        /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
        /// <param name="dynamicOffsets">Array containing buffer offsets in bytes for each entry in bindGroup marked as buffer.hasDynamicOffset, ordered by GPUBindGroupLayoutEntry.binding. See note for additional details.</param>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup bindGroup, GPUBufferDynamicOffset[]? dynamicOffsets = null)
        {
            if (dynamicOffsets != null) JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsets);
            else JSRef!.CallVoid("setBindGroup", index, bindGroup);
        }

        /// <summary>
        /// Sets the current index buffer.
        /// </summary>
        /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
        /// <param name="indexFormat">Format of the index data contained in buffer.</param>
        /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
        public void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset = 0) 
            => JSRef!.CallVoid("setIndexBuffer", buffer, indexFormat, offset);

        /// <summary>
        /// Sets the current index buffer.
        /// </summary>
        /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
        /// <param name="indexFormat">Format of the index data contained in buffer.</param>
        /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
        /// <param name="size">Size in bytes of the index data in buffer. Defaults to the size of the buffer minus the offset.</param>
        public void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size) 
            => JSRef!.CallVoid("setIndexBuffer", buffer, indexFormat, offset, size);

        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index">The index to set the bind group at.</param>
        /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
        /// <param name="dynamicOffsetsData">Array containing buffer offsets in bytes for each entry in bindGroup marked as buffer.hasDynamicOffset, ordered by GPUBindGroupLayoutEntry.binding. See note for additional details.</param>
        /// <param name="dynamicOffsetsDataStart">Offset in elements into dynamicOffsetsData where the buffer offset data begins.</param>
        /// <param name="dynamicOffsetsDataLength">Number of buffer offsets to read from dynamicOffsetsData.</param>
        public void SetBindGroup(GPUIndex32 index, GPUBindGroup bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength) 
            => JSRef!.CallVoid("setBindGroup", index, bindGroup, dynamicOffsetsData, dynamicOffsetsDataStart, dynamicOffsetsDataLength);

        /// <summary>
        /// Sets the current vertex buffer for the given slot.
        /// </summary>
        /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
        /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
        /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
        public void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset = 0) 
            => JSRef!.CallVoid("setVertexBuffer", slot, buffer, offset);

        /// <summary>
        /// Sets the current vertex buffer for the given slot.
        /// </summary>
        /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
        /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
        /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
        /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
        public void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size) 
            => JSRef!.CallVoid("setVertexBuffer", slot, buffer, offset, size);

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

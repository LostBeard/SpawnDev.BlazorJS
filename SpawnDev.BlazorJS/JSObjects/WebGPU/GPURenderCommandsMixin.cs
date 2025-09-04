namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpurendercommandsmixin
    /// </summary>
    public interface GPURenderCommandsMixin
    {
        /// <summary>
        /// Sets the GPU render pipeline to be used for subsequent rendering operations.
        /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/setPipeline
        /// </summary>
        /// <param name="pipeline">The <see cref="GPURenderPipeline"/> to set as the active pipeline. This cannot be null.</param>
        void SetPipeline(GPURenderPipeline pipeline);

        /// <summary>
        /// Sets the current index buffer.
        /// </summary>
        /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
        /// <param name="indexFormat">Format of the index data contained in buffer.</param>
        /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
        void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset = 0);

        /// <summary>
        /// Sets the current index buffer.
        /// </summary>
        /// <param name="buffer">Buffer containing index data to use for subsequent drawing commands.</param>
        /// <param name="indexFormat">Format of the index data contained in buffer.</param>
        /// <param name="offset">Offset in bytes into buffer where the index data begins. Defaults to 0.</param>
        /// <param name="size">Size in bytes of the index data in buffer. Defaults to the size of the buffer minus the offset.</param>
        void SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size);

        /// <summary>
        /// Sets the current vertex buffer for the given slot.
        /// </summary>
        /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
        /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
        /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
        void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset = 0);

        /// <summary>
        /// Sets the current vertex buffer for the given slot.
        /// </summary>
        /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
        /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
        /// <param name="offset">Offset in bytes into buffer where the vertex data begins. Defaults to 0.</param>
        /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
        void SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size);

        /// <summary>
        /// Draws primitives. See § 23.2 Rendering for the detailed specification.
        /// </summary>
        /// <param name="vertexCount">The number of vertices to draw.</param>
        /// <param name="instanceCount">The number of instances to draw.</param>
        /// <param name="firstVertex">Offset into the vertex buffers, in vertices, to begin drawing from.</param>
        /// <param name="firstInstance">First instance to draw.</param>
        void Draw(GPUSize32 vertexCount, GPUSize32 instanceCount = 1, GPUSize32 firstVertex = 0, GPUSize32 firstInstance = 0);

        /// <summary>
        /// Draws indexed primitives. See § 23.2 Rendering for the detailed specification.
        /// </summary>
        /// <param name="indexCount">The number of indices to draw.</param>
        /// <param name="instanceCount">The number of instances to draw.</param>
        /// <param name="firstIndex">Offset into the index buffer, in indices, begin drawing from.</param>
        /// <param name="baseVertex">Added to each index value before indexing into the vertex buffers.</param>
        /// <param name="firstInstance">First instance to draw.</param>
        void DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount = 1, GPUSize32 firstIndex = 0, GPUSignedOffset32 baseVertex = 0, GPUSize32 firstInstance = 0);

        /// <summary>
        /// Draws primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification.<br/>
        /// The indirect draw parameters encoded in the buffer must be a tightly packed block of four 32-bit unsigned integer values (16 bytes total), given in the same order as the arguments for draw(). For example:
        /// </summary>
        /// <param name="indirectBuffer">Buffer containing the indirect draw parameters.</param>
        /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
        void DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset);

        /// <summary>
        /// Draws indexed primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification.<br/>
        /// The indirect drawIndexed parameters encoded in the buffer must be a tightly packed block of five 32-bit values (20 bytes total), given in the same order as the arguments for drawIndexed(). The value corresponding to baseVertex is a signed 32-bit integer, and all others are unsigned 32-bit integers. For example:
        /// </summary>
        /// <param name="indirectBuffer"></param>
        /// <param name="indirectOffset"></param>
        void DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset);
    }
}

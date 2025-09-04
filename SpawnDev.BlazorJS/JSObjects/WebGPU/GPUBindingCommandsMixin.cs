namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpubindingcommandsmixin
    /// </summary>
    public interface GPUBindingCommandsMixin
    {
        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index">The index to set the bind group at.</param>
        /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
        /// <param name="dynamicOffsets">Array containing buffer offsets in bytes for each entry in bindGroup marked as buffer.hasDynamicOffset, ordered by GPUBindGroupLayoutEntry.binding. See note for additional details.</param>
        void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsets = null);
        /// <summary>
        /// Sets the current GPUBindGroup for the given index.
        /// </summary>
        /// <param name="index">The index to set the bind group at.</param>
        /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
        /// <param name="dynamicOffsetsData">Array containing buffer offsets in bytes for each entry in bindGroup marked as buffer.hasDynamicOffset, ordered by GPUBindGroupLayoutEntry.binding. See note for additional details.</param>
        /// <param name="dynamicOffsetsDataStart">Offset in elements into dynamicOffsetsData where the buffer offset data begins.</param>
        /// <param name="dynamicOffsetsDataLength">Number of buffer offsets to read from dynamicOffsetsData.</param>
        void SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength)
    }
}

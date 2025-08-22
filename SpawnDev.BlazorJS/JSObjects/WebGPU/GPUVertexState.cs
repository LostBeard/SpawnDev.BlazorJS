namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing the vertex shader entry point of the pipeline and its input buffer layouts.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpuvertexstate
    /// </summary>
    public class GPUVertexState : GPUProgrammableStage
    {
        /// <summary>
        /// A list of GPUVertexBufferLayouts, each defining the layout of vertex attribute data in a vertex buffer used by this pipeline.
        /// A vertex buffer is, conceptually, a view into buffer memory as an array of structures. arrayStride is the stride, in bytes,
        /// between elements of that array. Each element of a vertex buffer is like a structure with a memory layout defined by its attributes,
        /// which describe the members of the structure.
        /// </summary>
        public IEnumerable<GPUVertexBufferLayout>? Buffers { get; init; }
    }
}

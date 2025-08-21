namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes a single shader resource binding to be included in the GPUBindGroupLayout
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createBindGroupLayout#entry_objects
    /// </summary>
    public class GPUEntryObject
    {
        /// <summary>
        /// A number representing a unique identifier for this particular entry, which matches the binding 
        /// value of a corresponding GPUBindGroup entry. In addition, it matches the n index value of the 
        /// corresponding @binding(n) attribute in the shader (GPUShaderModule) used in the related pipeline.
        /// </summary>
        public int Binding { get; set; }
    }
}

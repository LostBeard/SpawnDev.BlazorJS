namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUPipelineLayout interface of the WebGPU API defines the GPUBindGroupLayouts used by a pipeline. 
    /// GPUBindGroups used with the pipeline during command encoding must have compatible GPUBindGroupLayouts.
    /// </summary>
    public class GPUPipelineLayout
    {
        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label { get; set; }
    }
}

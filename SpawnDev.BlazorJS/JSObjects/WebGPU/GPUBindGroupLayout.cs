namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUBindGroupLayout interface of the WebGPU API defines the structure and purpose of related GPU resources
    /// such as buffers that will be used in a pipeline, and is used as a template when creating GPUBindGroups.
    /// </summary>
    public class GPUBindGroupLayout
    {
        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label { get; set; }
    }
}

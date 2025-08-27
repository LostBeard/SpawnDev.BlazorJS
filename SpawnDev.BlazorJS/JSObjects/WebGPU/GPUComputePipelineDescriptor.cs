namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpucomputepipelinedescriptor
    /// </summary>
    public class GPUComputePipelineDescriptor : GPUPipelineDescriptorBase
    {
        /// <summary>
        /// Describes the compute shader entry point of the pipeline.
        /// </summary>
        public GPUProgrammableStage Compute { get; set; }
    }
}

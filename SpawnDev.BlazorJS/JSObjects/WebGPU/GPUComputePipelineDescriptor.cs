using System.Text.Json.Serialization;

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
        [JsonPropertyName("compute")]
        public GPUProgrammableStage Compute { get; set; }
    }
}

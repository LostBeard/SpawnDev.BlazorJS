using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpucomputepassdescriptor
    /// </summary>
    public class GPUComputePassDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// Defines which timestamp values will be written for this pass, and where to write them to.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GPUComputePassTimestampWrites? TimestampWrites { get; set; }
    }
}

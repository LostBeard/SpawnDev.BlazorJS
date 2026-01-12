using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a fragment of data or a computational unit intended for processing on a GPU.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpufragmentstate
    /// </summary>
    public class GPUFragmentState : GPUProgrammableStage
    {
        /// <summary>
        /// An array of objects representing color states that represent configuration details for the 
        /// colors output by the fragment shader stage.
        /// </summary>
        [JsonPropertyName("targets")]
        public IEnumerable<GPUColorTargetState> Targets { get; init; }
    }
}

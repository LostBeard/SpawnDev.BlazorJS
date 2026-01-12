using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents the state of a color target in a GPU rendering pipeline, including its format.
    /// https://www.w3.org/TR/webgpu/#color-target-state
    /// </summary>
    public class GPUColorTargetState
    {
        /// <summary>
        /// Gets or sets the format string used to define the output representation.
        /// </summary>
        [JsonPropertyName("format")]
        public EnumString<GPUTextureFormat> Format { get; init; }

        /// <summary>
        /// The blending behavior for this color target. If left undefined, disables blending for this color target.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("blend")]
        public GPUBlendState? Blend { get; init; }

        /// <summary>
        /// Bitmask controlling which channels are are written to when drawing to this color target.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("writeMask")]
        public GPUColorWriteFlags? WriteMask { get; init; } = GPUColorWriteFlags.ALL;
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gputexturebindinglayout
    /// </summary>
    public class GPUTextureBindingLayout
    {
        /// <summary>
        /// Indicates the type required for texture views bound to this binding.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SampleType { get; init; }

        /// <summary>
        /// Indicates the required dimension for texture views bound to this binding.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ViewDimension { get; init; }

        /// <summary>
        /// Indicates whether or not texture views bound to this binding must be multisampled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Multisampled { get; init; }
    }
}
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpusamplerbindinglayout
    /// </summary>
    public class GPUSamplerBindingLayout
    {
        /// <summary>
        /// Indicates the required type of a sampler bound to this bindings.
        /// Options are "filtering", "non-filtering", "comparison"
        /// </summary>
        /// <remarks>Optional (spec default "filtering"): unset is OMITTED - an explicit null is an invalid enum value.</remarks>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
    }
}
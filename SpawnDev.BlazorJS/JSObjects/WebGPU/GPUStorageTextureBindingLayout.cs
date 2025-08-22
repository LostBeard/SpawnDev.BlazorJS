using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#dictdef-gpustoragetexturebindinglayout
    /// </summary>
    public class GPUStorageTextureBindingLayout
    {
        /// <summary>
        /// The required format of texture views bound to this binding.
        /// </summary>
        public string Format { get; init; }

        /// <summary>
        /// The access mode for this binding, indicating readability and writability.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Access { get; init; }

        /// <summary>
        /// Indicates the required dimension for texture views bound to this binding.
        /// Options are "1d", "2d", "2d-array", "3d", "cube" and "cube-array".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ViewDimension { get; init; }
    }
}
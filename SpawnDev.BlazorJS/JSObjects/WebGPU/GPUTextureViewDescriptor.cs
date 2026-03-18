using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Descriptor for creating a GPUTextureView.
    /// https://www.w3.org/TR/webgpu/#dictdef-gputextureviewdescriptor
    /// </summary>
    public class GPUTextureViewDescriptor : GPUObjectDescriptorBase
    {
        /// <summary>
        /// The format of the texture view. Must be either the format of the texture or one of the viewFormats specified during its creation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("format")]
        public string? Format { get; set; }

        /// <summary>
        /// The dimension to view the texture as. One of "1d", "2d", "2d-array", "cube", "cube-array", "3d".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dimension")]
        public string? Dimension { get; set; }

        /// <summary>
        /// Which aspect(s) of the texture are accessible to the texture view. One of "all", "stencil-only", "depth-only".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("aspect")]
        public string? Aspect { get; set; }

        /// <summary>
        /// The first (most detailed) mipmap level accessible to the texture view.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("baseMipLevel")]
        public int? BaseMipLevel { get; set; }

        /// <summary>
        /// How many mipmap levels, starting with baseMipLevel, are accessible to the texture view.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("mipLevelCount")]
        public int? MipLevelCount { get; set; }

        /// <summary>
        /// The index of the first array layer accessible to the texture view.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("baseArrayLayer")]
        public int? BaseArrayLayer { get; set; }

        /// <summary>
        /// How many array layers, starting with baseArrayLayer, are accessible to the texture view.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("arrayLayerCount")]
        public int? ArrayLayerCount { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing how the pipeline interacts with a render pass's multisampled attachments.
    /// https://www.w3.org/TR/webgpu/#dictdef-gpumultisamplestate
    /// </summary>
    public class GPUMultisampleState
    {
        /// <summary>
        /// Number of samples per pixel. This GPURenderPipeline will be compatible only with attachment textures
        /// (colorAttachments and depthStencilAttachment) with matching sampleCounts.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("count")]
        public GPUSize32? Count { get; init; }

        /// <summary>
        /// Mask determining which samples are written to.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("mask")]
        public GPUSampleMask? Mask { get; init; }

        /// <summary>
        /// When true indicates that a fragment’s alpha channel should be used to generate a sample coverage mask.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("alphaToCoverageEnabled")]
        public bool? AlphaToCoverageEnabled { get; init; }
    }
}

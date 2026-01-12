using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a depth-stencil state in WebGPU, which is used to configure depth and stencil testing for rendering operations.
    /// https://www.w3.org/TR/webgpu/#depth-stencil-state
    /// </summary>
    public class GPUDepthStencilState
    {
        /// <summary>
        /// An enumerated value specifying the depthStencilAttachment format that the GPURenderPipeline will be compatible with. 
        /// See the specification's Texture Formats section for all the available format values.
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; init; }

        /// <summary>
        /// GPUCompareFunction specifies the behavior of a comparison sampler. If a comparison sampler is used in a shader, 
        /// the depth_ref is compared to the fetched texel value, and the result of this comparison test is generated (1.0f for pass, or 0.0f for fail). 
        /// After comparison, if texture filtering is enabled, the filtering step occurs, so that comparison results are mixed together resulting 
        /// in values in the range [0, 1]. Filtering should behave as usual, however it may be computed with lower precision or not mix results at all.
        /// The possible values are:
        /// "never" Comparison tests never pass.
        /// "less" A provided value passes the comparison test if it is less than the sampled value.
        /// "equal" A provided value passes the comparison test if it is equal to the sampled value.
        /// "less-equal" A provided value passes the comparison test if it is less than or equal to the sampled value.
        /// "greater" A provided value passes the comparison test if it is greater than the sampled value.
        /// "not-equal" A provided value passes the comparison test if it is not equal to the sampled value.
        /// "greater-equal" A provided value passes the comparison test if it is greater than or equal to the sampled value.
        /// "always" Comparison tests always pass.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("depthCompare")]
        public string? DepthCompare { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether depth writing is enabled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("depthWriteEnabled")]
        public bool? DepthWriteEnabled { get; init; }

        /// <summary>
        /// The depth bias to use.
        /// </summary>
        [JsonPropertyName("depthBias")]
        public int DepthBias { get; init; } = 0;

        /// <summary>
        /// The depth bias slope scale.
        /// </summary>
        [JsonPropertyName("depthBiasSlopeScale")]
        public float DepthBiasSlopeScale { get; init; } = 0;

        /// <summary>
        /// The depth bias clamp.
        /// </summary>
        [JsonPropertyName("depthBiasClamp")]
        public float DepthBiasClamp { get; init; } = 0;

        /// <summary>
        /// The stencil front state.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("stencilFront")]
        public GPUStencilFaceState? StencilFront { get; init; }

        /// <summary>
        /// The stencil back state.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("stencilBack")]
        public GPUStencilFaceState? StencilBack { get; init; }

        /// <summary>
        /// The stencil read mask.
        /// </summary>
        [JsonPropertyName("stencilReadMask")]
        public uint StencilReadMask { get; init; } = 0xFFFFFFFF;

        /// <summary>
        /// The stencil write mask.
        /// </summary>
        [JsonPropertyName("stencilWriteMask")]
        public uint StencilWriteMask { get; init; } = 0xFFFFFFFF;
    }
}

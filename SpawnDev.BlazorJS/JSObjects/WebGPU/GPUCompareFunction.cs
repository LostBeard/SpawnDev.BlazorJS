using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUCompareFunction specifies the behavior of a comparison sampler. If a comparison sampler is used in a shader, the depth_ref is compared to the fetched texel value, and the result of this comparison test is generated (1.0f for pass, or 0.0f for fail).<br/>
    /// After comparison, if texture filtering is enabled, the filtering step occurs, so that comparison results are mixed together resulting in values in the range [0, 1]. Filtering should behave as usual, however it may be computed with lower precision or not mix results at all.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUCompareFunction
    {
        /// <summary>
        /// Comparison tests never pass.
        /// </summary>
        [JsonPropertyName("never")]
        Never,
        /// <summary>
        /// A provided value passes the comparison test if it is less than the sampled value.
        /// </summary>
        [JsonPropertyName("less")]
        Less,
        /// <summary>
        /// A provided value passes the comparison test if it is equal to the sampled value.
        /// </summary>
        [JsonPropertyName("equal")]
        Equal,
        /// <summary>
        /// A provided value passes the comparison test if it is less than or equal to the sampled value.
        /// </summary>
        [JsonPropertyName("less-equal")]
        LessEqual,
        /// <summary>
        /// A provided value passes the comparison test if it is greater than the sampled value.
        /// </summary>
        [JsonPropertyName("greater")]
        Greater,
        /// <summary>
        /// A provided value passes the comparison test if it is not equal to the sampled value.
        /// </summary>
        [JsonPropertyName("not-equal")]
        NotEqual,
        /// <summary>
        /// A provided value passes the comparison test if it is greater than or equal to the sampled value.
        /// </summary>
        [JsonPropertyName("greater-equal")]
        GreaterEqual,
        /// <summary>
        /// Comparison tests always pass.
        /// </summary>
        [JsonPropertyName("always")]
        Always
    }
}

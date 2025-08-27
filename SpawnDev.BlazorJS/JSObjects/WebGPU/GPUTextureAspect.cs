using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Each GPUTextureAspect value corresponds to a set of aspects. The set of aspects are defined for each value below.<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gputextureaspect
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum GPUTextureAspect
    {
        /// <summary>
        /// All available aspects of the texture format will be accessible to the texture view. For color formats the color aspect will be accessible. For combined depth-stencil formats both the depth and stencil aspects will be accessible. Depth-or-stencil formats with a single aspect will only make that aspect accessible.<br/>
        /// The set of aspects is [color, depth, stencil].
        /// </summary>
        [JsonPropertyName("all")]
        All,
        /// <summary>
        /// Only the stencil aspect of a depth-or-stencil format format will be accessible to the texture view.<br/>
        /// The set of aspects is [stencil].
        /// </summary>
        [JsonPropertyName("stencil-only")]
        StencilOnly,
        /// <summary>
        /// Only the depth aspect of a depth-or-stencil format format will be accessible to the texture view.<br/>
        /// The set of aspects is [depth].
        /// </summary>
        [JsonPropertyName("depth-only")]
        DepthOnly
    }
}

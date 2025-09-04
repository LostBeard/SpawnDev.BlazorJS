using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpumipmapfiltermode
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUMipmapFilterMode
    {
        /// <summary>
        /// Return the value of the texel nearest to the texture coordinates.
        /// </summary>
        [JsonPropertyName("nearest")]
        Nearest,
        /// <summary>
        /// Select two texels in each dimension and return a linear interpolation between their values.
        /// </summary>
        [JsonPropertyName("linear")]
        Linear,
    }
}

using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpucullmode
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUCullMode
    {
        /// <summary>
        /// No polygons are discarded.
        /// </summary>
        [JsonPropertyName("none")]
        None,
        /// <summary>
        /// Front-facing polygons are discarded.
        /// </summary>
        [JsonPropertyName("front")]
        Front,
        /// <summary>
        /// Back-facing polygons are discarded.
        /// </summary>
        [JsonPropertyName("back")]
        Back,
    }
}

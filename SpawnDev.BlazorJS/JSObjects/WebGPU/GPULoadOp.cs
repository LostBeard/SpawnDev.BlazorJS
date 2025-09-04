using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuloadop
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPULoadOp
    {
        /// <summary>
        /// Load
        /// </summary>
        [JsonPropertyName("load")]
        Load,
        /// <summary>
        /// Clear
        /// </summary>
        [JsonPropertyName("clear")]
        Clear,
    }
}

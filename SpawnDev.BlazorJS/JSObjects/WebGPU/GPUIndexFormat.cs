using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuindexformat
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUIndexFormat
    {
        /// <summary>
        /// Uint16
        /// </summary>
        [JsonPropertyName("uint16")]
        Uint16,
        /// <summary>
        /// Uint32
        /// </summary>
        [JsonPropertyName("uint32")]
        Uint32,
    }
}

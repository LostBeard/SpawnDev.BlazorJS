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

    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpustoreop
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUStoreOp
    {
        /// <summary>
        /// Load
        /// </summary>
        [JsonPropertyName("store")]
        Store,
        /// <summary>
        /// Clear
        /// </summary>
        [JsonPropertyName("discard")]
        Discard,
    }
}

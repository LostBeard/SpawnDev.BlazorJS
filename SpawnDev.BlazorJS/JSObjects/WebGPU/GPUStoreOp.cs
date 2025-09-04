using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
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

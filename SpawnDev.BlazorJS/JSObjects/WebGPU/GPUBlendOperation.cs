using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUBlendOperation defines the algorithm used to combine source and destination blend factors:<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpublendoperation
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum GPUBlendOperation
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("add")]
        Add,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("subtract")]
        Subtract,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("reverse-subtract")]
        ReverseSubtract,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("min")]
        Min,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("max")]
        Max,
    }
}

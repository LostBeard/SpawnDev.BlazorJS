using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpustenciloperation
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GPUStencilOperation
    {
        [JsonPropertyName("keep")]
        Keep,
        [JsonPropertyName("zero")]
        Zero,
        [JsonPropertyName("replace")]
        Replace,
        [JsonPropertyName("invert")]
        Invert,
        [JsonPropertyName("increment-clamp")]
        IncrementClamp,
        [JsonPropertyName("decrement-clamp")]
        DecrementClamp,
        [JsonPropertyName("increment-wrap")]
        IncrementWrap,
        [JsonPropertyName("decrement-wrap")]
        DecrementWrap,
    }
}

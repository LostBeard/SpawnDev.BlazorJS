using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuaddressmode
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUAddressMode
    {
        /// <summary>
        /// Texture coordinates are clamped between 0.0 and 1.0, inclusive.
        /// </summary>
        [JsonPropertyName("clamp-to-edge")]
        ClampToEdge,
        /// <summary>
        /// Texture coordinates wrap to the other side of the texture.
        /// </summary>
        [JsonPropertyName("repeat")]
        Repeat,
        /// <summary>
        /// Texture coordinates wrap to the other side of the texture, but the texture is flipped when the integer part of the coordinate is odd.
        /// </summary>
        [JsonPropertyName("mirror-repeat")]
        MirrorRepeat,
    }
}

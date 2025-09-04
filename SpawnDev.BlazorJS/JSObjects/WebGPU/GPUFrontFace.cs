using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUFrontFace defines which polygons are considered front-facing by a GPURenderPipeline. See § 23.2.5.4 Polygon Rasterization for additional details:<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpufrontface
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUFrontFace
    {
        /// <summary>
        /// Polygons with vertices whose framebuffer coordinates are given in counter-clockwise order are considered front-facing.
        /// </summary>
        [JsonPropertyName("ccw")]
        CCW,
        /// <summary>
        /// Polygons with vertices whose framebuffer coordinates are given in clockwise order are considered front-facing.
        /// </summary>
        [JsonPropertyName("cw")]
        CW,
    }
}

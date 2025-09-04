using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUPrimitiveTopology defines the primitive type draw calls made with a GPURenderPipeline will use. See § 23.2.5 Rasterization for additional details:
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuprimitivetopology
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUPrimitiveTopology
    {
        /// <summary>
        /// Each vertex defines a point primitive.
        /// </summary>
        [JsonPropertyName("point-list")]
        PointList,
        /// <summary>
        /// Each consecutive pair of two vertices defines a line primitive.
        /// </summary>
        [JsonPropertyName("line-list")]
        LineList,
        /// <summary>
        /// Each vertex after the first defines a line primitive between it and the previous vertex.
        /// </summary>
        [JsonPropertyName("line-strip")]
        LineStrip,
        /// <summary>
        /// Each consecutive triplet of three vertices defines a triangle primitive.
        /// </summary>
        [JsonPropertyName("triangle-list")]
        TriangleList,
        /// <summary>
        /// Each vertex after the first two defines a triangle primitive between it and the previous two vertices.
        /// </summary>
        [JsonPropertyName("triangle-strip")]
        TriangleStrip,
    };
}

using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpuvertexformat
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUVertexFormat
    {
        /// <summary>
        /// unsigned int	1	1	u32
        /// </summary>
        [JsonPropertyName("uint8")]
        UInt8,
        /// <summary>
        /// unsigned int	2	2	vec2&lt;u32>
        /// </summary>
        [JsonPropertyName("uint8x2")]
        UInt8x2,
        /// <summary>
        /// unsigned int	4	4	vec4&lt;u32>
        /// </summary>
        [JsonPropertyName("uint8x4")]
        UInt8x4,
        /// <summary>
        /// signed int	1	1	i32
        /// </summary>
        [JsonPropertyName("sint8")]
        SInt8,
        /// <summary>
        /// signed int	2	2	vec2&lt;i32>
        /// </summary>
        [JsonPropertyName("sint8x2")]
        SInt8x2,
        /// <summary>
        /// signed int	4	4	vec4&lt;i32>
        /// </summary>
        [JsonPropertyName("sint8x4")]
        SInt8x4,
        /// <summary>
        /// unsigned normalized	1	1	f32
        /// </summary>
        [JsonPropertyName("unorm8")]
        UNorm8,
        /// <summary>
        /// unsigned normalized	2	2	vec2&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm8x2")]
        UNorm8x2,
        /// <summary>
        /// unsigned normalized	4	4	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm8x4")]
        UNorm8x4,
        /// <summary>
        /// signed normalized	1	1	f32
        /// </summary>
        [JsonPropertyName("snorm8")]
        SNorm8,
        /// <summary>
        /// signed normalized	2	2	vec2&lt;f32>
        /// </summary>
        [JsonPropertyName("snorm8x2")]
        SNorm8x2,
        /// <summary>
        /// signed normalized	4	4	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("snorm8x4")]
        SNorm8x4,
        /// <summary>
        /// unsigned int	1	2	u32
        /// </summary>
        [JsonPropertyName("uint16")]
        UInt16,
        /// <summary>
        /// unsigned int	2	4	vec2&lt;u32>
        /// </summary>
        [JsonPropertyName("uint16x2")]
        UInt16x2,
        /// <summary>
        /// unsigned int	4	8	vec4&lt;u32>
        /// </summary>
        [JsonPropertyName("uint16x4")]
        nt16x4,
        /// <summary>
        /// signed int	1	2	i32
        /// </summary>
        [JsonPropertyName("sint16")]
        SInt16,
        /// <summary>
        /// signed int	2	4	vec2&lt;i32>
        /// </summary>
        [JsonPropertyName("sint16x2")]
        SInt16x2,
        /// <summary>
        /// signed int	4	8	vec4&lt;i32>
        /// </summary>
        [JsonPropertyName("sint16x4")]
        SInt16x4,
        /// <summary>
        /// unsigned normalized	1	2	f32
        /// </summary>
        [JsonPropertyName("unorm16")]
        UNorm16,
        /// <summary>
        /// unsigned normalized	2	4	vec2&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm16x2")]
        UNorm16x2,
        /// <summary>
        /// unsigned normalized	4	8	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm16x4")]
        UNorm16x4,
        /// <summary>
        /// signed normalized	1	2	f32
        /// </summary>
        [JsonPropertyName("snorm16")]
        SNorm16,
        /// <summary>
        /// signed normalized	2	4	vec2&lt;f32>
        /// </summary>
        [JsonPropertyName("snorm16x2")]
        SNorm16x2,
        /// <summary>
        /// signed normalized	4	8	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("snorm16x4")]
        SNorm16x4,
        /// <summary>
        /// float	1	2	f32
        /// </summary>
        [JsonPropertyName("float16")]
        Float16,
        /// <summary>
        /// float	2	4	vec2&lt;f16>
        /// </summary>
        [JsonPropertyName("float16x2")]
        Float16x2,
        /// <summary>
        /// float	4	8	vec4&lt;f16>
        /// </summary>
        [JsonPropertyName("float16x4")]
        Float16x4,
        /// <summary>
        /// float	1	4	f32
        /// </summary>
        [JsonPropertyName("float32")]
        Float32,
        /// <summary>
        /// float	2	8	vec2&lt;f32>
        /// </summary>
        [JsonPropertyName("float32x2")]
        Float32x2,
        /// <summary>
        /// float	3	12	vec3&lt;f32>
        /// </summary>
        [JsonPropertyName("float32x3")]
        Float32x3,
        /// <summary>
        /// float	4	16	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("float32x4")]
        Float32x4,
        /// <summary>
        /// unsigned int	1	4	u32
        /// </summary>
        [JsonPropertyName("uint32")]
        UInt32,
        /// <summary>
        /// unsigned int	2	8	vec2&lt;u32>
        /// </summary>
        [JsonPropertyName("uint32x2")]
        UInt32x2,
        /// <summary>
        /// unsigned int	3	12	vec3&lt;u32>
        /// </summary>
        [JsonPropertyName("uint32x3")]
        UInt32x3,
        /// <summary>
        /// unsigned int	4	16	vec4&lt;u32>
        /// </summary>
        [JsonPropertyName("uint32x4")]
        UInt32x4,
        /// <summary>
        /// signed int	1	4	i32
        /// </summary>
        [JsonPropertyName("sint32")]
        SInt32,
        /// <summary>
        /// signed int	2	8	vec2&lt;i32>
        /// </summary>
        [JsonPropertyName("sint32x2")]
        SInt32x2,
        /// <summary>
        /// signed int	3	12	vec3&lt;i32>
        /// </summary>
        [JsonPropertyName("sint32x3")]
        SInt32x3,
        /// <summary>
        /// signed int	4	16	vec4&lt;i32>
        /// </summary>
        [JsonPropertyName("sint32x4")]
        SInt32x4,
        /// <summary>
        /// unsigned normalized	4	4	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm10-10-10-2")]
        UNorm10_10_10_2,
        /// <summary>
        /// unsigned normalized	4	4	vec4&lt;f32>
        /// </summary>
        [JsonPropertyName("unorm8x4-bgra")]
        UNorm8x4BGRA,
    }
}

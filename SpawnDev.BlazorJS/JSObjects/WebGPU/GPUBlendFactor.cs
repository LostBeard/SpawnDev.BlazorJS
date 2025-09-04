using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// GPUBlendFactor defines how either a source or destination blend factors is calculated:<br/>
    /// https://www.w3.org/TR/webgpu/#enumdef-gpublendfactor
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum GPUBlendFactor
    {
        /// <summary>
        /// (0, 0, 0, 0)
        /// </summary>
        [JsonPropertyName("zero")]
        Zero,
        /// <summary>
        /// (1, 1, 1, 1)
        /// </summary>
        [JsonPropertyName("one")]
        One,
        /// <summary>
        /// (Rsrc, Gsrc, Bsrc, Asrc)
        /// </summary>
        [JsonPropertyName("src")]
        Src,
        /// <summary>
        /// (1 - Rsrc, 1 - Gsrc, 1 - Bsrc, 1 - Asrc)
        /// </summary>
        [JsonPropertyName("one-minus-src")]
        OneMinusSrc,
        /// <summary>
        /// (Asrc, Asrc, Asrc, Asrc)
        /// </summary>
        [JsonPropertyName("src-alpha")]
        SrcAlpha,
        /// <summary>
        /// (1 - Asrc, 1 - Asrc, 1 - Asrc, 1 - Asrc)
        /// </summary>
        [JsonPropertyName("one-minus-src-alpha")]
        OneMinusSrcAlpha,
        /// <summary>
        /// (Rdst, Gdst, Bdst, Adst)
        /// </summary>
        [JsonPropertyName("dst")]
        Dst,
        /// <summary>
        /// (1 - Rdst, 1 - Gdst, 1 - Bdst, 1 - Adst)
        /// </summary>
        [JsonPropertyName("one-minus-dst")]
        OneMinusDst,
        /// <summary>
        /// (Adst, Adst, Adst, Adst)
        /// </summary>
        [JsonPropertyName("dst-alpha")]
        DstAlpha,
        /// <summary>
        /// (1 - Adst, 1 - Adst, 1 - Adst, 1 - Adst)
        /// </summary>
        [JsonPropertyName("one-minus-dst-alpha")]
        OneMinusDstAlpha,
        /// <summary>
        /// (min(Asrc, 1 - Adst), min(Asrc, 1 - Adst), min(Asrc, 1 - Adst), 1)
        /// </summary>
        [JsonPropertyName("src-alpha-saturated")]
        SrcAlphaSaturated,
        /// <summary>
        /// (Rconst, Gconst, Bconst, Aconst)
        /// </summary>
        [JsonPropertyName("constant")]
        Constant,
        /// <summary>
        /// (1 - Rconst, 1 - Gconst, 1 - Bconst, 1 - Aconst)
        /// </summary>
        [JsonPropertyName("one-minus-constant")]
        OneMinusConstant,
        /// <summary>
        /// (Rsrc1, Gsrc1, Bsrc1, Asrc1)
        /// </summary>
        [JsonPropertyName("src1")]
        Src1,
        /// <summary>
        /// (1 - Rsrc1, 1 - Gsrc1, 1 - Bsrc1, 1 - Asrc1)
        /// </summary>
        [JsonPropertyName("one-minus-src1")]
        OneMinusSrc1,
        /// <summary>
        /// (Asrc1, Asrc1, Asrc1, Asrc1)
        /// </summary>
        [JsonPropertyName("src1-alpha")]
        Src1Alpha,
        /// <summary>
        /// (1 - Asrc1, 1 - Asrc1, 1 - Asrc1, 1 - Asrc1)
        /// </summary>
        [JsonPropertyName("one-minus-src1-alpha")]
        OneMinusSrc1Alpha,
    }
}

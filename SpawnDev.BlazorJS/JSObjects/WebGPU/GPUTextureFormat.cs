using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUTextureFormat
    {
        // 8-bit formats
        /// <summary>
        /// r8unorm
        /// </summary>
        [JsonPropertyName("r8unorm")]
        r8unorm,
        /// <summary>
        /// r8snorm
        /// </summary>
        [JsonPropertyName("r8snorm")]
        r8snorm,
        /// <summary>
        /// r8uint
        /// </summary>
        [JsonPropertyName("r8uint")]
        r8uint,
        /// <summary>
        /// r8sint
        /// </summary>
        [JsonPropertyName("r8sint")]
        r8sint,

        // 16-bit formats
        /// <summary>
        /// r16unorm
        /// </summary>
        [JsonPropertyName("r16unorm")]
        r16unorm,
        /// <summary>
        /// r16snorm
        /// </summary>
        [JsonPropertyName("r16snorm")]
        r16snorm,
        /// <summary>
        /// r16uint
        /// </summary>
        [JsonPropertyName("r16uint")]
        r16uint,
        /// <summary>
        /// r16sint
        /// </summary>
        [JsonPropertyName("r16sint")]
        r16sint,
        /// <summary>
        /// r16float
        /// </summary>
        [JsonPropertyName("r16float")]
        r16float,
        /// <summary>
        /// rg8unorm
        /// </summary>
        [JsonPropertyName("rg8unorm")]
        rg8unorm,
        /// <summary>
        /// rg8snorm
        /// </summary>
        [JsonPropertyName("rg8snorm")]
        rg8snorm,
        /// <summary>
        /// rg8uint
        /// </summary>
        [JsonPropertyName("rg8uint")]
        rg8uint,
        /// <summary>
        /// rg8sint
        /// </summary>
        [JsonPropertyName("rg8sint")]
        rg8sint,

        // 32-bit formats
        /// <summary>
        /// r32uint
        /// </summary>
        [JsonPropertyName("r32uint")]
        r32uint,
        /// <summary>
        /// r32sint
        /// </summary>
        [JsonPropertyName("r32sint")]
        r32sint,
        /// <summary>
        /// r32float
        /// </summary>
        [JsonPropertyName("r32float")]
        r32float,
        /// <summary>
        /// rg16unorm
        /// </summary>
        [JsonPropertyName("rg16unorm")]
        rg16unorm,
        /// <summary>
        /// rg16snorm
        /// </summary>
        [JsonPropertyName("rg16snorm")]
        rg16snorm,
        /// <summary>
        /// rg16uint
        /// </summary>
        [JsonPropertyName("rg16uint")]
        rg16uint,
        /// <summary>
        /// rg16sint
        /// </summary>
        [JsonPropertyName("rg16sint")]
        rg16sint,
        /// <summary>
        /// rg16float
        /// </summary>
        [JsonPropertyName("rg16float")]
        rg16float,
        /// <summary>
        /// rgba8unorm
        /// </summary>
        [JsonPropertyName("rgba8unorm")]
        rgba8unorm,
        /// <summary>
        /// rgba8unorm_srgb
        /// </summary>
        [JsonPropertyName("rgba8unorm-srgb")]
        rgba8unorm_srgb,
        /// <summary>
        /// rgba8snorm
        /// </summary>
        [JsonPropertyName("rgba8snorm")]
        rgba8snorm,
        /// <summary>
        /// rgba8uint
        /// </summary>
        [JsonPropertyName("rgba8uint")]
        rgba8uint,
        /// <summary>
        /// rgba8sint
        /// </summary>
        [JsonPropertyName("rgba8sint")]
        rgba8sint,
        /// <summary>
        /// bgra8unorm
        /// </summary>
        [JsonPropertyName("bgra8unorm")]
        bgra8unorm,
        /// <summary>
        /// bgra8unorm_srgb
        /// </summary>
        [JsonPropertyName("bgra8unorm-srgb")]
        bgra8unorm_srgb,
        // Packed 32-bit formats
        /// <summary>
        /// rgb9e5ufloat
        /// </summary>
        [JsonPropertyName("rgb9e5ufloat")]
        rgb9e5ufloat,
        /// <summary>
        /// rgb10a2uint
        /// </summary>
        [JsonPropertyName("rgb10a2uint")]
        rgb10a2uint,
        /// <summary>
        /// rgb10a2unorm
        /// </summary>
        [JsonPropertyName("rgb10a2unorm")]
        rgb10a2unorm,
        /// <summary>
        /// rg11b10ufloat
        /// </summary>
        [JsonPropertyName("rg11b10ufloat")]
        rg11b10ufloat,

        // 64-bit formats
        /// <summary>
        /// rg32uint
        /// </summary>
        [JsonPropertyName("rg32uint")]
        rg32uint,
        /// <summary>
        /// rg32sint
        /// </summary>
        [JsonPropertyName("rg32sint")]
        rg32sint,
        /// <summary>
        /// rg32float
        /// </summary>
        [JsonPropertyName("rg32float")]
        rg32float,
        /// <summary>
        /// rgba16unorm
        /// </summary>
        [JsonPropertyName("rgba16unorm")]
        rgba16unorm,
        /// <summary>
        /// rgba16snorm
        /// </summary>
        [JsonPropertyName("rgba16snorm")]
        rgba16snorm,
        /// <summary>
        /// rgba16uint
        /// </summary>
        [JsonPropertyName("rgba16uint")]
        rgba16uint,
        /// <summary>
        /// rgba16sint
        /// </summary>
        [JsonPropertyName("rgba16sint")]
        rgba16sint,
        /// <summary>
        /// rgba16float
        /// </summary>
        [JsonPropertyName("rgba16float")]
        rgba16float,

        // 128-bit formats
        /// <summary>
        /// rgba32uint
        /// </summary>
        [JsonPropertyName("rgba32uint")]
        rgba32uint,
        /// <summary>
        /// rgba32sint
        /// </summary>
        [JsonPropertyName("rgba32sint")]
        rgba32sint,
        /// <summary>
        /// rgba32float
        /// </summary>
        [JsonPropertyName("rgba32float")]
        rgba32float,

        // Depth/stencil formats
        /// <summary>
        /// stencil8
        /// </summary>
        [JsonPropertyName("stencil8")]
        stencil8,
        /// <summary>
        /// depth16unorm
        /// </summary>
        [JsonPropertyName("depth16unorm")]
        depth16unorm,
        /// <summary>
        /// depth24plus
        /// </summary>
        [JsonPropertyName("depth24plus")]
        depth24plus,
        /// <summary>
        /// depth24plus_stencil8
        /// </summary>
        [JsonPropertyName("depth24plus-stencil8")]
        depth24plus_stencil8,
        /// <summary>
        /// depth32float
        /// </summary>
        [JsonPropertyName("depth32float")]
        depth32float,

        // "depth32float-stencil8" feature
        /// <summary>
        /// depth32float_stencil8
        /// </summary>
        [JsonPropertyName("depth32float-stencil8")]
        depth32float_stencil8,

        // BC compressed formats usable if "texture-compression-bc" is both
        // supported by the device/user agent and enabled in requestDevice.
        /// <summary>
        /// bc1_rgba_unorm
        /// </summary>
        [JsonPropertyName("bc1-rgba-unorm")]
        bc1_rgba_unorm,
        /// <summary>
        /// bc1_rgba_unorm_srgb
        /// </summary>
        [JsonPropertyName("bc1-rgba-unorm-srgb")]
        bc1_rgba_unorm_srgb,
        /// <summary>
        /// bc2_rgba_unorm
        /// </summary>
        [JsonPropertyName("bc2-rgba-unorm")]
        bc2_rgba_unorm,
        /// <summary>
        /// bc2_rgba_unorm_srgb
        /// </summary>
        [JsonPropertyName("bc2-rgba-unorm-srgb")]
        bc2_rgba_unorm_srgb,
        /// <summary>
        /// bc3_rgba_unorm
        /// </summary>
        [JsonPropertyName("bc3-rgba-unorm")]
        bc3_rgba_unorm,
        /// <summary>
        /// bc3_rgba_unorm_srgb
        /// </summary>
        [JsonPropertyName("bc3-rgba-unorm-srgb")]
        bc3_rgba_unorm_srgb,
        /// <summary>
        /// bc4_r_unorm
        /// </summary>
        [JsonPropertyName("bc4-r-unorm")]
        bc4_r_unorm,
        /// <summary>
        /// bc4_r_snorm
        /// </summary>
        [JsonPropertyName("bc4-r-snorm")]
        bc4_r_snorm,
        /// <summary>
        /// bc5_rg_unorm
        /// </summary>
        [JsonPropertyName("bc5-rg-unorm")]
        bc5_rg_unorm,
        /// <summary>
        /// bc5_rg_snorm
        /// </summary>
        [JsonPropertyName("bc5-rg-snorm")]
        bc5_rg_snorm,
        /// <summary>
        /// bc6h_rgb_ufloat
        /// </summary>
        [JsonPropertyName("bc6h-rgb-ufloat")]
        bc6h_rgb_ufloat,
        /// <summary>
        /// bc6h_rgb_float
        /// </summary>
        [JsonPropertyName("bc6h-rgb-float")]
        bc6h_rgb_float,
        /// <summary>
        /// bc7_rgba_unorm
        /// </summary>
        [JsonPropertyName("bc7-rgba-unorm")]
        bc7_rgba_unorm,
        /// <summary>
        /// bc7_rgba_unorm_srgb
        /// </summary>
        [JsonPropertyName("bc7-rgba-unorm-srgb")]
        bc7_rgba_unorm_srgb,

        // ETC2 compressed formats usable if "texture-compression-etc2" is both
        // supported by the device/user agent and enabled in requestDevice.
        /// <summary>
        /// etc2_rgb8unorm
        /// </summary>
        [JsonPropertyName("etc2-rgb8unorm")]
        etc2_rgb8unorm,
        /// <summary>
        /// etc2_rgb8unorm_srgb
        /// </summary>
        [JsonPropertyName("etc2-rgb8unorm-srgb")]
        etc2_rgb8unorm_srgb,
        /// <summary>
        /// etc2_rgb8a1unorm
        /// </summary>
        [JsonPropertyName("etc2-rgb8a1unorm")]
        etc2_rgb8a1unorm,
        /// <summary>
        /// etc2_rgb8a1unorm_srgb
        /// </summary>
        [JsonPropertyName("etc2-rgb8a1unorm-srgb")]
        etc2_rgb8a1unorm_srgb,
        /// <summary>
        /// etc2_rgba8unorm
        /// </summary>
        [JsonPropertyName("etc2-rgba8unorm")]
        etc2_rgba8unorm,
        /// <summary>
        /// etc2_rgba8unorm_srgb
        /// </summary>
        [JsonPropertyName("etc2-rgba8unorm-srgb")]
        etc2_rgba8unorm_srgb,
        /// <summary>
        /// eac_r11unorm
        /// </summary>
        [JsonPropertyName("eac-r11unorm")]
        eac_r11unorm,
        /// <summary>
        /// eac_r11snorm
        /// </summary>
        [JsonPropertyName("eac-r11snorm")]
        eac_r11snorm,
        /// <summary>
        /// eac_rg11unorm
        /// </summary>
        [JsonPropertyName("eac-rg11unorm")]
        eac_rg11unorm,
        /// <summary>
        /// eac_rg11snorm
        /// </summary>
        [JsonPropertyName("eac-rg11snorm")]
        eac_rg11snorm,

        // ASTC compressed formats usable if "texture-compression-astc" is both
        // supported by the device/user agent and enabled in requestDevice.
        /// <summary>
        /// astc_4x4_unorm
        /// </summary>
        [JsonPropertyName("astc-4x4-unorm")]
        astc_4x4_unorm,
        /// <summary>
        /// astc_4x4_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-4x4-unorm-srgb")]
        astc_4x4_unorm_srgb,
        /// <summary>
        /// astc_5x4_unorm
        /// </summary>
        [JsonPropertyName("astc-5x4-unorm")]
        astc_5x4_unorm,
        /// <summary>
        /// astc_5x4_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-5x4-unorm-srgb")]
        astc_5x4_unorm_srgb,
        /// <summary>
        /// astc_5x5_unorm
        /// </summary>
        [JsonPropertyName("astc-5x5-unorm")]
        astc_5x5_unorm,
        /// <summary>
        /// astc_5x5_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-5x5-unorm-srgb")]
        astc_5x5_unorm_srgb,
        /// <summary>
        /// astc_6x5_unorm
        /// </summary>
        [JsonPropertyName("astc-6x5-unorm")]
        astc_6x5_unorm,
        /// <summary>
        /// astc_6x5_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-6x5-unorm-srgb")]
        astc_6x5_unorm_srgb,
        /// <summary>
        /// astc_6x6_unorm
        /// </summary>
        [JsonPropertyName("astc-6x6-unorm")]
        astc_6x6_unorm,
        /// <summary>
        /// astc_6x6_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-6x6-unorm-srgb")]
        astc_6x6_unorm_srgb,
        /// <summary>
        /// astc_8x5_unorm
        /// </summary>
        [JsonPropertyName("astc-8x5-unorm")]
        astc_8x5_unorm,
        /// <summary>
        /// astc_8x5_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-8x5-unorm-srgb")]
        astc_8x5_unorm_srgb,
        /// <summary>
        /// astc_8x6_unorm
        /// </summary>
        [JsonPropertyName("astc-8x6-unorm")]
        astc_8x6_unorm,
        /// <summary>
        /// astc_8x6_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-8x6-unorm-srgb")]
        astc_8x6_unorm_srgb,
        /// <summary>
        /// astc_8x8_unorm
        /// </summary>
        [JsonPropertyName("astc-8x8-unorm")]
        astc_8x8_unorm,
        /// <summary>
        /// astc_8x8_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-8x8-unorm-srgb")]
        astc_8x8_unorm_srgb,
        /// <summary>
        /// astc_10x5_unorm
        /// </summary>
        [JsonPropertyName("astc-10x5-unorm")]
        astc_10x5_unorm,
        /// <summary>
        /// astc_10x5_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-10x5-unorm-srgb")]
        astc_10x5_unorm_srgb,
        /// <summary>
        /// astc_10x6_unorm
        /// </summary>
        [JsonPropertyName("astc-10x6-unorm")]
        astc_10x6_unorm,
        /// <summary>
        /// astc_10x6_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-10x6-unorm-srgb")]
        astc_10x6_unorm_srgb,
        /// <summary>
        /// astc_10x8_unorm
        /// </summary>
        [JsonPropertyName("astc-10x8-unorm")]
        astc_10x8_unorm,
        /// <summary>
        /// astc_10x8_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-10x8-unorm-srgb")]
        astc_10x8_unorm_srgb,
        /// <summary>
        /// astc_10x10_unorm
        /// </summary>
        [JsonPropertyName("astc-10x10-unorm")]
        astc_10x10_unorm,
        /// <summary>
        /// astc_10x10_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-10x10-unorm-srgb")]
        astc_10x10_unorm_srgb,
        /// <summary>
        /// astc_12x10_unorm
        /// </summary>
        [JsonPropertyName("astc-12x10-unorm")]
        astc_12x10_unorm,
        /// <summary>
        /// astc_12x10_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-12x10-unorm-srgb")]
        astc_12x10_unorm_srgb,
        /// <summary>
        /// astc_12x12_unorm
        /// </summary>
        [JsonPropertyName("astc-12x12-unorm")]
        astc_12x12_unorm,
        /// <summary>
        /// astc_12x12_unorm_srgb
        /// </summary>
        [JsonPropertyName("astc-12x12-unorm-srgb")]
        astc_12x12_unorm_srgb,
    }
}

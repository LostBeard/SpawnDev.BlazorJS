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
        [JsonPropertyName("r8unorm")]
        r8unorm,
        [JsonPropertyName("r8snorm")]
        r8snorm,
        [JsonPropertyName("r8uint")]
        r8uint,
        [JsonPropertyName("r8sint")]
        r8sint,

        // 16-bit formats
        [JsonPropertyName("r16unorm")]
        r16unorm,
        [JsonPropertyName("r16snorm")]
        r16snorm,
        [JsonPropertyName("r16uint")]
        r16uint,
        [JsonPropertyName("r16sint")]
        r16sint,
        [JsonPropertyName("r16float")]
        r16float,
        [JsonPropertyName("rg8unorm")]
        rg8unorm,
        [JsonPropertyName("rg8snorm")]
        rg8snorm,
        [JsonPropertyName("rg8uint")]
        rg8uint,
        [JsonPropertyName("rg8sint")]
        rg8sint,

        // 32-bit formats
        [JsonPropertyName("r32uint")]
        r32uint,
        [JsonPropertyName("r32sint")]
        r32sint,
        [JsonPropertyName("r32float")]
        r32float,
        [JsonPropertyName("rg16unorm")]
        rg16unorm,
        [JsonPropertyName("rg16snorm")]
        rg16snorm,
        [JsonPropertyName("rg16uint")]
        rg16uint,
        [JsonPropertyName("rg16sint")]
        rg16sint,
        [JsonPropertyName("rg16float")]
        rg16float,
        [JsonPropertyName("rgba8unorm")]
        rgba8unorm,
        [JsonPropertyName("rgba8unorm-srgb")]
        rgba8unorm_srgb,
        [JsonPropertyName("rgba8snorm")]
        rgba8snorm,
        [JsonPropertyName("rgba8uint")]
        rgba8uint,
        [JsonPropertyName("rgba8sint")]
        rgba8sint,
        [JsonPropertyName("bgra8unorm")]
        bgra8unorm,
        [JsonPropertyName("bgra8unorm-srgb")]
        bgra8unorm_srgb,
        // Packed 32-bit formats
        [JsonPropertyName("rgb9e5ufloat")]
        rgb9e5ufloat,
        [JsonPropertyName("rgb10a2uint")]
        rgb10a2uint,
        [JsonPropertyName("rgb10a2unorm")]
        rgb10a2unorm,
        [JsonPropertyName("rg11b10ufloat")]
        rg11b10ufloat,

        // 64-bit formats
        [JsonPropertyName("rg32uint")]
        rg32uint,
        [JsonPropertyName("rg32sint")]
        rg32sint,
        [JsonPropertyName("rg32float")]
        rg32float,
        [JsonPropertyName("rgba16unorm")]
        rgba16unorm,
        [JsonPropertyName("rgba16snorm")]
        rgba16snorm,
        [JsonPropertyName("rgba16uint")]
        rgba16uint,
        [JsonPropertyName("rgba16sint")]
        rgba16sint,
        [JsonPropertyName("rgba16float")]
        rgba16float,

        // 128-bit formats
        [JsonPropertyName("rgba32uint")]
        rgba32uint,
        [JsonPropertyName("rgba32sint")]
        rgba32sint,
        [JsonPropertyName("rgba32float")]
        rgba32float,

        // Depth/stencil formats
        [JsonPropertyName("stencil8")]
        stencil8,
        [JsonPropertyName("depth16unorm")]
        depth16unorm,
        [JsonPropertyName("depth24plus")]
        depth24plus,
        [JsonPropertyName("depth24plus-stencil8")]
        depth24plus_stencil8,
        [JsonPropertyName("depth32float")]
        depth32float,

        // "depth32float-stencil8" feature
        [JsonPropertyName("depth32float-stencil8")]
        depth32float_stencil8,

        // BC compressed formats usable if "texture-compression-bc" is both
        // supported by the device/user agent and enabled in requestDevice.
        [JsonPropertyName("bc1-rgba-unorm")]
        bc1_rgba_unorm,
        [JsonPropertyName("bc1-rgba-unorm-srgb")]
        bc1_rgba_unorm_srgb,
        [JsonPropertyName("bc2-rgba-unorm")]
        bc2_rgba_unorm,
        [JsonPropertyName("bc2-rgba-unorm-srgb")]
        bc2_rgba_unorm_srgb,
        [JsonPropertyName("bc3-rgba-unorm")]
        bc3_rgba_unorm,
        [JsonPropertyName("bc3-rgba-unorm-srgb")]
        bc3_rgba_unorm_srgb,
        [JsonPropertyName("bc4-r-unorm")]
        bc4_r_unorm,
        [JsonPropertyName("bc4-r-snorm")]
        bc4_r_snorm,
        [JsonPropertyName("bc5-rg-unorm")]
        bc5_rg_unorm,
        [JsonPropertyName("bc5-rg-snorm")]
        bc5_rg_snorm,
        [JsonPropertyName("bc6h-rgb-ufloat")]
        bc6h_rgb_ufloat,
        [JsonPropertyName("bc6h-rgb-float")]
        bc6h_rgb_float,
        [JsonPropertyName("bc7-rgba-unorm")]
        bc7_rgba_unorm,
        [JsonPropertyName("bc7-rgba-unorm-srgb")]
        bc7_rgba_unorm_srgb,

        // ETC2 compressed formats usable if "texture-compression-etc2" is both
        // supported by the device/user agent and enabled in requestDevice.
        [JsonPropertyName("etc2-rgb8unorm")]
        etc2_rgb8unorm,
        [JsonPropertyName("etc2-rgb8unorm-srgb")]
        etc2_rgb8unorm_srgb,
        [JsonPropertyName("etc2-rgb8a1unorm")]
        etc2_rgb8a1unorm,
        [JsonPropertyName("etc2-rgb8a1unorm-srgb")]
        etc2_rgb8a1unorm_srgb,
        [JsonPropertyName("etc2-rgba8unorm")]
        etc2_rgba8unorm,
        [JsonPropertyName("etc2-rgba8unorm-srgb")]
        etc2_rgba8unorm_srgb,
        [JsonPropertyName("eac-r11unorm")]
        eac_r11unorm,
        [JsonPropertyName("eac-r11snorm")]
        eac_r11snorm,
        [JsonPropertyName("eac-rg11unorm")]
        eac_rg11unorm,
        [JsonPropertyName("eac-rg11snorm")]
        eac_rg11snorm,

        // ASTC compressed formats usable if "texture-compression-astc" is both
        // supported by the device/user agent and enabled in requestDevice.
        [JsonPropertyName("astc-4x4-unorm")]
        astc_4x4_unorm,
        [JsonPropertyName("astc-4x4-unorm-srgb")]
        astc_4x4_unorm_srgb,
        [JsonPropertyName("astc-5x4-unorm")]
        astc_5x4_unorm,
        [JsonPropertyName("astc-5x4-unorm-srgb")]
        astc_5x4_unorm_srgb,
        [JsonPropertyName("astc-5x5-unorm")]
        astc_5x5_unorm,
        [JsonPropertyName("astc-5x5-unorm-srgb")]
        astc_5x5_unorm_srgb,
        [JsonPropertyName("astc-6x5-unorm")]
        astc_6x5_unorm,
        [JsonPropertyName("astc-6x5-unorm-srgb")]
        astc_6x5_unorm_srgb,
        [JsonPropertyName("astc-6x6-unorm")]
        astc_6x6_unorm,
        [JsonPropertyName("astc-6x6-unorm-srgb")]
        astc_6x6_unorm_srgb,
        [JsonPropertyName("astc-8x5-unorm")]
        astc_8x5_unorm,
        [JsonPropertyName("astc-8x5-unorm-srgb")]
        astc_8x5_unorm_srgb,
        [JsonPropertyName("astc-8x6-unorm")]
        astc_8x6_unorm,
        [JsonPropertyName("astc-8x6-unorm-srgb")]
        astc_8x6_unorm_srgb,
        [JsonPropertyName("astc-8x8-unorm")]
        astc_8x8_unorm,
        [JsonPropertyName("astc-8x8-unorm-srgb")]
        astc_8x8_unorm_srgb,
        [JsonPropertyName("astc-10x5-unorm")]
        astc_10x5_unorm,
        [JsonPropertyName("astc-10x5-unorm-srgb")]
        astc_10x5_unorm_srgb,
        [JsonPropertyName("astc-10x6-unorm")]
        astc_10x6_unorm,
        [JsonPropertyName("astc-10x6-unorm-srgb")]
        astc_10x6_unorm_srgb,
        [JsonPropertyName("astc-10x8-unorm")]
        astc_10x8_unorm,
        [JsonPropertyName("astc-10x8-unorm-srgb")]
        astc_10x8_unorm_srgb,
        [JsonPropertyName("astc-10x10-unorm")]
        astc_10x10_unorm,
        [JsonPropertyName("astc-10x10-unorm-srgb")]
        astc_10x10_unorm_srgb,
        [JsonPropertyName("astc-12x10-unorm")]
        astc_12x10_unorm,
        [JsonPropertyName("astc-12x10-unorm-srgb")]
        astc_12x10_unorm_srgb,
        [JsonPropertyName("astc-12x12-unorm")]
        astc_12x12_unorm,
        [JsonPropertyName("astc-12x12-unorm-srgb")]
        astc_12x12_unorm_srgb,
    }
}

# GPUCopyExternalImageDestInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUTexelCopyTextureInfo`  
**Source:** `JSObjects/WebGPU/GPUCopyExternalImageDestInfo.cs`  

> WebGPU textures hold raw numeric data, and are not tagged with semantic metadata describing colors. However, copyExternalImageToTexture() copies from sources that describe colors. "GPUCopyExternalImageDestInfo" describes the "info" about the "destination" of a "copyExternalImageToTexture()" operation. It is a GPUTexelCopyTextureInfo which is additionally tagged with color space/encoding and alpha-premultiplication metadata, so that semantic color data may be preserved during copies. This metadata affects only the semantics of the copy operation operation, not the state or semantics of the destination texture object. https://www.w3.org/TR/webgpu/#gpucopyexternalimagedestinfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ColorSpace` | `PredefinedColorSpace` | get | Describes the color space and encoding used to encode data into the destination texture. This may result in values outside of the range [0, 1] being written to the target texture, if its format can represent them. Otherwise, the results are clamped to the target texture format’s range. |
| `PremultipliedAlpha` | `bool` | get | Describes whether the data written into the texture should have its RGB channels premultiplied by the alpha channel, or not. If this option is set to true and the source is also premultiplied, the source RGB values must be preserved even if they exceed their corresponding alpha values. |


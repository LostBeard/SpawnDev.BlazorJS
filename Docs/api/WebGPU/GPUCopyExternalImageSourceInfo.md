# GPUCopyExternalImageSourceInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUCopyExternalImageSourceInfo.cs`  

> "GPUCopyExternalImageSourceInfo" describes the "info" about the "source" of a "copyExternalImageToTexture()" operation. https://www.w3.org/TR/webgpu/#gpucopyexternalimagesourceinfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUCopyExternalImageSourceInfo` | `class` | get | "GPUCopyExternalImageSourceInfo" describes the "info" about the "source" of a "copyExternalImageToTexture()" operation. https://www.w3.org/TR/webgpu/#gpucopyexternalimagesourceinfo |
| `Origin` | `GPUOrigin2D?` | get/set |  |
| `Flip` | `bool?` | get |  |
| `Source` | `GPUCopyExternalImageSource` | get/set | The source of the texel copy. The copy source data is captured at the moment that copyExternalImageToTexture() is issued. Source size is determined as described by the external source dimensions table. |
| `FlipY` | `bool?` | get/set | Describes whether the source image is vertically flipped, or not. If this option is set to true, the copy is flipped vertically: the bottom row of the source region is copied into the first row of the destination region, and so on. The origin option is still relative to the top-left corner of the source image, increasing downward. |


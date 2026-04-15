# GPUCanvasConfiguration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUCanvasConfiguration.cs`  

> Configuration options for creating a GPUCanvasContext. https://www.w3.org/TR/webgpu/#dictdef-gpucanvasconfiguration

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUCanvasConfiguration` | `class` | get | Configuration options for creating a GPUCanvasContext. https://www.w3.org/TR/webgpu/#dictdef-gpucanvasconfiguration |
| `Format` | `string` | get | The format that textures returned by getCurrentTexture() will have. This can be bgra8unorm, rgba8unorm, or rgba16float. The optimal canvas texture format for the current system can be returned by GPU.getPreferredCanvasFormat(). Using this is recommended - if you don't use the preferred format when configuring the canvas context, you may incur additional overhead, such as additional texture copies, depending on the platform. |
| `Usage` | `GPUFlagsConstant?` | get |  |
| `ViewFormats` | `string[]?` | get |  |
| `ColorSpace` | `string?` | get |  |
| `AlphaMode` | `string?` | get |  |


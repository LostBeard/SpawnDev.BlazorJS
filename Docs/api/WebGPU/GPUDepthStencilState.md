# GPUDepthStencilState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUDepthStencilState.cs`  

> Represents a depth-stencil state in WebGPU, which is used to configure depth and stencil testing for rendering operations. https://www.w3.org/TR/webgpu/#depth-stencil-state

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUDepthStencilState` | `class` | get | Represents a depth-stencil state in WebGPU, which is used to configure depth and stencil testing for rendering operations. https://www.w3.org/TR/webgpu/#depth-stencil-state |
| `DepthCompare` | `string?` | get |  |
| `DepthWriteEnabled` | `bool?` | get/set |  |
| `DepthBias` | `int` | get |  |
| `DepthBiasSlopeScale` | `float` | get/set |  |
| `DepthBiasClamp` | `float` | get |  |
| `StencilFront` | `GPUStencilFaceState?` | get |  |
| `StencilBack` | `GPUStencilFaceState?` | get/set |  |
| `StencilReadMask` | `uint` | get/set |  |
| `StencilWriteMask` | `uint` | get |  |


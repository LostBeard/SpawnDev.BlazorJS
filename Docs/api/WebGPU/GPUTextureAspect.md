# GPUTextureAspect

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUTextureAspect.cs`  

> Each GPUTextureAspect value corresponds to a set of aspects. The set of aspects are defined for each value below. https://www.w3.org/TR/webgpu/#enumdef-gputextureaspect

## Values

| Name | JSON Value | Description |
|---|---|---|
| `All` | `"all"` | All available aspects of the texture format will be accessible to the texture view. For color formats the color aspect will be accessible. For combined depth-stencil formats both the depth and stencil aspects will be accessible. Depth-or-stencil formats with a single aspect will only make that aspect accessible. The set of aspects is [color, depth, stencil]. |
| `StencilOnly` | `"stencil-only"` | Only the stencil aspect of a depth-or-stencil format format will be accessible to the texture view. The set of aspects is [stencil]. |
| `DepthOnly` | `"depth-only"` | Only the depth aspect of a depth-or-stencil format format will be accessible to the texture view. The set of aspects is [depth]. |

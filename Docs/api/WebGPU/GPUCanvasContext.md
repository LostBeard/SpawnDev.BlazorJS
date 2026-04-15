# GPUCanvasContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGPU/GPUCanvasContext.cs`  

> The GPUCanvasContext interface of the WebGPU API represents the WebGPU rendering context of a canvas element, returned via an HTMLCanvasElement.getContext() call with a contextType of "webgpu". https://www.w3.org/TR/webgpu/#gpucanvascontext

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(GPUCanvasConfiguration configuration)` | `void` | Configures the context to use for rendering with a given GPUDevice. When called the canvas will initially be cleared to transparent black. |
| `GetCurrentTexture()` | `GPUTexture` | The getCurrentTexture() method of the GPUCanvasContext interface returns the next GPUTexture to be composited to the document by the canvas context. |
| `Unconfigure()` | `void` | Removes the context configuration. Destroys any textures produced while configured |
| `GetConfiguration()` | `GPUCanvasConfiguration?` | Returns the context configuration. |


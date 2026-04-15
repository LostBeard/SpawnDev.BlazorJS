# XRGPUSubImage

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRSubImage`  
**Source:** `JSObjects/WebXR/XRGPUSubImage.cs`  

> The XRGPUSubImage interface provides the GPU textures for rendering a view in an XR session. This is the WebGPU counterpart to XRWebGLSubImage. https://immersive-web.github.io/WebXR-WebGPU-Binding/

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ColorTexture` | `GPUTexture` | get | The GPU texture to render the color attachment into for this view. |
| `DepthStencilTexture` | `GPUTexture?` | get | The GPU texture for the depth/stencil attachment, or null if not requested. |
| `Viewport` | `XRViewport` | get | The viewport describing the region of the texture to render into. |


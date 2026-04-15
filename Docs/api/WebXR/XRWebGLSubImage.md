# XRWebGLSubImage

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRSubImage`  
**Source:** `JSObjects/WebXR/XRWebGLSubImage.cs`  
**MDN Reference:** [XRWebGLSubImage on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLSubImage)

> The XRWebGLSubImage interface is used during rendering of WebGL layers. https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLSubImage

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ColorTexture` | `WebGLTexture` | get | A color WebGLTexture object for the XRCompositionLayer to render. |
| `DepthStencilTexture` | `WebGLTexture` | get | A depth/stencil WebGLTexture object for the XRCompositionLayer to render. |
| `ImageIndex` | `int?` | get | A number representing the offset into the texture array if the layer was requested with texture-array; null otherwise. |
| `ColorTextureWidth` | `int` | get | A number representing the width in pixels of the GL attachment. |
| `ColorTextureHeight` | `int` | get | A number representing the height in pixels of the GL attachment. |


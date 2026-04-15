# XRWebGLLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRLayer`  
**Source:** `JSObjects/WebXR/XRWebGLLayer.cs`  
**MDN Reference:** [XRWebGLLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLLayer)

> https://www.w3.org/TR/webxr/#xrwebgllayer https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLLayer

## Constructors

| Signature | Description |
|---|---|
| `XRWebGLLayer(XRSession session, WebGLRenderingContext context, XRWebGLLayerInit? options)` | Creates a new instance |
| `XRWebGLLayer(XRSession session, WebGL2RenderingContext context, XRWebGLLayerInit? options)` | Creates a new instance using a WebGL2 context |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Framebuffer` | `WebGLFramebuffer` | get | Returns a WebGLFramebuffer suitable for passing into the bindFrameBuffer() method. |
| `Antialias` | `bool` | get | A Boolean value indicating whether or not the WebGL context's framebuffer supports anti-aliasing. The specific type of anti-aliasing is determined by the user agent. |
| `FramebufferWidth` | `int` | get | Returns the width of the XRWebGLLayer's framebuffer. |
| `FramebufferHeight` | `int` | get | Returns the height of the layer's framebuffer. |
| `IgnoreDepthValues` | `bool` | get | A Boolean which Indicates whether or not the WebXR compositor should make use of the contents of the layer's depth buffer while compositing the scene. |
| `FixedFoveation` | `float` | get | A number indicating the amount of foveation used by the XR compositor. Fixed Foveated Rendering (FFR) renders the edges of the eye textures at a lower resolution than the center and reduces the GPU load. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetViewport(XRView view)` | `XRViewport` | Returns a new XRViewport instance representing the position, width, and height to which the WebGL context's viewport must be set to contain drawing to the area of the framebuffer designated for the specified view's contents. In this way, for example, the rendering of the left eye's point of view and of the right eye's point of view are each placed into the correct parts of the framebuffer. |
| `GetNativeFramebufferScaleFactor(XRSession session)` | `double` | The XRWebGLLayer.getNativeFramebufferScaleFactor() static method returns the scaling factor needed to scale the resolution of the specified XRSession to the native resolution of the WebXR device's display. https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLLayer/getNativeFramebufferScaleFactor_static The XRSession for which to return the native framebuffer scale factor. A floating-point value which, when multiplied by the session's recommended framebuffer dimensions, results in the WebXR device's native resolution. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRWebGLLayer>(...)` or constructor `new XRWebGLLayer(...)`

### Binding the layer to a WebGL context

```js
let glLayer = xrSession.renderState.baseLayer;
gl.bindFrameBuffer(gl.FRAMEBUFFER, glLayer.framebuffer);
```

### Rendering every view in a frame

```js
let pose = xrFrame.getViewerPose(xrReferenceSpace);

if (pose) {
  const glLayer = xrSession.renderState.baseLayer;
  gl.bindFrameBuffer(gl.FRAMEBUFFER, glLayer.framebuffer);

  for (const view of pose.views) {
    const viewport = glLayer.getViewport(view);
    gl.viewport(viewport.x, viewport.y, viewport.width, viewport.height);

    /* Render the view */
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLLayer)*


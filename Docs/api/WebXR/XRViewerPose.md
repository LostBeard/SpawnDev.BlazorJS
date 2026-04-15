# XRViewerPose

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRPose`  
**Source:** `JSObjects/WebXR/XRViewerPose.cs`  
**MDN Reference:** [XRViewerPose on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRViewerPose)

> https://developer.mozilla.org/en-US/docs/Web/API/XRViewerPose

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Views` | `XRView[]` | get | An array of XRView objects, one for each viewpoint on the scene which is needed to represent the scene to the user. A typical headset provides a viewer pose with two views whose eye property is either left or right, indicating which eye that view represents. Taken together, these views can reproduce the 3D effect when displayed on the XR device. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRViewerPose>(...)` or constructor `new XRViewerPose(...)`

```js
const pose = frame.getViewerPose(xrReferenceSpace);

if (pose) {
  const glLayer = xrSession.renderState.baseLayer;

  gl.bindFrameBuffer(gl.FRAMEBUFFER, glLayer.framebuffer);
  gl.clearColor(0, 0, 0, 1);
  gl.clearDepth(1);
  gl.clear(gl.COLOR_BUFFER_BIT, gl.DEPTH_BUFFER_BIT);

  for (const view of pose.views) {
    const viewport = glLayer.getViewport(view);
    gl.viewport(viewport.x, viewport.y, viewport.width, viewport.height);

    /* render the scene for the eye view.eye */
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRViewerPose)*


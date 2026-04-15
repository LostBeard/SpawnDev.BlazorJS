# XRViewport

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRViewport.cs`  
**MDN Reference:** [XRViewport on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRViewport)

> https://developer.mozilla.org/en-US/docs/Web/API/XRViewport

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `int` | get | The width, in pixels, of the viewport. |
| `Height` | `int` | get | The height, in pixels, of the viewport. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRViewport>(...)` or constructor `new XRViewport(...)`

```js
xrSession.requestAnimationFrame((time, xrFrame) => {
  const viewerPose = xrFrame.getViewerPose(xrReferenceSpace);

  gl.bindFramebuffer(xrWebGLLayer.framebuffer);

  for (const xrView of viewerPose.views) {
    const xrViewport = xrWebGLLayer.getViewport(xrView);
    gl.viewport(
      xrViewport.x,
      xrViewport.y,
      xrViewport.width,
      xrViewport.height,
    );

    // Now we can use WebGL to draw into a viewport matching
    // the viewer's needs
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRViewport)*


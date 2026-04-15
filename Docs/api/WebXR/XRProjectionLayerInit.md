# XRProjectionLayerInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRProjectionLayerInit.cs`  
**MDN Reference:** [XRProjectionLayerInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createProjectionLayer#options)

> An object to configure the XRProjectionLayer. https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createProjectionLayer#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRProjectionLayerInit` | `class` | get | An object to configure the XRProjectionLayer. https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createProjectionLayer#options |
| `ColorFormat` | `uint?` | get |  |
| `DepthFormat` | `uint?` | get |  |
| `ScaleFactor` | `float?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRProjectionLayerInit>(...)` or constructor `new XRProjectionLayerInit(...)`

### Creating an `XRProjectionLayer` in a WebGL 2 context

```js
function onXRSessionStarted(xrSession) {
  const glCanvas = document.createElement("canvas");
  const gl = glCanvas.getContext("webgl2", { xrCompatible: true });
  const xrGlBinding = new XRWebGLBinding(xrSession, gl);
  const projectionLayer = xrGlBinding.createProjectionLayer({
    textureType: "texture-array",
  });
  xrSession.updateRenderState({
    layers: [projectionLayer],
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createProjectionLayer)*


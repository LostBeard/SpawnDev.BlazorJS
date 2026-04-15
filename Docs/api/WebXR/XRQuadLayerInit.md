# XRQuadLayerInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRQuadLayerInit.cs`  
**MDN Reference:** [XRQuadLayerInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createQuadLayer#options)

> https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createQuadLayer#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRQuadLayerInit` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createQuadLayer#options |
| `Width` | `float?` | get |  |
| `TextureType` | `string?` | get |  |
| `Transform` | `XRRigidTransform?` | get |  |
| `Space` | `XRSpace` | get/set | An XRSpace object defining the layer's spatial relationship with the user's physical environment. |
| `ViewPixelWidth` | `int` | get/set | A number specifying the pixel width of the layer view. |
| `ViewPixelHeight` | `int` | get | A number specifying the pixel height of the layer view. |
| `ColorFormat` | `uint?` | get |  |
| `DepthFormat` | `uint?` | get |  |
| `IsStatic` | `bool?` | get |  |
| `Layout` | `string?` | get |  |
| `MipLevels` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRQuadLayerInit>(...)` or constructor `new XRQuadLayerInit(...)`

### Creating an `XRQuadLayer`

```js
function onXRSessionStarted(xrSession) {
  const glCanvas = document.createElement("canvas");
  const gl = glCanvas.getContext("webgl2", { xrCompatible: true });
  const xrGlBinding = new XRWebGLBinding(xrSession, gl);
  const quadLayer = xrGlBinding.createQuadLayer({
    space: xrReferenceSpace,
    viewPixelHeight: 512,
    viewPixelWidth: 512,
    transform: new XRRigidTransform({ z: -2 }),
  });
  xrSession.updateRenderState({
    layers: [quadLayer],
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createQuadLayer)*


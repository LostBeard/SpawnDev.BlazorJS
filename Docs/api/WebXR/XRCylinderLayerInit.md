# XRCylinderLayerInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRCylinderLayerInit.cs`  
**MDN Reference:** [XRCylinderLayerInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createCylinderLayer#init)

> https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createCylinderLayer#init

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRCylinderLayerInit` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createCylinderLayer#init |
| `CentralAngle` | `float?` | get |  |
| `Radius` | `float?` | get |  |
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
> - Access via `JS.Get<XRCylinderLayerInit>(...)` or constructor `new XRCylinderLayerInit(...)`

### Creating an `XRCylinderLayer`

```js
function onXRSessionStarted(xrSession) {
  const glCanvas = document.createElement("canvas");
  const gl = glCanvas.getContext("webgl2", { xrCompatible: true });
  const xrGlBinding = new XRWebGLBinding(xrSession, gl);
  const cylinderLayer = xrGlBinding.createCylinderLayer({
    space: xrReferenceSpace,
    viewPixelWidth: 1200,
    viewPixelHeight: 600,
    centralAngle: (60 * Math.PI) / 180,
    aspectRatio: 2,
    radius: 2,
    transform: new XRRigidTransform(/* … */),
  });

  xrSession.updateRenderState({
    layers: [cylinderLayer],
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createCylinderLayer)*


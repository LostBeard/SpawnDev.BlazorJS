# XREquirectLayerInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XREquirectLayerInit.cs`  
**MDN Reference:** [XREquirectLayerInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createEquirectLayer#options)

> https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createEquirectLayer#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XREquirectLayerInit` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createEquirectLayer#options |
| `LowerVerticalAngle` | `float?` | get |  |
| `AspectRatio` | `float?` | get |  |
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
> - Access via `JS.Get<XREquirectLayerInit>(...)` or constructor `new XREquirectLayerInit(...)`

### Creating an `XREquirectLayer`

```js
function onXRSessionStarted(xrSession) {
  const glCanvas = document.createElement("canvas");
  const gl = glCanvas.getContext("webgl2", { xrCompatible: true });
  const xrGlBinding = new XRWebGLBinding(xrSession, gl);
  const equirectLayer = xrGlBinding.createEquirectLayer({
    space: xrReferenceSpace,
    viewPixelWidth: 1200,
    viewPixelHeight: 600,
    centralHorizontalAngle: 2 * Math.PI,
    upperVerticalAngle: Math.PI / 2.0,
    lowerVerticalAngle: -Math.PI / 2.0,
    radius: 0,
  });

  xrSession.updateRenderState({
    layers: [equirectLayer],
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding/createEquirectLayer)*


# XRView

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRView.cs`  
**MDN Reference:** [XRView on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRView)

> https://developer.mozilla.org/en-US/docs/Web/API/XRView

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Eye` | `string` | get | Which of the two eyes (left) or (right) for which this XRView represents the perspective. This value is used to ensure that any content which is pre-rendered for presenting to a specific eye is distributed or positioned correctly. The value can also be none if the XRView is presenting monoscopic data (such as a 2D image, a fullscreen view of text, or a close-up view of something that doesn't need to appear in 3D). |
| `IsFirstPersonObserver` | `bool` | get | Returns a boolean indicating if the XRView is a first-person observer view. |
| `ProjectionMatrix` | `Float32Array` | get | The projection matrix that will transform the scene to appear correctly given the point-of-view indicated by eye. This matrix should be used directly in order to avoid presentation distortions that may lead to potentially serious user discomfort. |
| `RecommendedViewportScale` | `float?` | get | The recommended viewport scale value that you can use for requestViewportScale() if the user agent has such a recommendation; null otherwise. |
| `Transform` | `XRRigidTransform` | get | An XRRigidTransform which describes the current position and orientation of the viewpoint in relation to the XRReferenceSpace specified when getViewerPose() was called on the XRFrame being rendered. |
| `Camera` | `XRCamera?` | get | The camera property of the XRView interface returns an XRCamera object representing the camera for the view, if applicable for the session's XR device. Returns null if the feature is not enabled or supported. https://developer.mozilla.org/en-US/docs/Web/API/XRView/camera |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestViewportScale(float scale)` | `void` | The requestViewportScale() method of the XRView interface requests that the user agent sets the requested viewport scale for this viewport to the given value. This is used for dynamic viewport scaling which allows rendering to a subset of the WebXR viewport using a scale factor that can be changed every animation frame. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRView>(...)` or constructor `new XRView(...)`

### Preparing to render every view for a pose

```js
for (const view of pose.views) {
  const viewport = glLayer.getViewport(view);

  gl.viewport(viewport.x, viewport.y, viewport.width, viewport.height);

  // Draw the scene; the eye being drawn is identified
  // by view.eye.
}
```

### Special view transforms

```js
mat4.multiply(modelViewMatrix, view.transform.inverse.matrix, objectMatrix);
```

### Special view transforms

```js
mat4.invert(normalMatrix, modelViewMatrix);
mat4.transpose(normalMatrix, normalMatrix);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRView)*


# WindowControlsOverlayGeometryChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WindowControlsOverlayGeometryChangeEvent.cs`  
**MDN Reference:** [WindowControlsOverlayGeometryChangeEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlayGeometryChangeEvent)

> The WindowControlsOverlayGeometryChangeEvent interface of the Window Controls Overlay API is passed to geometrychange when the size or visibility of a desktop Progress Web App's title bar region changes. https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlayGeometryChangeEvent

## Constructors

| Signature | Description |
|---|---|
| `WindowControlsOverlayGeometryChangeEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Visible` | `bool` | get | A Boolean that indicates whether the window controls overlay is visible or not. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `TitlebarAreaRect()` | `DOMRectReadOnly` | A DOMRect representing the position and size of the title bar region. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WindowControlsOverlayGeometryChangeEvent>(...)` or constructor `new WindowControlsOverlayGeometryChangeEvent(...)`

```js
if ("windowControlsOverlay" in navigator) {
  navigator.windowControlsOverlay.addEventListener(
    "geometrychange",
    (event) => {
      if (event.visible) {
        const rect = event.titlebarAreaRect;
        // Do something with the coordinates of the title bar area.
      }
    },
  );
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlayGeometryChangeEvent)*


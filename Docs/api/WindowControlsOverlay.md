# WindowControlsOverlay

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WindowControlsOverlay.cs`  
**MDN Reference:** [WindowControlsOverlay on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlay)

> The WindowControlsOverlay interface of the Window Controls Overlay API exposes information about the geometry of the title bar area in desktop Progressive Web Apps, and an event to know whenever it changes. This interface is accessible from Navigator.windowControlsOverlay. https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlay

## Constructors

| Signature | Description |
|---|---|
| `WindowControlsOverlay(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Visible` | `bool` | get | A Boolean that indicates whether the window controls overlay is visible or not. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetTitlebarAreaRect()` | `DOMRectReadOnly` | The getTitlebarAreaRect() method of the WindowControlsOverlay interface queries the current geometry of the title bar area of the Progressive Web App window. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnGeometryChange` | `ActionEvent<WindowControlsOverlayGeometryChangeEvent>` | The geometrychange event is fired when the position, size, or visibility of a Progressive Web App's title bar area changes |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WindowControlsOverlay>(...)` or constructor `new WindowControlsOverlay(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlay)*


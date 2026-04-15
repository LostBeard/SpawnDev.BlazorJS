# CaptureController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/CaptureController.cs`  
**MDN Reference:** [CaptureController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CaptureController)

> The CaptureController interface provides methods that can be used to further manipulate a capture session separate from its initiation via MediaDevices.getDisplayMedia(). https://developer.mozilla.org/en-US/docs/Web/API/CaptureController

## Constructors

| Signature | Description |
|---|---|
| `CaptureController(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CaptureController()` | The CaptureController constructor creates a new CaptureController object instance. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetFocusBehavior(EnumString<CaptureStartFocusBehavior> focusBehavior)` | `void` | The CaptureController interface's setFocusBehavior() method controls whether the captured tab or window will be focused when an associated MediaDevices.getDisplayMedia() Promise fulfills, or whether the focus will remain with the tab containing the capturing app. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CaptureController>(...)` or constructor `new CaptureController(...)`

```js
// Create a new CaptureController instance
const controller = new CaptureController();

// Prompt the user to share a tab, window, or screen.
const stream = await navigator.mediaDevices.getDisplayMedia({ controller });

// Query the displaySurface value of the captured video track
const [track] = stream.getVideoTracks();
const displaySurface = track.getSettings().displaySurface;

if (displaySurface === "browser") {
  // Focus the captured tab.
  controller.setFocusBehavior("focus-captured-surface");
} else if (displaySurface === "window") {
  // Do not move focus to the captured window.
  // Keep the capturing page focused.
  controller.setFocusBehavior("no-focus-change");
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CaptureController)*


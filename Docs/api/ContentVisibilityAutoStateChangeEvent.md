# ContentVisibilityAutoStateChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/ContentVisibilityAutoStateChangeEvent.cs`  
**MDN Reference:** [ContentVisibilityAutoStateChangeEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ContentVisibilityAutoStateChangeEvent)

> The ContentVisibilityAutoStateChangeEvent interface is the event object for the contentvisibilityautostatechange event, which fires on any element with content-visibility: auto set on it when it starts or stops being relevant to the user and skipping its contents. https://developer.mozilla.org/en-US/docs/Web/API/ContentVisibilityAutoStateChangeEvent

## Constructors

| Signature | Description |
|---|---|
| `ContentVisibilityAutoStateChangeEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Skipped` | `bool` | get | Returns true if the user agent is skipping the element's rendering, or false otherwise. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ContentVisibilityAutoStateChangeEvent>(...)` or constructor `new ContentVisibilityAutoStateChangeEvent(...)`

```js
const canvasElem = document.querySelector("canvas");

canvasElem.addEventListener("contentvisibilityautostatechange", stateChanged);
canvasElem.style.contentVisibility = "auto";

function stateChanged(event) {
  if (event.skipped) {
    stopCanvasUpdates(canvasElem);
  } else {
    startCanvasUpdates(canvasElem);
  }
}

// Call this when the canvas updates need to start.
function startCanvasUpdates(canvas) {
  // …
}

// Call this when the canvas updates need to stop.
function stopCanvasUpdates(canvas) {
  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ContentVisibilityAutoStateChangeEvent)*


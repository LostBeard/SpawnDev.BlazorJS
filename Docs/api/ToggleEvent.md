# ToggleEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/ToggleEvent.cs`  
**MDN Reference:** [ToggleEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ToggleEvent)

> The ToggleEvent interface represents an event notifying the user when a popover element's state toggles between showing and hidden. https://developer.mozilla.org/en-US/docs/Web/API/ToggleEvent

## Constructors

| Signature | Description |
|---|---|
| `ToggleEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NewState` | `string` | get | A string (either "open" or "closed"), representing the state the element is transitioning to. |
| `OldState` | `string` | get | A string (either "open" or "closed"), representing the state the element is transitioning from. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ToggleEvent>(...)` or constructor `new ToggleEvent(...)`

### Basic example

```js
const popover = document.getElementById("mypopover");

// …

popover.addEventListener("beforetoggle", (event) => {
  if (event.newState === "open") {
    console.log("Popover is being shown");
  } else {
    console.log("Popover is being hidden");
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ToggleEvent)*


# ScreenDetailed

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Screen`  
**Source:** `JSObjects/ScreenDetailed.cs`  
**MDN Reference:** [ScreenDetailed on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed)

> The ScreenDetailed interface of the Window Management API represents detailed information about one specific screen available to the user's device. https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed

## Constructors

| Signature | Description |
|---|---|
| `ScreenDetailed(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DevicePixelRatio` | `double` | get | A number representing the screen's device pixel ratio. |
| `IsInternal` | `bool` | get/set | A boolean indicating whether the screen is internal to the device or external. |
| `IsPrimary` | `bool` | get | A boolean indicating whether the screen is set as the operating system (OS) primary screen or not. |
| `Label` | `string` | get | A string providing a descriptive label for the screen, for example "Built-in Retina Display". |
| `Left` | `int` | get | A number representing the x-coordinate (left-hand edge) of the total screen area. |
| `Top` | `int` | get | A number representing the y-coordinate (top edge) of the total screen area. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ScreenDetailed>(...)` or constructor `new ScreenDetailed(...)`

```js
// Return ScreenDetails
const allScreens = await window.getScreenDetails();

// Return the primary screen ScreenDetailed object
const primaryScreenDetailed = allScreens.screens.find(
  (screenDetailed) => screenDetailed.isPrimary,
);

// Open a window in the top-left corner of the OS primary screen
window.open(
  "https://example.com",
  "_blank",
  `left=${primaryScreenDetailed.availLeft},
   top=${primaryScreenDetailed.availTop},
   width=200,
   height=200`,
);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed)*


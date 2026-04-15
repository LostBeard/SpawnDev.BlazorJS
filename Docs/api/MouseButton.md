# MouseButton

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MouseButton.cs`  
**MDN Reference:** [MouseButton on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent/button#value)

> A number representing a given button https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent/button#value

## Values

| Name | JSON Value | Description |
|---|---|---|
| `PrimaryButton` |  | Primary button (usually the left button) |
| `AuxiliaryButton` |  | Auxiliary button (usually the mouse wheel button or middle button) |
| `SecondaryButton` |  | Secondary button (usually the right button) |
| `FourthButton` |  | 4th button (typically the "Browser Back" button) |
| `FifthButton` |  | 5th button (typically the "Browser Forward" button) |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MouseButton` | `enum` | get | A number representing a given button https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent/button#value |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MouseButton>(...)` or constructor `new MouseButton(...)`

### JavaScript

```js
const button = document.querySelector("#button");
const log = document.querySelector("#log");
button.addEventListener("mouseup", (e) => {
  switch (e.button) {
    case 0:
      log.textContent = "Left button clicked.";
      break;
    case 1:
      log.textContent = "Middle button clicked.";
      break;
    case 2:
      log.textContent = "Right button clicked.";
      break;
    default:
      log.textContent = `Unknown button code: ${e.button}`;
  }
});
button.addEventListener("contextmenu", (e) => {
  e.preventDefault();
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent/button)*


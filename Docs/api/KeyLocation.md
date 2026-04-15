# KeyLocation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/KeyLocation.cs`  

> The following constants identify which part of the keyboard the key event originates from.

## Values

| Name | JSON Value | Description |
|---|---|---|
| `DomKeyLocationStandard` |  | The key described by the event is not identified as being located in a particular area of the keyboard. https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants |
| `DomKeyLocationLeft` |  | The key is one which may exist in multiple locations on the keyboard and, in this instance, is on the left side of the keyboard. https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants |
| `DomKeyLocationRight` |  | The key is one which may exist in multiple positions on the keyboard and, in this case, is located on the right side of the keyboard. https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants |
| `DomKeyLocationNumpad` |  | The key is located on the numeric keypad, or is a virtual key associated with the numeric keypad if there's more than one place the key could originate from. https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent#constants |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `KeyLocation` | `enum` | get | The following constants identify which part of the keyboard the key event originates from. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<KeyLocation>(...)` or constructor `new KeyLocation(...)`

```js
document.addEventListener("keydown", (event) => {
  const keyName = event.key;

  if (keyName === "Control") {
    // do not alert when only Control key is pressed.
    return;
  }

  if (event.ctrlKey) {
    // Even though event.key is not 'Control' (e.g., 'a' is pressed),
    // event.ctrlKey may be true if Ctrl key is pressed at the same time.
    alert(`Combination of ctrlKey + ${keyName}`);
  } else {
    alert(`Key pressed ${keyName}`);
  }
});

document.addEventListener("keyup", (event) => {
  const keyName = event.key;

  // As the user releases the Ctrl key, the key is no longer active,
  // so event.ctrlKey is false.
  if (keyName === "Control") {
    alert("Control key was released");
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent)*


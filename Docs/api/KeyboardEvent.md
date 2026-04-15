# KeyboardEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `UIEvent`  
**Source:** `JSObjects/KeyboardEvent.cs`  
**MDN Reference:** [KeyboardEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent)

> KeyboardEvent objects describe a user interaction with the keyboard https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent

## Constructors

| Signature | Description |
|---|---|
| `KeyboardEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Code` | `string` | get | Returns a string with the code value of the physical key represented by the event. |
| `Key` | `string` | get | Returns a string representing the key value of the key represented by the event. |
| `AltKey` | `bool` | get | Returns a boolean value that is true if the Alt (Option or ⌥ on macOS) key was active when the key event was generated. |
| `CtrlKey` | `bool` | get | Returns a boolean value that is true if the Ctrl key was active when the key event was generated. |
| `MetaKey` | `bool` | get | Returns a boolean value that is true if the Meta key (on Mac keyboards, the ⌘ Command key; on Windows keyboards, the Windows key (⊞)) was active when the key event was generated. |
| `ShiftKey` | `bool` | get | Returns a boolean value that is true if the Shift key was active when the key event was generated. |
| `IsComposing` | `bool` | get | Returns a boolean value that is true if the event is fired between after compositionstart and before compositionend. |
| `Repeat` | `bool` | get | Returns a boolean value that is true if the key is being held down such that it is automatically repeating. |
| `Location` | `KeyLocation` | get | Returns a number representing the location of the key on the keyboard or other input device. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetModifierState()` | `bool` | Returns a boolean value indicating if a modifier key such as Alt, Shift, Ctrl, or Meta, was pressed when the event was created. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<KeyboardEvent>(...)` or constructor `new KeyboardEvent(...)`

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


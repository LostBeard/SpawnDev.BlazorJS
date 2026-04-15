# MouseEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `UIEvent`  
**Source:** `JSObjects/MouseEvent.cs`  
**MDN Reference:** [MouseEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent)

> The MouseEvent interface represents events that occur due to the user interacting with a pointing device (such as a mouse). Common events using this interface include click, dblclick, mouseup, mousedown. https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent

## Constructors

| Signature | Description |
|---|---|
| `MouseEvent(string type)` | The MouseEvent() constructor creates a new MouseEvent object. A string with the name of the event. It is case-sensitive and browsers set it to dblclick, mousedown, mouseenter, mouseleave, mousemove, mouseout, mouseover, or mouseup. |
| `MouseEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AltKey` | `bool` | get | Returns a boolean value that is true if the Alt (Option or ⌥ on macOS) key was active when the key event was generated. |
| `CtrlKey` | `bool` | get | Returns a boolean value that is true if the Ctrl key was active when the key event was generated. |
| `MetaKey` | `bool` | get | Returns a boolean value that is true if the Meta key (on Mac keyboards, the ⌘ Command key; on Windows keyboards, the Windows key (⊞)) was active when the key event was generated. |
| `ShiftKey` | `bool` | get | Returns a boolean value that is true if the Shift key was active when the key event was generated. |
| `Button` | `MouseButton` | get | The button number that was pressed (if applicable) when the mouse event was fired. |
| `Buttons` | `MouseButtons` | get | The buttons being pressed (if any) when the mouse event was fired. |
| `ClientX` | `double` | get | The X coordinate of the mouse pointer in viewport coordinates. |
| `ClientY` | `double` | get | The Y coordinate of the mouse pointer in viewport coordinates. |
| `LayerX` | `int?` | get | Returns the horizontal coordinate of the event relative to the current layer. |
| `LayerY` | `int?` | get | Returns the vertical coordinate of the event relative to the current layer. |
| `MovementX` | `double` | get | The X coordinate of the mouse pointer relative to the position of the last mousemove event. |
| `MovementY` | `double` | get | The Y coordinate of the mouse pointer relative to the position of the last mousemove event. |
| `OffsetX` | `double` | get | The X coordinate of the mouse pointer relative to the position of the padding edge of the target node. |
| `OffsetY` | `double` | get | The Y coordinate of the mouse pointer relative to the position of the padding edge of the target node. |
| `PageX` | `double` | get | The X coordinate of the mouse pointer relative to the whole document. |
| `PageY` | `double` | get | The Y coordinate of the mouse pointer relative to the whole document. |
| `RelatedTarget` | `EventTarget?` | get | The secondary target for the event, if there is one. |
| `ScreenX` | `double` | get | The X coordinate of the mouse pointer in screen coordinates. |
| `ScreenY` | `double` | get | The Y coordinate of the mouse pointer in screen coordinates. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetModifierState(string key)` | `bool` | Returns the current state of the specified modifier key. See KeyboardEvent.getModifierState() for details. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MouseEvent>(...)` or constructor `new MouseEvent(...)`

### JavaScript

```js
function simulateClick() {
  // Get the element to send a click event
  const cb = document.getElementById("checkbox");

  // Create a synthetic click MouseEvent
  let evt = new MouseEvent("click", {
    bubbles: true,
    cancelable: true,
    view: window,
  });

  // Send the event to the checkbox element
  cb.dispatchEvent(evt);
}
document.getElementById("button").addEventListener("click", simulateClick);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MouseEvent)*


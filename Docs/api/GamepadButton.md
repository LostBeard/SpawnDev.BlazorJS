# GamepadButton

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/GamepadButton.cs`  
**MDN Reference:** [GamepadButton on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadButton)

> The GamepadButton interface defines an individual button of a gamepad or other controller, allowing access to the current state of different types of buttons available on the control device. GamepadButton, when serialized via JSON.stringify(), returns and empty object {} so a JSObject is used even though the values are static https://developer.mozilla.org/en-US/docs/Web/API/GamepadButton

## Constructors

| Signature | Description |
|---|---|
| `GamepadButton(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Pressed` | `bool` | get | A boolean value indicating whether the button is currently pressed (true) or unpressed (false). |
| `Touched` | `bool` | get | A boolean value indicating whether the button is currently touched (true) or not touched (false) |
| `Value` | `double` | get | A double value used to represent the current state of analog buttons, such as the triggers on many modern gamepads. The values are normalized to the range 0.0 -1.0, with 0.0 representing a button that is not pressed, and 1.0 representing a button that is fully pressed. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GamepadButton>(...)` or constructor `new GamepadButton(...)`

```js
function gameLoop() {
  const gp = navigator.getGamepads()[0];

  if (gp.buttons[0].value > 0 || gp.buttons[0].pressed) {
    b--;
  } else if (gp.buttons[1].value > 0 || gp.buttons[1].pressed) {
    a++;
  } else if (gp.buttons[2].value > 0 || gp.buttons[2].pressed) {
    b++;
  } else if (gp.buttons[3].value > 0 || gp.buttons[3].pressed) {
    a--;
  }

  ball.style.left = `${a * 2}px`; // ball is a UI widget
  ball.style.top = `${b * 2}px`;

  requestAnimationFrame(gameLoop);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadButton)*


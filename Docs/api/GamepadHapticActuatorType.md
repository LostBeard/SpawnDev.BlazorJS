# GamepadHapticActuatorType

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/GamepadHapticActuatorType.cs`  
**MDN Reference:** [GamepadHapticActuatorType on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type#value)

> An enumerated value representing the haptic hardware type. https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type#value

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Vibration` | `"vibration"` | Simple vibration hardware, which creates a rumbling effect. |
| `DualRumble` | `"dual-rumble"` | A controller with a vibration motor in each handle. Each motor can be vibrated independently to create positional rumbling effects. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GamepadHapticActuatorType` | `enum` | get | An enumerated value representing the haptic hardware type. https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type#value |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GamepadHapticActuatorType>(...)` or constructor `new GamepadHapticActuatorType(...)`

```js
const gamepad = navigator.getGamepads()[0];

// Logs "vibration" or "dual-rumble"
console.log(gamepad.hapticActuators[0].type);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type)*


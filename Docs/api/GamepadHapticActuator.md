# GamepadHapticActuator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/GamepadHapticActuator.cs`  
**MDN Reference:** [GamepadHapticActuator on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator)

> The GamepadHapticActuator interface of the Gamepad API represents hardware in the controller designed to provide haptic feedback to the user (if available), most commonly vibration hardware. https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator

## Constructors

| Signature | Description |
|---|---|
| `GamepadHapticActuator(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `GamepadHapticActuatorType` | get | Returns an enum representing the type of the haptic hardware. |
| `PlayEffectSupported` | `bool` | get | Returns true if PlayEffect is supported |
| `PulseSupported` | `bool` | get | Returns true if Pulse is supported |
| `ResetSupported` | `bool` | get | Returns true if Reset is supported |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Pulse(double value, double duration)` | `Task` | The pulse() method of the GamepadHapticActuator interface makes the hardware pulse at a certain intensity for a specified duration. May be Firefox and not Chrome A double representing the intensity of the pulse. This can vary depending on the hardware type, but generally takes a value between 0.0 (no intensity) and 1.0 (full intensity). A double representing the duration of the pulse, in milliseconds. |
| `PlayEffect(string type, HapticEffectParams effectParams)` | `Task` | The playEffect() method of the GamepadHapticActuator interface makes the hardware play a specific vibration pattern. May be Chrome and not Firefox A string representing the desired effect. This can vary depending on the hardware type. Possible values are "dual-rumble" or "vibration". An object to describe a desired haptic effect. |
| `Reset()` | `void` | Cancels the active Effect May be Chrome specific |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GamepadHapticActuator>(...)` or constructor `new GamepadHapticActuator(...)`

```js
const gamepad = navigator.getGamepads()[0];

gamepad.hapticActuators[0].pulse(1.0, 200);

gamepad.vibrationActuator.playEffect("dual-rumble", {
  startDelay: 0,
  duration: 200,
  weakMagnitude: 1.0,
  strongMagnitude: 1.0,
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator)*


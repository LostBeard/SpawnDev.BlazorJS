# Gamepad

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Gamepad.cs`  
**MDN Reference:** [Gamepad on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Gamepad)

> The Gamepad interface of the Gamepad API defines an individual gamepad or other controller, allowing access to information such as button presses, axis positions, and id. A Gamepad object can be returned in one of two ways: via the gamepad property of the gamepadconnected and gamepaddisconnected events, or by grabbing any position in the array returned by the Navigator.getGamepads() method. https://developer.mozilla.org/en-US/docs/Web/API/Gamepad

## Constructors

| Signature | Description |
|---|---|
| `Gamepad(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Axes` | `double[]` | get | An array representing the controls with axes present on the device (e.g. analog thumb sticks). |
| `Buttons` | `GamepadButton[]` | get | An array of gamepadButton objects representing the buttons present on the device. |
| `Connected` | `bool` | get | A boolean indicating whether the gamepad is still connected to the system. |
| `Hand` | `GamepadHand?` | get | An enum defining what hand the controller is being held in, or is most likely to be held in. |
| `HapticActuators` | `GamepadHapticActuator[]?` | get | An array containing GamepadHapticActuator objects, each of which represents haptic feedback hardware available on the controller. |
| `VibrationActuator` | `GamepadHapticActuator?` | get | A GamepadHapticActuator object, which represents haptic feedback hardware available on the controller. ⚠ non-standard |
| `Id` | `string` | get | A string containing identifying information about the controller. |
| `Index` | `int` | get | An integer that is auto-incremented to be unique for each device currently connected to the system. |
| `Mapping` | `string` | get | A string indicating whether the browser has remapped the controls on the device to a known layout. |
| `Pose` | `GamepadPose` | get | A GamepadPose object representing the pose information associated with a WebVR controller (e.g. its position and orientation in 3D space). |
| `Timestamp` | `double` | get | A DOMHighResTimeStamp representing the last time the data for this gamepad was updated. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Gamepad>(...)` or constructor `new Gamepad(...)`

```js
window.addEventListener("gamepadconnected", (e) => {
  console.log(
    "Gamepad connected at index %d: %s. %d buttons, %d axes.",
    e.gamepad.index,
    e.gamepad.id,
    e.gamepad.buttons.length,
    e.gamepad.axes.length,
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Gamepad)*


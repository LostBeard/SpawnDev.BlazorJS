# DeviceMotionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/DeviceMotionEvent.cs`  
**MDN Reference:** [DeviceMotionEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DeviceMotionEvent)

> The DeviceMotionEvent interface provides web developers with information about the speed of changes for the device's position and orientation. https://developer.mozilla.org/en-US/docs/Web/API/DeviceMotionEvent

## Constructors

| Signature | Description |
|---|---|
| `DeviceMotionEvent(IJSInProcessObjectReference _ref)` | Default deserialize constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Acceleration` | `DeviceMotionXYZ` | get | An object giving the acceleration of the device on the three axis X, Y and Z. Acceleration is expressed in m/s². |
| `AccelerationIncludingGravity` | `DeviceMotionXYZ` | get | An object giving the acceleration of the device on the three axis X, Y and Z with the effect of gravity. Acceleration is expressed in m/s². |
| `RotationRate` | `DeviceMotionAlphaBetaGamma` | get | An object giving the rate of change of the device's orientation on the three orientation axis alpha, beta and gamma. Rotation rate is expressed in degrees per seconds. |
| `Interval` | `double` | get | A number representing the interval of time, in milliseconds, at which data is obtained from the device. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DeviceMotionEvent>(...)` or constructor `new DeviceMotionEvent(...)`

```js
window.addEventListener("devicemotion", (event) => {
  console.log(`${event.acceleration.x} m/s2`);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DeviceMotionEvent)*


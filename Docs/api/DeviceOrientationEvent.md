# DeviceOrientationEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/DeviceOrientationEvent.cs`  
**MDN Reference:** [DeviceOrientationEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DeviceOrientationEvent)

> The DeviceOrientationEvent object provides web developers with information from the physical orientation of the device running the web page. https://www.w3.org/TR/orientation-event/#deviceorientation https://developer.mozilla.org/en-US/docs/Web/API/DeviceOrientationEvent

## Constructors

| Signature | Description |
|---|---|
| `DeviceOrientationEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Absolute` | `bool` | get | A boolean that indicates whether or not the device is providing orientation data absolutely. |
| `Alpha` | `double?` | get | A number representing the motion of the device around the z axis, express in degrees with values ranging from 0 (inclusive) to 360 (exclusive). |
| `Beta` | `double?` | get | A number representing the motion of the device around the x axis, express in degrees with values ranging from -180 (inclusive) to 180 (exclusive). This represents a front to back motion of the device. |
| `Gamma` | `double?` | get | A number representing the motion of the device around the y axis, express in degrees with values ranging from -90 (inclusive) to 90 (exclusive). This represents a left to right motion of the device. |
| `WebkitCompassHeading` | `double?` | get | Gets the compass heading in degrees as reported by the device's webkit-compatible orientation sensor. This property is specific to browsers that implement the non-standard 'webkitCompassHeading' property, primarily on iOS devices. The value may be null if the sensor is unavailable or unsupported by the browser. |
| `WebkitCompassAccuracy` | `double?` | get | The accuracy of the compass means that the deviation is positive or negative. It's usually 10. This property is specific to browsers that implement the non-standard |
| `RequestPermissionSupported` | `bool` | get | Returns true if the DeviceOrientationEvent.requestPermission method is supported in the current environment. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestPermission(bool absolute)` | `Task<string>` | Requests permission from the user to access device orientation events. This method is typically required on certain platforms, such as iOS, where explicit user permission is needed to access device orientation events. The returned permission status should be checked before attempting to use device orientation data. A value indicating whether to request permission in absolute mode. If , requests absolute orientation data; otherwise, requests relative orientation data. A task that represents the asynchronous operation. The task result contains a string indicating the permission status, such as "granted", "denied", or "prompt". |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DeviceOrientationEvent>(...)` or constructor `new DeviceOrientationEvent(...)`

```js
window.addEventListener("deviceorientation", (event) => {
  console.log(`${event.alpha} : ${event.beta} : ${event.gamma}`);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DeviceOrientationEvent)*


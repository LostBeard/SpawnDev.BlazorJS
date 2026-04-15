# InputDeviceInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MediaDeviceInfo`  
**Source:** `JSObjects/InputDeviceInfo.cs`  
**MDN Reference:** [InputDeviceInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo)

> The InputDeviceInfo interface of the Media Capture and Streams API gives access to the capabilities of the input device that it represents. https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo

## Constructors

| Signature | Description |
|---|---|
| `InputDeviceInfo(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCapabilities()` | `MediaTrackCapabilities` | Returns a MediaTrackCapabilities object describing the primary audio or video track of a device's MediaStream. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<InputDeviceInfo>(...)` or constructor `new InputDeviceInfo(...)`

```js
navigator.mediaDevices.enumerateDevices().then((devices) => {
  devices.forEach((device) => {
    console.log(device); // an InputDeviceInfo object if the device is an input device, otherwise a MediaDeviceInfo object.
  });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo)*


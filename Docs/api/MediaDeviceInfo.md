# MediaDeviceInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaDeviceInfo.cs`  
**MDN Reference:** [MediaDeviceInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaDeviceInfo)

> The MediaDeviceInfo interface of the Media Capture and Streams API contains information that describes a single media input or output device. https://developer.mozilla.org/en-US/docs/Web/API/MediaDeviceInfo

## Constructors

| Signature | Description |
|---|---|
| `MediaDeviceInfo(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DeviceId` | `string` | get | Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions). |
| `Kind` | `string` | get | Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput". |
| `Label` | `string` | get | Returns a string describing this device (for example "External USB Webcam"). Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user. |
| `GroupId` | `string` | get | Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device - for example a monitor with both a built-in camera and a microphone. |
| `Facing` | `EnumString<VideoFacingModeEnum>?` | get | Facing mode |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToJSON()` | `MediaDeviceInfoJson` | Returns a JSON representation of the MediaDeviceInfo object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaDeviceInfo>(...)` or constructor `new MediaDeviceInfo(...)`

```js
if (!navigator.mediaDevices || !navigator.mediaDevices.enumerateDevices) {
  console.log("enumerateDevices() not supported.");
} else {
  // List cameras and microphones.
  navigator.mediaDevices
    .enumerateDevices()
    .then((devices) => {
      devices.forEach((device) => {
        console.log(`${device.kind}: ${device.label} id = ${device.deviceId}`);
      });
    })
    .catch((err) => {
      console.log(`${err.name}: ${err.message}`);
    });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaDeviceInfo)*


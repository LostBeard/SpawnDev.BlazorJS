# XRSystem

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebXR`  
**Inheritance:** `JSObject` -> `EventTarget` -> `XRSystem`  
**MDN Reference:** [XRSystem - MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSystem)

> The `XRSystem` interface is the entry point for the WebXR Device API. Access via `Navigator.XR`. It provides methods to check for XR support and to create XR sessions.

## Constructors

| Signature | Description |
|---|---|
| `XRSystem(IJSInProcessObjectReference _ref)` | Deserialization constructor. Access via `navigator.XR`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsSessionSupported(string mode)` | `Task<bool>` | Checks if the given session mode is supported. Modes: `"inline"`, `"immersive-vr"`, `"immersive-ar"`. |
| `RequestSession(string mode)` | `Task<XRSession>` | Requests an XR session of the given mode. |
| `RequestSession(string mode, XRSessionInit options)` | `Task<XRSession>` | Requests a session with options (required/optional features). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDeviceChange` | `ActionEvent<Event>` | Fired when the set of available XR devices changes. |

## Example

```csharp
using var navigator = new Navigator();
var xr = navigator.XR;
if (xr != null)
{
    bool vrSupported = await xr.IsSessionSupported("immersive-vr");
    if (vrSupported)
    {
        using var session = await xr.RequestSession("immersive-vr");
        Console.WriteLine($"XR session started");
    }
}
```

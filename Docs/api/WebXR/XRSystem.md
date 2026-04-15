# XRSystem

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebXR/XRSystem.cs`  
**MDN Reference:** [XRSystem on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSystem)

> The WebXR Device API interface XRSystem provides methods which let you get access to an XRSession object representing a WebXR session. With that XRSession in hand, you can use it to interact with the Augmented Reality (AR) or Virtual Reality (VR) device. https://developer.mozilla.org/en-US/docs/Web/API/XRSystem https://www.w3.org/TR/webxr/#xrsystem-interface

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsSessionSupported(EnumString<XRSessionMode> mode)` | `Task<bool>` | The isSessionSupported(mode) method queries if a given mode may be supported by the user agent and device capabilities. |
| `RequestSession(EnumString<XRSessionMode> mode, XRSessionInit? options)` | `Task<XRSession>` | The requestSession(mode, options) method attempts to initialize an XRSession for the given mode if possible, entering immersive mode if necessary. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDeviceChange` | `ActionEvent<Event>` | A devicechange event is fired on an XRSystem object whenever the availability of immersive XR devices has changed; for example, a VR headset or AR goggles have been connected or disconnected. It's a generic Event with no added properties. |

## Example

```csharp
// Access the XRSystem from the navigator
using var navigator = JS.Get<Navigator>("navigator");
using var xr = navigator.XR;
if (xr == null)
{
    Console.WriteLine("WebXR not supported.");
    return;
}

// Check if immersive VR sessions are supported
bool vrSupported = await xr.IsSessionSupported(XRSessionMode.ImmersiveVR);
Console.WriteLine($"Immersive VR supported: {vrSupported}");

// Check for inline (non-immersive) session support
bool inlineSupported = await xr.IsSessionSupported(XRSessionMode.Inline);
Console.WriteLine($"Inline session supported: {inlineSupported}");

// Listen for VR device connect/disconnect events
xr.OnDeviceChange += (Event e) =>
{
    Console.WriteLine("XR device availability changed");
};

// Request an immersive VR session (requires user gesture)
if (vrSupported)
{
    using var session = await xr.RequestSession(XRSessionMode.ImmersiveVR);
    Console.WriteLine("VR session started");
    // Use session for rendering - see XRSession example
    await session.End();
}
```


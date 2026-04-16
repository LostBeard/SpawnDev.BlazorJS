# XRSession

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebXR`  
**Inheritance:** `JSObject` -> `EventTarget` -> `XRSession`  
**MDN Reference:** [XRSession - MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession)

> The `XRSession` interface represents an ongoing XR session, providing the context for all XR interactions including rendering, input handling, and spatial tracking.

## Constructors

| Signature | Description |
|---|---|
| `XRSession(IJSInProcessObjectReference _ref)` | Deserialization constructor. Obtained via `XRSystem.RequestSession()`. |

## Properties

| Property | Type | Description |
|---|---|---|
| `RenderState` | `XRRenderState` | The current render state (base layer, depth range). |
| `InputSources` | `XRInputSource[]` | Currently active input sources (controllers, hands). |
| `VisibilityState` | `string` | Visibility: `"visible"`, `"visible-blurred"`, or `"hidden"`. |
| `FrameRate` | `float?` | The current frame rate, if available. |
| `SupportedFrameRates` | `float[]?` | Frame rates that can be requested. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestReferenceSpace(string type)` | `Task<XRReferenceSpace>` | Gets a reference space. Types: `"local"`, `"local-floor"`, `"bounded-floor"`, `"unbounded"`, `"viewer"`. |
| `RequestAnimationFrame(Callback callback)` | `int` | Schedules a callback for the next XR frame. Returns a handle. |
| `UpdateRenderState(XRRenderStateInit options)` | `void` | Updates the render state. |
| `End()` | `Task` | Ends the XR session. |
| `RequestHitTestSource(XRHitTestOptionsInit options)` | `Task<XRHitTestSource>` | Creates a hit test source for AR. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnd` | `ActionEvent<XRSessionEvent>` | Fired when the session ends. |
| `OnInputSourcesChange` | `ActionEvent<XRInputSourcesChangeEvent>` | Fired when input sources change. |
| `OnSelect` | `ActionEvent<XRInputSourceEvent>` | Fired on a primary select action (trigger press). |
| `OnSqueeze` | `ActionEvent<XRInputSourceEvent>` | Fired on a squeeze action (grip press). |
| `OnVisibilityChange` | `ActionEvent<XRSessionEvent>` | Fired when visibility state changes. |

## Example

```csharp
using var session = await xr.RequestSession("immersive-vr");
using var refSpace = await session.RequestReferenceSpace("local-floor");

// Subscribe using named methods (required for proper cleanup)
session.OnEnd += Session_OnEnd;
session.OnSelect += Session_OnSelect;

// Clean up event handlers before disposal
session.OnEnd -= Session_OnEnd;
session.OnSelect -= Session_OnSelect;

void Session_OnEnd(XRSessionEvent e)
{
    Console.WriteLine("XR session ended");
}

void Session_OnSelect(XRInputSourceEvent e)
{
    Console.WriteLine("User selected something");
}
```

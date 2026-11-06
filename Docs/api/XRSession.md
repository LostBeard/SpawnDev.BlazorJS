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
| `DepthDataFormat` | `string` | Returns the depth-sensing data format with which the session was configured. |
| `DepthUsage` | `string` | Returns the depth-sensing usage with which the session was configured |
| `DomOverlayState` | `XRDOMOverlayState?` | Provides information about the DOM overlay, if the feature is enabled. |
| `EnabledFeatures` | `string[]` | Returns an array of granted session features. |
| `EnvironmentBlendMode` | `string` | Returns this session's blend mode which denotes how much of the real-world environment is visible through the XR device and how the device will blend the device imagery with it. |
| `PreferredReflectionFormat` | `string` | Returns this session's preferred reflection format used for lighting estimation texture data. |
| `InteractionMode` | `string` | Returns this session's interaction mode, which describes the best space (according to the user agent) for the application to draw interactive UI for the current session. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestReferenceSpace(string type)` | `Task<XRReferenceSpace>` | Gets a reference space. Types: `"local"`, `"local-floor"`, `"bounded-floor"`, `"unbounded"`, `"viewer"`. |
| `RequestAnimationFrame(Callback callback)` | `int` | Schedules a callback for the next XR frame. Returns a handle. |
| `UpdateRenderState(XRRenderStateInit options)` | `void` | Updates the render state. |
| `End()` | `Task` | Ends the XR session. |
| `RequestHitTestSource(XRHitTestOptionsInit options)` | `Task<XRHitTestSource>` | Creates a hit test source for AR. |
| `UpdateTargetFrameRate(float rate)` | `Task` | The updateTargetFrameRate() method of the XRSession interface requests that the user agent update the session's target frame rate to the specified value. https://developer.mozilla.org/en-US/docs/Web/API/XRSession/updateTargetFrameRate |
| `CancelAnimationFrame(long handle)` | `void` | The cancelAnimationFrame() method of the XRSession interface cancels an animation frame which was previously requested by calling requestAnimationFrame. |
| `RequestAnimationFrame(Action<double, XRFrame?> callback)` | `long` | Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method. |
| `RequestAnimationFrame(ActionCallback<double, XRFrame?> callback)` | `long` | Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method. |
| `RequestHitTestSourceForTransientInput(XRTransientInputHitTestOptionsInit options)` | `Task<XRTransientInputHitTestSource>` | The requestHitTestSourceForTransientInput() method of the XRSession interface returns a Promise that resolves with an XRTransientInputHitTestSource object that can be passed to XRFrame.getHitTestResultsForTransientInput(). |
| `RequestLightProbe(XRLightProbeInit? options = null)` | `Task<XRLightProbe>` | The requestLightProbe() method of the XRSession interface returns a Promise that resolves with an XRLightProbe object that estimates lighting information at a given point in the user's environment. |
| `RequestReferenceSpace(EnumString<XRReferenceSpaceType> type)` | `Task<XRReferenceSpace>` | Requests that a new XRReferenceSpace of the specified type be created. Returns a promise which resolves with the XRReferenceSpace or XRBoundedReferenceSpace which was requested, or throws a NotSupportedError DOMException if the requested space type isn't supported by the device. |
| `UpdateRenderState(XRRenderStateInit? state = null)` | `void` | Updates the properties of the session's render state. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnd` | `ActionEvent<XRSessionEvent>` | Fired when the session ends. |
| `OnInputSourcesChange` | `ActionEvent<XRInputSourcesChangeEvent>` | Fired when input sources change. |
| `OnSelect` | `ActionEvent<XRInputSourceEvent>` | Fired on a primary select action (trigger press). |
| `OnSqueeze` | `ActionEvent<XRInputSourceEvent>` | Fired on a squeeze action (grip press). |
| `OnVisibilityChange` | `ActionEvent<XRSessionEvent>` | Fired when visibility state changes. |
| `OnSelectEnd` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which gets sent to the session object when one of its input devices finishes its primary action or gets disconnected while in the process of handling a primary action. For example: for button or trigger actions, this means the button has been released; for spoken commands, it means the user has finished speaking. This is the last of the three select* events to be sent. Also available through the onselectend event handler property. |
| `OnSelectStart` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which is sent to the session object when one of its input devices is first engaged by the user in such a way as to cause the primary action to begin. This is the first of the session* event to be sent. Also available through the onselectstart event handler property. |
| `OnSqueezeEnd` | `ActionEvent<XRInputSourceEvent>` | An XRInputSourceEvent sent to the XRSession when the primary squeeze action ends, whether or not the action was successful. Also available using the onsqueezeend event handler property. |
| `OnSqueezeStart` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which is sent to the XRSession when the user initially squeezes a squeezable controller. This may be, for example, a trigger which is used to represent grabbing objects, or might represent actual squeezing when wearing a haptic glove. Also available through the onsqueezestart event handler property. |

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

# XRSession

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebXR/XRSession.cs`  
**MDN Reference:** [XRSession on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession)

> The XRSession interface of the WebXR Device API represents an ongoing XR session, providing methods and properties used to interact with and control the session. To open a WebXR session, use the XRSystem interface's requestSession() method. https://www.w3.org/TR/webxr/#xrsession https://developer.mozilla.org/en-US/docs/Web/API/XRSession

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DepthDataFormat` | `string` | get | Returns the depth-sensing data format with which the session was configured. |
| `DepthUsage` | `string` | get | Returns the depth-sensing usage with which the session was configured |
| `DomOverlayState` | `XRDOMOverlayState?` | get | Provides information about the DOM overlay, if the feature is enabled. |
| `EnabledFeatures` | `string[]` | get | Returns an array of granted session features. |
| `EnvironmentBlendMode` | `string` | get | Returns this session's blend mode which denotes how much of the real-world environment is visible through the XR device and how the device will blend the device imagery with it. |
| `PreferredReflectionFormat` | `string` | get | Returns this session's preferred reflection format used for lighting estimation texture data. |
| `InputSources` | `Array<XRInputSource>` | get | Returns a list of this session's XRInputSources, each representing an input device used to control the camera and/or scene. |
| `InteractionMode` | `string` | get | Returns this session's interaction mode, which describes the best space (according to the user agent) for the application to draw interactive UI for the current session. |
| `RenderState` | `XRRenderState` | get | An XRRenderState object which contains options affecting how the imagery is rendered. This includes things such as the near and far clipping planes (distances defining how close and how far away objects can be and still get rendered), as well as field of view information. |
| `VisibilityState` | `string` | get | A string indicating whether or not the session's imagery is visible to the user, and if so, if it's being visible but not currently the target for user events. |
| `FrameRate` | `float?` | get | A float value indicating the current frame rate of the XR session, or null if not available. https://developer.mozilla.org/en-US/docs/Web/API/XRSession/frameRate |
| `SupportedFrameRates` | `Float32Array?` | get | Returns a Float32Array of supported frame rates for the XR session, or null if not supported. https://developer.mozilla.org/en-US/docs/Web/API/XRSession/supportedFrameRates |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `UpdateTargetFrameRate(float rate)` | `Task` | The updateTargetFrameRate() method of the XRSession interface requests that the user agent update the session's target frame rate to the specified value. https://developer.mozilla.org/en-US/docs/Web/API/XRSession/updateTargetFrameRate A float indicating the target frame rate in frames per second. |
| `End()` | `Task` | Ends the WebXR session. Returns a promise which resolves when the session has been shut down. |
| `CancelAnimationFrame(long handle)` | `void` | The cancelAnimationFrame() method of the XRSession interface cancels an animation frame which was previously requested by calling requestAnimationFrame. |
| `RequestAnimationFrame(Action<double, XRFrame?> callback)` | `long` | Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method. |
| `RequestAnimationFrame(ActionCallback<double, XRFrame?> callback)` | `long` | Schedules the specified method to be called the next time the user agent is working on rendering an animation frame for the WebXR device. Returns an integer value which can be used to identify the request for the purposes of canceling the callback using cancelAnimationFrame(). This method is comparable to the Window.requestAnimationFrame() method. |
| `RequestHitTestSource(XRHitTestOptionsInit options)` | `Task<XRHitTestSource>` | Requests an XRHitTestSource object that handles hit test subscription. |
| `RequestHitTestSourceForTransientInput(XRTransientInputHitTestOptionsInit options)` | `Task<XRTransientInputHitTestSource>` | The requestHitTestSourceForTransientInput() method of the XRSession interface returns a Promise that resolves with an XRTransientInputHitTestSource object that can be passed to XRFrame.getHitTestResultsForTransientInput(). |
| `RequestLightProbe(XRLightProbeInit? options)` | `Task<XRLightProbe>` | The requestLightProbe() method of the XRSession interface returns a Promise that resolves with an XRLightProbe object that estimates lighting information at a given point in the user's environment. |
| `RequestReferenceSpace(EnumString<XRReferenceSpaceType> type)` | `Task<XRReferenceSpace>` | Requests that a new XRReferenceSpace of the specified type be created. Returns a promise which resolves with the XRReferenceSpace or XRBoundedReferenceSpace which was requested, or throws a NotSupportedError DOMException if the requested space type isn't supported by the device. |
| `UpdateRenderState(XRRenderStateInit? state)` | `void` | Updates the properties of the session's render state. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnd` | `ActionEvent<XRSessionEvent>` | An end event is fired at an XRSession object when the WebXR session has ended, either because the web application has chosen to stop the session, or because the user agent terminated the session. |
| `OnInputSourcesChange` | `ActionEvent<XRInputSourcesChangeEvent>` | The inputsourceschange event is sent to an XRSession when the set of available WebXR input devices changes. |
| `OnSelect` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which is sent to the session when one of the session's input sources has successfully completed a primary action. This generally corresponds to the user pressing a trigger, touchpad, or button, speaks a command, or performs a recognizable gesture. The select event is sent after the selectstart event is sent and immediately before the selectend event is sent. If select is not sent, then the select action was aborted before being completed. Also available through the onselect event handler property. |
| `OnSelectEnd` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which gets sent to the session object when one of its input devices finishes its primary action or gets disconnected while in the process of handling a primary action. For example: for button or trigger actions, this means the button has been released; for spoken commands, it means the user has finished speaking. This is the last of the three select* events to be sent. Also available through the onselectend event handler property. |
| `OnSelectStart` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which is sent to the session object when one of its input devices is first engaged by the user in such a way as to cause the primary action to begin. This is the first of the session* event to be sent. Also available through the onselectstart event handler property. |
| `OnSqueeze` | `ActionEvent<XRInputSourceEvent>` | An XRInputSourceEvent sent to indicate that a primary squeeze action has successfully completed. This indicates that the device being squeezed has been released, and may represent dropping a grabbed object, for example. It is sent immediately before the squeezeend event is sent to indicate that the squeeze action is over. Also available through the onsqueeze event handler property. |
| `OnSqueezeEnd` | `ActionEvent<XRInputSourceEvent>` | An XRInputSourceEvent sent to the XRSession when the primary squeeze action ends, whether or not the action was successful. Also available using the onsqueezeend event handler property. |
| `OnSqueezeStart` | `ActionEvent<XRInputSourceEvent>` | An event of type XRInputSourceEvent which is sent to the XRSession when the user initially squeezes a squeezable controller. This may be, for example, a trigger which is used to represent grabbing objects, or might represent actual squeezing when wearing a haptic glove. Also available through the onsqueezestart event handler property. |
| `OnVisibilityChange` | `ActionEvent<XRSessionEvent>` | An XRSessionEvent which is sent to the session when its visibility state as indicated by the visibilityState changes. Also available through the onvisibilitychange event handler property. |

## Example

```csharp
// Request an immersive VR session (see XRSystem for setup)
using var navigator = JS.Get<Navigator>("navigator");
using var xr = navigator.XR;
using var session = await xr.RequestSession(XRSessionMode.ImmersiveVR);

// Request a reference space for positioning
using var refSpace = await session.RequestReferenceSpace(XRReferenceSpaceType.Local);

// Update render state (e.g., set the WebGL layer)
session.UpdateRenderState(new XRRenderStateInit
{
    // Set the base layer for rendering
});

// Check session properties
Console.WriteLine($"Visibility: {session.VisibilityState}");
Console.WriteLine($"Frame rate: {session.FrameRate}");
Console.WriteLine($"Enabled features: {string.Join(", ", session.EnabledFeatures)}");

// Set up the XR render loop
session.RequestAnimationFrame((double time, XRFrame? xrFrame) =>
{
    if (xrFrame != null)
    {
        // Get viewer pose and render the scene
        // Continue the render loop
        session.RequestAnimationFrame(/* ... */);
    }
});

// Listen for controller input events
session.OnSelect += (XRInputSourceEvent e) =>
{
    Console.WriteLine("Controller select action triggered");
};

session.OnEnd += (XRSessionEvent e) =>
{
    Console.WriteLine("XR session ended");
};

// End the session when done
await session.End();
```


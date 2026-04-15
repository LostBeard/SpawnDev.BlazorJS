# XRInputSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRInputSource.cs`  
**MDN Reference:** [XRInputSource on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRInputSource)

> The WebXR Device API's XRInputSource interface describes a single source of control input which is part of the user's WebXR-compatible virtual or augmented reality system. The device is specific to the platform being used, but provides the direction in which it is being aimed and optionally may generate events if the user triggers performs actions using the device. https://developer.mozilla.org/en-US/docs/Web/API/XRInputSource

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Gamepad` | `Gamepad?` | get | A Gamepad object describing the state of the buttons and axes on the XR input source, if it is a gamepad or comparable device. If the device isn't a gamepad-like device, this property's value is null. |
| `Hand` | `XRHand?` | get | An XRHand object providing access to the underlying hand-tracking device. |
| `Handedness` | `string` | get | A string that indicates which hand the device represented by this XRInputSource is being used in, if any. The value will be left, right, or none. |
| `Profiles` | `string[]` | get | An array of strings, each specifying the name of an input profile describing the preferred visual representation and behavior of this input source. |
| `TargetRayMode` | `string` | get | A string indicating the methodology used to produce the target ray: gaze, tracked-pointer, or screen. |
| `TargetRaySpace` | `XRSpace?` | get | An XRSpace object defining the origin of the target ray and the direction in which it extends. This space is established using the method defined by targetRayMode. |
| `GripSpace` | `XRSpace?` | get | An XRSpace whose native origin tracks the pose used to render virtual objects so they appear to be held in the user's hand. Null if the input source is not inherently associated with a hand. |


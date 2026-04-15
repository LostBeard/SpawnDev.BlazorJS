# XRReferenceSpaceEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebXR/XRReferenceSpaceEvent.cs`  
**MDN Reference:** [XRReferenceSpaceEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpaceEvent)

> The WebXR Device API interface XRReferenceSpaceEvent represents an event sent to an XRReferenceSpace. Currently, the only event that uses this type is the reset event. https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpaceEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ReferenceSpace` | `XRReferenceSpace` | get | An XRReferenceSpace indicating the reference space that generated the event. |
| `Transform` | `XRRigidTransform` | get | An XRRigidTransform object indicating the position and orientation of the specified referenceSpace's native origin after the event, defined relative to the coordinate system before the event. |


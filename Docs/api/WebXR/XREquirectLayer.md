# XREquirectLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRCompositionLayer`  
**Source:** `JSObjects/WebXR/XREquirectLayer.cs`  
**MDN Reference:** [XREquirectLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XREquirectLayer)

> https://developer.mozilla.org/en-US/docs/Web/API/XREquirectLayer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CentralHorizontalAngle` | `float` | get | A number indicating the central horizontal angle in radians for the sphere. |
| `LowerVerticalAngle` | `float` | get/set | A number indicating the lower vertical angle in radians for the sphere. |
| `Radius` | `float` | get | A number indicating the radius of the sphere. |
| `Space` | `XRSpace` | get | An XRSpace representing the layer's spatial relationship with the user's physical environment. |
| `Transform` | `XRRigidTransform` | get | An XRRigidTransform representing the offset and orientation relative to space. |
| `UpperVerticalAngle` | `float` | get | A number indicating the upper vertical angle in radians for the sphere. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnRedraw` | `ActionEvent<XRLayerEvent>` | Sent to the XREquirectLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame. |


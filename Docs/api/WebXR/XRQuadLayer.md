# XRQuadLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRCompositionLayer`  
**Source:** `JSObjects/WebXR/XRQuadLayer.cs`  
**MDN Reference:** [XRQuadLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRQuadLayer)

> https://developer.mozilla.org/en-US/docs/Web/API/XRQuadLayer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Height` | `float` | get/set | Represents the height of the layer in meters. |
| `Width` | `float` | get | Represents the width of the layer in meters. |
| `Space` | `XRSpace` | get | An XRSpace representing the layer's spatial relationship with the user's physical environment. |
| `Transform` | `XRRigidTransform` | get | An XRRigidTransform representing the offset and orientation relative to space. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnRedraw` | `ActionEvent<XRLayerEvent>` | Sent to the XRQuadLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame. |


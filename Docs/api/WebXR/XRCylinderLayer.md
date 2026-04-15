# XRCylinderLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRCompositionLayer`  
**Source:** `JSObjects/WebXR/XRCylinderLayer.cs`  
**MDN Reference:** [XRCylinderLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRCylinderLayer)

> https://developer.mozilla.org/en-US/docs/Web/API/XRCylinderLayer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AspectRatio` | `float` | get | A number indicating the ratio of the visible cylinder section. It is the ratio of the width of the visible section of the cylinder divided by its height. The width is calculated by multiplying the radius with the centralAngle. |
| `CentralAngle` | `float` | get/set | A number indicating the angle in radians of the visible section of the cylinder. |
| `Radius` | `float` | get | A number indicating the radius of the cylinder. |
| `Space` | `XRSpace` | get | An XRSpace representing the layer's spatial relationship with the user's physical environment. |
| `Transform` | `XRRigidTransform` | get | An XRRigidTransform representing the offset and orientation relative to space. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnRedraw` | `ActionEvent<XRLayerEvent>` | Sent to the XRCylinderLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame. |


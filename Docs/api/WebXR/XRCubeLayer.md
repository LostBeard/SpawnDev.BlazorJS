# XRCubeLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRCompositionLayer`  
**Source:** `JSObjects/WebXR/XRCubeLayer.cs`  
**MDN Reference:** [XRCubeLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRCubeLayer)

> The XRCubeLayer interface of the WebXR Device API is a layer that renders directly from a cubemap and projects it onto the inside faces of a cube. https://developer.mozilla.org/en-US/docs/Web/API/XRCubeLayer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Space` | `XRSpace` | get | An XRSpace representing the layer's spatial relationship with the user's physical environment. |
| `Orientation` | `DOMPointReadOnly` | get | A DOMPointReadOnly representing the orientation relative to the space property. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnRedraw` | `ActionEvent<XRLayerEvent>` | The redraw event is sent to the XRCubeLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame. |


# XRPlane

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRPlane.cs`  

> The XRPlane interface of the WebXR Device API describes a detected flat surface in the real world. An XRPlane is detected by the underlying XR system and represents a polygon on a surface. https://immersive-web.github.io/real-world-geometry/plane-detection.html#xrplane-interface

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PlaneSpace` | `XRSpace` | get | Returns an XRSpace tracking the plane's position and orientation. |
| `Polygon` | `DOMPointReadOnly[]` | get | Returns an array of DOMPointReadOnly objects representing the vertices of the plane's polygon, in the coordinate system of planeSpace. |
| `LastChangedTime` | `double` | get | Returns a DOMHighResTimeStamp indicating the last time the plane's data was updated. |
| `SemanticLabel` | `string?` | get | Returns a string indicating the semantic label of the plane (e.g., "floor", "wall", "ceiling"), or null if not available. |
| `Orientation` | `string?` | get | Returns a string indicating the orientation of the plane. Values include "horizontal" and "vertical". |


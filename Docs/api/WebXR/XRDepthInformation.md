# XRDepthInformation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRDepthInformation.cs`  
**MDN Reference:** [XRDepthInformation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRDepthInformation)

> https://developer.mozilla.org/en-US/docs/Web/API/XRDepthInformation

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `int` | get | Contains the width of the depth buffer (number of columns). |
| `Height` | `int` | get | Contains the height of the depth buffer (number of rows). |
| `NormDepthBufferFromNormView` | `XRRigidTransform` | get | An XRRigidTransform that needs to be applied when indexing into the depth buffer. The transformation that the matrix represents changes the coordinate system from normalized view coordinates to normalized depth-buffer coordinates that can then be scaled by depth buffer's width and height to obtain the absolute depth buffer coordinates. |
| `RawValueToMeters` | `float` | get | Contains the scale factor by which the raw depth values must be multiplied in order to get the depths in meters. |


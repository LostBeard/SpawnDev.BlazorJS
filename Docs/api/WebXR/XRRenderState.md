# XRRenderState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRRenderState.cs`  
**MDN Reference:** [XRRenderState on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRRenderState)

> https://developer.mozilla.org/en-US/docs/Web/API/XRRenderState

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BaseLayer` | `XRWebGLLayer` | get | The XRWebGLLayer from which the browser's compositing system obtains the image for the XR session. |
| `DepthFar` | `float` | get | The distance, in meters, of the far clip plane from the viewer. The far clip plane is the plane which is parallel to the display beyond which rendering of the scene no longer takes place. This, essentially, specifies the maximum distance the user can see. |
| `DepthNear` | `float` | get | The distance, in meters, of the near clip plane from the viewer. The near clip plane is the plane, parallel to the display, at which rendering of the scene begins. Any closer to the viewer than this, and no portions of the scene are drawn. |
| `InlineVerticalFieldOfView` | `float?` | get | The default vertical field of view, defined in radians, to use when the session is in inline mode. null for all immersive sessions. |
| `Layers` | `Array<XRLayer>` | get | An ordered array containing XRLayer objects that are displayed by the XR compositor. |


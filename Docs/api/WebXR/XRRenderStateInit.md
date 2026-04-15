# XRRenderStateInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRRenderStateInit.cs`  

> https://www.w3.org/TR/webxr/#dictdef-xrrenderstateinit

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRRenderStateInit` | `class` | get | https://www.w3.org/TR/webxr/#dictdef-xrrenderstateinit |
| `DepthFar` | `double` | get | depthNear and depthFar are used in the computation of the projectionMatrix of XRViews. When the projectionMatrix is used during rendering, only geometry with a distance to the viewer that falls between depthNear and depthFar will be drawn. They also determine how the values of an XRWebGLLayer depth buffer are interpreted. depthNear MAY be greater than depthFar. |
| `PassthroughFullyObscured` | `bool?` | get |  |
| `InlineVerticalFieldOfView` | `double?` | get |  |
| `BaseLayer` | `XRWebGLLayer?` | get/set |  |
| `Layers` | `IEnumerable<XRLayer>?` | get |  |


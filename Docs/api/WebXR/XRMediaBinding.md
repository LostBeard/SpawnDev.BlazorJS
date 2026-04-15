# XRMediaBinding

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRMediaBinding.cs`  

> The XRMediaBinding interface is used to create XR layers that display the content of an HTMLVideoElement. https://immersive-web.github.io/layers/#xrmediabinding

## Constructors

| Signature | Description |
|---|---|
| `XRMediaBinding(XRSession session, XRWebGLBinding binding)` | Creates a new XRMediaBinding associated with the specified XRSession and XRWebGLBinding. An XRSession object to associate with the media binding. An XRWebGLBinding object to use for creating media layers. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRMediaQuadLayerInit` | `class` | get | Configuration options for XRMediaBinding.createQuadLayer(). |
| `Transform` | `XRRigidTransform?` | get/set | An XRRigidTransform specifying the position and orientation of the layer in the space. |
| `Width` | `float?` | get/set | The width of the quad layer in meters. |
| `Height` | `float?` | get | The height of the quad layer in meters. |
| `XRMediaCylinderLayerInit` | `class` | get | Configuration options for XRMediaBinding.createCylinderLayer(). |
| `Radius` | `float?` | get/set | The radius of the cylinder in meters. |
| `CentralAngle` | `float?` | get/set | The central angle of the cylinder in radians. |
| `AspectRatio` | `float?` | get | The aspect ratio of the cylinder (width / height). |
| `XRMediaEquirectLayerInit` | `class` | get | Configuration options for XRMediaBinding.createEquirectLayer(). |
| `CentralHorizontalAngle` | `float?` | get/set | The central horizontal angle of the equirect layer in radians. |
| `UpperVerticalAngle` | `float?` | get/set | The upper vertical angle of the portion of the sphere in radians. |
| `LowerVerticalAngle` | `float?` | get | The lower vertical angle of the portion of the sphere in radians. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateQuadLayer(HTMLVideoElement video, XRMediaQuadLayerInit? init)` | `XRQuadLayer` | Creates an XRQuadLayer that displays a flat video on a quad in the XR scene. An HTMLVideoElement to display. Optional configuration for the quad layer. |
| `CreateCylinderLayer(HTMLVideoElement video, XRMediaCylinderLayerInit? init)` | `XRCylinderLayer` | Creates an XRCylinderLayer that displays a video on a cylinder surface in the XR scene. An HTMLVideoElement to display. Optional configuration for the cylinder layer. |
| `CreateEquirectLayer(HTMLVideoElement video, XRMediaEquirectLayerInit? init)` | `XREquirectLayer` | Creates an XREquirectLayer that displays a video on an equirectangular surface in the XR scene. An HTMLVideoElement to display. Optional configuration for the equirect layer. |


# XRCompositionLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRLayer`  
**Source:** `JSObjects/WebXR/XRCompositionLayer.cs`  
**MDN Reference:** [XRCompositionLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRCompositionLayer)

> The XRCompositionLayer interface of the WebXR Device API is a base class that defines a set of common properties and behaviors for WebXR layer types. It is not constructable on its own. https://developer.mozilla.org/en-US/docs/Web/API/XRCompositionLayer https://www.w3.org/TR/webxrlayers-1/#xrcompositionlayertype

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BlendTextureSourceAlpha` | `bool` | get | A boolean enabling the layer's texture alpha channel. |
| `Layout` | `string` | get | The read-only layout property of the XRCompositionLayer interface is the layout type of the layer. default The layer accommodates all views of the session.It is recommended to use the texture-array texture type for default layouts. mono A single XRSubImage is allocated and presented to both eyes. stereo The user agent decides how it allocates the XRSubImage (one or two) and the layout(top/bottom or left/right). It is recommended to use the texture-array texture type for stereo layouts. stereo-left-right A single XRSubImage is allocated.Left eye gets the left area of the texture, right eye the right. This layout is designed to minimize draw calls for content that is already in stereo (for example stereo videos or images). stereo-top-bottom A single XRSubImage is allocated.Left eye gets the top area of the texture, right eye the bottom.This layout is designed to minimize draw calls for content that is already in stereo (for example stereo videos or images). |
| `MipLevels` | `int` | get | The number of mip levels in the color and texture data for the layer. |
| `NeedsRedraw` | `int` | get | A boolean signaling that the layer should be re-rendered in the next frame. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Destroy()` | `void` | Deletes the underlying layer attachments. |


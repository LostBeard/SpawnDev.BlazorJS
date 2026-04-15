# XRProjectionLayer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRCompositionLayer`  
**Source:** `JSObjects/WebXR/XRProjectionLayer.cs`  
**MDN Reference:** [XRProjectionLayer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRProjectionLayer)

> The XRProjectionLayer interface of the WebXR Device API is a layer that fills the entire view of the observer and is refreshed close to the device's native frame rate. XRProjectionLayer is supported by all XRSession objects (no layers feature descriptor is needed). https://developer.mozilla.org/en-US/docs/Web/API/XRProjectionLayer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FixedFoveation` | `float` | get | A number indicating the amount of foveation used by the XR compositor for the layer. Fixed Foveated Rendering (FFR) renders the edges of the eye textures at a lower resolution than the center and reduces the GPU load. |
| `IgnoreDepthValues` | `bool` | get | A boolean indicating that the XR compositor is not making use of depth buffer values when rendering the layer. |
| `TextureArrayLength` | `int` | get | The layer's layer count for array textures when using texture-array as the textureType. |
| `TextureHeight` | `int` | get | The height in pixels of the color textures of this layer. |
| `TextureWidth` | `int` | get | The width in pixels of the color textures of this layer. |


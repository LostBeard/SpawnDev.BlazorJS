# XRWebGLBinding

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRWebGLBinding.cs`  
**MDN Reference:** [XRWebGLBinding on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding)

> The XRWebGLBinding interface is used to create layers that have a GPU backend. https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding https://docs.w3cub.com/dom/xrwebglbinding

## Constructors

| Signature | Description |
|---|---|
| `XRWebGLBinding(XRSession session, WebGLRenderingContext context)` | The XRWebGLBinding() constructor creates and returns a new XRWebGLBinding object. An XRSession object specifying the WebXR session which will be rendered using the WebGL context. A WebGLRenderingContext or WebGL2RenderingContext identifying the WebGL drawing context to use for rendering the scene for the specified WebXR session. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NativeProjectionScaleFactor` | `float` | get | The read-only nativeProjectionScaleFactor property of the XRWebGLBinding interface represents the scaling factor by which the projection layer's resolution is multiplied by to get the native resolution of the WebXR device's frame buffer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateCubeLayer(XRCubeLayerInit options)` | `XRCubeLayer` | The createCubeLayer() method of the XRWebGLBinding interface returns an XRCubeLayer object, which is a layer that renders directly from a cubemap, and projects it onto the inside faces of a cube. |
| `CreateCylinderLayer(XRCylinderLayerInit options)` | `XRCylinderLayer` | The createCylinderLayer() method of the XRWebGLBinding interface returns an XRCylinderLayer object, which is a layer that takes up a curved rectangular space in the virtual environment. |
| `CreateProjectionLayer(XRProjectionLayerInit options)` | `XRProjectionLayer` | The createProjectionLayer() method of the XRWebGLBinding interface returns an XRProjectionLayer object which is a layer that fills the entire view of the observer and is refreshed close to the device's native frame rate. |
| `CreateQuadLayer(XRQuadLayerInit options)` | `XRQuadLayer` | The createQuadLayer() method of the XRWebGLBinding interface returns an XRQuadLayer object which is a layer that takes up a flat rectangular space in the virtual environment. |
| `CreateEquirectLayer(XREquirectLayerInit options)` | `XREquirectLayer` | The createEquirectLayer() method of the XRWebGLBinding interface returns an XREquirectLayer object, which is a layer that maps equirectangular coded data onto the inside of a sphere. |
| `GetDepthInformation(XRView view)` | `XRWebGLDepthInformation` | Returns an XRWebGLDepthInformation object containing WebGL depth information. |
| `GetReflectionCubeMap(XRLightProbe lightProbe)` | `WebGLTexture` | The getReflectionCubeMap() method of the XRWebGLBinding interface returns a WebGLTexture object containing a reflection cube map texture. The texture format is specified by the session's reflectionFormat. See the options parameter on XRSession.requestLightProbe() and XRSession.preferredReflectionFormat for more details. By default, the srgba8 format is used. When using a rgba16f format, you need to be within a WebGL 2.0 context or enable the OES_texture_half_float extension within WebGL 1.0 contexts. |
| `GetSubImage(XRCompositionLayer layer, XRFrame frame, string eye)` | `XRWebGLSubImage` | The getSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render. The XRCompositionLayer to use for rendering (can be all types of XRCompositionLayer objects except XRProjectionLayer, see XRWebGLBinding.getViewSubImage() for rendering projection layers). The XRFrame frame to use for rendering. An optional XRView.eye indicating which view's eye to use for rendering. 'left', 'right', or 'none'. Defaults to none. A XRWebGLSubImage object. |
| `GetSubImage(XRCompositionLayer layer, XRFrame frame)` | `XRWebGLSubImage` | The getSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render. The XRCompositionLayer to use for rendering (can be all types of XRCompositionLayer objects except XRProjectionLayer, see XRWebGLBinding.getViewSubImage() for rendering projection layers). The XRFrame frame to use for rendering. A XRWebGLSubImage object. |
| `GetViewSubImage(XRProjectionLayer layer, XRView view)` | `XRWebGLSubImage` | The getViewSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render for a view. The XRProjectionLayer to use for rendering (to render other layer types, see XRWebGLBinding.getSubImage()). The XRView to use for rendering. A XRWebGLSubImage object. |


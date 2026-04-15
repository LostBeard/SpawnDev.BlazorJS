# XRGPUBinding

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRGPUBinding.cs`  

> The XRGPUBinding interface is used to create GPU layers for WebXR rendering with WebGPU. This is the WebGPU counterpart to XRWebGLBinding. Requires the "webgpu" feature in the XR session and Chrome's webxr-webgpu flag. https://immersive-web.github.io/WebXR-WebGPU-Binding/

## Constructors

| Signature | Description |
|---|---|
| `XRGPUBinding(XRSession session, GPUDevice device)` | Creates a new XRGPUBinding for the given XR session and GPU device. The XRSession to bind to. The GPUDevice to use for rendering. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NativeProjectionScaleFactor` | `float` | get | The read-only nativeProjectionScaleFactor property represents the scaling factor by which the projection layer's resolution is multiplied to get the native resolution. |
| `XRGPUProjectionLayerInit` | `class` | get/set | Configuration options for XRGPUBinding.createProjectionLayer(). |
| `DepthStencilFormat` | `string?` | get/set | The GPUTextureFormat for the depth/stencil texture, or null for no depth. |
| `ScaleFactor` | `float?` | get | A scaling factor for the projection layer resolution. Default 1.0. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateProjectionLayer(XRGPUProjectionLayerInit? options)` | `XRProjectionLayer` | Creates an XRProjectionLayer that fills the entire view and is refreshed at the device's native frame rate. Configuration options for the projection layer. An XRProjectionLayer object. |
| `GetViewSubImage(XRProjectionLayer layer, XRView view)` | `XRGPUSubImage` | Returns an XRGPUSubImage for a projection layer view, providing the GPU texture to render into. The XRProjectionLayer to get the sub-image for. The XRView (eye) to get the sub-image for. An XRGPUSubImage containing the GPU texture and viewport. |
| `GetPreferredColorFormat()` | `string` | Returns the preferred GPU texture format for the XR session's color attachments. A GPUTextureFormat string (e.g., "rgba8unorm"). |


using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRWebGLBinding interface is used to create layers that have a GPU backend.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding
    /// </summary>
    public class XRWebGLBinding : JSObject
    {
        /// <inheritdoc/>
        public XRWebGLBinding(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
    /// <summary>
    /// The XRCamera interface is introduced as a way to expose information about the camera texture that can be obtained from XRWebGLBinding.<br/>
    /// https://immersive-web.github.io/raw-camera-access/#xr-camera-section
    /// </summary>
    public class WebXRCamera : JSObject
    {
        /// <inheritdoc/>
        public WebXRCamera(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}

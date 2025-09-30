using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRCamera interface is introduced as a way to expose information about the camera texture that can be obtained from XRWebGLBinding.<br/>
    /// https://immersive-web.github.io/raw-camera-access/#xr-camera-section
    /// </summary>
    public class XRCamera : JSObject
    {
        /// <inheritdoc/>
        public XRCamera(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRCamera contains width attribute that contains the width (in texels) of the camera image.
        /// </summary>
        public long Width => JSRef!.Get<long>("width");
        /// <summary>
        /// The XRCamera contains height attribute that contains the height (in texels) of the camera image.
        /// </summary>
        public long Height => JSRef!.Get<long>("height");
    }
}

using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrsession
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSession
    /// </summary>
    public class XRSession : EventTarget
    {
        /// <inheritdoc/>
        public XRSession(IJSInProcessObjectReference _ref) : base(_ref) { }

        public void End() => JSRef!.CallVoid("end");

        public Task<XRReferenceSpace> RequestReferenceSpace(EnumString<XRReferenceSpaceType> type) => JSRef!.CallAsync<XRReferenceSpace>("requestReferenceSpace", type);

        public Task<XRHitTestSource> RequestHitTestSource(object options) => JSRef!.CallAsync<XRHitTestSource>("requestHitTestSource", options);

        public void UpdateRenderState(XRRenderStateInit? state = null)
        {
            if (state == null) JSRef!.CallVoid("updateRenderState");
            else JSRef!.CallVoid("updateRenderState", state);
        }

        public long RequestAnimationFrame(Action<double, XRFrame?> callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));

        public long RequestAnimationFrame(ActionCallback<double, XRFrame?> callback) => JSRef!.Call<long>("requestAnimationFrame", callback);


        public XRRenderState RenderState => JSRef!.Get<XRRenderState>("renderState");
    }
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRRenderState
    /// </summary>
    public class XRRenderState : JSObject
    {
        /// <inheritdoc/>
        public XRRenderState(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRWebGLLayer from which the browser's compositing system obtains the image for the XR session.
        /// </summary>
        public XRWebGLLayer BaseLayer => JSRef!.Get<XRWebGLLayer>("baseLayer");
    }
}

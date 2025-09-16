using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestResult
    /// </summary>
    public class XRHitTestResult : JSObject
    {
        /// <inheritdoc/>
        public XRHitTestResult(IJSInProcessObjectReference _ref) : base(_ref) { }

        public XRPose GetPose(XRReferenceSpace referenceSpace) => JSRef!.Call<XRPose>("getPose", referenceSpace);
    }
}

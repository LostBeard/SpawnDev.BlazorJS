using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrframe-interface
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRFrame
    /// </summary>
    public class XRFrame : JSObject
    {
        /// <inheritdoc/>
        public XRFrame(IJSInProcessObjectReference _ref) : base(_ref) { }


        public XRHitTestResult[] GetHitTestResults(XRHitTestSource hitTestSource) => JSRef!.Call<XRHitTestResult[]>("getHitTestResults", hitTestSource);


        public XRViewerPose? GetViewerPose(XRReferenceSpace referenceSpace) => JSRef!.Call<XRViewerPose?>("getViewerPose",  referenceSpace);
    }
}

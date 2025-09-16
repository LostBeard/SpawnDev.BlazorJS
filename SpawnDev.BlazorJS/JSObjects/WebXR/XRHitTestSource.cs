using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRHitTestSource interface of the WebXR Device API handles hit test subscriptions. You can get an XRHitTestSource object by using the XRSession.requestHitTestSource() method.<br/>
    /// This object doesn't itself contain hit test results, but it is used to compute hit tests for each XRFrame by calling XRFrame.getHitTestResults(), which returns XRHitTestResult objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestSource
    /// </summary>
    public class XRHitTestSource : EventTarget
    {
        /// <inheritdoc/>
        public XRHitTestSource(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

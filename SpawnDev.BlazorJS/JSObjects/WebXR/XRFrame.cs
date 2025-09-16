using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class XRFrame : JSObject
    {
        /// <inheritdoc/>
        public XRFrame(IJSInProcessObjectReference _ref) : base(_ref) { }


        public XRHitTestResult[] GetHitTestResults(XRHitTestSource hitTestSource) => JSRef!.Call<XRHitTestResult[]>("getHitTestResults", hitTestSource);
    }
}

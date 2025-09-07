using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrspace
    /// </summary>
    public class XRSpace : EventTarget
    {
        /// <inheritdoc/>
        public XRSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

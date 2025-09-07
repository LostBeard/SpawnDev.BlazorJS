using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrreferencespace
    /// </summary>
    public class XRReferenceSpace : XRSpace
    {
        /// <inheritdoc/>
        public XRReferenceSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

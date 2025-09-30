using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRAnchor
    /// </summary>
    public class XRAnchor : JSObject
    {
        /// <inheritdoc/>
        public XRAnchor(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an XRSpace object to locate the anchor relative to other XRSpace objects.
        /// </summary>
        public XRSpace AnchorSpace => JSRef!.Get<XRSpace>("anchorSpace");
        /// <summary>
        /// Removes the anchor.
        /// </summary>
        /// <returns></returns>
        public Task<XRAnchor> Delete() => JSRef!.CallAsync<XRAnchor>("delete");
    }
}

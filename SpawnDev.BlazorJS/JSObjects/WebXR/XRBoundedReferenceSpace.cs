using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrboundedreferencespace
    /// </summary>
    public class XRBoundedReferenceSpace : XRReferenceSpace
    {
        /// <inheritdoc/>
        public XRBoundedReferenceSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

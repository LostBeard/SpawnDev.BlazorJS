using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRAnchorSet
    /// </summary>
    public class XRAnchorSet : Set<XRAnchor>
    {
        /// <inheritdoc/>
        public XRAnchorSet(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public XRAnchorSet(IEnumerable<XRAnchor> iterable) : base(JS.New("Set", iterable)) { }
    }
}

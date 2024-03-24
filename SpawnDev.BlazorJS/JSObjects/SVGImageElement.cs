using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SVGImageElement interface corresponds to the image element.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/SVGImageElement
    /// </summary>
    public class SVGImageElement : SVGGraphicsElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SVGImageElement(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

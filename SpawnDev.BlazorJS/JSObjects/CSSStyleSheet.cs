using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSStyleSheet interface represents a single CSS stylesheet, and lets you inspect and modify the list of rules contained in the stylesheet. It inherits properties and methods from its parent, StyleSheet.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleSheet
    /// </summary>
    public class CSSStyleSheet : StyleSheet
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CSSStyleSheet(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}

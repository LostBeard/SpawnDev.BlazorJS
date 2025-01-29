using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object implementing the StyleSheet interface represents a single style sheet. CSS style sheets will further implement the more specialized CSSStyleSheet interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/StyleSheet
    /// </summary>
    public class StyleSheet : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public StyleSheet(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}

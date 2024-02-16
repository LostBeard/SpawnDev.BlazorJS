using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSRule interface represents a single CSS rule. There are several types of rules which inherit properties from CSSRule.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSRule
    /// </summary>
    public class CSSRule : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CSSRule(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

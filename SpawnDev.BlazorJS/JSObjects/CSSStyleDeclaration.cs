using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CSSStyleDeclaration interface represents an object that is a CSS declaration block, and exposes style information and various style-related methods and properties.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CSSStyleDeclaration
    /// </summary>
    public class CSSStyleDeclaration : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param
        public CSSStyleDeclaration(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Textual representation of the declaration block, if and only if it is exposed via HTMLElement.style. Setting this attribute changes the inline style. If you want a text representation of a computed declaration block, you can get it with JSON.stringify().
        /// </summary>
        public string CSSText { get => JSRef.Get<string>("cssText"); set => JSRef.Set("cssText", value); }
        /// <summary>
        /// The number of properties. See the item() method below.
        /// </summary>
        public int Length => JSRef.Get<int>("length");
        /// <summary>
        /// The containing CSSRule.
        /// </summary>
        public CSSRule? ParentRule => JSRef.Get<CSSRule?>("parentRule");
    }
}

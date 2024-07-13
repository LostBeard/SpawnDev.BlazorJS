using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// For historical reasons, Window objects have a window.HTMLDocument property whose value is the Document interface. So you can think of HTMLDocument as an alias for Document, and you can find documentation for HTMLDocument members under the documentation for the Document interface.
    /// </summary>
    public class HTMLDocument : Document
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLDocument?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLDocument(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLDocument?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLDocument(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLDocument(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLDocument(ElementReference elementReference) : base(JS.ToJSRef(elementReference)) { }
    }
}

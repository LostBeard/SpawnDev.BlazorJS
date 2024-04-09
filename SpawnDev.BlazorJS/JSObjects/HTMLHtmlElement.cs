using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLHtmlElement interface serves as the root node for a given HTML document. This object inherits the properties and methods described in the HTMLElement interface.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLHtmlElement
    /// </summary>
    public class HTMLHtmlElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public HTMLHtmlElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLHtmlElement(ElementReference elementReference) : base(elementReference) { }
    }
}

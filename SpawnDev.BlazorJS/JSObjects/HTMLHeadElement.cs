using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLHeadElement interface contains the descriptive information, or metadata, for a document. This object inherits all of the properties and methods described in the HTMLElement interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLHeadElement
    /// </summary>
    public class HTMLHeadElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLHeadElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLHeadElement(ElementReference elementReference) : base(elementReference) { }
    }
}

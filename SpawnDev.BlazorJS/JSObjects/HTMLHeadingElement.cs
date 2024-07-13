using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLHeadingElement interface represents the different heading elements, h1 through h6. It inherits methods and properties from the HTMLElement interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLHeadingElement
    /// </summary>
    public class HTMLHeadingElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLHeadingElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLHeadingElement(ElementReference elementReference) : base(elementReference) { }
    }
}

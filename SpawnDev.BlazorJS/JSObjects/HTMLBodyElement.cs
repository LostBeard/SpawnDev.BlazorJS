using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLBodyElement interface provides special properties (beyond those inherited from the regular HTMLElement interface) for manipulating body elements.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLBodyElement
    /// </summary>
    public class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public HTMLBodyElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLBodyElement(ElementReference elementReference) : base(elementReference) { }
    }
}

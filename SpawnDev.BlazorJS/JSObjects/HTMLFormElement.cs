using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLFormElement interface represents a form element in the DOM. It allows access to—and, in some cases, modification of—aspects of the form, as well as access to its component elements.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLFormElement
    /// </summary>
    public class HTMLFormElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLFormElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Constructor for ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLFormElement(ElementReference elementReference) : base(elementReference) { }
    }
}

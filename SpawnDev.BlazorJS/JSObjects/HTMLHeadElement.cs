using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLHeadElement : HTMLElement
    {
        public HTMLHeadElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLHeadElement(ElementReference elementReference) : base(elementReference) { }
    }
}

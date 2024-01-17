using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HTMLDocument : Document
    {
        public HTMLDocument(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLBodyElement(ElementReference elementReference) : base(elementReference) { }
    }
}

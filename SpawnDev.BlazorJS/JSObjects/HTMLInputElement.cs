using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLInputElement interface provides special properties and methods for manipulating the options, layout, and presentation of input elements.
    /// </summary>
    public class HTMLInputElement : HTMLElement
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLInputElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLInputElement(ElementReference elementReference) : base(elementReference) { }
        /// <summary>
        /// A FileList that represents the files selected for upload.
        /// </summary>
        public Array<File>? Files => JSRef.Get<Array<File>?>("files");
        /// <summary>
        /// A string that represents the current value of the control. If the user enters a value different from the value expected, this may return an empty string.
        /// </summary>
        public string Value => JSRef.Get<string>("value");
    }
}

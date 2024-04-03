using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLInputElement interface provides special properties and methods for manipulating the options, layout, and presentation of input elements.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement
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
        public FileList? Files => JSRef.Get<FileList?>("files");
        /// <summary>
        /// A string that represents the current value of the control. If the user enters a value different from the value expected, this may return an empty string.
        /// </summary>
        public string Value => JSRef.Get<string>("value");
        /// <summary>
        /// A string that represents the element's type attribute, indicating the type of control to display. For possible values, see the documentation for the type attribute.
        /// </summary>
        public string Type { get => JSRef.Get<string>("type"); set => JSRef.Set("type", value); }
        /// <summary>
        /// A boolean that represents the element's multiple attribute, indicating whether more than one value is possible (e.g., multiple files).
        /// </summary>
        public bool Multiple  { get => JSRef.Get<bool>("multiple"); set => JSRef.Set("multiple", value); }
        /// <summary>
        /// A boolean that represents the element's disabled attribute, indicating that the control is not available for interaction. The input values will not be submitted with the form. See also readonly.
        /// </summary>
        public bool Disabled { get => JSRef.Get<bool>("disabled"); set => JSRef.Set("disabled", value); }
        /// <summary>
        /// Hint for expected file type in file upload controls
        /// </summary>
        public string Accept { get => JSRef.Get<string>("accept"); set => JSRef.Set("accept", value); }
    }
}

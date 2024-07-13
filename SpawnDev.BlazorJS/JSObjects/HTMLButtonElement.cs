using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLButtonElement interface provides properties and methods (beyond the regular HTMLElement interface it also has available to it by inheritance) for manipulating button elements.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLButtonElement
    /// </summary>
    public class HTMLButtonElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLButtonElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLButtonElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLButtonElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLButtonElement(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLButtonElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLButtonElement(ElementReference elementReference) : base(elementReference) { }

        #region Properties
        /// <summary>
        /// A boolean value indicating whether or not the control is disabled, meaning that it does not accept any clicks.
        /// </summary>
        public bool Disabled { get => JSRef!.Get<bool>("disabled"); set => JSRef!.Set("disabled", value); }
        /// <summary>
        /// A NodeList that represents a list of label elements that are labels for this button.
        /// </summary>
        public NodeList Labels => JSRef!.Get<NodeList>("labels");
        /// <summary>
        /// A string indicating the behavior of the button. This is an enumerated attribute with the following possible values:<br />
        /// submit: The button submits the form. This is the default value if the attribute is not specified, or if it is dynamically changed to an empty or invalid value.<br />
        /// reset: The button resets the form.<br />
        /// button: The button does nothing.<br />
        /// menu: The button displays a menu. (experimental)
        /// </summary>
        public string Type { get => JSRef!.Get<string>("type"); set => JSRef!.Set("type", value); }
        #endregion
    }
}

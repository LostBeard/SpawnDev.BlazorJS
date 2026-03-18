using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLInputElement interface provides special properties and methods for manipulating the options, layout, and presentation of input elements.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement
    /// </summary>
    public class HTMLInputElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLInputElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLInputElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLInputElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLInputElement(elementReference.Value);
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
        public FileList? Files => JSRef!.Get<FileList?>("files");
        /// <summary>
        /// A string that represents the current value of the control.
        /// </summary>
        public string Value { get => JSRef!.Get<string>("value"); set => JSRef!.Set("value", value); }
        /// <summary>
        /// Returns the value as a number, or NaN if conversion is not possible.
        /// </summary>
        public double ValueAsNumber { get => JSRef!.Get<double>("valueAsNumber"); set => JSRef!.Set("valueAsNumber", value); }
        /// <summary>
        /// A string that represents the element's type attribute, indicating the type of control to display.
        /// </summary>
        public string Type { get => JSRef!.Get<string>("type"); set => JSRef!.Set("type", value); }
        /// <summary>
        /// A string that represents the element's name attribute, containing a name that identifies the element when submitting the form.
        /// </summary>
        public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }
        /// <summary>
        /// A boolean that represents the element's checked state. Present on checkbox and radio types.
        /// </summary>
        public bool Checked { get => JSRef!.Get<bool>("checked"); set => JSRef!.Set("checked", value); }
        /// <summary>
        /// A boolean that represents the element's defaultChecked attribute, the original checked state.
        /// </summary>
        public bool DefaultChecked { get => JSRef!.Get<bool>("defaultChecked"); set => JSRef!.Set("defaultChecked", value); }
        /// <summary>
        /// A string representing the default value as originally specified in the HTML.
        /// </summary>
        public string DefaultValue { get => JSRef!.Get<string>("defaultValue"); set => JSRef!.Set("defaultValue", value); }
        /// <summary>
        /// A boolean that represents the element's indeterminate state (checkbox only).
        /// </summary>
        public bool Indeterminate { get => JSRef!.Get<bool>("indeterminate"); set => JSRef!.Set("indeterminate", value); }
        /// <summary>
        /// A boolean that represents the element's multiple attribute, indicating whether more than one value is possible (e.g., multiple files).
        /// </summary>
        public bool Multiple { get => JSRef!.Get<bool>("multiple"); set => JSRef!.Set("multiple", value); }
        /// <summary>
        /// A boolean that represents the element's disabled attribute, indicating that the control is not available for interaction.
        /// </summary>
        public bool Disabled { get => JSRef!.Get<bool>("disabled"); set => JSRef!.Set("disabled", value); }
        /// <summary>
        /// A boolean that represents the element's readOnly attribute.
        /// </summary>
        public bool ReadOnly { get => JSRef!.Get<bool>("readOnly"); set => JSRef!.Set("readOnly", value); }
        /// <summary>
        /// A boolean that represents the element's required attribute, indicating that the user must fill in a value before submitting.
        /// </summary>
        public bool Required { get => JSRef!.Get<bool>("required"); set => JSRef!.Set("required", value); }
        /// <summary>
        /// A string that represents the element's placeholder attribute, containing a hint to the user.
        /// </summary>
        public string Placeholder { get => JSRef!.Get<string>("placeholder"); set => JSRef!.Set("placeholder", value); }
        /// <summary>
        /// A string that represents the element's pattern attribute, containing a regular expression for validation.
        /// </summary>
        public string Pattern { get => JSRef!.Get<string>("pattern"); set => JSRef!.Set("pattern", value); }
        /// <summary>
        /// A string that represents the element's min attribute, containing the minimum value.
        /// </summary>
        public string Min { get => JSRef!.Get<string>("min"); set => JSRef!.Set("min", value); }
        /// <summary>
        /// A string that represents the element's max attribute, containing the maximum value.
        /// </summary>
        public string Max { get => JSRef!.Get<string>("max"); set => JSRef!.Set("max", value); }
        /// <summary>
        /// A string that represents the element's step attribute, containing the step increment.
        /// </summary>
        public string Step { get => JSRef!.Get<string>("step"); set => JSRef!.Set("step", value); }
        /// <summary>
        /// An int that represents the element's minLength attribute.
        /// </summary>
        public int MinLength { get => JSRef!.Get<int>("minLength"); set => JSRef!.Set("minLength", value); }
        /// <summary>
        /// An int that represents the element's maxLength attribute.
        /// </summary>
        public int MaxLength { get => JSRef!.Get<int>("maxLength"); set => JSRef!.Set("maxLength", value); }
        /// <summary>
        /// An int that represents the element's size attribute, containing visual size of the control.
        /// </summary>
        public int Size { get => JSRef!.Get<int>("size"); set => JSRef!.Set("size", value); }
        /// <summary>
        /// Hint for expected file type in file upload controls.
        /// </summary>
        public string Accept { get => JSRef!.Get<string>("accept"); set => JSRef!.Set("accept", value); }
        /// <summary>
        /// A string that represents the element's autocomplete attribute.
        /// </summary>
        public string Autocomplete { get => JSRef!.Get<string>("autocomplete"); set => JSRef!.Set("autocomplete", value); }
        /// <summary>
        /// The beginning index of the selected text. When nothing is selected, returns the position of the text input cursor.
        /// </summary>
        public int? SelectionStart { get => JSRef!.Get<int?>("selectionStart"); set => JSRef!.Set("selectionStart", value); }
        /// <summary>
        /// The end index of the selected text. When nothing is selected, returns the position of the text input cursor.
        /// </summary>
        public int? SelectionEnd { get => JSRef!.Get<int?>("selectionEnd"); set => JSRef!.Set("selectionEnd", value); }
        /// <summary>
        /// The direction in which selection occurred. Possible values: "forward", "backward", "none".
        /// </summary>
        public string? SelectionDirection { get => JSRef!.Get<string?>("selectionDirection"); set => JSRef!.Set("selectionDirection", value); }
        /// <summary>
        /// Returns a boolean value that is true if the element is a candidate for constraint validation and does not satisfy its constraints.
        /// </summary>
        public bool WillValidate => JSRef!.Get<bool>("willValidate");
        /// <summary>
        /// Returns the error message that would be shown to the user if the element was to be checked for validity.
        /// </summary>
        public string ValidationMessage => JSRef!.Get<string>("validationMessage");
        /// <summary>
        /// Returns true if the element meets all constraint validations, false otherwise.
        /// </summary>
        public bool CheckValidity() => JSRef!.Call<bool>("checkValidity");
        /// <summary>
        /// Reports invalid fields to the user and returns true if valid.
        /// </summary>
        public bool ReportValidity() => JSRef!.Call<bool>("reportValidity");
        /// <summary>
        /// Sets a custom validity message. Pass empty string to mark as valid.
        /// </summary>
        public void SetCustomValidity(string message) => JSRef!.CallVoid("setCustomValidity", message);
        /// <summary>
        /// Selects the entire content of the text field.
        /// </summary>
        public void Select() => JSRef!.CallVoid("select");
        /// <summary>
        /// Sets the selection range for a text input element.
        /// </summary>
        public void SetSelectionRange(int start, int end, string? direction = null)
        {
            if (direction == null)
                JSRef!.CallVoid("setSelectionRange", start, end);
            else
                JSRef!.CallVoid("setSelectionRange", start, end, direction);
        }
        /// <summary>
        /// Replaces a range of text in the input.
        /// </summary>
        public void SetRangeText(string replacement) => JSRef!.CallVoid("setRangeText", replacement);
        /// <summary>
        /// Increments the value by (step * n), where n defaults to 1.
        /// </summary>
        public void StepUp(int n = 1) => JSRef!.CallVoid("stepUp", n);
        /// <summary>
        /// Decrements the value by (step * n), where n defaults to 1.
        /// </summary>
        public void StepDown(int n = 1) => JSRef!.CallVoid("stepDown", n);
        /// <summary>
        /// Shows a picker for date, time, color, or file inputs.
        /// </summary>
        public void ShowPicker() => JSRef!.CallVoid("showPicker");
    }
}

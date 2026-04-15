# HTMLInputElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLInputElement.cs`  
**MDN Reference:** [HTMLInputElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement)

> The HTMLInputElement interface provides special properties and methods for manipulating the options, layout, and presentation of input elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLInputElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLInputElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Files` | `FileList?` | get | A FileList that represents the files selected for upload. |
| `Value` | `string` | get | A string that represents the current value of the control. |
| `ValueAsNumber` | `double` | get | Returns the value as a number, or NaN if conversion is not possible. |
| `Type` | `string` | get | A string that represents the element's type attribute, indicating the type of control to display. |
| `Name` | `string` | get | A string that represents the element's name attribute, containing a name that identifies the element when submitting the form. |
| `Checked` | `bool` | get | A boolean that represents the element's checked state. Present on checkbox and radio types. |
| `DefaultChecked` | `bool` | get | A boolean that represents the element's defaultChecked attribute, the original checked state. |
| `DefaultValue` | `string` | get | A string representing the default value as originally specified in the HTML. |
| `Indeterminate` | `bool` | get | A boolean that represents the element's indeterminate state (checkbox only). |
| `Multiple` | `bool` | get | A boolean that represents the element's multiple attribute, indicating whether more than one value is possible (e.g., multiple files). |
| `Disabled` | `bool` | get/set | A boolean that represents the element's disabled attribute, indicating that the control is not available for interaction. |
| `ReadOnly` | `bool` | get | A boolean that represents the element's readOnly attribute. |
| `Required` | `bool` | get | A boolean that represents the element's required attribute, indicating that the user must fill in a value before submitting. |
| `Placeholder` | `string` | get | A string that represents the element's placeholder attribute, containing a hint to the user. |
| `Pattern` | `string` | get | A string that represents the element's pattern attribute, containing a regular expression for validation. |
| `Min` | `string` | get | A string that represents the element's min attribute, containing the minimum value. |
| `Max` | `string` | get | A string that represents the element's max attribute, containing the maximum value. |
| `Step` | `string` | get/set | A string that represents the element's step attribute, containing the step increment. |
| `MinLength` | `int` | get/set | An int that represents the element's minLength attribute. |
| `MaxLength` | `int` | get | An int that represents the element's maxLength attribute. |
| `Size` | `int` | get/set | An int that represents the element's size attribute, containing visual size of the control. |
| `Accept` | `string` | get | Hint for expected file type in file upload controls. |
| `Autocomplete` | `string` | get | A string that represents the element's autocomplete attribute. |
| `SelectionStart` | `int?` | get | The beginning index of the selected text. When nothing is selected, returns the position of the text input cursor. |
| `SelectionEnd` | `int?` | get | The end index of the selected text. When nothing is selected, returns the position of the text input cursor. |
| `SelectionDirection` | `string?` | get | The direction in which selection occurred. Possible values: "forward", "backward", "none". |
| `WillValidate` | `bool` | get | Returns a boolean value that is true if the element is a candidate for constraint validation and does not satisfy its constraints. |
| `ValidationMessage` | `string` | get | Returns the error message that would be shown to the user if the element was to be checked for validity. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CheckValidity()` | `bool` | Returns true if the element meets all constraint validations, false otherwise. |
| `ReportValidity()` | `bool` | Reports invalid fields to the user and returns true if valid. |
| `SetCustomValidity(string message)` | `void` | Sets a custom validity message. Pass empty string to mark as valid. |
| `Select()` | `void` | Selects the entire content of the text field. |
| `SetSelectionRange(int start, int end, string? direction)` | `void` | Sets the selection range for a text input element. |
| `SetRangeText(string replacement)` | `void` | Replaces a range of text in the input. |
| `StepUp(int n)` | `void` | Increments the value by (step * n), where n defaults to 1. |
| `StepDown(int n)` | `void` | Decrements the value by (step * n), where n defaults to 1. |
| `ShowPicker()` | `void` | Shows a picker for date, time, color, or file inputs. |


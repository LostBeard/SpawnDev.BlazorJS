# HTMLInputElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Element -> HTMLElement -> HTMLInputElement  
**MDN Reference:** [HTMLInputElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLInputElement)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/HTMLInputElement.cs`

> The HTMLInputElement interface provides properties and methods for manipulating the layout and presentation of input elements. It covers all input types (text, checkbox, radio, file, range, etc.) with type-specific properties.

## Constructor

```csharp
public HTMLInputElement(IJSInProcessObjectReference _ref)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Accept` | `string` | File types accepted (for type="file"). |
| `Alt` | `string` | Alt text (for type="image"). |
| `Autocomplete` | `string` | Get/set autocomplete hint ("on"/"off"/specific values). |
| `Checked` | `bool` | Get/set the checked state (checkbox/radio). |
| `DefaultChecked` | `bool` | The default checked state. |
| `DefaultValue` | `string` | The default value. |
| `Disabled` | `bool` | Get/set the disabled state. |
| `Files` | `FileList?` | The selected files (for type="file"). |
| `Form` | `HTMLFormElement?` | The containing form. |
| `FormAction` | `string` | Override the form's action URL. |
| `FormEnctype` | `string` | Override the form's encoding type. |
| `FormMethod` | `string` | Override the form's HTTP method. |
| `FormNoValidate` | `bool` | Override the form's novalidate. |
| `FormTarget` | `string` | Override the form's target. |
| `Height` | `int` | Height (for type="image"). |
| `Indeterminate` | `bool` | Get/set the indeterminate state (checkbox). |
| `Max` | `string` | The maximum value. |
| `MaxLength` | `int` | Maximum character length. |
| `Min` | `string` | The minimum value. |
| `MinLength` | `int` | Minimum character length. |
| `Multiple` | `bool` | Whether multiple values are allowed (file/email). |
| `Name` | `string` | Get/set the element name. |
| `Pattern` | `string` | Validation pattern (regex). |
| `Placeholder` | `string` | Placeholder text. |
| `ReadOnly` | `bool` | Get/set read-only state. |
| `Required` | `bool` | Get/set required state. |
| `SelectionDirection` | `string` | Direction of text selection. |
| `SelectionEnd` | `int?` | End index of text selection. |
| `SelectionStart` | `int?` | Start index of text selection. |
| `Size` | `int` | Display size (character width). |
| `Src` | `string` | Image source URL (for type="image"). |
| `Step` | `string` | Step increment for numeric/date inputs. |
| `Type` | `string` | Get/set the input type ("text", "password", "checkbox", etc.). |
| `Value` | `string` | Get/set the current value. |
| `ValueAsDate` | `DateTime?` | Get/set the value as a DateTime. |
| `ValueAsNumber` | `double` | Get/set the value as a number. |
| `Width` | `int` | Width (for type="image"). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Select()` | `void` | Select all text in the input. |
| `SetSelectionRange(int start, int end)` | `void` | Set the text selection range. |
| `SetSelectionRange(int start, int end, string direction)` | `void` | Set selection range with direction ("forward"/"backward"/"none"). |
| `StepUp()` | `void` | Increment the value by one step. |
| `StepUp(int n)` | `void` | Increment the value by n steps. |
| `StepDown()` | `void` | Decrement the value by one step. |
| `StepDown(int n)` | `void` | Decrement the value by n steps. |
| `CheckValidity()` | `bool` | Check if the input satisfies its constraints. |
| `ReportValidity()` | `bool` | Check validity and show validation UI. |
| `SetCustomValidity(string message)` | `void` | Set a custom validation message. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnInput` | `ActionEvent<Event>` | Fired when the value changes. |
| `OnChange` | `ActionEvent<Event>` | Fired when a change is committed (blur or Enter). |
| `OnInvalid` | `ActionEvent<Event>` | Fired when the element fails validation. |
| `OnSelect` | `ActionEvent<Event>` | Fired when text is selected. |

## Example

```csharp
using var input = doc.QuerySelector<HTMLInputElement>("#username");

// Read value
string username = input!.Value;

// Validation
input.Required = true;
input.MinLength = 3;
input.Pattern = "^[a-zA-Z0-9]+$";

if (!input.CheckValidity())
{
    input.SetCustomValidity("Username must be alphanumeric, 3+ characters");
}

// Events
void OnInput(Event e)
{
    Console.WriteLine($"Current value: {input.Value}");
}
input.OnInput += OnInput;
// ... later
input.OnInput -= OnInput;
```

## Example - File Input

```csharp
using var fileInput = doc.QuerySelector<HTMLInputElement>("input[type=file]");
fileInput!.Accept = "image/*";
fileInput.Multiple = true;

void OnChange(Event e)
{
    using var files = fileInput.Files;
    if (files != null)
    {
        for (int i = 0; i < files.Length; i++)
        {
            using var file = files[i];
            Console.WriteLine($"File: {file.Name}, Size: {file.Size}");
        }
    }
}
fileInput.OnChange += OnChange;
```

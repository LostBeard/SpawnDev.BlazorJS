# HTMLButtonElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLButtonElement.cs`  
**MDN Reference:** [HTMLButtonElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLButtonElement)

> The HTMLButtonElement interface provides properties and methods (beyond the regular HTMLElement interface it also has available to it by inheritance) for manipulating button elements. https://developer.mozilla.org/en-US/docs/Web/API/HTMLButtonElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLButtonElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLButtonElement(ElementReference elementReference)` | Get an instance from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Disabled` | `bool` | get | A boolean value indicating whether or not the control is disabled, meaning that it does not accept any clicks. |
| `Labels` | `NodeList` | get | A NodeList that represents a list of label elements that are labels for this button. |
| `Type` | `string` | get | A string indicating the behavior of the button. This is an enumerated attribute with the following possible values: submit: The button submits the form. This is the default value if the attribute is not specified, or if it is dynamically changed to an empty or invalid value. reset: The button resets the form. button: The button does nothing. menu: The button displays a menu. (experimental) |


# HTMLElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Element`  
**Source:** `JSObjects/DOM/HTMLElement.cs`  
**MDN Reference:** [HTMLElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement)

> The HTMLElement interface represents any HTML element. Some elements directly implement this interface, while others implement it via an interface that inherits it. https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLElement(ElementReference elementReference)` | Constructor for ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AccessKey` | `string?` | get | A string representing the access key assigned to the element. |
| `AccessKeyLabel` | `string?` | get | Returns a string containing the element's assigned access key. |
| `AutoFocus` | `bool` | get | A boolean value reflecting the autofocus HTML global attribute, which indicates whether the control should be focused when the page loads, or when dialog or popover become shown if specified in an element inside dialog elements or elements whose popover attribute is set. |
| `ContentEditable` | `string` | get | A string, where a value of true means the element is editable and a value of false means it isn't. |
| `Dir` | `string` | get/set | A string, reflecting the dir global attribute, representing the directionality of the element. Possible values are "ltr", "rtl", and "auto". |
| `Draggable` | `bool` | get | A boolean value indicating if the element can be dragged. |
| `EnterKeyHint` | `string` | get | A string defining what action label (or icon) to present for the enter key on virtual keyboards. |
| `Hidden` | `bool` | get | A string or boolean value reflecting the value of the element's hidden attribute. |
| `InnerText` | `string` | get | Represents the rendered text content of a node and its descendants. As a getter, it approximates the text the user would get if they highlighted the contents of the element with the cursor and then copied it to the clipboard. As a setter, it replaces the content inside the selected element, converting any line breaks into br elements. |
| `InputMode` | `string` | get | A string value reflecting the value of the element's inputmode attribute. |
| `IsContentEditable` | `bool` | get | Returns a boolean value indicating whether or not the content of the element can be edited. |
| `Lang` | `string` | get | A string representing the language of an element's attributes, text, and element contents. |
| `OffsetHeight` | `double` | get | Returns a double containing the height of an element, relative to the layout. |
| `OffsetLeft` | `double` | get | Returns a double, the distance from this element's left border to its offsetParent's left border. |
| `OffsetParent` | `Element?` | get | An Element that is the element from which all offset calculations are currently computed. |
| `OffsetTop` | `double` | get | Returns a double, the distance from this element's top border to its offsetParent's top border. |
| `OffsetWidth` | `double` | get | Returns a double containing the width of an element, relative to the layout. |
| `OuterText` | `string` | get | Represents the rendered text content of a node and its descendants. As a getter, it is the same as HTMLElement.innerText (it represents the rendered text content of an element and its descendants). As a setter, it replaces the selected node and its contents with the given value, converting any line breaks into br elements. |
| `Popover` | `string` | get | Gets and sets an element's popover state via JavaScript ("auto" or "manual"), and can be used for feature detection. Reflects the value of the popover global HTML attribute. |
| `SpellCheck` | `bool` | get | A boolean value that controls the spell-checking hint. It is available on all HTML elements, though it doesn't affect all of them. |
| `Style` | `CSSStyleDeclaration` | get | A CSSStyleDeclaration representing the declarations of the element's style attribute. |
| `TabIndex` | `long` | get | A long representing the position of the element in the tabbing order. |
| `Title` | `string` | get/set | A string containing the text that appears in a popup box when mouse is over the element. |
| `Translate` | `bool` | get | A boolean value representing the translation. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Blur()` | `void` | Removes keyboard focus from the currently focused element. |
| `Click()` | `void` | Sends a mouse click event to the element. |
| `Focus(FocusOptions? options)` | `void` | Makes the element the current keyboard focus. |
| `HidePopover()` | `void` | Hides a popover element by removing it from the top layer and styling it with display: none. |
| `ShowPopover()` | `void` | Shows a popover element by adding it to the top layer and removing display: none; from its styles. |
| `TogglePopover()` | `bool` | Toggles a popover element between the hidden and showing states. true if the popup is open after the call, and false otherwise. |
| `TogglePopover(bool force)` | `bool` | Toggles a popover element between the hidden and showing states. true if the popup is open after the call, and false otherwise. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnCancel` | `ActionEvent<Event>` | Fired for input and dialog elements when the user cancels the currently open dialog by closing it with the Esc key. |
| `OnChange` | `ActionEvent<Event>` | Fired for input, select, and textarea elements when the user modifies the element's value. |
| `OnError` | `ActionEvent<Event>` | Fired on an element when a resource failed to load, or can't be used. |
| `OnLoad` | `ActionEvent<Event>` | Fires for elements containing a resource when the resource has successfully loaded. |
| `OnDrag` | `ActionEvent<DragEvent>` | Fired every few hundred milliseconds as an element or text selection is being dragged by the user. |
| `OnDragEnd` | `ActionEvent<DragEvent>` | Fired when a drag operation ends (by releasing a mouse button or hitting the escape key). |
| `OnDragEnter` | `ActionEvent<DragEvent>` | Fired when a dragged element or text selection enters a valid drop target. |
| `OnDragLeave` | `ActionEvent<DragEvent>` | Fired when a dragged element or text selection leaves a valid drop target. |
| `OnDragOver` | `ActionEvent<DragEvent>` | Fired when an element or text selection is being dragged over a valid drop target (every few hundred milliseconds). |
| `OnDragStart` | `ActionEvent<DragEvent>` | Fired when the user starts dragging an element or text selection. |
| `OnDrop` | `ActionEvent<DragEvent>` | Fired when an element or text selection is dropped on a valid drop target. |
| `OnBeforeToggle` | `ActionEvent<ToggleEvent>` | Fired when the element is a popover, before it is hidden or shown. |
| `OnToggle` | `ActionEvent<ToggleEvent>` | Fired when the element is a popover, just after it is hidden or shown. |

## Example

```csharp
// Cast a Blazor ElementReference to HTMLElement
using var el = new HTMLElement(elementRef);

// Read and set inner text
string text = el.InnerText;
el.InnerText = "Updated content";

// Access CSS styles via the Style property
using var style = el.Style;
style.SetProperty("color", "red");
style.SetProperty("font-size", "24px");
style.SetProperty("background-color", "#f0f0f0");

// Click, focus, and blur
el.Click();
el.Focus();
el.Blur();

// Read layout measurements
double height = el.OffsetHeight;
double width = el.OffsetWidth;
double top = el.OffsetTop;
double left = el.OffsetLeft;

// Set element properties
el.Title = "Tooltip text";
el.Hidden = false;
el.Draggable = true;
el.TabIndex = 1;

// Listen for events
el.OnChange += (e) => Console.WriteLine("Value changed");
el.OnLoad += (e) => Console.WriteLine("Resource loaded");
el.OnError += (e) => Console.WriteLine("Error occurred");

// Drag-and-drop events
el.OnDragStart += (e) => Console.WriteLine("Drag started");
el.OnDrop += (e) => Console.WriteLine("Dropped");
```


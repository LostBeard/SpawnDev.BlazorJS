# HTMLElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Element -> HTMLElement  
**MDN Reference:** [HTMLElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/HTMLElement.cs`

> HTMLElement is the base interface for all HTML elements. It adds properties for style, content editing, drag and drop, offset dimensions, and element-specific events. All specific HTML element types (HTMLDivElement, HTMLButtonElement, HTMLInputElement, etc.) inherit from HTMLElement.

## Constructor

```csharp
public HTMLElement(IJSInProcessObjectReference _ref)
public HTMLElement(ElementReference elementReference)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `AccessKey` | `string` | Get/set the keyboard shortcut key. |
| `ContentEditable` | `string` | Get/set content editability ("true"/"false"/"inherit"). |
| `IsContentEditable` | `bool` | Whether the element is editable. |
| `Dataset` | `DOMStringMap` | The data-* attributes as a string map. |
| `Dir` | `string` | Get/set text direction ("ltr"/"rtl"/"auto"). |
| `Draggable` | `bool` | Get/set whether the element is draggable. |
| `Hidden` | `bool` | Get/set the hidden attribute. |
| `InnerText` | `string` | Get/set the rendered text content. |
| `Lang` | `string` | Get/set the language. |
| `OffsetHeight` | `int` | Layout height including borders. |
| `OffsetLeft` | `int` | Distance from the left of the offsetParent. |
| `OffsetParent` | `Element?` | The nearest positioned ancestor. |
| `OffsetTop` | `int` | Distance from the top of the offsetParent. |
| `OffsetWidth` | `int` | Layout width including borders. |
| `Style` | `CSSStyleDeclaration` | The inline style object. |
| `TabIndex` | `int` | Get/set the tab order. |
| `Title` | `string` | Get/set the title (tooltip). |
| `AccessKeyLabel` | `string?` | Returns a string containing the element's assigned access key. |
| `AutoFocus` | `bool` | A boolean value reflecting the autofocus HTML global attribute, which indicates whether the control should be focused when the page loads, or when dialog or popover become shown if specified in an element inside dialog elements or elements whose popover attribute is set. |
| `EnterKeyHint` | `string` | A string defining what action label (or icon) to present for the enter key on virtual keyboards. |
| `InputMode` | `string` | A string value reflecting the value of the element's inputmode attribute. |
| `OuterText` | `string` | Represents the rendered text content of a node and its descendants. As a getter, it is the same as HTMLElement.innerText (it represents the rendered text content of an element and its descendants). As a setter, it replaces the selected node and its contents with the given value, converting any line breaks into br elements. |
| `Popover` | `string` | Gets and sets an element's popover state via JavaScript ("auto" or "manual"), and can be used for feature detection. Reflects the value of the popover global HTML attribute. |
| `SpellCheck` | `bool` | A boolean value that controls the spell-checking hint. It is available on all HTML elements, though it doesn't affect all of them. |
| `Translate` | `bool` | A boolean value representing the translation. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Click()` | `void` | Simulate a click on the element. |
| `Focus()` | `void` | Give focus to the element. |
| `Focus(FocusOptions options)` | `void` | Give focus with options (preventScroll). |
| `Blur()` | `void` | Remove focus from the element. |
| `Focus(FocusOptions? options = null)` | `void` | Makes the element the current keyboard focus. |
| `HidePopover()` | `void` | Hides a popover element by removing it from the top layer and styling it with display: none. |
| `ShowPopover()` | `void` | Shows a popover element by adding it to the top layer and removing display: none; from its styles. |
| `TogglePopover()` | `bool` | Toggles a popover element between the hidden and showing states. |
| `TogglePopover(bool force)` | `bool` | Toggles a popover element between the hidden and showing states. |

## Events

All events inherited from Element, plus:

| Event | Type | Description |
|---|---|---|
| `OnInput` | `ActionEvent<Event>` | Fired when the value changes (for editable content). |
| `OnChange` | `ActionEvent<Event>` | Fired when a change is committed. |
| `OnDragStart` | `ActionEvent<DragEvent>` | Fired when a drag operation starts. |
| `OnDrag` | `ActionEvent<DragEvent>` | Fired during a drag operation. |
| `OnDragEnd` | `ActionEvent<DragEvent>` | Fired when a drag operation ends. |
| `OnDragEnter` | `ActionEvent<DragEvent>` | Fired when a dragged item enters the element. |
| `OnDragOver` | `ActionEvent<DragEvent>` | Fired when a dragged item is over the element. |
| `OnDragLeave` | `ActionEvent<DragEvent>` | Fired when a dragged item leaves the element. |
| `OnDrop` | `ActionEvent<DragEvent>` | Fired when an item is dropped on the element. |
| `OnAnimationStart` | `ActionEvent<AnimationEvent>` | Fired when a CSS animation starts. |
| `OnAnimationEnd` | `ActionEvent<AnimationEvent>` | Fired when a CSS animation ends. |
| `OnTransitionEnd` | `ActionEvent<TransitionEvent>` | Fired when a CSS transition ends. |

## Constructors

| Signature | Description |
|---|---|
| `HTMLElement(ElementReference elementReference)` | Constructor for ElementReference |

## Events

| Event | Type | Description |
|---|---|---|
| `OnCancel` | `ActionEvent<Event>` | Fired for input and dialog elements when the user cancels the currently open dialog by closing it with the Esc key. |
| `OnError` | `ActionEvent<Event>` | Fired on an element when a resource failed to load, or can't be used. |
| `OnLoad` | `ActionEvent<Event>` | Fires for elements containing a resource when the resource has successfully loaded. |
| `OnBeforeToggle` | `ActionEvent<ToggleEvent>` | Fired when the element is a popover, before it is hidden or shown. |
| `OnToggle` | `ActionEvent<ToggleEvent>` | Fired when the element is a popover, just after it is hidden or shown. |

## Example

```csharp
using var el = doc.QuerySelector<HTMLElement>("#myDiv");

// Style manipulation
el!.Style.SetProperty("background-color", "red");
el.Style.SetProperty("display", "flex");

// Content
el.InnerText = "Updated text";
el.Title = "Hover tooltip";

// Interaction
el.Focus();
el.Click();

// Offset dimensions
Console.WriteLine($"Size: {el.OffsetWidth}x{el.OffsetHeight}");
Console.WriteLine($"Position: ({el.OffsetLeft}, {el.OffsetTop})");

// Visibility
el.Hidden = true;  // Hide the element
el.Hidden = false;  // Show the element
```

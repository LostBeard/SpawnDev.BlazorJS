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

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Click()` | `void` | Simulate a click on the element. |
| `Focus()` | `void` | Give focus to the element. |
| `Focus(FocusOptions options)` | `void` | Give focus with options (preventScroll). |
| `Blur()` | `void` | Remove focus from the element. |

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

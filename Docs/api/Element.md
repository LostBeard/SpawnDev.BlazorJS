# Element

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Element  
**MDN Reference:** [Element on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Element)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/Element.cs`

> Element is the most general base class from which all element objects in a Document inherit. It provides methods and properties common to all kinds of elements - attribute access, DOM querying, geometry, scroll behavior, and shadow DOM. More specific classes like HTMLElement, SVGElement, etc. inherit from Element.

## Constructor

```csharp
// From existing reference
public Element(IJSInProcessObjectReference _ref)

// From Blazor ElementReference
public Element(ElementReference elementReference)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Attributes` | `NamedNodeMap` | The element's attributes. |
| `ChildElementCount` | `int` | Number of child elements. |
| `Children` | `HTMLCollection` | Live collection of child elements. |
| `ClassList` | `DOMTokenList` | The element's class list (add/remove/toggle). |
| `ClassName` | `string` | Get/set the class attribute value. |
| `ClientHeight` | `int` | Inner height including padding (no scrollbar). |
| `ClientLeft` | `int` | Width of the left border. |
| `ClientTop` | `int` | Width of the top border. |
| `ClientWidth` | `int` | Inner width including padding (no scrollbar). |
| `FirstElementChild` | `Element?` | First child element. |
| `Id` | `string` | Get/set the element's id attribute. |
| `InnerHTML` | `string` | Get/set the HTML content of the element. |
| `LastElementChild` | `Element?` | Last child element. |
| `LocalName` | `string` | The local part of the qualified name. |
| `NamespaceURI` | `string?` | The namespace URI. |
| `NextElementSibling` | `Element?` | Next sibling element. |
| `OuterHTML` | `string` | Get/set the HTML including the element itself. |
| `Part` | `DOMTokenList` | The element's part attribute (for CSS ::part). |
| `Prefix` | `string?` | The namespace prefix. |
| `PreviousElementSibling` | `Element?` | Previous sibling element. |
| `ScrollHeight` | `int` | Total height of content including overflow. |
| `ScrollLeft` | `double` | Get/set horizontal scroll position. |
| `ScrollTop` | `double` | Get/set vertical scroll position. |
| `ScrollWidth` | `int` | Total width of content including overflow. |
| `ShadowRoot` | `ShadowRoot?` | The element's shadow root, if any. |
| `Slot` | `string` | The slot the element is inserted in. |
| `TagName` | `string` | The tag name (uppercase, e.g., "DIV"). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetAttribute(string name)` | `string?` | Get an attribute value. |
| `SetAttribute(string name, string value)` | `void` | Set an attribute value. |
| `RemoveAttribute(string name)` | `void` | Remove an attribute. |
| `HasAttribute(string name)` | `bool` | Whether the attribute exists. |
| `ToggleAttribute(string name)` | `bool` | Toggle a boolean attribute. Returns new state. |
| `ToggleAttribute(string name, bool force)` | `bool` | Force add/remove a boolean attribute. |
| `GetBoundingClientRect()` | `DOMRect` | Get size and position relative to viewport. |
| `CheckVisibility(CheckVisibilityOptions? opts)` | `bool` | Check if the element is visible. |
| `QuerySelector(string selector)` | `Element?` | Find first matching descendant. |
| `QuerySelector<T>(string selector)` | `T?` | Find first matching typed descendant. |
| `QuerySelectorAll(string selector)` | `NodeList<Element>` | Find all matching descendants. |
| `QuerySelectorAll<T>(string selector)` | `NodeList<T>` | Find all matching typed descendants. |
| `Closest<T>(string selector)` | `T?` | Traverse up to find the nearest matching ancestor. |
| `Matches(string selector)` | `bool` | Whether the element matches the CSS selector. |
| `RequestFullscreen()` | `Task` | Request fullscreen mode. |
| `RequestFullscreen(RequestFullscreenOptions)` | `Task` | Request fullscreen with options. |
| `RequestPointerLock()` | `Task` | Request pointer lock. |
| `AttachShadow(AttachShadowRootOptions options)` | `ShadowRoot` | Attach a shadow DOM tree. |
| `ScrollIntoView()` | `void` | Scroll the element into view. |
| `ScrollIntoView(ScrollIntoViewOptions opts)` | `void` | Scroll into view with options. |
| `Append(params Union<Node, string>[] nodes)` | `void` | Append nodes/strings after last child. |
| `Prepend(params Union<Node, string>[] nodes)` | `void` | Insert nodes/strings before first child. |
| `After(params Union<Node, string>[] nodes)` | `void` | Insert nodes/strings after this element. |
| `Before(params Union<Node, string>[] nodes)` | `void` | Insert nodes/strings before this element. |
| `Remove()` | `void` | Remove this element from its parent. |
| `InsertAdjacentHTML(string position, string text)` | `void` | Parse HTML and insert at the specified position. |
| `InsertAdjacentElement(string position, Element el)` | `Element` | Insert an element at the specified position. |
| `Animate(object keyframes, object options)` | `Animation` | Create a CSS animation. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnClick` | `ActionEvent<MouseEvent>` | Fired on click. |
| `OnDblClick` | `ActionEvent<MouseEvent>` | Fired on double-click. |
| `OnMouseDown` | `ActionEvent<MouseEvent>` | Fired when mouse button is pressed. |
| `OnMouseUp` | `ActionEvent<MouseEvent>` | Fired when mouse button is released. |
| `OnMouseEnter` | `ActionEvent<MouseEvent>` | Fired when pointer enters the element. |
| `OnMouseLeave` | `ActionEvent<MouseEvent>` | Fired when pointer leaves the element. |
| `OnMouseMove` | `ActionEvent<MouseEvent>` | Fired when pointer moves within the element. |
| `OnMouseOver` | `ActionEvent<MouseEvent>` | Fired when pointer moves onto the element. |
| `OnMouseOut` | `ActionEvent<MouseEvent>` | Fired when pointer moves off the element. |
| `OnContextMenu` | `ActionEvent<MouseEvent>` | Fired on right-click. |
| `OnWheel` | `ActionEvent<WheelEvent>` | Fired on mouse wheel. |
| `OnKeyDown` | `ActionEvent<KeyboardEvent>` | Fired when a key is pressed. |
| `OnKeyUp` | `ActionEvent<KeyboardEvent>` | Fired when a key is released. |
| `OnFocus` | `ActionEvent<FocusEvent>` | Fired when the element gains focus. |
| `OnBlur` | `ActionEvent<FocusEvent>` | Fired when the element loses focus. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the element is scrolled. |
| `OnTouchStart` | `ActionEvent<TouchEvent>` | Fired when a touch begins. |
| `OnTouchEnd` | `ActionEvent<TouchEvent>` | Fired when a touch ends. |
| `OnTouchMove` | `ActionEvent<TouchEvent>` | Fired when a touch moves. |
| `OnTouchCancel` | `ActionEvent<TouchEvent>` | Fired when a touch is cancelled. |
| `OnPointerDown` | `ActionEvent<PointerEvent>` | Fired when a pointer becomes active. |
| `OnPointerUp` | `ActionEvent<PointerEvent>` | Fired when a pointer is released. |
| `OnPointerMove` | `ActionEvent<PointerEvent>` | Fired when a pointer moves. |
| `OnFullscreenChange` | `ActionEvent<Event>` | Fired when fullscreen state changes. |
| `OnFullscreenError` | `ActionEvent<Event>` | Fired on fullscreen error. |

## Example

```csharp
using var doc = JS.Get<Document>("document");
using var el = doc.QuerySelector<Element>("#myElement");

// Attributes
el!.SetAttribute("data-value", "42");
string? val = el.GetAttribute("data-value"); // "42"
bool hasIt = el.HasAttribute("data-value");  // true

// Geometry
using var rect = el.GetBoundingClientRect();
Console.WriteLine($"Position: ({rect.X}, {rect.Y}), Size: {rect.Width}x{rect.Height}");

// Classes
el.ClassList.Add("active");
el.ClassList.Toggle("hidden");

// DOM manipulation
el.InnerHTML = "<span>New content</span>";
el.Append("Text node", doc.CreateElement("br"), "More text");
```

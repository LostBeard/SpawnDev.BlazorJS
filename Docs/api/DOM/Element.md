# Element

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Node`  
**Source:** `JSObjects/DOM/Element.cs`  
**MDN Reference:** [Element on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Element)

> Element is the most general base class from which all element objects (i.e. objects that represent elements) in a Document inherit. It only has methods and properties common to all kinds of elements. More specific classes inherit from Element. https://developer.mozilla.org/en-US/docs/Web/API/Element https://docs.w3cub.com/dom/element

## Constructors

| Signature | Description |
|---|---|
| `Element(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Element(ElementReference elementReference)` | Creates a new Element from an ElementReference |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AssignedSlot` | `HTMLSlotElement?` | get | Returns a HTMLSlotElement representing the &lt;slot> the node is inserted in. |
| `ChildElementCount` | `int` | get | Returns the number of child elements of this element. |
| `Children` | `HTMLCollection` | get | Returns the child elements of this element. |
| `ClassList` | `DOMTokenList` | get | Returns a DOMTokenList containing the list of class attributes. |
| `ClassName` | `string` | get | A string representing the class of the element. |
| `ClassNames` | `string[]` | get | Returns ClassNames from ClassName split on spaces |
| `ClientHeight` | `int` | get | Returns a number representing the inner height of the element. This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect(). |
| `ClientWidth` | `int` | get | Returns a number representing the inner width of the element. This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect(). |
| `ClientTop` | `int` | get | Returns a number representing the width of the top border of the element. This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect(). |
| `ClientLeft` | `int` | get | Returns a number representing the width of the left border of the element. This property will round the value to an integer. If you need a fractional value, use element.getBoundingClientRect(). |
| `CurrentCSSZoom` | `float` | get | A number indicating the effective zoom size of the element, or 1.0 if the element is not rendered. |
| `ElementTiming` | `string?` | get | A string reflecting the elementtiming attribute which marks an element for observation in the PerformanceElementTiming API. |
| `FirstElementChild` | `Element?` | get | Returns the first child element of this element. |
| `Id` | `string?` | get/set | The id property of the Element interface represents the element's identifier, reflecting the id global attribute. |
| `InnerHTML` | `string` | get | A string representing the markup of the element's content. |
| `LastElementChild` | `Element?` | get | Returns the last child element of this element. |
| `LocalName` | `string?` | get | A string representing the local part of the qualified name of the element. |
| `NamespaceURI` | `string?` | get | The namespace URI of the element, or null if it is no namespace. |
| `NextElementSibling` | `Element?` | get | An Element, the element immediately following the given one in the tree, or null if there's no sibling node. |
| `OuterHTML` | `string?` | get | A string representing the markup of the element including its content. When used as a setter, replaces the element with nodes parsed from the given string. |
| `PreviousElementSibling` | `Element?` | get | An Element, the element immediately preceding the given one in the tree, or null if there is no sibling element. |
| `ScrollHeight` | `int` | get | Returns a number representing the scroll view height of an element. |
| `ScrollWidth` | `int` | get | Returns a number representing the scroll view width of the element. |
| `ScrollTop` | `int` | get | A number representing number of pixels the top of the element is scrolled vertically. |
| `ScrollLeft` | `int` | get | A number representing the number of pixels the element is scrolled horizontally. |
| `ShadowRoot` | `ShadowRoot?` | get | The Element.shadowRoot read-only property represents the shadow root hosted by the element. Use Element.attachShadow() to add a shadow root to an existing element. |
| `TagName` | `string` | get | Returns a string with the name of the tag for the given element. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `QuerySelectorAll(string selector)` | `NodeList<Element>` | The Element method querySelectorAll() returns a static (not live) NodeList representing a list of elements matching the specified group of selectors which are descendants of the element on which the method was called. |
| `QuerySelector(string selector)` | `Element?` | The querySelector() method of the Element interface returns the first element that is a descendant of the element on which it is invoked that matches the specified group of selectors. |
| `Closest(string selector)` | `TElement?` | The closest() method of the Element interface traverses the element and its parents (heading toward the document root) until it finds a node that matches the specified CSS selector. |
| `CheckVisibility(CheckVisibilityOptions? options)` | `bool` | The checkVisibility() method of the Element interface checks whether the element is visible. |
| `GetBoundingClientRect()` | `DOMRect` | Returns the size of an element and its position relative to the viewport. |
| `RequestFullscreen()` | `Task` | Asynchronously asks the browser to make the element fullscreen. |
| `RequestFullscreen(RequestFullscreenOptions options)` | `Task` | Asynchronously asks the browser to make the element fullscreen. |
| `RequestPointerLock()` | `Task` | The Element.requestPointerLock() method lets you asynchronously ask for the pointer to be locked on the given element. https://developer.mozilla.org/en-US/docs/Web/API/Element/requestPointerLock |
| `GetAttribute(string name)` | `string?` | Retrieves the value of the named attribute from the current node and returns it as a string. |
| `RemoveAttribute(string name)` | `void` | Removes the named attribute from the current node. |
| `SetAttribute(string name, string value)` | `void` | Sets the value of a named attribute of the current node. |
| `After(params Union<Node, string>[] nodes)` | `void` | Inserts a set of Node objects or strings in the children list of the Element's parent, just after the Element. |
| `Append(params Union<Node, string>[] nodes)` | `void` | The Element.append() method inserts a set of Node objects or string objects after the last child of the Element. String objects are inserted as equivalent Text nodes. |
| `Prepend(params Union<Node, string>[] nodes)` | `void` | Inserts a set of Node objects or strings before the first child of the element. |
| `Before(params Union<Node, string>[] nodes)` | `void` | The Element.before() method inserts a set of Node or string objects in the children list of this Element's parent, just before this Element. String objects are inserted as equivalent Text nodes. |
| `Remove()` | `void` | Removes the element from the children list of its parent. |
| `AttachShadow(AttachShadowRootOptions options)` | `ShadowRoot` | The Element.attachShadow() method attaches a shadow DOM tree to the specified element and returns a reference to its ShadowRoot. Note that you can't attach a shadow root to every type of element. There are some that can't have a shadow DOM for security reasons (for example a element). |
| `HasAttribute(string name)` | `bool` | Returns a boolean indicating whether the specified element has the specified attribute or not. |
| `ToggleAttribute(string name)` | `bool` | Toggles a boolean attribute (removing it if present, adding it if absent). Returns true if the attribute is present after the call, false otherwise. |
| `ToggleAttribute(string name, bool force)` | `bool` | Toggles a boolean attribute. If force is true, adds the attribute; if false, removes it. |
| `Matches(string selectors)` | `bool` | Returns true if the element would be selected by the specified selector string. |
| `ScrollIntoView()` | `void` | Scrolls the element into the visible area of the browser window. |
| `ScrollIntoView(bool alignToTop)` | `void` | Scrolls the element into the visible area of the browser window. If alignToTop is true, the top of the element will be aligned with the top of the visible area; if false, the bottom will be aligned with the bottom. |
| `InsertAdjacentHTML(string position, string text)` | `void` | Parses the specified text as HTML and inserts the resulting nodes into the DOM tree at a specified position. One of "beforebegin", "afterbegin", "beforeend", "afterend". The HTML string to parse and insert. |
| `InsertAdjacentElement(string position, Element element)` | `Element?` | Inserts a given element node at a given position relative to the element it is invoked upon. One of "beforebegin", "afterbegin", "beforeend", "afterend". The element to insert. |
| `SetPointerCapture(int pointerId)` | `void` | Designates a specific element as the capture target of future pointer events. |
| `ReleasePointerCapture(int pointerId)` | `void` | Releases pointer capture that was previously set for a specific pointer event. |
| `HasPointerCapture(int pointerId)` | `bool` | Returns true if the element has pointer capture for the pointer identified by the given pointer ID. |
| `GetClientRects()` | `DOMRect[]` | Returns a collection of DOMRect objects that indicate the bounding rectangles for each CSS border box in a client. |
| `ReplaceWith(params Union<Node, string>[] nodes)` | `void` | Replaces the element in the children list of its parent with a set of Node or string objects. |
| `ReplaceChildren(params Union<Node, string>[] nodes)` | `void` | Replaces the existing children of a node with a specified new set of children. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnSecurityPolicyViolation` | `ActionEvent<SecurityPolicyViolationEvent>` | Fired when a Content Security Policy is violated. |
| `OnContentVisibilityAutoStateChange` | `ActionEvent<ContentVisibilityAutoStateChangeEvent>` | Fires on any element with content-visibility: auto set on it when it starts or stops being relevant to the user and skipping its contents. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the document view or an element has been scrolled. |
| `OnScrollEnd` | `ActionEvent<Event>` | Fires when the document view has completed scrolling. |
| `OnWheel` | `ActionEvent<WheelEvent>` | Fired when the user rotates a wheel button on a pointing device (typically a mouse). |
| `OnInput` | `ActionEvent<InputEvent>` | Fires when the value of an input, select, or textarea element has been changed as a direct result of a user action (such as typing in a textbox or checking a checkbox). |
| `OnBeforeInput` | `ActionEvent<InputEvent>` | Fires when the value of an input or textarea element is about to be modified. |
| `OnFullscreenChange` | `ActionEvent<Event>` | Sent to an Element when it transitions into or out of fullscreen mode. |
| `OnFullscreenError` | `ActionEvent<Event>` | Sent to an Element if an error occurs while attempting to switch it into or out of fullscreen mode. |
| `OnCopy` | `ActionEvent<ClipboardEvent>` | Fires when the user initiates a copy action through the browser's user interface. |
| `OnCut` | `ActionEvent<ClipboardEvent>` | Fired when the user has initiated a "cut" action through the browser's user interface. |
| `OnPaste` | `ActionEvent<ClipboardEvent>` | Fires when the user initiates a paste action through the browser's user interface. |
| `OnAuxClick` | `ActionEvent<PointerEvent>` | Fired when a non-primary pointing device button (e.g., any mouse button other than the left button) has been pressed and released on an element. |
| `OnClick` | `ActionEvent<PointerEvent>` | Fired when a pointing device button (e.g., a mouse's primary button) is pressed and released on a single element. |
| `OnContextMenu` | `ActionEvent<PointerEvent>` | Fired when the user attempts to open a context menu. |
| `OnDblClick` | `ActionEvent<MouseEvent>` | Fired when a pointing device button (e.g., a mouse's primary button) is clicked twice on a single element. |
| `OnMouseDown` | `ActionEvent<MouseEvent>` | Fired when a pointing device button is pressed on an element. |
| `OnMouseEnter` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved over the element that has the listener attached. |
| `OnMouseLeave` | `ActionEvent<MouseEvent>` | Fired when the pointer of a pointing device (usually a mouse) is moved out of an element that has the listener attached to it. |
| `OnMouseMove` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved while over an element. |
| `OnMouseOut` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved off the element to which the listener is attached or off one of its children. |
| `OnMouseOver` | `ActionEvent<MouseEvent>` | Fired when a pointing device is moved onto the element to which the listener is attached or onto one of its children. |
| `OnMouseUp` | `ActionEvent<MouseEvent>` | Fired when a pointing device button is released on an element. |
| `OnBlur` | `ActionEvent<FocusEvent>` | Fired when an element has lost focus. |
| `OnFocus` | `ActionEvent<FocusEvent>` | Fired when an element has gained focus. |
| `OnFocusIn` | `ActionEvent<FocusEvent>` | Fired when an element has gained focus, after focus. |
| `OnFocusOut` | `ActionEvent<FocusEvent>` | Fired when an element has lost focus, after blur. |
| `OnKeyDown` | `ActionEvent<KeyboardEvent>` | The keydown event is fired when a key is pressed. |
| `OnKeyUp` | `ActionEvent<KeyboardEvent>` | The keyup event is fired when a key is released. |
| `OnGotPointerCapture` | `ActionEvent<PointerEvent>` | Fired when an element captures a pointer using setPointerCapture(). |
| `OnLostPointerCapture` | `ActionEvent<PointerEvent>` | Fired when a captured pointer is released. |
| `OnPointerCancel` | `ActionEvent<PointerEvent>` | Fired when a pointer event is canceled. |
| `OnPointerDown` | `ActionEvent<PointerEvent>` | Fired when a pointer becomes active. |
| `OnPointerEnter` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved into the hit test boundaries of an element or one of its descendants. |
| `OnPointerLeave` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved out of the hit test boundaries of an element. |
| `OnPointerMove` | `ActionEvent<PointerEvent>` | Fired when a pointer changes coordinates. |
| `OnPointerOut` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved out of the hit test boundaries of an element (among other reasons). |
| `OnPointerOver` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved into an element's hit test boundaries. |
| `OnPointerRawUpdate` | `ActionEvent<PointerEvent>` | Fired when a pointer changes any properties that don't fire pointerdown or pointerup events. |
| `OnPointerUp` | `ActionEvent<PointerEvent>` | Fired when a pointer is no longer active. |
| `OnGestureChange` | `ActionEvent<GestureEvent>` | Fired when digits move during a touch gesture. |
| `OnGestureEnd` | `ActionEvent<GestureEvent>` | Fired when there are no longer multiple fingers contacting the touch surface, thus ending the gesture. |
| `OnGestureStart` | `ActionEvent<GestureEvent>` | Fired when multiple fingers contact the touch surface, thus starting a new gesture. |
| `OnTouchCancel` | `ActionEvent<TouchEvent>` | Fired when one or more touch points have been disrupted in an implementation-specific manner (for example, too many touch points are created). |
| `OnTouchEnd` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are removed from the touch surface. |
| `OnTouchMove` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are moved along the touch surface. |
| `OnTouchStart` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are placed on the touch surface. |

## Example

```csharp
// Get the document to query for elements
using var document = JS.Get<Document>("document");

// Query for elements
using var header = document.QuerySelector<Element>(".page-header");
if (header != null)
{
    // Read and set attributes
    header.SetAttribute("role", "banner");
    string? role = header.GetAttribute("role");
    bool hasRole = header.HasAttribute("role");
    header.RemoveAttribute("role");

    // Work with class list
    using var classList = header.ClassList;
    classList.Add("active");
    classList.Remove("inactive");
    classList.Toggle("highlight");

    // Read and set innerHTML
    string html = header.InnerHTML;
    header.InnerHTML = "<span>New content</span>";

    // Get element dimensions and position
    using var rect = header.GetBoundingClientRect();
    double top = rect.Top;
    double left = rect.Left;
    double width = rect.Width;
    double height = rect.Height;

    // Scroll the element into view
    header.ScrollIntoView();

    // Query descendants
    using var firstLink = header.QuerySelector<Element>("a");
    using var allItems = header.QuerySelectorAll<Element>(".item");
}

// Element properties
using var el = document.QuerySelector<Element>("#myElement");
if (el != null)
{
    string tag = el.TagName;
    string? id = el.Id;
    int scrollHeight = el.ScrollHeight;
    int clientWidth = el.ClientWidth;

    // Insert adjacent HTML
    el.InsertAdjacentHTML("beforeend", "<p>Added paragraph</p>");

    // Subscribe to events using named methods (required for proper cleanup)
    el.OnClick += Element_OnClick;
    el.OnKeyDown += Element_OnKeyDown;
    el.OnScroll += Element_OnScroll;

    // Request fullscreen
    await el.RequestFullscreen();

    // Unsubscribe before disposing - every += must have a matching -=
    el.OnClick -= Element_OnClick;
    el.OnKeyDown -= Element_OnKeyDown;
    el.OnScroll -= Element_OnScroll;
}

void Element_OnClick(PointerEvent e) => Console.WriteLine($"Clicked at {e.ClientX},{e.ClientY}");
void Element_OnKeyDown(KeyboardEvent e) => Console.WriteLine($"Key: {e.Key}");
void Element_OnScroll(Event e) => Console.WriteLine("Scrolling");
```


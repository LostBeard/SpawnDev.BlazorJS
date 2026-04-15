# Document

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Node`  
**Source:** `JSObjects/DOM/Document.cs`  
**MDN Reference:** [Document on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Document)

> The Document interface represents any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree. https://developer.mozilla.org/en-US/docs/Web/API/Document

## Constructors

| Signature | Description |
|---|---|
| `Document()` | The Document constructor creates a new Document object that is a web page loaded in the browser and serving as an entry point into the page's content. |
| `Document(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ActiveElement` | `Element?` | get | The activeElement read-only property of the Document interface returns the Element within the DOM that currently has focus. |
| `Body` | `HTMLBodyElement?` | get | The Document.body property represents the body or frameset node of the current document, or null if no such element exists. |
| `ChildElementCount` | `int` | get | Returns the number of child elements of the current document. |
| `Children` | `HTMLCollection` | get | Returns the child elements of the current document. |
| `ContentType` | `string` | get | Returns the Content-Type from the MIME Header of the current document. |
| `CurrentScript` | `HTMLScriptElement?` | get | Returns the script element whose script is currently being processed and isn't a JavaScript module. |
| `Cookie` | `string` | get | The Document property cookie lets you read and write cookies associated with the document. It serves as a getter and setter for the actual values of the cookies. |
| `DesignMode` | `string` | get | document.designMode controls whether the entire document is editable. Valid values are "on" and "off". According to the specification, this property is meant to default to "off". Firefox follows this standard. The earlier versions of Chrome and IE default to "inherit". Starting in Chrome 43, the default is "off" and "inherit" is no longer supported. In IE6-10, the value is capitalized. |
| `Dir` | `string` | get | The Document.dir property is a string representing the directionality of the text of the document, whether left to right (default) or right to left. Possible values are 'rtl', right to left, and 'ltr', left to right. |
| `Doctype` | `string?` | get | Returns the Document Type Declaration (DTD) associated with current document. The returned object implements the DocumentType interface. Use DOMImplementation.createDocumentType() to create a DocumentType. |
| `DocumentElement` | `Element?` | get | Document.documentElement returns the Element that is the root element of the document (for example, the html element for HTML documents). |
| `DocumentURI` | `string` | get | The documentURI read-only property of the Document interface returns the document location as a string. |
| `Embeds` | `HTMLCollection?` | get | Returns an HTMLCollection of the embedded embed elements in the document. |
| `FirstElementChild` | `Element?` | get | Returns the first child element of the current document. |
| `Forms` | `HTMLCollection?` | get | Returns an HTMLCollection of the form elements in the document. |
| `FullscreenElement` | `Element?` | get | The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use. |
| `Head` | `HTMLHeadElement?` | get | Returns the head element of the current document. |
| `Images` | `HTMLCollection?` | get | Returns an HTMLCollection of the images in the document. |
| `FullscreenEnabled` | `bool` | get | The read-only fullscreenEnabled property on the Document interface indicates whether or not fullscreen mode is available. |
| `Hidden` | `bool` | get | The Document.hidden read-only property returns a Boolean value indicating if the page is considered hidden or not. |
| `LastElementChild` | `Element?` | get | The Document.lastElementChild read-only property returns the document's last child Element, or null if there are no child elements. |
| `Links` | `HTMLCollection?` | get | Returns an HTMLCollection of the hyperlinks in the document. |
| `Plugins` | `HTMLCollection?` | get | Returns an HTMLCollection of the available plugins. |
| `Scripts` | `HTMLCollection?` | get | Returns an HTMLCollection of the script elements in the document. |
| `ScrollingElement` | `Element?` | get | Returns a reference to the Element that scrolls the document. |
| `Location` | `Location?` | get | The Document.location read-only property returns a Location object, which contains information about the URL of the document and provides methods for changing that URL and loading another URL. |
| `LastModified` | `string` | get | The lastModified property of the Document interface returns a string containing the date and time on which the current document was last modified. |
| `PictureInPictureElement` | `Element?` | get | The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use. |
| `PictureInPictureEnabled` | `bool` | get/set | The read-only pictureInPictureEnabled property of the Document interface indicates whether or not picture-in-picture mode is available. |
| `PointerLockElement` | `Element?` | get | The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document. |
| `Prerendering` | `bool` | get | The prerendering read-only property of the Document interface returns true if the document is currently in the process of prerendering, as initiated via the Speculation Rules API. |
| `ReadyState` | `string` | get | The Document.readyState property describes the loading state of the document. When the value of this property changes, a readystatechange event fires on the document object. |
| `Referrer` | `string` | get | The Document.referrer property returns the URI of the page that linked to this page. |
| `Title` | `string` | get | The document.title property gets or sets the current title of the document. When present, it defaults to the value of the title. |
| `VisibilityState` | `string` | get | The Document.visibilityState read-only property returns the visibility of the document. It can be used to check whether the document is in the background or in a minimized window, or is otherwise not visible to the user. |
| `URL` | `string` | get | Returns the document location as a string. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateTextNode(string data)` | `Text` | Creates a text node. |
| `CreateElement(string tagName)` | `T` | In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized. Element type |
| `CreateElement(string tagName, ElementCreationOptions options)` | `T` | In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized. |
| `CreateElementNS(string namespaceURI, string qualifiedName, ElementCreationOptions options)` | `TElement` | Creates a new element with the given tag name and namespace URI. Return element as type TElement A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs. A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName. An optional ElementCreationOptions object containing a single property named is, whose value is the tag name for a custom element previously defined using customElements.define() TElement |
| `CreateElementNS(string namespaceURI, string qualifiedName)` | `TElement` | Creates a new element with the given tag name and namespace URI. Return element as type TElement A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs. A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName. TElement |
| `ExitFullscreen()` | `Task` | The Document method exitFullscreen() requests that the element on this document which is currently being presented in fullscreen mode be taken out of fullscreen mode, restoring the previous state of the screen. This usually reverses the effects of a previous call to Element.requestFullscreen(). |
| `ExitPointerLock()` | `void` | Release the pointer lock. |
| `ExitPictureInPicture()` | `Task` | Remove the video from the floating picture-in-picture window back to its original container. |
| `QuerySelectorAll(string selector)` | `NodeList` | The Document method querySelectorAll() returns a static (not live) NodeList representing a list of the document's elements that match the specified group of selectors. A string containing one or more selectors to match against. This string must be a valid CSS selector string; if it's not, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more information about using selectors to identify elements. Multiple selectors may be specified by separating them using commas. A non-live NodeList containing one Element object for each element that matches at least one of the specified selectors or an empty NodeList in case of no matches. |
| `QuerySelector(string selector)` | `Element?` | The Document method querySelector() returns the first Element within the document that matches the specified selector, or group of selectors. If no matches are found, null is returned. A string containing one or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more about selectors and how to manage them. An Element object representing the first element in the document that matches the specified set of CSS selectors, or null is returned if there are no matches. |
| `GetElementById(string id)` | `Element?` | Returns an object reference to the identified element. |
| `HasFocus()` | `bool` | The hasFocus() method of the Document interface returns a boolean value indicating whether the document or any element inside the document has focus. This method can be used to determine whether the active element in a document has focus. |
| `Open()` | `Document` | The Document.open() method opens a document for writing. This does come with some side effects.For example: All event listeners currently registered on the document, nodes inside the document, or the document's window are removed. All existing nodes are removed from the document. |
| `Append(params Union<string, Node>[] nodes)` | `void` | The Document.append() method inserts a set of Node objects or string objects after the last child of the document. String objects are inserted as equivalent Text nodes. |
| `Prepend(params Union<string, Node>[] nodes)` | `void` | The Document.prepend() method inserts a set of Node objects or string objects before the first child of the document. String objects are inserted as equivalent Text nodes. |
| `GetSelection()` | `Selection?` | The Window.getSelection() method returns a Selection object representing the range of text selected by the user or the current position of the caret. |
| `GetElementsByClassName(string classNames)` | `HTMLCollection` | Returns a list of elements with the given class name. |
| `GetElementsByTagName(string tagName)` | `HTMLCollection` | Returns a list of elements with the given tag name. |
| `CreateDocumentFragment()` | `DocumentFragment` | Creates a new empty DocumentFragment into which DOM nodes can be added to build an offscreen DOM tree. |
| `CreateComment(string data)` | `Comment` | Creates a new comment node and returns it. |
| `ImportNode(Node node, bool deep)` | `Node` | Imports a node from an external document. |
| `AdoptNode(Node node)` | `Node` | Adopts a node from an external document. The node and its subtree are removed from the document it's in. |
| `CreateRange()` | `Range` | Creates a new Range object. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAuxClick` | `ActionEvent<PointerEvent>` | Fired when a non-primary pointing device button (e.g., any mouse button other than the left button) has been pressed and released. |
| `OnClick` | `ActionEvent<PointerEvent>` | Fired when a pointing device button (e.g., a mouse's primary button) is pressed and released. |
| `OnContextMenu` | `ActionEvent<PointerEvent>` | Fired when the user attempts to open a context menu. |
| `OnDblClick` | `ActionEvent<MouseEvent>` | Fired when a pointing device button (e.g., a mouse's primary button) is clicked twice. |
| `OnMouseDown` | `ActionEvent<MouseEvent>` | Fired when a pointing device button is pressed. |
| `OnMouseEnter` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved over the element that has the listener attached. |
| `OnMouseLeave` | `ActionEvent<MouseEvent>` | Fired when the pointer of a pointing device (usually a mouse) is moved out of an element that has the listener attached to it. |
| `OnMouseMove` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved while over the document. |
| `OnMouseOut` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved off the element to which the listener is attached or off one of its children. |
| `OnMouseOver` | `ActionEvent<MouseEvent>` | Fired when a pointing device is moved onto the element to which the listener is attached or onto one of its children. |
| `OnMouseUp` | `ActionEvent<MouseEvent>` | Fired when a pointing device button is released. |
| `OnKeyDown` | `ActionEvent<KeyboardEvent>` | Fired when a key is pressed. |
| `OnKeyUp` | `ActionEvent<KeyboardEvent>` | Fired when a key is released. |
| `OnPointerCancel` | `ActionEvent<PointerEvent>` | Fired when a pointer event is canceled. |
| `OnPointerDown` | `ActionEvent<PointerEvent>` | Fired when a pointer becomes active. |
| `OnPointerEnter` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved into the hit test boundaries of an element or one of its descendants. |
| `OnPointerLeave` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved out of the hit test boundaries of an element. |
| `OnPointerMove` | `ActionEvent<PointerEvent>` | Fired when a pointer changes coordinates. |
| `OnPointerOut` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved out of the hit test boundaries of an element (among other reasons). |
| `OnPointerOver` | `ActionEvent<PointerEvent>` | Fired when a pointer is moved into an element's hit test boundaries. |
| `OnPointerUp` | `ActionEvent<PointerEvent>` | Fired when a pointer is no longer active. |
| `OnTouchCancel` | `ActionEvent<TouchEvent>` | Fired when one or more touch points have been disrupted in an implementation-specific manner. |
| `OnTouchEnd` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are removed from the touch surface. |
| `OnTouchMove` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are moved along the touch surface. |
| `OnTouchStart` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are placed on the touch surface. |
| `OnBlur` | `ActionEvent<FocusEvent>` | Fired when an element has lost focus. |
| `OnFocus` | `ActionEvent<FocusEvent>` | Fired when an element has gained focus. |
| `OnFocusIn` | `ActionEvent<FocusEvent>` | Fired when an element has gained focus, after focus. |
| `OnFocusOut` | `ActionEvent<FocusEvent>` | Fired when an element has lost focus, after blur. |
| `OnPrerenderingChange` | `ActionEvent<Event>` | The prerenderingchange event is fired on a prerendered document when it is activated (i.e. the user views the page). |
| `OnSecurityPolicyViolation` | `ActionEvent<SecurityPolicyViolationEvent>` | The securitypolicyviolation event is fired when a Content Security Policy is violated. |
| `OnVisibilityChange` | `ActionEvent<Event>` | The visibilitychange event is fired at the document when the contents of its tab have become visible or have been hidden. |
| `OnCopy` | `ActionEvent<ClipboardEvent>` | The copy event fires when the user initiates a copy action through the browser's user interface. |
| `OnCut` | `ActionEvent<ClipboardEvent>` | The cut event fires when the user initiates a cut action through the browser's user interface. |
| `OnPaste` | `ActionEvent<ClipboardEvent>` | The paste event fires when the user initiates a paste action through the browser's user interface. |
| `OnFullscreenChange` | `ActionEvent<Event>` | The fullscreenchange event is fired immediately after the browser switches into or out of fullscreen mode. |
| `OnFullscreenError` | `ActionEvent<Event>` | The fullscreenerror event is fired when the browser cannot switch to fullscreen mode. |
| `OnDOMContentLoaded` | `ActionEvent<Event>` | The DOMContentLoaded event fires when the HTML document has been completely parsed, and all deferred scripts (script defer src="…" and type="module") have downloaded and executed. It doesn't wait for other things like images, subframes, and async scripts to finish loading. |
| `OnReadyStateChange` | `ActionEvent<Event>` | The readystatechange event is fired when the readyState attribute of a document has changed. |
| `OnPointerLockChange` | `ActionEvent<Event>` | The pointerlockchange event is fired when the pointer is locked/unlocked. |
| `OnPointerLockError` | `ActionEvent<Event>` | The pointerlockerror event is fired when locking the pointer failed (for technical reasons or because the permission was denied). |
| `OnScroll` | `ActionEvent<Event>` | The scroll event fires when the document view has been scrolled. To detect when scrolling has completed, see the Document: scrollend event. For element scrolling, see Element: scroll event. |
| `OnScrollEnd` | `ActionEvent<Event>` | The scrollend event fires when the document view has completed scrolling. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture. |
| `OnSelectionChange` | `ActionEvent<Event>` | The selectionchange event of the Selection API is fired when the current Selection of a Document is changed. |

## Example

```csharp
// Get the document via BlazorJSRuntime
using var document = JS.Get<Document>("document");

// Read document properties
string title = document.Title;
document.Title = "My Blazor App";
string readyState = document.ReadyState;
bool isHidden = document.Hidden;
string url = document.URL;

// Query elements by ID
using var container = document.GetElementById<Element>("app-container");

// Query elements by selector
using var firstButton = document.QuerySelector<Element>("button.primary");
using var allLinks = document.QuerySelectorAll<Element>("a[href]");

// Create elements dynamically
using var div = document.CreateElement<HTMLElement>("div");
div.InnerText = "Created with BlazorJS";

using var canvas = document.CreateElement<HTMLCanvasElement>("canvas");

// Access document body and head
using var body = document.Body;
using var head = document.Head;

// Get the active (focused) element
using var focused = document.ActiveElement;

// Check focus state
bool hasFocus = document.HasFocus();

// Listen for document-level events
document.OnVisibilityChange += (e) =>
{
    string state = document.VisibilityState;
    Console.WriteLine($"Visibility: {state}");
};

document.OnKeyDown += (e) =>
{
    Console.WriteLine($"Key pressed: {e.Key}");
};

document.OnDOMContentLoaded += (e) =>
{
    Console.WriteLine("DOM content loaded");
};

// Exit fullscreen
await document.ExitFullscreen();
```


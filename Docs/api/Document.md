# Document

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Document  
**MDN Reference:** [Document on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Document)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/Document.cs`

> The Document interface represents any web page loaded in the browser and serves as an entry point into the web page's content - the DOM tree. It provides methods for creating elements, querying the DOM, and managing document state.

## Constructor

```csharp
// Create a new empty document
public Document()

// From existing reference
public Document(IJSInProcessObjectReference _ref)

// Get the current document
var doc = JS.Get<Document>("document");
var doc = JS.WindowThis?.Document;
```

## Properties

| Property | Type | Description |
|---|---|---|
| `ActiveElement` | `Element?` | The element that currently has focus. |
| `Body` | `HTMLBodyElement` | The document body element. |
| `CharacterSet` | `string` | The character encoding of the document. |
| `ChildElementCount` | `int` | Number of child elements. |
| `Children` | `HTMLCollection` | The child elements. |
| `ContentType` | `string` | The MIME type of the document. |
| `Cookie` | `string` | Get/set document cookies. |
| `CurrentScript` | `HTMLScriptElement?` | The currently executing script element. |
| `DesignMode` | `string` | Get/set the document's design mode ("on"/"off"). |
| `Dir` | `string` | The text direction of the document ("ltr"/"rtl"). |
| `Doctype` | `DocumentType?` | The DOCTYPE node. |
| `DocumentElement` | `Element` | The root element (html element). |
| `DocumentURI` | `string` | The document URI. |
| `Domain` | `string` | The domain of the document. |
| `FirstElementChild` | `Element?` | The first child element. |
| `FullscreenElement` | `Element?` | The element currently in fullscreen mode. |
| `FullscreenEnabled` | `bool` | Whether fullscreen mode is available. |
| `Head` | `HTMLHeadElement` | The head element. |
| `Hidden` | `bool` | Whether the page is hidden. |
| `LastElementChild` | `Element?` | The last child element. |
| `LastModified` | `string` | The date of last modification. |
| `PictureInPictureElement` | `Element?` | The element currently in PiP mode. |
| `PictureInPictureEnabled` | `bool` | Whether PiP is available. |
| `PointerLockElement` | `Element?` | The element with pointer lock. |
| `ReadyState` | `string` | The loading state ("loading"/"interactive"/"complete"). |
| `Referrer` | `string` | The referring URI. |
| `Title` | `string` | Get/set the document title. |
| `URL` | `string` | The document URL. |
| `VisibilityState` | `string` | The visibility state ("visible"/"hidden"). |
| `AdoptedStyleSheets` | `Array<CSSStyleSheet>` | Add an array of constructed stylesheets to be used by the document. These stylesheets may also be shared with shadow DOM subtrees of the same document. |
| `Embeds` | `HTMLCollection?` | Returns an HTMLCollection of the embedded embed elements in the document. |
| `Forms` | `HTMLCollection?` | Returns an HTMLCollection of the form elements in the document. |
| `Images` | `HTMLCollection?` | Returns an HTMLCollection of the images in the document. |
| `Links` | `HTMLCollection?` | Returns an HTMLCollection of the hyperlinks in the document. |
| `Plugins` | `HTMLCollection?` | Returns an HTMLCollection of the available plugins. |
| `Scripts` | `HTMLCollection?` | Returns an HTMLCollection of the script elements in the document. |
| `ScrollingElement` | `Element?` | Returns a reference to the Element that scrolls the document. |
| `Location` | `Location?` | The Document.location read-only property returns a Location object, which contains information about the URL of the document and provides methods for changing that URL and loading another URL. |
| `Prerendering` | `bool` | The prerendering read-only property of the Document interface returns true if the document is currently in the process of prerendering, as initiated via the Speculation Rules API. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateElement(string tagName)` | `Element` | Create an HTML element by tag name. |
| `CreateElement<T>(string tagName)` | `T` | Create a typed HTML element. |
| `CreateElement<T>(string tagName, ElementCreationOptions)` | `T` | Create with options (for custom elements). |
| `CreateElementNS(string nsURI, string qualName)` | `Element` | Create an element with a namespace URI. |
| `CreateElementNS<T>(string nsURI, string qualName)` | `T` | Create a typed namespaced element. |
| `CreateTextNode(string data)` | `Text` | Create a text node. |
| `CreateDocumentFragment()` | `DocumentFragment` | Create a new DocumentFragment. |
| `CreateComment(string data)` | `Comment` | Create a comment node. |
| `CreateRange()` | `Range` | Create a new Range object. |
| `GetElementById(string id)` | `Element?` | Get an element by its ID. |
| `GetElementById<T>(string id)` | `T?` | Get a typed element by ID. |
| `QuerySelector(string selector)` | `Element?` | Get the first matching element. |
| `QuerySelector<T>(string selector)` | `T?` | Get the first matching typed element. |
| `QuerySelectorAll(string selector)` | `NodeList` | Get all matching elements. |
| `QuerySelectorAll<T>(string selector)` | `NodeList<T>` | Get all matching typed elements. |
| `GetElementsByClassName(string classNames)` | `HTMLCollection` | Get elements by class name. |
| `GetElementsByTagName(string tagName)` | `HTMLCollection` | Get elements by tag name. |
| `GetSelection()` | `Selection?` | Get the current text selection. |
| `ImportNode(Node node, bool deep = false)` | `Node` | Import a node from an external document. |
| `AdoptNode(Node node)` | `Node` | Adopt a node from an external document. |
| `HasFocus()` | `bool` | Whether any element in the document has focus. |
| `Open()` | `Document` | Open the document for writing. |
| `Append(params Union<string, Node>[] nodes)` | `void` | Append nodes after the last child. |
| `Prepend(params Union<string, Node>[] nodes)` | `void` | Insert nodes before the first child. |
| `ExitFullscreen()` | `Task` | Exit fullscreen mode. |
| `ExitPointerLock()` | `void` | Release the pointer lock. |
| `ExitPictureInPicture()` | `Task` | Exit Picture-in-Picture mode. |
| `CreateElementNS<TElement>(string namespaceURI, string qualifiedName, ElementCreationOptions options)` | `TElement` | Creates a new element with the given tag name and namespace URI. |
| `CreateElementNS(string namespaceURI, string qualifiedName, ElementCreationOptions options)` | `Element` | Creates a new element with the given tag name and namespace URI. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnReadyStateChange` | `ActionEvent<Event>` | Fired when readyState changes. |
| `OnVisibilityChange` | `ActionEvent<Event>` | Fired when visibility state changes. |
| `OnFullscreenChange` | `ActionEvent<Event>` | Fired when entering/exiting fullscreen. |
| `OnFullscreenError` | `ActionEvent<Event>` | Fired on fullscreen error. |
| `OnPointerlockChange` | `ActionEvent<Event>` | Fired when pointer lock changes. |
| `OnPointerlockError` | `ActionEvent<Event>` | Fired on pointer lock error. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the document is scrolled. |
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
| `OnCopy` | `ActionEvent<ClipboardEvent>` | The copy event fires when the user initiates a copy action through the browser's user interface. |
| `OnCut` | `ActionEvent<ClipboardEvent>` | The cut event fires when the user initiates a cut action through the browser's user interface. |
| `OnPaste` | `ActionEvent<ClipboardEvent>` | The paste event fires when the user initiates a paste action through the browser's user interface. |
| `OnDOMContentLoaded` | `ActionEvent<Event>` | The DOMContentLoaded event fires when the HTML document has been completely parsed, and all deferred scripts (script defer src="…" and type="module") have downloaded and executed. It doesn't wait for other things like images, subframes, and async scripts to finish loading. |
| `OnPointerLockChange` | `ActionEvent<Event>` | The pointerlockchange event is fired when the pointer is locked/unlocked. |
| `OnPointerLockError` | `ActionEvent<Event>` | The pointerlockerror event is fired when locking the pointer failed (for technical reasons or because the permission was denied). |
| `OnScrollEnd` | `ActionEvent<Event>` | The scrollend event fires when the document view has completed scrolling. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture. |
| `OnSelectionChange` | `ActionEvent<Event>` | The selectionchange event of the Selection API is fired when the current Selection of a Document is changed. |

## Constructors

| Signature | Description |
|---|---|
| `Document()` | The Document constructor creates a new Document object that is a web page loaded in the browser and serving as an entry point into the page's content. |

## Example

```csharp
using var doc = JS.Get<Document>("document");

// Create elements
using var div = doc.CreateElement<HTMLDivElement>("div");
div.InnerHTML = "<p>Hello World</p>";
doc.Body.AppendChild(div);

// Query the DOM
using var header = doc.QuerySelector<HTMLElement>("#header");
if (header != null)
{
    header.Style.SetProperty("color", "blue");
}

// Get all matching elements and process them
using var items = doc.QuerySelectorAll<Element>(".item");
// items is disposable - disposes the NodeList and all contained elements
```

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

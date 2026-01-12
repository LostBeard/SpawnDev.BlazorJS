using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Document interface represents any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Document<br/>
    /// </summary>
    public class Document : Node
    {
        #region Constructors
        /// <summary>
        /// The Document constructor creates a new Document object that is a web page loaded in the browser and serving as an entry point into the page's content.
        /// </summary>
        public Document() : base(JS.New(nameof(Document))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Document(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a text node.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Text CreateTextNode(string data) => JSRef!.Call<Text>("createTextNode", data);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public T CreateElement<T>(string tagName) where T : Element => JSRef!.Call<T>("createElement", tagName);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public T CreateElement<T>(string tagName, ElementCreationOptions options) where T : Element => JSRef!.Call<T>("createElement", tagName, options);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public Element CreateElement(string tagName) => JSRef!.Call<Element>("createElement", tagName);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Element CreateElement(string tagName, ElementCreationOptions options) => JSRef!.Call<Element>("createElement", tagName, options);
        /// <summary>
        /// Creates a new element with the given tag name and namespace URI.
        /// </summary>
        /// <typeparam name="TElement">Return element as type TElement</typeparam>
        /// <param name="namespaceURI">A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs.</param>
        /// <param name="qualifiedName">A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName.</param>
        /// <param name="options">An optional ElementCreationOptions object containing a single property named is, whose value is the tag name for a custom element previously defined using customElements.define()</param>
        /// <returns>TElement</returns>
        public TElement CreateElementNS<TElement>(string namespaceURI, string qualifiedName, ElementCreationOptions options) where TElement : Element => JSRef!.Call<TElement>("createElementNS", namespaceURI, qualifiedName, options);
        /// <summary>
        /// Creates a new element with the given tag name and namespace URI.
        /// </summary>
        /// <param name="namespaceURI">A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs.</param>
        /// <param name="qualifiedName">A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName.</param>
        /// <param name="options">An optional ElementCreationOptions object containing a single property named is, whose value is the tag name for a custom element previously defined using customElements.define()</param>
        /// <returns>TElement</returns>
        public Element CreateElementNS(string namespaceURI, string qualifiedName, ElementCreationOptions options) => JSRef!.Call<Element>("createElementNS", namespaceURI, qualifiedName, options);
        /// <summary>
        /// Creates a new element with the given tag name and namespace URI.
        /// </summary>
        /// <typeparam name="TElement">Return element as type TElement</typeparam>
        /// <param name="namespaceURI">A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs.</param>
        /// <param name="qualifiedName">A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName.</param>
        /// <returns>TElement</returns>
        public TElement CreateElementNS<TElement>(string namespaceURI, string qualifiedName) where TElement : Element => JSRef!.Call<TElement>("createElementNS", namespaceURI, qualifiedName);
        /// <summary>
        /// Creates a new element with the given tag name and namespace URI.
        /// </summary>
        /// <param name="namespaceURI">A string that specifies the namespace URI to associate with the element. The namespaceURI property of the created element is initialized with the value of namespaceURI. See Valid Namespace URIs.</param>
        /// <param name="qualifiedName">A string that specifies the type of element to be created. The nodeName property of the created element is initialized with the value of qualifiedName.</param>
        /// <returns>TElement</returns>
        public Element CreateElementNS(string namespaceURI, string qualifiedName) => JSRef!.Call<Element>("createElementNS", namespaceURI, qualifiedName);
        /// <summary>
        /// The Document method exitFullscreen() requests that the element on this document which is currently being presented in fullscreen mode be taken out of fullscreen mode, restoring the previous state of the screen. This usually reverses the effects of a previous call to Element.requestFullscreen().
        /// </summary>
        /// <returns></returns>
        public Task ExitFullscreen() => JSRef!.CallVoidAsync("exitFullscreen");
        /// <summary>
        /// Release the pointer lock.
        /// </summary>
        public void ExitPointerLock() => JSRef!.CallVoid("exitPointerLock");
        /// <summary>
        /// Remove the video from the floating picture-in-picture window back to its original container.
        /// </summary>
        /// <returns></returns>
        public Task ExitPictureInPicture() => JSRef!.CallVoidAsync("exitPictureInPicture");
        /// <summary>
        /// The Document method querySelectorAll() returns a static (not live) NodeList representing a list of the document's elements that match the specified group of selectors.
        /// </summary>
        /// <param name="selector">A string containing one or more selectors to match against. This string must be a valid CSS selector string; if it's not, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more information about using selectors to identify elements. Multiple selectors may be specified by separating them using commas.</param>
        /// <returns>A non-live NodeList containing one Element object for each element that matches at least one of the specified selectors or an empty NodeList in case of no matches.</returns>
        public NodeList QuerySelectorAll(string selector) => JSRef!.Call<NodeList>("querySelectorAll", selector);
        /// <summary>
        /// The Document method querySelectorAll() returns a static (not live) NodeList representing a list of the document's elements that match the specified group of selectors.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public NodeList<T> QuerySelectorAll<T>(string selector) where T : Node => JSRef!.Call<NodeList<T>>("querySelectorAll", selector);
        /// <summary>
        /// The Document method querySelector() returns the first Element within the document that matches the specified selector, or group of selectors. If no matches are found, null is returned.
        /// </summary>
        /// <param name="selector">A string containing one or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more about selectors and how to manage them.</param>
        /// <returns>An Element object representing the first element in the document that matches the specified set of CSS selectors, or null is returned if there are no matches.</returns>
        public Element? QuerySelector(string selector) => JSRef!.Call<Element?>("querySelector", selector);
        /// <summary>
        /// The Document method querySelector() returns the first Element within the document that matches the specified selector, or group of selectors. If no matches are found, null is returned.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public TElement? QuerySelector<TElement>(string selector) where TElement : Element => JSRef!.Call<TElement?>("querySelector", selector);
        /// <summary>
        /// Returns an object reference to the identified element.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Element? GetElementById(string id) => JSRef!.Call<Element?>("getElementById", id);
        /// <summary>
        /// Returns an object reference to the identified element.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TElement? GetElementById<TElement>(string id) where TElement : Element => JSRef!.Call<TElement?>("getElementById", id);
        /// <summary>
        /// The hasFocus() method of the Document interface returns a boolean value indicating whether the document or any element inside the document has focus. This method can be used to determine whether the active element in a document has focus.
        /// </summary>
        /// <returns></returns>
        public bool HasFocus() => JSRef!.Call<bool>("hasFocus");
        /// <summary>
        /// The Document.open() method opens a document for writing.<br/>
        /// This does come with some side effects.For example:<br/>
        /// All event listeners currently registered on the document, nodes inside the document, or the document's window are removed.<br/>
        /// All existing nodes are removed from the document.
        /// </summary>
        /// <returns></returns>
        public Document Open() => JSRef!.Call<Document>("open");
        /// <summary>
        /// The Document.append() method inserts a set of Node objects or string objects after the last child of the document. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Append(params Union<string, Node>[] nodes) => JSRef!.CallApplyVoid("append", nodes);
        /// <summary>
        /// The Document.prepend() method inserts a set of Node objects or string objects before the first child of the document. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Prepend(params Union<string, Node>[] nodes) => JSRef!.CallApplyVoid("prepend", nodes);
        /// <summary>
        /// The Window.getSelection() method returns a Selection object representing the range of text selected by the user or the current position of the caret.
        /// </summary>
        /// <returns></returns>
        public Selection? GetSelection() => JSRef!.Call<Selection?>("getSelection");
        #endregion

        #region Properties
        /// <summary>
        /// The activeElement read-only property of the Document interface returns the Element within the DOM that currently has focus.
        /// </summary>
        public Element? ActiveElement => JSRef!.Get<Element?>("activeElement");
        /// <summary>
        /// The Document.body property represents the body or frameset node of the current document, or null if no such element exists.
        /// </summary>
        public HTMLBodyElement? Body => JSRef!.Get<HTMLBodyElement?>("body");
        /// <summary>
        /// Returns the number of child elements of the current document.
        /// </summary>
        public int ChildElementCount => JSRef!.Get<int>("childElementCount");
        /// <summary>
        /// Returns the child elements of the current document.
        /// </summary>
        public HTMLCollection Children => JSRef!.Get<HTMLCollection>("children");
        /// <summary>
        /// Returns the Content-Type from the MIME Header of the current document.
        /// </summary>
        public string ContentType => JSRef!.Get<string>("contentType");
        /// <summary>
        /// Returns the script element whose script is currently being processed and isn't a JavaScript module.
        /// </summary>
        public HTMLScriptElement? CurrentScript => JSRef!.Get<HTMLScriptElement?>("currentScript");
        /// <summary>
        /// The Document property cookie lets you read and write cookies associated with the document. It serves as a getter and setter for the actual values of the cookies.
        /// </summary>
        public string Cookie { get => JSRef!.Get<string>("cookie"); set => JSRef!.Set("cookie", value); }
        /// <summary>
        /// document.designMode controls whether the entire document is editable. Valid values are "on" and "off". According to the specification, this property is meant to default to "off". Firefox follows this standard. The earlier versions of Chrome and IE default to "inherit". Starting in Chrome 43, the default is "off" and "inherit" is no longer supported. In IE6-10, the value is capitalized.
        /// </summary>
        public string DesignMode { get => JSRef!.Get<string>("designMode"); set => JSRef!.Set("designMode", value); }
        /// <summary>
        /// The Document.dir property is a string representing the directionality of the text of the document, whether left to right (default) or right to left. Possible values are 'rtl', right to left, and 'ltr', left to right.
        /// </summary>
        public string Dir => JSRef!.Get<string>("dir");
        /// <summary>
        /// Returns the Document Type Declaration (DTD) associated with current document. The returned object implements the DocumentType interface. Use DOMImplementation.createDocumentType() to create a DocumentType.
        /// </summary>
        public string? Doctype => JSRef!.Get<string?>("doctype");
        /// <summary>
        /// Document.documentElement returns the Element that is the root element of the document (for example, the html element for HTML documents).
        /// </summary>
        public Element? DocumentElement => JSRef!.Get<Element?>("documentElement");
        /// <summary>
        /// The documentURI read-only property of the Document interface returns the document location as a string.
        /// </summary>
        public string DocumentURI => JSRef!.Get<string>("documentURI");
        /// <summary>
        /// Returns an HTMLCollection of the embedded embed elements in the document.
        /// </summary>
        public HTMLCollection? Embeds => JSRef!.Get<HTMLCollection?>("embeds");
        /// <summary>
        /// Returns the first child element of the current document.
        /// </summary>
        public Element? FirstElementChild => JSRef!.Get<Element?>("firstElementChild");
        /// <summary>
        /// Returns an HTMLCollection of the form elements in the document.
        /// </summary>
        public HTMLCollection? Forms => JSRef!.Get<HTMLCollection?>("forms");
        /// <summary>
        /// The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use.
        /// </summary>
        public Element? FullscreenElement => JSRef!.Get<Element?>("fullscreenElement");
        /// <summary>
        /// Returns the head element of the current document.
        /// </summary>
        public HTMLHeadElement? Head => JSRef!.Get<HTMLHeadElement?>("head");
        /// <summary>
        /// Returns an HTMLCollection of the images in the document.
        /// </summary>
        public HTMLCollection? Images => JSRef!.Get<HTMLCollection?>("images");
        /// <summary>
        /// The read-only fullscreenEnabled property on the Document interface indicates whether or not fullscreen mode is available.
        /// </summary>
        public bool FullscreenEnabled => JSRef!.Get<bool>("fullscreenEnabled");
        /// <summary>
        /// The Document.hidden read-only property returns a Boolean value indicating if the page is considered hidden or not.
        /// </summary>
        public bool Hidden => JSRef!.Get<bool>("hidden");
        /// <summary>
        /// The Document.lastElementChild read-only property returns the document's last child Element, or null if there are no child elements.
        /// </summary>
        public Element? LastElementChild => JSRef!.Get<Element?>("lastElementChild");
        /// <summary>
        /// Returns an HTMLCollection of the hyperlinks in the document.
        /// </summary>
        public HTMLCollection? Links => JSRef!.Get<HTMLCollection?>("links");
        /// <summary>
        /// Returns an HTMLCollection of the available plugins.
        /// </summary>
        public HTMLCollection? Plugins => JSRef!.Get<HTMLCollection?>("plugins");
        /// <summary>
        /// Returns an HTMLCollection of the script elements in the document.
        /// </summary>
        public HTMLCollection? Scripts => JSRef!.Get<HTMLCollection?>("scripts");
        /// <summary>
        /// Returns a reference to the Element that scrolls the document.
        /// </summary>
        public Element? ScrollingElement => JSRef!.Get<Element?>("scrollingElement");
        /// <summary>
        /// The Document.location read-only property returns a Location object, which contains information about the URL of the document and provides methods for changing that URL and loading another URL.
        /// </summary>
        public Location? Location => JSRef!.Get<Location?>("location");
        /// <summary>
        /// The lastModified property of the Document interface returns a string containing the date and time on which the current document was last modified.
        /// </summary>
        public string LastModified => JSRef!.Get<string>("lastModified");
        /// <summary>
        /// The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use.
        /// </summary>
        public Element? PictureInPictureElement => JSRef!.Get<Element?>("pictureInPictureElement");
        /// <summary>
        /// The read-only pictureInPictureEnabled property of the Document interface indicates whether or not picture-in-picture mode is available.
        /// </summary>
        public bool PictureInPictureEnabled => JSRef!.Get<bool>("pictureInPictureEnabled");
        /// <summary>
        /// The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document.
        /// </summary>
        public Element? PointerLockElement => JSRef!.Get<Element?>("pointerLockElement");
        /// <summary>
        /// The prerendering read-only property of the Document interface returns true if the document is currently in the process of prerendering, as initiated via the Speculation Rules API.
        /// </summary>
        public bool Prerendering => JSRef!.Get<bool>("prerendering");
        /// <summary>
        /// The Document.readyState property describes the loading state of the document. When the value of this property changes, a readystatechange event fires on the document object.
        /// </summary>
        public string ReadyState => JSRef!.Get<string>("readyState");
        /// <summary>
        /// The Document.referrer property returns the URI of the page that linked to this page.
        /// </summary>
        public string Referrer => JSRef!.Get<string>("referrer");
        /// <summary>
        /// The document.title property gets or sets the current title of the document. When present, it defaults to the value of the title.
        /// </summary>
        public string Title { get => JSRef!.Get<string>("title"); set => JSRef!.Set("title", value); }
        /// <summary>
        /// The Document.visibilityState read-only property returns the visibility of the document. It can be used to check whether the document is in the background or in a minimized window, or is otherwise not visible to the user.
        /// </summary>
        public string VisibilityState => JSRef!.Get<string>("visibilityState");
        /// <summary>
        /// Returns the document location as a string.
        /// </summary>
        public string URL => JSRef!.Get<string>("URL");
        #endregion

        #region Events
        // https://developer.mozilla.org/en-US/docs/Web/API/Document#events
        /// <summary>
        /// The prerenderingchange event is fired on a prerendered document when it is activated (i.e. the user views the page).
        /// </summary>
        public ActionEvent<Event> OnPrerenderingChange { get => new ActionEvent<Event>("prerenderingchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The securitypolicyviolation event is fired when a Content Security Policy is violated.
        /// </summary>
        public ActionEvent<SecurityPolicyViolationEvent> OnSecurityPolicyViolation { get => new ActionEvent<SecurityPolicyViolationEvent>("securitypolicyviolation", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The visibilitychange event is fired at the document when the contents of its tab have become visible or have been hidden.
        /// </summary>
        public ActionEvent<Event> OnVisibilityChange { get => new ActionEvent<Event>("visibilitychange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The copy event fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnCopy { get => new ActionEvent<ClipboardEvent>("copy", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The cut event fires when the user initiates a cut action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnCut { get => new ActionEvent<ClipboardEvent>("cut", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The paste event fires when the user initiates a paste action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnPaste { get => new ActionEvent<ClipboardEvent>("paste", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The fullscreenchange event is fired immediately after the browser switches into or out of fullscreen mode.
        /// </summary>
        public ActionEvent<Event> OnFullscreenChange { get => new ActionEvent<Event>("fullscreenchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The fullscreenerror event is fired when the browser cannot switch to fullscreen mode.
        /// </summary>
        public ActionEvent<Event> OnFullscreenError { get => new ActionEvent<Event>("fullscreenerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The DOMContentLoaded event fires when the HTML document has been completely parsed, and all deferred scripts (script defer src="…" and type="module") have downloaded and executed. It doesn't wait for other things like images, subframes, and async scripts to finish loading.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnDOMContentLoaded { get => new ActionEvent<ClipboardEvent>("DOMContentLoaded", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The readystatechange event is fired when the readyState attribute of a document has changed.
        /// </summary>
        public ActionEvent<Event> OnReadyStateChange { get => new ActionEvent<Event>("readystatechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The pointerlockchange event is fired when the pointer is locked/unlocked.
        /// </summary>
        public ActionEvent<Event> OnPointerLockChange { get => new ActionEvent<Event>("pointerlockchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The pointerlockerror event is fired when locking the pointer failed (for technical reasons or because the permission was denied).
        /// </summary>
        public ActionEvent<Event> OnPointerLockError { get => new ActionEvent<Event>("pointerlockerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The scroll event fires when the document view has been scrolled. To detect when scrolling has completed, see the Document: scrollend event. For element scrolling, see Element: scroll event.
        /// </summary>
        public ActionEvent<Event> OnScroll { get => new ActionEvent<Event>("scroll", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The scrollend event fires when the document view has completed scrolling. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture.
        /// </summary>
        public ActionEvent<Event> OnScrollEnd { get => new ActionEvent<Event>("scrollend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The selectionchange event of the Selection API is fired when the current Selection of a Document is changed.
        /// </summary>
        public ActionEvent<Event> OnSelectionChange { get => new ActionEvent<Event>("selectionchange", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}

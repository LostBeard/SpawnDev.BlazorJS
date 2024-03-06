using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Document interface represents any web page loaded in the browser and serves as an entry point into the web page's content, which is the DOM tree.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Document<br />
    /// TODO - finish implementation
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
        public Text CreateTextNode(string data) => JSRef.Call<Text>("createTextNode", data);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public T CreateElement<T>(string tagName) where T : Element => JSRef.Call<T>("createElement", tagName);
        /// <summary>
        /// In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public IJSInProcessObjectReference CreateElement(string tagName) => JSRef.Call<IJSInProcessObjectReference>("createElement", tagName);
        /// <summary>
        /// The Document method exitFullscreen() requests that the element on this document which is currently being presented in fullscreen mode be taken out of fullscreen mode, restoring the previous state of the screen. This usually reverses the effects of a previous call to Element.requestFullscreen().
        /// </summary>
        /// <returns></returns>
        public Task ExitFullscreen() => JSRef.CallVoidAsync("exitFullscreen");
        /// <summary>
        /// The Document method querySelectorAll() returns a static (not live) NodeList representing a list of the document's elements that match the specified group of selectors.
        /// </summary>
        /// <param name="selector">A string containing one or more selectors to match against. This string must be a valid CSS selector string; if it's not, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more information about using selectors to identify elements. Multiple selectors may be specified by separating them using commas.</param>
        /// <returns>A non-live NodeList containing one Element object for each element that matches at least one of the specified selectors or an empty NodeList in case of no matches.</returns>
        public NodeList QuerySelectorAll(string selector) => JSRef.Call<NodeList>("querySelectorAll", selector);
        /// <summary>
        /// The Document method querySelector() returns the first Element within the document that matches the specified selector, or group of selectors. If no matches are found, null is returned.
        /// </summary>
        /// <param name="selector">A string containing one or more selectors to match. This string must be a valid CSS selector string; if it isn't, a SyntaxError exception is thrown. See Locating DOM elements using selectors for more about selectors and how to manage them.</param>
        /// <returns>An Element object representing the first element in the document that matches the specified set of CSS selectors, or null is returned if there are no matches.</returns>
        public Element? QuerySelector(string selector) => JSRef.Call<Element?>("querySelector", selector);
        /// <summary>
        /// The Document method querySelector() returns the first Element within the document that matches the specified selector, or group of selectors. If no matches are found, null is returned.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public TElement? QuerySelector<TElement>(string selector) where TElement : Element => JSRef.Call<TElement?>("querySelector", selector);
        /// <summary>
        /// Returns an object reference to the identified element.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Element? GetElementById(string id) => JSRef.Call<Element?>("getElementById", id);
        /// <summary>
        /// Returns an object reference to the identified element.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TElement? GetElementById<TElement>(string id) where TElement : Element => JSRef.Call<TElement?>("getElementById", id);
        /// <summary>
        /// The hasFocus() method of the Document interface returns a boolean value indicating whether the document or any element inside the document has focus. This method can be used to determine whether the active element in a document has focus.
        /// </summary>
        /// <returns></returns>
        public bool HasFocus() => JSRef.Call<bool>("hasFocus");
        /// <summary>
        /// The Document.open() method opens a document for writing.<br />
        /// This does come with some side effects.For example:<br />
        /// All event listeners currently registered on the document, nodes inside the document, or the document's window are removed.<br />
        /// All existing nodes are removed from the document.
        /// </summary>
        /// <returns></returns>
        public Document Open() => JSRef.Call<Document>("open");
        /// <summary>
        /// The Document.append() method inserts a set of Node objects or string objects after the last child of the document. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Append(params Union<string, Node>[] nodes) => JSRef.CallApplyVoid("append", nodes);
        /// <summary>
        /// The Document.prepend() method inserts a set of Node objects or string objects before the first child of the document. String objects are inserted as equivalent Text nodes.
        /// </summary>
        /// <param name="nodes"></param>
        public void Prepend(params Union<string, Node>[] nodes) => JSRef.CallApplyVoid("prepend", nodes);
        /// <summary>
        /// The Window.getSelection() method returns a Selection object representing the range of text selected by the user or the current position of the caret.
        /// </summary>
        /// <returns></returns>
        public Selection GetSelection() => JSRef.Call<Selection>("getSelection");
        #endregion

        #region Properties
        /// <summary>
        /// The activeElement read-only property of the Document interface returns the Element within the DOM that currently has focus.
        /// </summary>
        public Element? ActiveElement => JSRef.Get<Element?>("activeElement");
        /// <summary>
        /// The head read-only property of the Document interface returns the head element of the current document.
        /// </summary>
        public HTMLHeadElement? Head => JSRef.Get<HTMLHeadElement?>("head");
        /// <summary>
        /// The Document.body property represents the body or frameset node of the current document, or null if no such element exists.
        /// </summary>
        public HTMLBodyElement? Body => JSRef.Get<HTMLBodyElement?>("body");
        /// <summary>
        /// The Document property cookie lets you read and write cookies associated with the document. It serves as a getter and setter for the actual values of the cookies.
        /// </summary>
        public string Cookie { get => JSRef.Get<string>("cookie"); set => JSRef.Set("cookie", value); }
        /// <summary>
        /// document.designMode controls whether the entire document is editable. Valid values are "on" and "off". According to the specification, this property is meant to default to "off". Firefox follows this standard. The earlier versions of Chrome and IE default to "inherit". Starting in Chrome 43, the default is "off" and "inherit" is no longer supported. In IE6-10, the value is capitalized.
        /// </summary>
        public string DesignMode { get => JSRef.Get<string>("designMode"); set => JSRef.Set("designMode", value); }
        /// <summary>
        /// The Document.dir property is a string representing the directionality of the text of the document, whether left to right (default) or right to left. Possible values are 'rtl', right to left, and 'ltr', left to right.
        /// </summary>
        public string Dir => JSRef.Get<string>("dir");
        /// <summary>
        /// Returns the Document Type Declaration (DTD) associated with current document. The returned object implements the DocumentType interface. Use DOMImplementation.createDocumentType() to create a DocumentType.
        /// </summary>
        public string? Doctype => JSRef.Get<string?>("doctype");
        /// <summary>
        /// Document.documentElement returns the Element that is the root element of the document (for example, the html element for HTML documents).
        /// </summary>
        public Element? DocumentElement => JSRef.Get<Element?>("documentElement");
        /// <summary>
        /// The documentURI read-only property of the Document interface returns the document location as a string.
        /// </summary>
        public string DocumentURI => JSRef.Get<string>("documentURI");
        /// <summary>
        /// The Document.fullscreenElement read-only property returns the Element that is currently being presented in fullscreen mode in this document, or null if fullscreen mode is not currently in use.
        /// </summary>
        public Element? FullscreenElement => JSRef.Get<Element?>("fullscreenElement");
        /// <summary>
        /// The read-only fullscreenEnabled property on the Document interface indicates whether or not fullscreen mode is available.
        /// </summary>
        public bool FullscreenEnabled => JSRef.Get<bool>("fullscreenEnabled");
        /// <summary>
        /// The Document.hidden read-only property returns a Boolean value indicating if the page is considered hidden or not.
        /// </summary>
        public bool Hidden => JSRef.Get<bool>("hidden");
        /// <summary>
        /// The Document.lastElementChild read-only property returns the document's last child Element, or null if there are no child elements.
        /// </summary>
        public Element? LastElementChild => JSRef.Get<Element?>("lastElementChild");
        /// <summary>
        /// The Document.location read-only property returns a Location object, which contains information about the URL of the document and provides methods for changing that URL and loading another URL.
        /// </summary>
        public Location? Location => JSRef.Get<Location?>("location");
        /// <summary>
        /// The lastModified property of the Document interface returns a string containing the date and time on which the current document was last modified.
        /// </summary>
        public string LastModified => JSRef.Get<string>("lastModified");
        /// <summary>
        /// The Document.pictureInPictureElement read-only property returns the Element that is currently being presented in picture-in-picture mode in this document, or null if picture-in-picture mode is not currently in use.
        /// </summary>
        public Element? PictureInPictureElement => JSRef.Get<Element?>("pictureInPictureElement");
        /// <summary>
        /// The read-only pictureInPictureEnabled property of the Document interface indicates whether or not picture-in-picture mode is available.
        /// </summary>
        public bool PictureInPictureEnabled => JSRef.Get<bool>("pictureInPictureEnabled");
        /// <summary>
        /// The read-only pointerLockElement property of the Document interface provides the element set as the target for mouse events while the pointer is locked. It is null if lock is pending, pointer is unlocked, or the target is in another document.
        /// </summary>
        public Element? PointerLockElement => JSRef.Get<Element?>("pointerLockElement");
        /// <summary>
        /// The prerendering read-only property of the Document interface returns true if the document is currently in the process of prerendering, as initiated via the Speculation Rules API.
        /// </summary>
        public bool Prerendering => JSRef.Get<bool>("prerendering");
        /// <summary>
        /// The Document.readyState property describes the loading state of the document. When the value of this property changes, a readystatechange event fires on the document object.
        /// </summary>
        public string ReadyState => JSRef.Get<string>("readyState");
        /// <summary>
        /// The Document.referrer property returns the URI of the page that linked to this page.
        /// </summary>
        public string Referrer => JSRef.Get<string>("referrer");
        /// <summary>
        /// The document.title property gets or sets the current title of the document. When present, it defaults to the value of the title.
        /// </summary>
        public string Title { get => JSRef.Get<string>("title"); set => JSRef.Set("title", value);  }
        /// <summary>
        /// The Document.visibilityState read-only property returns the visibility of the document. It can be used to check whether the document is in the background or in a minimized window, or is otherwise not visible to the user.
        /// </summary>
        public string VisibilityState => JSRef.Get<string>("visibilityState");
        #endregion

        #region Events
        // TODO - event callback types need to be checked/added
        /// <summary>
        /// The copy event fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCopy { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("copy", o), o => RemoveEventListener("copy", o)); set { /** required **/ } }
        /// <summary>
        /// The cut event fires when the user initiates a cut action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCut { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("cut", o), o => RemoveEventListener("cut", o)); set { /** required **/ } }
        /// <summary>
        /// The DOMContentLoaded event fires when the HTML document has been completely parsed, and all deferred scripts (<script defer src="…"> and <script type="module">) have downloaded and executed. It doesn't wait for other things like images, subframes, and async scripts to finish loading.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnDOMContentLoaded { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("DOMContentLoaded", o), o => RemoveEventListener("DOMContentLoaded", o)); set { /** required **/ } }
        /// <summary>
        /// The fullscreenchange event is fired immediately after the browser switches into or out of fullscreen mode.
        /// </summary>
        public JSEventCallback<Event> OnFullscreenChange { get => new JSEventCallback<Event>(o => AddEventListener("fullscreenchange", o), o => RemoveEventListener("fullscreenchange", o)); set { } }
        /// <summary>
        /// The fullscreenerror event is fired when the browser cannot switch to fullscreen mode.
        /// </summary>
        public JSEventCallback<Event> OnFullscreenError { get => new JSEventCallback<Event>(o => AddEventListener("fullscreenerror", o), o => RemoveEventListener("fullscreenerror", o)); set { /** required **/ } }
        /// <summary>
        /// The paste event fires when the user initiates a paste action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnPaste { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("paste", o), o => RemoveEventListener("paste", o)); set { /** required **/ } }
        /// <summary>
        /// The pointerlockchange event is fired when the pointer is locked/unlocked.
        /// </summary>
        public JSEventCallback<Event> OnPointerLockChange { get => new JSEventCallback<Event>(o => AddEventListener("pointerlockchange", o), o => RemoveEventListener("pointerlockchange", o)); set { /** required **/ } }
        /// <summary>
        /// The pointerlockerror event is fired when locking the pointer failed (for technical reasons or because the permission was denied).
        /// </summary>
        public JSEventCallback<Event> OnPointerLockError { get => new JSEventCallback<Event>(o => AddEventListener("pointerlockerror", o), o => RemoveEventListener("pointerlockerror", o)); set { /** required **/ } }
        /// <summary>
        /// The prerenderingchange event is fired on a prerendered document when it is activated (i.e. the user views the page).
        /// </summary>
        public JSEventCallback<Event> OnPrerenderingChange { get => new JSEventCallback<Event>(o => AddEventListener("prerenderingchange", o), o => RemoveEventListener("prerenderingchange", o)); set { /** required **/ } }
        /// <summary>
        /// The readystatechange event is fired when the readyState attribute of a document has changed.
        /// </summary>
        public JSEventCallback<Event> OnReadyStateChange { get => new JSEventCallback<Event>(o => AddEventListener("readystatechange", o), o => RemoveEventListener("readystatechange", o)); set { /** required **/ } }
        /// <summary>
        /// The scroll event fires when the document view has been scrolled. To detect when scrolling has completed, see the Document: scrollend event. For element scrolling, see Element: scroll event.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>(o => AddEventListener("scroll", o), o => RemoveEventListener("scroll", o)); set { /** required **/ } }
        /// <summary>
        /// The scrollend event fires when the document view has completed scrolling. Scrolling is considered completed when the scroll position has no more pending updates and the user has completed their gesture.
        /// </summary>
        public JSEventCallback<Event> OnScrollEnd { get => new JSEventCallback<Event>(o => AddEventListener("scrollend", o), o => RemoveEventListener("scrollend", o)); set { /** required **/ } }
        /// <summary>
        /// The securitypolicyviolation event is fired when a Content Security Policy is violated.
        /// </summary>
        public JSEventCallback<SecurityPolicyViolationEvent> OnSecurityPolicyViolation { get => new JSEventCallback<SecurityPolicyViolationEvent>(o => AddEventListener("securitypolicyviolation", o), o => RemoveEventListener("securitypolicyviolation", o)); set { /** required **/ } }
        /// <summary>
        /// The selectionchange event of the Selection API is fired when the current Selection of a Document is changed.
        /// </summary>
        public JSEventCallback<Event> OnSelectionChange { get => new JSEventCallback<Event>(o => AddEventListener("selectionchange", o), o => RemoveEventListener("selectionchange", o)); set { /** required **/ } }
        /// <summary>
        /// The visibilitychange event is fired at the document when the contents of its tab have become visible or have been hidden.
        /// </summary>
        public JSEventCallback<Event> OnVisibilityChange { get => new JSEventCallback<Event>(o => AddEventListener("visibilitychange", o), o => RemoveEventListener("visibilitychange", o)); set { /** required **/ } }

        // bubbleable events
        public JSEventCallback OnAbort { get => new JSEventCallback(o => AddEventListener("abort", o), o => RemoveEventListener("abort", o)); set { /** required **/ } }
        public JSEventCallback OnAnimationEnd { get => new JSEventCallback(o => AddEventListener("animationend", o), o => RemoveEventListener("animationend", o)); set { /** required **/ } }
        public JSEventCallback OnAnimationIteration { get => new JSEventCallback(o => AddEventListener("animationiteration", o), o => RemoveEventListener("animationiteration", o)); set { /** required **/ } }
        public JSEventCallback OnAnimationStart { get => new JSEventCallback(o => AddEventListener("animationstart", o), o => RemoveEventListener("animationstart", o)); set { /** required **/ } }
        public JSEventCallback OnAuxClick { get => new JSEventCallback(o => AddEventListener("auxclick", o), o => RemoveEventListener("auxclick", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeCopy { get => new JSEventCallback(o => AddEventListener("beforecopy", o), o => RemoveEventListener("beforecopy", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeCut { get => new JSEventCallback(o => AddEventListener("beforecut", o), o => RemoveEventListener("beforecut", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeInput { get => new JSEventCallback(o => AddEventListener("beforeinput", o), o => RemoveEventListener("beforeinput", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeMatch { get => new JSEventCallback(o => AddEventListener("beforematch", o), o => RemoveEventListener("beforematch", o)); set { /** required **/ } }
        public JSEventCallback OnBeforePaste { get => new JSEventCallback(o => AddEventListener("beforepaste", o), o => RemoveEventListener("beforepaste", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeToggle { get => new JSEventCallback(o => AddEventListener("beforetoggle", o), o => RemoveEventListener("beforetoggle", o)); set { /** required **/ } }
        public JSEventCallback OnBeforeXRSelect { get => new JSEventCallback(o => AddEventListener("beforexrselect", o), o => RemoveEventListener("beforexrselect", o)); set { /** required **/ } }
        public JSEventCallback OnBlur { get => new JSEventCallback(o => AddEventListener("blur", o), o => RemoveEventListener("blur", o)); set { /** required **/ } }
        public JSEventCallback OnCancel { get => new JSEventCallback(o => AddEventListener("cancel", o), o => RemoveEventListener("cancel", o)); set { /** required **/ } }
        public JSEventCallback OnCanPlay { get => new JSEventCallback(o => AddEventListener("canplay", o), o => RemoveEventListener("canplay", o)); set { /** required **/ } }
        public JSEventCallback OnCanplayThrough { get => new JSEventCallback(o => AddEventListener("canplaythrough", o), o => RemoveEventListener("canplaythrough", o)); set { /** required **/ } }
        public JSEventCallback OnChange { get => new JSEventCallback(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { /** required **/ } }
        public JSEventCallback OnClick { get => new JSEventCallback(o => AddEventListener("click", o), o => RemoveEventListener("click", o)); set { /** required **/ } }
        public JSEventCallback OnClose { get => new JSEventCallback(o => AddEventListener("close", o), o => RemoveEventListener("close", o)); set { /** required **/ } }
        public JSEventCallback OnContentVisibilityAutoStateChange { get => new JSEventCallback(o => AddEventListener("contentvisibilityautostatechange", o), o => RemoveEventListener("contentvisibilityautostatechange", o)); set { /** required **/ } }
        public JSEventCallback OnContextLost { get => new JSEventCallback(o => AddEventListener("contextlost", o), o => RemoveEventListener("contextlost", o)); set { /** required **/ } }
        public JSEventCallback OnContextMenu { get => new JSEventCallback(o => AddEventListener("contextmenu", o), o => RemoveEventListener("contextmenu", o)); set { /** required **/ } }
        public JSEventCallback OnContextRestored { get => new JSEventCallback(o => AddEventListener("contextrestored", o), o => RemoveEventListener("contextrestored", o)); set { /** required **/ } }
        public JSEventCallback OnCueChange { get => new JSEventCallback(o => AddEventListener("cuechange", o), o => RemoveEventListener("cuechange", o)); set { /** required **/ } }
        public JSEventCallback OnDblClick { get => new JSEventCallback(o => AddEventListener("dblclick", o), o => RemoveEventListener("dblclick", o)); set { /** required **/ } }
        public JSEventCallback OnDrag { get => new JSEventCallback(o => AddEventListener("drag", o), o => RemoveEventListener("drag", o)); set { /** required **/ } }
        public JSEventCallback OnDragEnd { get => new JSEventCallback(o => AddEventListener("dragend", o), o => RemoveEventListener("dragend", o)); set { /** required **/ } }
        public JSEventCallback OnDragEnter { get => new JSEventCallback(o => AddEventListener("dragenter", o), o => RemoveEventListener("dragenter", o)); set { /** required **/ } }
        public JSEventCallback OnDragLeave { get => new JSEventCallback(o => AddEventListener("dragleave", o), o => RemoveEventListener("dragleave", o)); set { /** required **/ } }
        public JSEventCallback OnDragOver { get => new JSEventCallback(o => AddEventListener("dragover", o), o => RemoveEventListener("dragover", o)); set { /** required **/ } }
        public JSEventCallback OnDragStart { get => new JSEventCallback(o => AddEventListener("dragstart", o), o => RemoveEventListener("dragstart", o)); set { /** required **/ } }
        public JSEventCallback OnDrop { get => new JSEventCallback(o => AddEventListener("drop", o), o => RemoveEventListener("drop", o)); set { /** required **/ } }
        public JSEventCallback OnDurationChange { get => new JSEventCallback(o => AddEventListener("durationchange", o), o => RemoveEventListener("durationchange", o)); set { /** required **/ } }
        public JSEventCallback OnEmptied { get => new JSEventCallback(o => AddEventListener("emptied", o), o => RemoveEventListener("emptied", o)); set { /** required **/ } }
        public JSEventCallback OnEnded { get => new JSEventCallback(o => AddEventListener("ended", o), o => RemoveEventListener("ended", o)); set { /** required **/ } }
        public JSEventCallback OnError { get => new JSEventCallback(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** required **/ } }
        public JSEventCallback OnFocus { get => new JSEventCallback(o => AddEventListener("focus", o), o => RemoveEventListener("focus", o)); set { /** required **/ } }
        public JSEventCallback OnFormData { get => new JSEventCallback(o => AddEventListener("formdata", o), o => RemoveEventListener("formdata", o)); set { /** required **/ } }
        public JSEventCallback OnFreeze { get => new JSEventCallback(o => AddEventListener("freeze", o), o => RemoveEventListener("freeze", o)); set { /** required **/ } }
        public JSEventCallback OnGotPointerCapture { get => new JSEventCallback(o => AddEventListener("gotpointercapture", o), o => RemoveEventListener("gotpointercapture", o)); set { /** required **/ } }
        public JSEventCallback OnInput { get => new JSEventCallback(o => AddEventListener("input", o), o => RemoveEventListener("input", o)); set { /** required **/ } }
        public JSEventCallback OnInvalid { get => new JSEventCallback(o => AddEventListener("invalid", o), o => RemoveEventListener("invalid", o)); set { /** required **/ } }
        public JSEventCallback OnKeyDown { get => new JSEventCallback(o => AddEventListener("keydown", o), o => RemoveEventListener("keydown", o)); set { /** required **/ } }
        public JSEventCallback OnKeyPress { get => new JSEventCallback(o => AddEventListener("keypress", o), o => RemoveEventListener("keypress", o)); set { /** required **/ } }
        public JSEventCallback OnKeyUp { get => new JSEventCallback(o => AddEventListener("keyup", o), o => RemoveEventListener("keyup", o)); set { /** required **/ } }
        public JSEventCallback OnLoad { get => new JSEventCallback(o => AddEventListener("load", o), o => RemoveEventListener("load", o)); set { /** required **/ } }
        public JSEventCallback OnLoadedData { get => new JSEventCallback(o => AddEventListener("loadeddata", o), o => RemoveEventListener("loadeddata", o)); set { /** required **/ } }
        public JSEventCallback OnLoadedMetadata { get => new JSEventCallback(o => AddEventListener("loadedmetadata", o), o => RemoveEventListener("loadedmetadata", o)); set { /** required **/ } }
        public JSEventCallback OnLoadStart { get => new JSEventCallback(o => AddEventListener("loadstart", o), o => RemoveEventListener("loadstart", o)); set { /** required **/ } }
        public JSEventCallback OnLostPointerCapture { get => new JSEventCallback(o => AddEventListener("lostpointercapture", o), o => RemoveEventListener("lostpointercapture", o)); set { /** required **/ } }
        public JSEventCallback OnMouseDown { get => new JSEventCallback(o => AddEventListener("mousedown", o), o => RemoveEventListener("mousedown", o)); set { /** required **/ } }
        public JSEventCallback OnMouseEnter { get => new JSEventCallback(o => AddEventListener("mouseenter", o), o => RemoveEventListener("mouseenter", o)); set { /** required **/ } }
        public JSEventCallback OnMouseLeave { get => new JSEventCallback(o => AddEventListener("mouseleave", o), o => RemoveEventListener("mouseleave", o)); set { /** required **/ } }
        public JSEventCallback OnMouseMove { get => new JSEventCallback(o => AddEventListener("mousemove", o), o => RemoveEventListener("mousemove", o)); set { /** required **/ } }
        public JSEventCallback OnMouseOut { get => new JSEventCallback(o => AddEventListener("mouseout", o), o => RemoveEventListener("mouseout", o)); set { /** required **/ } }
        public JSEventCallback OnMouseOver { get => new JSEventCallback(o => AddEventListener("mouseover", o), o => RemoveEventListener("mouseover", o)); set { /** required **/ } }
        public JSEventCallback OnMouseUp { get => new JSEventCallback(o => AddEventListener("mouseup", o), o => RemoveEventListener("mouseup", o)); set { /** required **/ } }
        public JSEventCallback OnMouseWheel { get => new JSEventCallback(o => AddEventListener("mousewheel", o), o => RemoveEventListener("mousewheel", o)); set { /** required **/ } }
        public JSEventCallback OnPause { get => new JSEventCallback(o => AddEventListener("pause", o), o => RemoveEventListener("pause", o)); set { /** required **/ } }
        public JSEventCallback OnPlay { get => new JSEventCallback(o => AddEventListener("play", o), o => RemoveEventListener("play", o)); set { /** required **/ } }
        public JSEventCallback OnPlaying { get => new JSEventCallback(o => AddEventListener("playing", o), o => RemoveEventListener("playing", o)); set { /** required **/ } }
        public JSEventCallback OnPointerCancel { get => new JSEventCallback(o => AddEventListener("pointercancel", o), o => RemoveEventListener("pointercancel", o)); set { /** required **/ } }
        public JSEventCallback OnPointerDown { get => new JSEventCallback(o => AddEventListener("pointerdown", o), o => RemoveEventListener("pointerdown", o)); set { /** required **/ } }
        public JSEventCallback OnPointerEnter { get => new JSEventCallback(o => AddEventListener("pointerenter", o), o => RemoveEventListener("pointerenter", o)); set { /** required **/ } }
        public JSEventCallback OnPointerLeave { get => new JSEventCallback(o => AddEventListener("pointerleave", o), o => RemoveEventListener("pointerleave", o)); set { /** required **/ } }
        public JSEventCallback OnPointerMove { get => new JSEventCallback(o => AddEventListener("pointermove", o), o => RemoveEventListener("pointermove", o)); set { /** required **/ } }
        public JSEventCallback OnPointerOut { get => new JSEventCallback(o => AddEventListener("pointerout", o), o => RemoveEventListener("pointerout", o)); set { /** required **/ } }
        public JSEventCallback OnPointerOver { get => new JSEventCallback(o => AddEventListener("pointerover", o), o => RemoveEventListener("pointerover", o)); set { /** required **/ } }
        public JSEventCallback OnPointerRawUpdate { get => new JSEventCallback(o => AddEventListener("pointerrawupdate", o), o => RemoveEventListener("pointerrawupdate", o)); set { /** required **/ } }
        public JSEventCallback OnPointerUp { get => new JSEventCallback(o => AddEventListener("pointerup", o), o => RemoveEventListener("pointerup", o)); set { /** required **/ } }        
        public JSEventCallback OnProgress { get => new JSEventCallback(o => AddEventListener("progress", o), o => RemoveEventListener("progress", o)); set { /** required **/ } }
        public JSEventCallback OnRateChange { get => new JSEventCallback(o => AddEventListener("ratechange", o), o => RemoveEventListener("ratechange", o)); set { /** required **/ } }        
        public JSEventCallback OnReset { get => new JSEventCallback(o => AddEventListener("reset", o), o => RemoveEventListener("reset", o)); set { /** required **/ } }
        public JSEventCallback OnResize { get => new JSEventCallback(o => AddEventListener("resize", o), o => RemoveEventListener("resize", o)); set { /** required **/ } }
        public JSEventCallback OnResume { get => new JSEventCallback(o => AddEventListener("resume", o), o => RemoveEventListener("resume", o)); set { /** required **/ } }                
        public JSEventCallback OnSearch { get => new JSEventCallback(o => AddEventListener("search", o), o => RemoveEventListener("search", o)); set { /** required **/ } }        
        public JSEventCallback OnSeeked { get => new JSEventCallback(o => AddEventListener("seeked", o), o => RemoveEventListener("seeked", o)); set { /** required **/ } }
        public JSEventCallback OnSeeking { get => new JSEventCallback(o => AddEventListener("seeking", o), o => RemoveEventListener("seeking", o)); set { /** required **/ } }
        public JSEventCallback OnSelect { get => new JSEventCallback(o => AddEventListener("select", o), o => RemoveEventListener("select", o)); set { /** required **/ } }        
        public JSEventCallback OnSlotChange { get => new JSEventCallback(o => AddEventListener("slotchange", o), o => RemoveEventListener("slotchange", o)); set { /** required **/ } }
        public JSEventCallback OnStalled { get => new JSEventCallback(o => AddEventListener("stalled", o), o => RemoveEventListener("stalled", o)); set { /** required **/ } }
        public JSEventCallback OnSubmit { get => new JSEventCallback(o => AddEventListener("submit", o), o => RemoveEventListener("submit", o)); set { /** required **/ } }
        public JSEventCallback OnSuspend { get => new JSEventCallback(o => AddEventListener("suspend", o), o => RemoveEventListener("suspend", o)); set { /** required **/ } }
        public JSEventCallback OnTimeUpdate { get => new JSEventCallback(o => AddEventListener("timeupdate", o), o => RemoveEventListener("timeupdate", o)); set { /** required **/ } }
        public JSEventCallback OnToggle { get => new JSEventCallback(o => AddEventListener("toggle", o), o => RemoveEventListener("toggle", o)); set { /** required **/ } }
        public JSEventCallback OnTransitionCancel { get => new JSEventCallback(o => AddEventListener("transitioncancel", o), o => RemoveEventListener("transitioncancel", o)); set { /** required **/ } }
        public JSEventCallback OnTransitionEnd { get => new JSEventCallback(o => AddEventListener("transitionend", o), o => RemoveEventListener("transitionend", o)); set { /** required **/ } }
        public JSEventCallback OnTransitionRun { get => new JSEventCallback(o => AddEventListener("transitionrun", o), o => RemoveEventListener("transitionrun", o)); set { /** required **/ } }
        public JSEventCallback OnTransitionStart { get => new JSEventCallback(o => AddEventListener("transitionstart", o), o => RemoveEventListener("transitionstart", o)); set { /** required **/ } }        
        public JSEventCallback OnVolumeChange { get => new JSEventCallback(o => AddEventListener("volumechange", o), o => RemoveEventListener("volumechange", o)); set { /** required **/ } }
        public JSEventCallback OnWaiting { get => new JSEventCallback(o => AddEventListener("waiting", o), o => RemoveEventListener("waiting", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitAnimationEnd { get => new JSEventCallback(o => AddEventListener("webkitanimationend", o), o => RemoveEventListener("webkitanimationend", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitAnimationIteration { get => new JSEventCallback(o => AddEventListener("webkitanimationiteration", o), o => RemoveEventListener("webkitanimationiteration", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitAnimationStart { get => new JSEventCallback(o => AddEventListener("webkitanimationstart", o), o => RemoveEventListener("webkitanimationstart", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitFullscreenChange { get => new JSEventCallback(o => AddEventListener("webkitfullscreenchange", o), o => RemoveEventListener("webkitfullscreenchange", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitFullscreenError { get => new JSEventCallback(o => AddEventListener("webkitfullscreenerror", o), o => RemoveEventListener("webkitfullscreenerror", o)); set { /** required **/ } }
        public JSEventCallback OnWebkitTransitionEnd { get => new JSEventCallback(o => AddEventListener("webkittransitionend", o), o => RemoveEventListener("webkittransitionend", o)); set { /** required **/ } }
        public JSEventCallback OnWheel { get => new JSEventCallback(o => AddEventListener("wheel", o), o => RemoveEventListener("wheel", o)); set { /** required **/ } }
        #endregion
    }
}

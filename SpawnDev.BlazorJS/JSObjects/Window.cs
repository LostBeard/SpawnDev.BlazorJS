using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Window interface represents a window containing a DOM document; the document property points to the DOM document loaded in that window.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window
    /// </summary>
    public class Window : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Window(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Gets the global Window instance
        /// </summary>
        public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }

        #region Properties
        /// <summary>
        /// The Window.closed read-only property indicates whether the referenced window is closed or not.
        /// </summary>
        public bool Closed => JSRef.Get<bool>("closed");
        /// <summary>
        /// Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests.
        /// </summary>
        public CacheStorage Caches => JSRef.Get<CacheStorage>("caches");
        /// <summary>
        /// The devicePixelRatio of Window interface returns the ratio of the resolution in physical pixels to the resolution in CSS pixels for the current display device.
        /// </summary>
        public double DevicePixelRatio { get { var tmp = JSRef.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        /// <summary>
        /// window.document returns a reference to the document contained in the window.
        /// </summary>
        public Document Document => JSRef.Get<Document>("document");
        /// <summary>
        /// The Window.frameElement property returns the element (such as iframe or object) in which the window is embedded.
        /// </summary>
        public Element? FrameElement => JSRef.Get<Element?>("frameElement");
        /// <summary>
        /// The Window.history read-only property returns a reference to the History object, which provides an interface for manipulating the browser session history (pages visited in the tab or frame that the current page is loaded in).
        /// </summary>
        public History History => JSRef.Get<History>("history");
        /// <summary>
        /// Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object.
        /// </summary>
        public IDBFactory IndexedDB => JSRef.Get<IDBFactory>("indexedDB");
        /// <summary>
        /// The read-only innerHeight property of the Window interface returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present.
        /// </summary>
        public int InnerHeight => JSRef.Get<int>("innerHeight");
        /// <summary>
        /// The read-only Window property innerWidth returns the interior width of the window in pixels. This includes the width of the vertical scroll bar, if one is present
        /// </summary>
        public int InnerWidth => JSRef.Get<int>("innerWidth");
        /// <summary>
        /// The launchQueue read-only property of the Window interface provides access to the LaunchQueue class, which allows custom launch navigation handling to be implemented in a progressive web app (PWA), with the handling context signified by the launch_handler manifest field client_mode value.
        /// </summary>
        public LaunchQueue LaunchQueue => JSRef.Get<LaunchQueue>("launchQueue");
        /// <summary>
        /// Returns the number of frames (either frame or iframe elements) in the window.
        /// </summary>
        public int Length => JSRef.Get<int>("length");
        /// <summary>
        /// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin; the stored data is saved across browser sessions.
        /// </summary>
        public Storage LocalStorage => JSRef.Get<Storage>("localStorage");
        /// <summary>
        /// The Window.location read-only property returns a Location object with information about the current location of the document.
        /// </summary>
        public Location Location => JSRef.Get<Location>("location");
        /// <summary>
        /// The Window.name property gets/sets the name of the window's browsing context.
        /// </summary>
        public string? Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
        /// <summary>
        /// The Window.navigator read-only property returns a reference to the Navigator object, which has methods and properties about the application running the script.
        /// </summary>
        public Navigator Navigator => JSRef.Get<Navigator>("navigator");
        /// <summary>
        /// The Window interface's opener property returns a reference to the window that opened the window, either with open(), or by navigating a link with a target attribute.
        /// </summary>
        public Window Opener => JSRef.Get<Window>("opener");
        /// <summary>
        /// The Window.outerHeight read-only property returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles.
        /// </summary>
        public int OuterHeight => JSRef.Get<int>("outerHeight");
        /// <summary>
        /// Window.outerWidth read-only property returns the width of the outside of the browser window. It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles.
        /// </summary>
        public int OuterWidth => JSRef.Get<int>("outerWidth");
        /// <summary>
        /// The read-only Window property pageXOffset is an alias for scrollX.
        /// </summary>
        public int PageXOffset => JSRef.Get<int>("pageXOffset");
        /// <summary>
        /// The read-only Window property pageYOffset is an alias for scrollY; as such, it returns the number of pixels the document is currently scrolled along the vertical axis (that is, up or down) with a value of 0.0, indicating that the top edge of the Document is currently aligned with the top edge of the window's content area.
        /// </summary>
        public int PageYOffset => JSRef.Get<int>("pageYOffset");
        /// <summary>
        /// The Window.parent property is a reference to the parent of the current window or subframe<br />
        /// If a window does not have a parent, its parent property is a reference to itself.
        /// </summary>
        public Element Parent => JSRef.Get<Element>("parent");
        /// <summary>
        /// The Window property screen returns a reference to the screen object associated with the window. The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered.
        /// </summary>
        public Screen Screen => JSRef.Get<Screen>("screen");
        /// <summary>
        /// The Window.screenLeft read-only property returns the horizontal distance, in CSS pixels, from the left border of the user's browser viewport to the left side of the screen.
        /// </summary>
        public int ScreenLeft => JSRef.Get<int>("screenLeft");
        /// <summary>
        /// The Window.screenTop read-only property returns the vertical distance, in CSS pixels, from the top border of the user's browser viewport to the top side of the screen
        /// </summary>
        public int ScreenTop => JSRef.Get<int>("screenTop");
        /// <summary>
        /// The Window.screenX read-only property returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
        /// </summary>
        public int ScreenX => JSRef.Get<int>("screenX");
        /// <summary>
        /// The Window.screenY read-only property returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen
        /// </summary>
        public int ScreenY => JSRef.Get<int>("screenY");
        /// <summary>
        /// The read-only scrollX property of the Window interface returns the number of pixels that the document is currently scrolled horizontally. This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number. You can get the number of pixels the document is scrolled vertically from the scrollY property.
        /// </summary>
        public double ScrollX => JSRef.Get<double>("scrollX");
        /// <summary>
        /// The read-only scrollY property of the Window interface returns the number of pixels that the document is currently scrolled vertically.
        /// </summary>
        public double ScrollY => JSRef.Get<double>("scrollY");
        /// <summary>
        /// The read-only sessionStorage property accesses a session Storage object for the current origin. sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
        /// </summary>
        public Storage SessionStorage => JSRef.Get<Storage>("sessionStorage");
        /// <summary>
        /// Returns a reference to the topmost window in the window hierarchy.
        /// </summary>
        public Element Top => JSRef.Get<Element>("top");
        /// <summary>
        /// Returns a boolean value that indicates whether the website is in a cross-origin isolation state.
        /// </summary>
        public bool CrossOriginIsolated => JSRef.Get<bool>("crossOriginIsolated");
        /// <summary>
        /// Returns the browser crypto object.
        /// </summary>
        public Crypto Crypto => JSRef.Get<Crypto>("crypto");
        /// <summary>
        /// Returns a boolean that indicates whether the current document was loaded inside a credentialless iframe. See IFrame credentialless for more details.
        /// </summary>
        public bool Credentialless => JSRef.Get<bool>("credentialless");
        /// <summary>
        /// Returns a reference to the document Picture-in-Picture window for the current document context.
        /// </summary>
        public DocumentPictureInPicture DocumentPictureInPicture => JSRef.Get<DocumentPictureInPicture>("documentPictureInPicture");
        /// <summary>
        /// Returns a boolean indicating whether the current context is secure (true) or not (false).
        /// </summary>
        public bool IsSecureContext => JSRef.Get<bool>("isSecureContext");
        /// <summary>
        /// Returns the global object's origin, serialized as a string.
        /// </summary>
        public string Origin => JSRef.Get<string>("origin");
        /// <summary>
        /// Returns a VisualViewport object which represents the visual viewport for a given window.
        /// </summary>
        public VisualViewport VisualViewport => JSRef.Get<VisualViewport>("visualViewport");
        /// <summary>
        /// The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker).
        /// </summary>
        public Performance Performance => JSRef.Get<Performance>("performance");
        #endregion

        #region Methods
        /// <summary>
        /// Displays an alert dialog.
        /// </summary>
        /// <param name="msg"></param>
        public void Alert(string msg = "") => JSRef.CallVoid("alert", msg);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Callback callback, double delay) => JSRef.Call<long>("setTimeout", callback, delay);
        /// <summary>
        /// Cancels the delayed execution set using setTimeout().
        /// </summary>
        /// <param name="requestId"></param>
        public void ClearTimeout(long requestId) => JSRef.CallVoid("clearTimeout", requestId);
        /// <summary>
        /// Tells the browser that an animation is in progress, requesting that the browser schedule a repaint of the window for the next animation frame
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(ActionCallback<double> callback) => JSRef.Call<long>("requestAnimationFrame", callback);
        /// <summary>
        /// Enables you to cancel a callback previously scheduled with Window.requestAnimationFrame.
        /// </summary>
        /// <param name="requestId"></param>
        public void CancelAnimationFrame(long requestId) => JSRef.CallVoid("cancelAnimationFrame", requestId);
        /// <summary>
        /// Experimental state. Not supported in most browsers. (Works in Chrome)
        /// </summary>
        /// <returns>ScreenDetails</returns>
        public Task<ScreenDetails> GetScreenDetails() => JSRef.CallAsync<ScreenDetails>("getScreenDetails");
        /// <summary>
        /// The Window interface's matchMedia() method returns a new MediaQueryList object that can then be used to determine if the document matches the media query string, as well as to monitor the document to detect when it matches (or stops matching) that media query.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public MediaQueryList MatchMedia(string mode) => JSRef.Call<MediaQueryList>("matchMedia", mode);
        #endregion
        #region Events
        /// <summary>
        /// The afterprint event is fired after the associated document has started printing or the print preview has been closed.
        /// </summary>
        public JSEventCallback OnAfterPrint { get => new JSEventCallback(o => AddEventListener("afterprint", o), o => RemoveEventListener("afterprint", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The appinstalled event of the Web Manifest API is fired when the browser has successfully installed a page as an application.
        /// </summary>
        public JSEventCallback OnAppInstalled { get => new JSEventCallback(o => AddEventListener("appinstalled", o), o => RemoveEventListener("appinstalled", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The beforeinstallprompt event fires when the browser has detected that a website can be installed as a Progressive Web App.
        /// </summary>
        public JSEventCallback<BeforeInstallPromptEvent> OnBeforeInstallPrompt { get => new JSEventCallback<BeforeInstallPromptEvent>(o => AddEventListener("beforeinstallprompt", o), o => RemoveEventListener("beforeinstallprompt", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The beforeprint event is fired when the associated document is about to be printed or previewed for printing.
        /// </summary>
        public JSEventCallback OnBeforePrint { get => new JSEventCallback(o => AddEventListener("beforeprint", o), o => RemoveEventListener("beforeprint", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The beforeunload event is fired when the window, the document and its resources are about to be unloaded. The document is still visible and the event is still cancelable at this point.
        /// </summary>
        public JSEventCallback<BeforeUnloadEvent> OnBeforeUnload { get => new JSEventCallback<BeforeUnloadEvent>(o => AddEventListener("beforeunload", o), o => RemoveEventListener("beforeunload", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The blur event fires when an element has lost focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnBlur { get => new JSEventCallback<FocusEvent>(o => AddEventListener("blur", o), o => RemoveEventListener("blur", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The copy event fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCopy { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("copy", o), o => RemoveEventListener("copy", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The cut event is fired when the user has initiated a "cut" action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnCut { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("cut", o), o => RemoveEventListener("cut", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The devicemotion event is fired at a regular interval and indicates the amount of physical force of acceleration the device is receiving at that time. It also provides information about the rate of rotation, if available.
        /// </summary>
        public JSEventCallback<DeviceMotionEvent> OnDeviceMotion { get => new JSEventCallback<DeviceMotionEvent>(o => AddEventListener("devicemotion", o), o => RemoveEventListener("devicemotion", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The deviceorientation event is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device.
        /// </summary>
        public JSEventCallback<DeviceOrientationEvent> OnDeviceOrientation { get => new JSEventCallback<DeviceOrientationEvent>(o => AddEventListener("deviceorientation", o), o => RemoveEventListener("deviceorientation", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The deviceorientationabsolute event is sent to the ondeviceorientationabsolute event handler on a Window event when absolute device orientation changes.
        /// </summary>
        public JSEventCallback<DeviceOrientationEvent> OnDeviceOrientationAbsolute { get => new JSEventCallback<DeviceOrientationEvent>(o => AddEventListener("deviceorientationabsolute", o), o => RemoveEventListener("deviceorientationabsolute", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The DOMContentLoaded event fires when the HTML document has been completely parsed, and all deferred scripts (script defer src="…" and script type="module") have downloaded and executed. It doesn't wait for other things like images, subframes, and async scripts to finish loading.
        /// </summary>
        public JSEventCallback OnDOMContentLoaded { get => new JSEventCallback(o => AddEventListener("DOMContentLoaded", o), o => RemoveEventListener("DOMContentLoaded", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The error event is fired on a Window object when a resource failed to load or couldn't be used — for example if a script has an execution error.
        /// </summary>
        public JSEventCallback<ErrorEvent> OnError { get => new JSEventCallback<ErrorEvent>(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The focus event fires when an element has received focus.
        /// </summary>
        public JSEventCallback<FocusEvent> OnFocus { get => new JSEventCallback<FocusEvent>(o => AddEventListener("focus", o), o => RemoveEventListener("focus", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The gamepadconnected event is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used.
        /// </summary>
        public JSEventCallback<GamepadEvent> OnGamepadConnected { get => new JSEventCallback<GamepadEvent>(o => AddEventListener("gamepadconnected", o), o => RemoveEventListener("gamepadconnected", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The gamepaddisconnected event is fired when the browser detects that a gamepad has been disconnected.
        /// </summary>
        public JSEventCallback<GamepadEvent> OnGamepadDisconnected { get => new JSEventCallback<GamepadEvent>(o => AddEventListener("gamepaddisconnected", o), o => RemoveEventListener("gamepaddisconnected", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The hashchange event is fired when the fragment identifier of the URL has changed (the part of the URL beginning with and following the # symbol).
        /// </summary>
        public JSEventCallback<HashChangeEvent> OnHashChange { get => new JSEventCallback<HashChangeEvent>(o => AddEventListener("hashchange", o), o => RemoveEventListener("hashchange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The languagechange event is fired at the global scope object when the user's preferred language changes.
        /// </summary>
        public JSEventCallback OnLanguageChange { get => new JSEventCallback(o => AddEventListener("languagechange", o), o => RemoveEventListener("languagechange", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The load event is fired when the whole page has loaded, including all dependent resources such as stylesheets, scripts, iframes, and images. This is in contrast to DOMContentLoaded, which is fired as soon as the page DOM has been loaded, without waiting for resources to finish loading.
        /// </summary>
        public JSEventCallback OnLoad { get => new JSEventCallback(o => AddEventListener("load", o), o => RemoveEventListener("load", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The message event is fired on a Window object when the window receives a message, for example from a call to Window.postMessage() from another browsing context.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessage { get => new JSEventCallback<MessageEvent>(o => AddEventListener("message", o), o => RemoveEventListener("message", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The messageerror event is fired on a Window object when it receives a message that can't be deserialized.
        /// </summary>
        public JSEventCallback<MessageEvent> OnMessageError { get => new JSEventCallback<MessageEvent>(o => AddEventListener("messageerror", o), o => RemoveEventListener("messageerror", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The offline event of the Window interface is fired when the browser has lost access to the network and the value of Navigator.onLine switches to false
        /// </summary>
        public JSEventCallback OnOffline { get => new JSEventCallback(o => AddEventListener("offline", o), o => RemoveEventListener("offline", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The online event of the Window interface is fired when the browser has gained access to the network and the value of Navigator.onLine switches to true
        /// </summary>
        public JSEventCallback OnOnline { get => new JSEventCallback(o => AddEventListener("online", o), o => RemoveEventListener("online", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The pagehide event is sent to a Window when the browser hides the current page in the process of presenting a different page from the session's history
        /// </summary>
        public JSEventCallback<PageTransitionEvent> OnPageHide { get => new JSEventCallback<PageTransitionEvent>(o => AddEventListener("pagehide", o), o => RemoveEventListener("pagehide", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The pageshow event is sent to a Window when the browser displays the window's document due to navigation.
        /// </summary>
        public JSEventCallback<PageTransitionEvent> OnPageShow { get => new JSEventCallback<PageTransitionEvent>(o => AddEventListener("pageshow", o), o => RemoveEventListener("pageshow", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The paste event is fired when the user has initiated a "paste" action through the browser's user interface.
        /// </summary>
        public JSEventCallback<ClipboardEvent> OnPaste { get => new JSEventCallback<ClipboardEvent>(o => AddEventListener("paste", o), o => RemoveEventListener("paste", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The popstate event of the Window interface is fired when the active history entry changes while the user navigates the session history. It changes the current history entry to that of the last page the user visited or, if history.pushState() has been used to add a history entry to the history stack, that history entry is used instead.
        /// </summary>
        public JSEventCallback<PopStateEvent> OnPopState { get => new JSEventCallback<PopStateEvent>(o => AddEventListener("popstate", o), o => RemoveEventListener("popstate", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The rejectionhandled event is sent to the script's global scope (usually window but also Worker) whenever a rejected JavaScript Promise is handled late, i.e. when a handler is attached to the promise after its rejection had caused an unhandledrejection event.
        /// </summary>
        public JSEventCallback<PromiseRejectionEvent> OnRejectionHandled { get => new JSEventCallback<PromiseRejectionEvent>(o => AddEventListener("rejectionhandled", o), o => RemoveEventListener("rejectionhandled", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The resize event fires when the document view (window) has been resized.
        /// </summary>
        public JSEventCallback<UIEvent> OnResize { get => new JSEventCallback<UIEvent>(o => AddEventListener("resize", o), o => RemoveEventListener("resize", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The storage event of the Window interface fires when a storage area (localStorage) has been modified in the context of another document.
        /// </summary>
        public JSEventCallback<StorageEvent> OnStorage { get => new JSEventCallback<StorageEvent>(o => AddEventListener("storage", o), o => RemoveEventListener("storage", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The unhandledrejection event is sent to the global scope of a script when a JavaScript Promise that has no rejection handler is rejected; typically, this is the window, but may also be a Worker.
        /// </summary>
        public JSEventCallback<PromiseRejectionEvent> OnUnhandledRejection { get => new JSEventCallback<PromiseRejectionEvent>(o => AddEventListener("unhandledrejection", o), o => RemoveEventListener("unhandledrejection", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        /// <summary>
        /// The unload event is fired when the document or a child resource is being unloaded.<br />
        /// Warning: Developers should avoid using this event.
        /// </summary>
        public JSEventCallback OnUnload { get => new JSEventCallback(o => AddEventListener("unload", o), o => RemoveEventListener("unload", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
        #endregion

        public bool ShowDirectoryPickerSupported() => !JS.IsUndefined("showDirectoryPicker");

        public Task<FileSystemDirectoryHandle> ShowDirectoryPicker(ShowDirectoryPickerOptions? options = null) => options == null ?
            JSRef.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker") :
            JSRef.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker", options);

        public Task<Array<FileSystemFileHandle>> ShowOpenFilePicker(ShowOpenFilePickerOptions? options = null) => options == null ?
            JSRef.CallAsync<Array<FileSystemFileHandle>>("showOpenFilePicker") :
            JSRef.CallAsync<Array<FileSystemFileHandle>>("showOpenFilePicker", options);

        public Task<FileSystemFileHandle> ShowSaveFilePicker(ShowSaveFilePickerOptions? options = null) => options == null ?
            JSRef.CallAsync<FileSystemFileHandle>("showSaveFilePicker") :
            JSRef.CallAsync<FileSystemFileHandle>("showSaveFilePicker", options);
    }
}

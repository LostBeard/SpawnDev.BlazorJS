using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Window interface represents a window containing a DOM document; the document property points to the DOM document loaded in that window.<br/>
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
        public bool Closed => JSRef!.Get<bool>("closed");
        /// <summary>
        /// Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests.
        /// </summary>
        public CacheStorage Caches => JSRef!.Get<CacheStorage>("caches");
        /// <summary>
        /// Returns a reference to the CookieStore object, or null if not supported.
        /// </summary>
        public CookieStore? CookieStore => JSRef!.Get<CookieStore?>("cookieStore");
        /// <summary>
        /// The devicePixelRatio of Window interface returns the ratio of the resolution in physical pixels to the resolution in CSS pixels for the current display device.
        /// </summary>
        public double DevicePixelRatio { get { var tmp = JSRef!.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        /// <summary>
        /// window.document returns a reference to the document contained in the window.
        /// </summary>
        public Document Document => JSRef!.Get<Document>("document");
        /// <summary>
        /// The Window.frameElement property returns the element (such as iframe or object) in which the window is embedded.
        /// </summary>
        public Element? FrameElement => JSRef!.Get<Element?>("frameElement");
        /// <summary>
        /// The Window.history read-only property returns a reference to the History object, which provides an interface for manipulating the browser session history (pages visited in the tab or frame that the current page is loaded in).
        /// </summary>
        public History History => JSRef!.Get<History>("history");
        /// <summary>
        /// Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object.
        /// </summary>
        public IDBFactory IndexedDB => JSRef!.Get<IDBFactory>("indexedDB");
        /// <summary>
        /// The read-only innerHeight property of the Window interface returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present.
        /// </summary>
        public int InnerHeight => JSRef!.Get<int>("innerHeight");
        /// <summary>
        /// The read-only Window property innerWidth returns the interior width of the window in pixels. This includes the width of the vertical scroll bar, if one is present
        /// </summary>
        public int InnerWidth => JSRef!.Get<int>("innerWidth");
        /// <summary>
        /// The launchQueue read-only property of the Window interface provides access to the LaunchQueue class, which allows custom launch navigation handling to be implemented in a progressive web app (PWA), with the handling context signified by the launch_handler manifest field client_mode value.
        /// </summary>
        public LaunchQueue LaunchQueue => JSRef!.Get<LaunchQueue>("launchQueue");
        /// <summary>
        /// Returns the number of frames (either frame or iframe elements) in the window.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin; the stored data is saved across browser sessions.
        /// </summary>
        public Storage LocalStorage => JSRef!.Get<Storage>("localStorage");
        /// <summary>
        /// The Window.location read-only property returns a Location object with information about the current location of the document.
        /// </summary>
        public Location Location => JSRef!.Get<Location>("location");
        /// <summary>
        /// The Window.name property gets/sets the name of the window's browsing context.
        /// </summary>
        public string? Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }
        /// <summary>
        /// The Window.navigator read-only property returns a reference to the Navigator object, which has methods and properties about the application running the script.
        /// </summary>
        public Navigator Navigator => JSRef!.Get<Navigator>("navigator");
        /// <summary>
        /// The Window interface's opener property returns a reference to the window that opened the window, either with open(), or by navigating a link with a target attribute.
        /// </summary>
        public Window Opener => JSRef!.Get<Window>("opener");
        /// <summary>
        /// The Window.outerHeight read-only property returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles.
        /// </summary>
        public int OuterHeight => JSRef!.Get<int>("outerHeight");
        /// <summary>
        /// Window.outerWidth read-only property returns the width of the outside of the browser window. It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles.
        /// </summary>
        public int OuterWidth => JSRef!.Get<int>("outerWidth");
        /// <summary>
        /// The read-only Window property pageXOffset is an alias for scrollX.
        /// </summary>
        public int PageXOffset => JSRef!.Get<int>("pageXOffset");
        /// <summary>
        /// The read-only Window property pageYOffset is an alias for scrollY; as such, it returns the number of pixels the document is currently scrolled along the vertical axis (that is, up or down) with a value of 0.0, indicating that the top edge of the Document is currently aligned with the top edge of the window's content area.
        /// </summary>
        public int PageYOffset => JSRef!.Get<int>("pageYOffset");
        /// <summary>
        /// The Window.parent property is a reference to the parent of the current window or subframe<br/>
        /// If a window does not have a parent, its parent property is a reference to itself.
        /// </summary>
        public Element Parent => JSRef!.Get<Element>("parent");
        /// <summary>
        /// The Window property screen returns a reference to the screen object associated with the window. The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered.
        /// </summary>
        public Screen Screen => JSRef!.Get<Screen>("screen");
        /// <summary>
        /// The Window.screenLeft read-only property returns the horizontal distance, in CSS pixels, from the left border of the user's browser viewport to the left side of the screen.
        /// </summary>
        public int ScreenLeft => JSRef!.Get<int>("screenLeft");
        /// <summary>
        /// The Window.screenTop read-only property returns the vertical distance, in CSS pixels, from the top border of the user's browser viewport to the top side of the screen
        /// </summary>
        public int ScreenTop => JSRef!.Get<int>("screenTop");
        /// <summary>
        /// The Window.screenX read-only property returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
        /// </summary>
        public int ScreenX => JSRef!.Get<int>("screenX");
        /// <summary>
        /// The Window.screenY read-only property returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen
        /// </summary>
        public int ScreenY => JSRef!.Get<int>("screenY");
        /// <summary>
        /// The read-only scrollX property of the Window interface returns the number of pixels that the document is currently scrolled horizontally. This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number. You can get the number of pixels the document is scrolled vertically from the scrollY property.
        /// </summary>
        public double ScrollX => JSRef!.Get<double>("scrollX");
        /// <summary>
        /// The read-only scrollY property of the Window interface returns the number of pixels that the document is currently scrolled vertically.
        /// </summary>
        public double ScrollY => JSRef!.Get<double>("scrollY");
        /// <summary>
        /// The read-only sessionStorage property accesses a session Storage object for the current origin. sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends.
        /// </summary>
        public Storage SessionStorage => JSRef!.Get<Storage>("sessionStorage");
        /// <summary>
        /// Returns a reference to the topmost window in the window hierarchy.
        /// </summary>
        public Element Top => JSRef!.Get<Element>("top");
        /// <summary>
        /// Returns true if the website is in a cross-origin isolation state.<br/>
        /// Returns null if the browser does not support cross-origin isolation detection.
        /// </summary>
        public bool? CrossOriginIsolated => JSRef!.Get<bool?>("crossOriginIsolated");
        /// <summary>
        /// Returns the browser crypto object.
        /// </summary>
        public Crypto Crypto => JSRef!.Get<Crypto>("crypto");
        /// <summary>
        /// Returns a boolean that indicates whether the current document was loaded inside a credentialless iframe. See IFrame credentialless for more details.
        /// </summary>
        public bool? Credentialless => JSRef!.Get<bool?>("credentialless");
        /// <summary>
        /// Returns a reference to the document Picture-in-Picture window for the current document context.
        /// </summary>
        public DocumentPictureInPicture DocumentPictureInPicture => JSRef!.Get<DocumentPictureInPicture>("documentPictureInPicture");
        /// <summary>
        /// Returns a boolean indicating whether the current context is secure (true) or not (false).
        /// </summary>
        public bool IsSecureContext => JSRef!.Get<bool>("isSecureContext");
        /// <summary>
        /// Returns the global object's origin, serialized as a string.
        /// </summary>
        public string Origin => JSRef!.Get<string>("origin");
        /// <summary>
        /// Returns a VisualViewport object which represents the visual viewport for a given window.
        /// </summary>
        public VisualViewport VisualViewport => JSRef!.Get<VisualViewport>("visualViewport");
        /// <summary>
        /// The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker).
        /// </summary>
        public Performance Performance => JSRef!.Get<Performance>("performance");
        #endregion

        #region Methods
        /// <summary>
        /// Displays an alert dialog.
        /// </summary>
        /// <param name="msg"></param>
        public void Alert(string msg = "") => JSRef!.CallVoid("alert", msg);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Callback callback, double delay) => JSRef!.Call<long>("setTimeout", callback, delay);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Action callback, double delay) => JSRef!.Call<long>("setTimeout", ActionCallback.CreateOne(callback), delay);
        /// <summary>
        /// Schedules a function to execute in a given amount of time.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetTimeout(Func<Task> callback, double delay) => JSRef!.Call<long>("setTimeout", Callback.CreateOne(callback), delay);
        /// <summary>
        /// The setInterval() method of the Window interface repeatedly calls a function or executes a code snippet, with a fixed time delay between each call.<br/>
        /// This method returns an interval ID which uniquely identifies the interval, so you can remove it later by calling clearInterval().
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public long SetInterval(Callback callback, double delay) => JSRef!.Call<long>("setInterval", callback, delay);
        /// <summary>
        /// Cancels the delayed execution set using setInterval().
        /// </summary>
        /// <param name="requestId"></param>
        public void ClearInterval(long requestId) => JSRef!.CallVoid("clearInterval", requestId);
        /// <summary>
        /// Cancels the delayed execution set using setTimeout().
        /// </summary>
        /// <param name="requestId"></param>
        public void ClearTimeout(long requestId) => JSRef!.CallVoid("clearTimeout", requestId);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="sx">The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sy">The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="sh">The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="options">An object that sets options for the image's extraction.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh, ImageBitmapOptions options) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, sx, sy, sw, sh, options);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="options">An object that sets options for the image's extraction.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, ImageBitmapOptions options) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, options);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image);
        /// <summary>
        /// The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap.
        /// </summary>
        /// <param name="image">An image source</param>
        /// <param name="sx">The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sy">The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <param name="sh">The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative.</param>
        /// <returns>A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle.</returns>
        public Task<ImageBitmap> CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh) => JSRef!.CallAsync<ImageBitmap>("createImageBitmap", image, sx, sy, sw, sh);
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(ActionCallback<double> callback) => JSRef!.Call<long>("requestAnimationFrame", callback);
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(ActionCallback callback) => JSRef!.Call<long>("requestAnimationFrame", callback);
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(Action<double> callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(Action callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(Func<double, Task> callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));
        /// <summary>
        /// The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestAnimationFrame(Func<Task> callback) => JSRef!.Call<long>("requestAnimationFrame", Callback.CreateOne(callback));
        /// <summary>
        /// Enables you to cancel a callback previously scheduled with Window.requestAnimationFrame.
        /// </summary>
        /// <param name="requestId"></param>
        public void CancelAnimationFrame(long requestId) => JSRef!.CallVoid("cancelAnimationFrame", requestId);
        /// <summary>
        /// The window.requestIdleCallback() method queues a function to be called during a browser's idle periods. This enables developers to perform background and low priority work on the main event loop, without impacting latency-critical events such as animation and input response. Functions are generally called in first-in-first-out order; however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestIdleCallback(ActionCallback<IdleDeadline> callback) => JSRef!.Call<long>("requestIdleCallback", callback);
        /// <summary>
        /// The Window.resizeBy() method resizes the current window by a specified amount.
        /// </summary>
        /// <param name="deltaX">The number of pixels to grow the window horizontally.</param>
        /// <param name="deltaY">The number of pixels to grow the window vertically.</param>
        public void ResizeBy(int deltaX, int deltaY) => JSRef!.CallVoid("resizeBy", deltaX, deltaY);
        /// <summary>
        /// The Window.resizeTo() method dynamically resizes the window.
        /// </summary>
        /// <param name="width">An integer representing the new outerWidth in pixels (including scroll bars, title bars, etc.).</param>
        /// <param name="height">An integer value representing the new outerHeight in pixels (including scroll bars, title bars, etc.).</param>
        public void ResizeTo(int width, int height) => JSRef!.CallVoid("resizeTo", width, height);
        /// <summary>
        /// The Window.scroll() method scrolls the window to a particular place in the document.
        /// </summary>
        /// <param name="xCoord">The pixel along the horizontal axis of the document that you want displayed in the upper left.</param>
        /// <param name="yCoord">The pixel along the vertical axis of the document that you want displayed in the upper left.</param>
        public void Scroll(int xCoord, int yCoord) => JSRef!.CallVoid("scroll", xCoord, yCoord);
        /// <summary>
        /// The Window.scroll() method scrolls the window to a particular place in the document.
        /// </summary>
        /// <param name="options">Scroll options</param>
        public void Scroll(ScrollOptions options) => JSRef!.CallVoid("scroll", options);
        /// <summary>
        /// The Window.scrollBy() method scrolls the document in the window by the given amount.
        /// </summary>
        /// <param name="options"></param>
        public void ScrollBy(ScrollOptions options) => JSRef!.CallVoid("scrollBy", options);
        /// <summary>
        /// The Window.scrollBy() method scrolls the document in the window by the given amount.
        /// </summary>
        /// <param name="xCoord">The horizontal pixel value that you want to scroll by.</param>
        /// <param name="yCoord">The vertical pixel value that you want to scroll by.</param>
        public void ScrollBy(int xCoord, int yCoord) => JSRef!.CallVoid("scrollBy", xCoord, yCoord);
        /// <summary>
        /// Window.scrollTo() scrolls to a particular set of coordinates in the document.
        /// </summary>
        /// <param name="options"></param>
        public void ScrollTo(ScrollOptions options) => JSRef!.CallVoid("scrollTo", options);
        /// <summary>
        /// The window.stop() stops further resource loading in the current browsing context, equivalent to the stop button in the browser.<br/>
        /// Because of how scripts are executed, this method cannot interrupt its parent document's loading, but it will stop its images, new windows, and other still-loading objects.
        /// </summary>
        public void Stop() => JSRef!.CallVoid("stop");
        /// <summary>
        /// The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm.<br/>
        /// The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The object to be cloned. This can be any structured-cloneable type.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public T StructuredClone<T>(object value, StructuredCloneOptions options) => JSRef!.Call<T>("structuredClone", value, options);
        /// <summary>
        /// The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm.<br/>
        /// The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The object to be cloned. This can be any structured-cloneable type.</param>
        /// <returns></returns>
        public T StructuredClone<T>(object value) => JSRef!.Call<T>("structuredClone", value);
        /// <summary>
        /// Window.scrollTo() scrolls to a particular set of coordinates in the document.
        /// </summary>
        /// <param name="xCoord">The pixel along the horizontal axis of the document that you want displayed in the upper left.</param>
        /// <param name="yCoord">The pixel along the vertical axis of the document that you want displayed in the upper left.</param>
        public void ScrollTo(int xCoord, int yCoord) => JSRef!.CallVoid("scrollTo", xCoord, yCoord);
        /// <summary>
        /// The window.requestIdleCallback() method queues a function to be called during a browser's idle periods. This enables developers to perform background and low priority work on the main event loop, without impacting latency-critical events such as animation and input response. Functions are generally called in first-in-first-out order; however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public long RequestIdleCallback(Action<IdleDeadline> callback) => JSRef!.Call<long>("requestIdleCallback", Callback.CreateOne(callback));
        /// <summary>
        /// Enables you to cancel a callback previously scheduled with Window.requestIdleCallback.
        /// </summary>
        /// <param name="handle">The ID value returned by window.requestIdleCallback() when the callback was established.</param>
        public void CancelIdleCallback(long handle) => JSRef!.CallVoid("cancelIdleCallback", handle);
        /// <summary>
        /// Closes the current window.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog.
        /// </summary>
        /// <returns>A boolean indicating whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false.</returns>
        public bool Confirm() => JSRef!.Call<bool>("confirm");
        /// <summary>
        /// window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog.
        /// </summary>
        /// <param name="message">A string you want to display in the confirmation dialog.</param>
        /// <returns>A boolean indicating whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false.</returns>
        public bool Confirm(string message) => JSRef!.Call<bool>("confirm", message);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(Request resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource) => JS.CallAsync<Response>("fetch", resource);
        /// <summary>
        /// Calls fetch
        /// </summary>
        public Task<Response> Fetch(string resource, FetchOptions options) => JS.CallAsync<Response>("fetch", resource, options);
        /// <summary>
        /// Makes a request to bring the window to the front. It may fail due to user settings and the window isn't guaranteed to be frontmost before this method returns.
        /// </summary>
        public void Focus() => JSRef!.CallVoid("focus");
        /// <summary>
        /// Gets computed style for the specified element. Computed style indicates the computed values of all CSS properties of the element.
        /// </summary>
        /// <param name="element">The Element for which to get the computed style.</param>
        /// <param name="pseudoElement">A string specifying the pseudo-element to match. Omitted (or null) for real elements.</param>
        /// <returns>A live CSSStyleDeclaration object, which updates automatically when the element's styles are changed.</returns>
        public CSSStyleDeclaration GetComputedStyle(Element element, string? pseudoElement = null) => JSRef!.Call<CSSStyleDeclaration>("getComputedStyle", element, pseudoElement);
        /// <summary>
        /// The getSelection() method of the Window interface returns the Selection object associated with the window's document, representing the range of text selected by the user or the current position of the caret.
        /// </summary>
        /// <returns>A Selection object, or null if the associated document has no browsing context (for example, the window is an iframe that is not attached to a document).</returns>
        public Selection? GetSelection() => JSRef!.Call<Selection?>("getSelection");
        /// <summary>
        /// Experimental state. Not supported in most browsers. (Works in Chrome)
        /// </summary>
        /// <returns>ScreenDetails</returns>
        public Task<ScreenDetails> GetScreenDetails() => JSRef!.CallAsync<ScreenDetails>("getScreenDetails");
        /// <summary>
        /// The Window interface's matchMedia() method returns a new MediaQueryList object that can then be used to determine if the document matches the media query string, as well as to monitor the document to detect when it matches (or stops matching) that media query.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public MediaQueryList MatchMedia(string mode) => JSRef!.Call<MediaQueryList>("matchMedia", mode);
        /// <summary>
        /// The moveBy() method of the Window interface moves the current window by a specified amount.<br/>
        /// Note: This function moves the window relative to its current location. In contrast, window.moveTo() moves the window to an absolute location.
        /// </summary>
        /// <param name="deltaX">The amount of pixels to move the window horizontally. Positive values are to the right, while negative values are to the left.</param>
        /// <param name="deltaY">The amount of pixels to move the window vertically. Positive values are down, while negative values are up.</param>
        public void MoveBy(int deltaX, int deltaY) => JSRef!.CallVoid("moveBy", deltaX, deltaY);
        /// <summary>
        /// The moveTo() method of the Window interface moves the current window to the specified coordinates.<br/>
        /// Note: This function moves the window to an absolute location. In contrast, window.moveBy() moves the window relative to its current location.
        /// </summary>
        /// <param name="x">The horizontal coordinate to be moved to.</param>
        /// <param name="y">The vertical coordinate to be moved to.</param>
        public void MoveTo(int x, int y) => JSRef!.CallVoid("moveTo", x, y);
        /// <summary>
        /// The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
        /// </summary>
        /// <param name="url">A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context.</param>
        /// <param name="target">A string, without whitespace, specifying the name of the browsing context the resource is being loaded into. If the name doesn't identify an existing context, a new context is created and given the specified name. The special target keywords, _self, _blank (default), _parent, _top, and _unfencedTop can also be used. _unfencedTop is only relevant to fenced frames.</param>
        /// <param name="windowFeatures">
        /// A string containing a comma-separated list of window features in the form name=value. Boolean values can be set to true using one of: name, name=yes, name=true, or name=n where n is any non-zero integer. These features include options such as the window's default size and position, whether or not to open a minimal popup window, and so forth.
        /// </param>
        /// <returns>If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements.</returns>
        public Window? Open(string url, string target, string windowFeatures) => JSRef!.Call<Window?>("open", url, target, windowFeatures);
        /// <summary>
        /// The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
        /// </summary>
        /// <param name="url">A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context.</param>
        /// <param name="target">A string, without whitespace, specifying the name of the browsing context the resource is being loaded into. If the name doesn't identify an existing context, a new context is created and given the specified name. The special target keywords, _self, _blank (default), _parent, _top, and _unfencedTop can also be used. _unfencedTop is only relevant to fenced frames.</param>
        /// <returns>If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements.</returns>
        public Window? Open(string url, string target) => JSRef!.Call<Window?>("open", url, target);
        /// <summary>
        /// The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
        /// </summary>
        /// <param name="url">A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context.</param>
        /// <returns>If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements.</returns>
        public Window? Open(string url) => JSRef!.Call<Window?>("open", url);
        /// <summary>
        /// The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.
        /// </summary>
        /// <returns>If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements.</returns>
        public Window? Open() => JSRef!.Call<Window?>("open");
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        /// <param name="targetOrigin">Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin.</param>
        /// <param name="transfer">An optional array of transferable objects to transfer ownership of. The ownership of these objects is given to the destination side and they are no longer usable on the sending side. These transferable objects should be attached to the message; otherwise they would be moved but not actually accessible on the receiving end.</param>
        public void PostMessage(object message, string targetOrigin, object[] transfer) => JSRef!.CallVoid("postMessage", message, targetOrigin, transfer);
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        /// <param name="targetOrigin">Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin.</param>
        public void PostMessage(object message, string targetOrigin) => JSRef!.CallVoid("postMessage", message, targetOrigin);
        /// <summary>
        /// The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it.
        /// </summary>
        /// <param name="message">Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself.</param>
        public void PostMessage(object message) => JSRef!.CallVoid("postMessage", message);
        /// <summary>
        /// Opens the print dialog to print the current document.
        /// </summary>
        public void Print() => JSRef!.CallVoid("print");
        /// <summary>
        /// window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        public string? Prompt() => JSRef!.Call<string>("prompt");
        /// <summary>
        /// window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <param name="message">A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window.</param>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        public string? Prompt(string message) => JSRef!.Call<string>("prompt", message);
        /// <summary>
        /// window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <param name="message">A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window.</param>
        /// <param name="defaultValue">A string containing the default value displayed in the text input field.</param>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        public string? Prompt(string message, string defaultValue) => JSRef!.Call<string>("prompt", message, defaultValue);
        /// <summary>
        /// The queueMicrotask() method of the Window interface queues a microtask to be executed at a safe time prior to control returning to the browser's event loop.
        /// </summary>
        /// <param name="callback">A function to be executed when the browser engine determines it is safe to call your code. Enqueued microtasks are executed after all pending tasks have completed but before yielding control to the browser's event loop.</param>
        public void QueueMicrotask(Action callback) => JSRef!.CallVoid("queueMicrotask", ActionCallback.CreateOne(callback));
        #endregion
        #region Events
        /// <summary>
        /// The afterprint event is fired after the associated document has started printing or the print preview has been closed.
        /// </summary>
        public ActionEvent<Event> OnAfterPrint { get => new ActionEvent<Event>("afterprint", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The appinstalled event of the Web Manifest API is fired when the browser has successfully installed a page as an application.
        /// </summary>
        public ActionEvent<Event> OnAppInstalled { get => new ActionEvent<Event>("appinstalled", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The beforeinstallprompt event fires when the browser has detected that a website can be installed as a Progressive Web App.
        /// </summary>
        public ActionEvent<BeforeInstallPromptEvent> OnBeforeInstallPrompt { get => new ActionEvent<BeforeInstallPromptEvent>("beforeinstallprompt", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The beforeprint event is fired when the associated document is about to be printed or previewed for printing.
        /// </summary>
        public ActionEvent<Event> OnBeforePrint { get => new ActionEvent<Event>("beforeprint", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The beforeunload event is fired when the window, the document and its resources are about to be unloaded. The document is still visible and the event is still cancelable at this point.
        /// </summary>
        public ActionEvent<BeforeUnloadEvent> OnBeforeUnload { get => new ActionEvent<BeforeUnloadEvent>("beforeunload", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The blur event fires when an element has lost focus.
        /// </summary>
        public ActionEvent<FocusEvent> OnBlur { get => new ActionEvent<FocusEvent>("blur", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The copy event fires when the user initiates a copy action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnCopy { get => new ActionEvent<ClipboardEvent>("copy", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The cut event is fired when the user has initiated a "cut" action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnCut { get => new ActionEvent<ClipboardEvent>("cut", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The devicemotion event is fired at a regular interval and indicates the amount of physical force of acceleration the device is receiving at that time. It also provides information about the rate of rotation, if available.
        /// </summary>
        public ActionEvent<DeviceMotionEvent> OnDeviceMotion { get => new ActionEvent<DeviceMotionEvent>("devicemotion", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The deviceorientation event is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device.
        /// </summary>
        public ActionEvent<DeviceOrientationEvent> OnDeviceOrientation { get => new ActionEvent<DeviceOrientationEvent>("deviceorientation", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The deviceorientationabsolute event is sent to the ondeviceorientationabsolute event handler on a Window event when absolute device orientation changes.
        /// </summary>
        public ActionEvent<DeviceOrientationEvent> OnDeviceOrientationAbsolute { get => new ActionEvent<DeviceOrientationEvent>("deviceorientationabsolute", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The error event is fired on a Window object when a resource failed to load or couldn't be used — for example if a script has an execution error.
        /// </summary>
        public ActionEvent<ErrorEvent> OnError { get => new ActionEvent<ErrorEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The focus event fires when an element has received focus.
        /// </summary>
        public ActionEvent<FocusEvent> OnFocus { get => new ActionEvent<FocusEvent>("focus", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The gamepadconnected event is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used.
        /// </summary>
        public ActionEvent<GamepadEvent> OnGamepadConnected { get => new ActionEvent<GamepadEvent>("gamepadconnected", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The gamepaddisconnected event is fired when the browser detects that a gamepad has been disconnected.
        /// </summary>
        public ActionEvent<GamepadEvent> OnGamepadDisconnected { get => new ActionEvent<GamepadEvent>("gamepaddisconnected", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The hashchange event is fired when the fragment identifier of the URL has changed (the part of the URL beginning with and following the # symbol).
        /// </summary>
        public ActionEvent<HashChangeEvent> OnHashChange { get => new ActionEvent<HashChangeEvent>("hashchange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The keydown event is fired when a key is pressed.
        /// </summary>
        public ActionEvent<KeyboardEvent> OnKeyDown { get => new ActionEvent<KeyboardEvent>("keydown", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The keyup event is fired when a key is released.
        /// </summary>
        public ActionEvent<KeyboardEvent> OnKeyUp { get => new ActionEvent<KeyboardEvent>("keyup", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The languagechange event is fired at the global scope object when the user's preferred language changes.
        /// </summary>
        public ActionEvent<Event> OnLanguageChange { get => new ActionEvent<Event>("languagechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The load event is fired when the whole page has loaded, including all dependent resources such as stylesheets, scripts, iframes, and images. This is in contrast to DOMContentLoaded, which is fired as soon as the page DOM has been loaded, without waiting for resources to finish loading.
        /// </summary>
        public ActionEvent<Event> OnLoad { get => new ActionEvent<Event>("load", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The message event is fired on a Window object when the window receives a message, for example from a call to Window.postMessage() from another browsing context.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessage { get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The messageerror event is fired on a Window object when it receives a message that can't be deserialized.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessageError { get => new ActionEvent<MessageEvent>("messageerror", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The offline event of the Window interface is fired when the browser has lost access to the network and the value of Navigator.onLine switches to false
        /// </summary>
        public ActionEvent<Event> OnOffline { get => new ActionEvent<Event>("offline", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The online event of the Window interface is fired when the browser has gained access to the network and the value of Navigator.onLine switches to true
        /// </summary>
        public ActionEvent<Event> OnOnline { get => new ActionEvent<Event>("online", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The pagehide event is sent to a Window when the browser hides the current page in the process of presenting a different page from the session's history
        /// </summary>
        public ActionEvent<PageTransitionEvent> OnPageHide { get => new ActionEvent<PageTransitionEvent>("pagehide", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The pageshow event is sent to a Window when the browser displays the window's document due to navigation.
        /// </summary>
        public ActionEvent<PageTransitionEvent> OnPageShow { get => new ActionEvent<PageTransitionEvent>("pageshow", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The paste event is fired when the user has initiated a "paste" action through the browser's user interface.
        /// </summary>
        public ActionEvent<ClipboardEvent> OnPaste { get => new ActionEvent<ClipboardEvent>("paste", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The popstate event of the Window interface is fired when the active history entry changes while the user navigates the session history. It changes the current history entry to that of the last page the user visited or, if history.pushState() has been used to add a history entry to the history stack, that history entry is used instead.
        /// </summary>
        public ActionEvent<PopStateEvent> OnPopState { get => new ActionEvent<PopStateEvent>("popstate", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The rejectionhandled event is sent to the script's global scope (usually window but also Worker) whenever a rejected JavaScript Promise is handled late, i.e. when a handler is attached to the promise after its rejection had caused an unhandledrejection event.
        /// </summary>
        public ActionEvent<PromiseRejectionEvent> OnRejectionHandled { get => new ActionEvent<PromiseRejectionEvent>("rejectionhandled", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The resize event fires when the document view (window) has been resized.
        /// </summary>
        public ActionEvent<UIEvent> OnResize { get => new ActionEvent<UIEvent>("resize", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The storage event of the Window interface fires when a storage area (localStorage) has been modified in the context of another document.
        /// </summary>
        public ActionEvent<StorageEvent> OnStorage { get => new ActionEvent<StorageEvent>("storage", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The unhandledrejection event is sent to the global scope of a script when a JavaScript Promise that has no rejection handler is rejected; typically, this is the window, but may also be a Worker.
        /// </summary>
        public ActionEvent<PromiseRejectionEvent> OnUnhandledRejection { get => new ActionEvent<PromiseRejectionEvent>("unhandledrejection", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The unload event is fired when the document or a child resource is being unloaded.<br/>
        /// Warning: Developers should avoid using this event.
        /// </summary>
        public ActionEvent<Event> OnUnload { get => new ActionEvent<Event>("unload", AddEventListener, RemoveEventListener); set { } }
        #endregion
        /// <summary>
        /// Returns true if showDirectoryPicker is found
        /// </summary>
        /// <returns></returns>
        public bool ShowDirectoryPickerSupported() => !JS.IsUndefined("showDirectoryPicker");
        /// <summary>
        /// The showDirectoryPicker() method of the Window interface displays a directory picker which allows the user to select a directory.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<FileSystemDirectoryHandle> ShowDirectoryPicker(ShowDirectoryPickerOptions? options = null) => options == null ?
            JSRef!.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker") :
            JSRef!.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker", options);
        /// <summary>
        /// The showOpenFilePicker() method of the Window interface shows a file picker that allows a user to select a file or multiple files and returns a handle for the file(s).
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Array<FileSystemFileHandle>> ShowOpenFilePicker(ShowOpenFilePickerOptions? options = null) => options == null ?
            JSRef!.CallAsync<Array<FileSystemFileHandle>>("showOpenFilePicker") :
            JSRef!.CallAsync<Array<FileSystemFileHandle>>("showOpenFilePicker", options);
        /// <summary>
        /// The showSaveFilePicker() method of the Window interface shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<FileSystemFileHandle> ShowSaveFilePicker(ShowSaveFilePickerOptions? options = null) => options == null ?
            JSRef!.CallAsync<FileSystemFileHandle>("showSaveFilePicker") :
            JSRef!.CallAsync<FileSystemFileHandle>("showSaveFilePicker", options);
    }
}

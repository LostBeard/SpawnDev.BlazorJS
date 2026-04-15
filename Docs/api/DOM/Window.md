# Window

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/DOM/Window.cs`  
**MDN Reference:** [Window on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window)

> The Window interface represents a window containing a DOM document; the document property points to the DOM document loaded in that window. https://developer.mozilla.org/en-US/docs/Web/API/Window

## Constructors

| Signature | Description |
|---|---|
| `Window(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Window()` | Gets the global Window instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Closed` | `bool` | get | The Window.closed read-only property indicates whether the referenced window is closed or not. |
| `Caches` | `CacheStorage` | get | Returns the CacheStorage object associated with the current context. This object enables functionality such as storing assets for offline use, and generating custom responses to requests. |
| `CookieStore` | `CookieStore?` | get | Returns a reference to the CookieStore object, or null if not supported. |
| `DevicePixelRatio` | `double` | get | The devicePixelRatio of Window interface returns the ratio of the resolution in physical pixels to the resolution in CSS pixels for the current display device. |
| `Document` | `Document` | get | window.document returns a reference to the document contained in the window. |
| `FrameElement` | `Element?` | get | The Window.frameElement property returns the element (such as iframe or object) in which the window is embedded. |
| `History` | `History` | get | The Window.history read-only property returns a reference to the History object, which provides an interface for manipulating the browser session history (pages visited in the tab or frame that the current page is loaded in). |
| `IndexedDB` | `IDBFactory` | get | Provides a mechanism for applications to asynchronously access capabilities of indexed databases; returns an IDBFactory object. |
| `InnerHeight` | `int` | get | The read-only innerHeight property of the Window interface returns the interior height of the window in pixels, including the height of the horizontal scroll bar, if present. |
| `InnerWidth` | `int` | get | The read-only Window property innerWidth returns the interior width of the window in pixels. This includes the width of the vertical scroll bar, if one is present |
| `LaunchQueue` | `LaunchQueue` | get | The launchQueue read-only property of the Window interface provides access to the LaunchQueue class, which allows custom launch navigation handling to be implemented in a progressive web app (PWA), with the handling context signified by the launch_handler manifest field client_mode value. |
| `Length` | `int` | get | Returns the number of frames (either frame or iframe elements) in the window. |
| `LocalStorage` | `Storage` | get | The localStorage read-only property of the window interface allows you to access a Storage object for the Document's origin; the stored data is saved across browser sessions. |
| `Location` | `Location` | get | The Window.location read-only property returns a Location object with information about the current location of the document. |
| `Name` | `string?` | get | The Window.name property gets/sets the name of the window's browsing context. |
| `Navigator` | `Navigator` | get | The Window.navigator read-only property returns a reference to the Navigator object, which has methods and properties about the application running the script. |
| `Opener` | `Window` | get | The Window interface's opener property returns a reference to the window that opened the window, either with open(), or by navigating a link with a target attribute. |
| `OuterHeight` | `int` | get | The Window.outerHeight read-only property returns the height in pixels of the whole browser window, including any sidebar, window chrome, and window-resizing borders/handles. |
| `OuterWidth` | `int` | get/set | Window.outerWidth read-only property returns the width of the outside of the browser window. It represents the width of the whole browser window including sidebar (if expanded), window chrome and window resizing borders/handles. |
| `PageXOffset` | `int` | get | The read-only Window property pageXOffset is an alias for scrollX. |
| `PageYOffset` | `int` | get | The read-only Window property pageYOffset is an alias for scrollY; as such, it returns the number of pixels the document is currently scrolled along the vertical axis (that is, up or down) with a value of 0.0, indicating that the top edge of the Document is currently aligned with the top edge of the window's content area. |
| `Parent` | `Window` | get | The Window.parent property is a reference to the parent of the current window or subframe If a window does not have a parent, its parent property is a reference to itself. |
| `Screen` | `Screen` | get | The Window property screen returns a reference to the screen object associated with the window. The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered. |
| `ScreenLeft` | `int` | get | The Window.screenLeft read-only property returns the horizontal distance, in CSS pixels, from the left border of the user's browser viewport to the left side of the screen. |
| `ScreenTop` | `int` | get | The Window.screenTop read-only property returns the vertical distance, in CSS pixels, from the top border of the user's browser viewport to the top side of the screen |
| `ScreenX` | `int` | get | The Window.screenX read-only property returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen. |
| `ScreenY` | `int` | get | The Window.screenY read-only property returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen |
| `ScrollX` | `double` | get | The read-only scrollX property of the Window interface returns the number of pixels that the document is currently scrolled horizontally. This value is subpixel precise in modern browsers, meaning that it isn't necessarily a whole number. You can get the number of pixels the document is scrolled vertically from the scrollY property. |
| `ScrollY` | `double` | get | The read-only scrollY property of the Window interface returns the number of pixels that the document is currently scrolled vertically. |
| `SessionStorage` | `Storage` | get | The read-only sessionStorage property accesses a session Storage object for the current origin. sessionStorage is similar to localStorage; the difference is that while data in localStorage doesn't expire, data in sessionStorage is cleared when the page session ends. |
| `Top` | `Window?` | get | Returns a reference to the topmost window in the window hierarchy. |
| `CrossOriginIsolated` | `bool?` | get | Returns true if the website is in a cross-origin isolation state. Returns null if the browser does not support cross-origin isolation detection. |
| `Crypto` | `Crypto` | get | Returns the browser crypto object. |
| `Credentialless` | `bool?` | get | Returns a boolean that indicates whether the current document was loaded inside a credentialless iframe. See IFrame credentialless for more details. |
| `DocumentPictureInPicture` | `DocumentPictureInPicture` | get | Returns a reference to the document Picture-in-Picture window for the current document context. |
| `IsSecureContext` | `bool` | get | Returns a boolean indicating whether the current context is secure (true) or not (false). |
| `Origin` | `string` | get | Returns the global object's origin, serialized as a string. |
| `VisualViewport` | `VisualViewport` | get | Returns a VisualViewport object which represents the visual viewport for a given window. |
| `Performance` | `Performance` | get | The global performance property returns a Performance object, which can be used to gather performance information about the context it is called in (window or worker). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Alert(string msg)` | `void` | Displays an alert dialog. |
| `SetTimeout(Callback callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetTimeout(Action callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetTimeout(Func<Task> callback, double delay)` | `long` | Schedules a function to execute in a given amount of time. |
| `SetInterval(Callback callback, double delay)` | `long` | The setInterval() method of the Window interface repeatedly calls a function or executes a code snippet, with a fixed time delay between each call. This method returns an interval ID which uniquely identifies the interval, so you can remove it later by calling clearInterval(). |
| `ClearInterval(long requestId)` | `void` | Cancels the delayed execution set using setInterval(). |
| `ClearTimeout(long requestId)` | `void` | Cancels the delayed execution set using setTimeout(). |
| `CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative. The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative. An object that sets options for the image's extraction. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source An object that sets options for the image's extraction. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. An image source The x coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The y coordinate of the reference point of the rectangle from which the ImageBitmap will be extracted. The width of the rectangle from which the ImageBitmap will be extracted. This value can be negative. The height of the rectangle from which the ImageBitmap will be extracted. This value can be negative. A Promise which resolves to an ImageBitmap object containing bitmap data from the given rectangle. |
| `RequestAnimationFrame(ActionCallback<double> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(ActionCallback callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(Action<double> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(Action callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(Func<double, Task> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(Func<Task> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `CancelAnimationFrame(long requestId)` | `void` | Enables you to cancel a callback previously scheduled with Window.requestAnimationFrame. |
| `RequestIdleCallback(ActionCallback<IdleDeadline> callback)` | `long` | The window.requestIdleCallback() method queues a function to be called during a browser's idle periods. This enables developers to perform background and low priority work on the main event loop, without impacting latency-critical events such as animation and input response. Functions are generally called in first-in-first-out order; however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses. |
| `ResizeBy(int deltaX, int deltaY)` | `void` | The Window.resizeBy() method resizes the current window by a specified amount. The number of pixels to grow the window horizontally. The number of pixels to grow the window vertically. |
| `ResizeTo(int width, int height)` | `void` | The Window.resizeTo() method dynamically resizes the window. An integer representing the new outerWidth in pixels (including scroll bars, title bars, etc.). An integer value representing the new outerHeight in pixels (including scroll bars, title bars, etc.). |
| `Scroll(int xCoord, int yCoord)` | `void` | The Window.scroll() method scrolls the window to a particular place in the document. The pixel along the horizontal axis of the document that you want displayed in the upper left. The pixel along the vertical axis of the document that you want displayed in the upper left. |
| `Scroll(ScrollOptions options)` | `void` | The Window.scroll() method scrolls the window to a particular place in the document. Scroll options |
| `ScrollBy(ScrollOptions options)` | `void` | The Window.scrollBy() method scrolls the document in the window by the given amount. |
| `ScrollBy(int xCoord, int yCoord)` | `void` | The Window.scrollBy() method scrolls the document in the window by the given amount. The horizontal pixel value that you want to scroll by. The vertical pixel value that you want to scroll by. |
| `ScrollTo(ScrollOptions options)` | `void` | Window.scrollTo() scrolls to a particular set of coordinates in the document. |
| `Stop()` | `void` | The window.stop() stops further resource loading in the current browsing context, equivalent to the stop button in the browser. Because of how scripts are executed, this method cannot interrupt its parent document's loading, but it will stop its images, new windows, and other still-loading objects. |
| `StructuredClone(object value, StructuredCloneOptions options)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. The object to be cloned. This can be any structured-cloneable type. |
| `StructuredClone(object value)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. The object to be cloned. This can be any structured-cloneable type. |
| `ScrollTo(int xCoord, int yCoord)` | `void` | Window.scrollTo() scrolls to a particular set of coordinates in the document. The pixel along the horizontal axis of the document that you want displayed in the upper left. The pixel along the vertical axis of the document that you want displayed in the upper left. |
| `RequestIdleCallback(Action<IdleDeadline> callback)` | `long` | The window.requestIdleCallback() method queues a function to be called during a browser's idle periods. This enables developers to perform background and low priority work on the main event loop, without impacting latency-critical events such as animation and input response. Functions are generally called in first-in-first-out order; however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses. |
| `CancelIdleCallback(long handle)` | `void` | Enables you to cancel a callback previously scheduled with Window.requestIdleCallback. The ID value returned by window.requestIdleCallback() when the callback was established. |
| `Close()` | `void` | Closes the current window. |
| `Confirm()` | `bool` | window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog. A boolean indicating whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false. |
| `Confirm(string message)` | `bool` | window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog. A string you want to display in the confirmation dialog. A boolean indicating whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false. |
| `Fetch(Request resource)` | `Task<Response>` | Calls fetch |
| `Fetch(string resource)` | `Task<Response>` | Calls fetch |
| `Fetch(string resource, FetchOptions options)` | `Task<Response>` | Calls fetch |
| `Focus()` | `void` | Makes a request to bring the window to the front. It may fail due to user settings and the window isn't guaranteed to be frontmost before this method returns. |
| `GetComputedStyle(Element element, string? pseudoElement)` | `CSSStyleDeclaration` | Gets computed style for the specified element. Computed style indicates the computed values of all CSS properties of the element. The Element for which to get the computed style. A string specifying the pseudo-element to match. Omitted (or null) for real elements. A live CSSStyleDeclaration object, which updates automatically when the element's styles are changed. |
| `GetSelection()` | `Selection?` | The getSelection() method of the Window interface returns the Selection object associated with the window's document, representing the range of text selected by the user or the current position of the caret. A Selection object, or null if the associated document has no browsing context (for example, the window is an iframe that is not attached to a document). |
| `GetScreenDetails()` | `Task<ScreenDetails>` | Experimental state. Not supported in most browsers. (Works in Chrome) ScreenDetails |
| `MatchMedia(string mode)` | `MediaQueryList` | The Window interface's matchMedia() method returns a new MediaQueryList object that can then be used to determine if the document matches the media query string, as well as to monitor the document to detect when it matches (or stops matching) that media query. |
| `MoveBy(int deltaX, int deltaY)` | `void` | The moveBy() method of the Window interface moves the current window by a specified amount. Note: This function moves the window relative to its current location. In contrast, window.moveTo() moves the window to an absolute location. The amount of pixels to move the window horizontally. Positive values are to the right, while negative values are to the left. The amount of pixels to move the window vertically. Positive values are down, while negative values are up. |
| `MoveTo(int x, int y)` | `void` | The moveTo() method of the Window interface moves the current window to the specified coordinates. Note: This function moves the window to an absolute location. In contrast, window.moveBy() moves the window relative to its current location. The horizontal coordinate to be moved to. The vertical coordinate to be moved to. |
| `Open(string url, string target, string windowFeatures)` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context. A string, without whitespace, specifying the name of the browsing context the resource is being loaded into. If the name doesn't identify an existing context, a new context is created and given the specified name. The special target keywords, _self, _blank (default), _parent, _top, and _unfencedTop can also be used. _unfencedTop is only relevant to fenced frames. A string containing a comma-separated list of window features in the form name=value. Boolean values can be set to true using one of: name, name=yes, name=true, or name=n where n is any non-zero integer. These features include options such as the window's default size and position, whether or not to open a minimal popup window, and so forth. If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements. |
| `Open(string url, string target)` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context. A string, without whitespace, specifying the name of the browsing context the resource is being loaded into. If the name doesn't identify an existing context, a new context is created and given the specified name. The special target keywords, _self, _blank (default), _parent, _top, and _unfencedTop can also be used. _unfencedTop is only relevant to fenced frames. If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements. |
| `Open(string url)` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. A string indicating the URL or path of the resource to be loaded. If an empty string ("") is specified or this parameter is omitted, a blank page is opened into the targeted browsing context. If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements. |
| `Open()` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. If the browser successfully opens the new browsing context, a WindowProxy object is returned. The returned reference can be used to access properties and methods of the new context as long as it complies with the same-origin policy security requirements. |
| `PostMessage(object message, string targetOrigin, object[] transfer)` | `void` | The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it. Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself. Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin. An optional array of transferable objects to transfer ownership of. The ownership of these objects is given to the destination side and they are no longer usable on the sending side. These transferable objects should be attached to the message; otherwise they would be moved but not actually accessible on the receiving end. |
| `PostMessage(object message, string targetOrigin)` | `void` | The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it. Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself. Specifies the origin the recipient window must have in order to receive the event. In order for the event to be dispatched, the origin must match exactly (including scheme, hostname, and port). If omitted, then defaults to the origin that is calling the method. This mechanism provides control over where messages are sent; for example, if postMessage() was used to transmit a password, it would be absolutely critical that this argument be a URI whose origin is the same as the intended receiver of the message containing the password, to prevent interception of the password by a malicious third party. * may also be provided, which means the message can be dispatched to a listener with any origin. |
| `PostMessage(object message)` | `void` | The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it. Data to be dispatched to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself. |
| `Print()` | `void` | Opens the print dialog to print the current document. |
| `Prompt()` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. A string containing the text entered by the user, or null. |
| `Prompt(string message)` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window. A string containing the text entered by the user, or null. |
| `Prompt(string message, string defaultValue)` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window. A string containing the default value displayed in the text input field. A string containing the text entered by the user, or null. |
| `QueueMicrotask(Action callback)` | `void` | The queueMicrotask() method of the Window interface queues a microtask to be executed at a safe time prior to control returning to the browser's event loop. A function to be executed when the browser engine determines it is safe to call your code. Enqueued microtasks are executed after all pending tasks have completed but before yielding control to the browser's event loop. |
| `ShowDirectoryPickerSupported()` | `bool` | Returns true if showDirectoryPicker is found |
| `ShowDirectoryPicker(ShowDirectoryPickerOptions? options)` | `Task<FileSystemDirectoryHandle>` | The showDirectoryPicker() method of the Window interface displays a directory picker which allows the user to select a directory. |
| `ShowOpenFilePicker(ShowOpenFilePickerOptions? options)` | `Task<Array<FileSystemFileHandle>>` | The showOpenFilePicker() method of the Window interface shows a file picker that allows a user to select a file or multiple files and returns a handle for the file(s). |
| `ShowSaveFilePicker(ShowSaveFilePickerOptions? options)` | `Task<FileSystemFileHandle>` | The showSaveFilePicker() method of the Window interface shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAfterPrint` | `ActionEvent<Event>` | The afterprint event is fired after the associated document has started printing or the print preview has been closed. |
| `OnAppInstalled` | `ActionEvent<Event>` | The appinstalled event of the Web Manifest API is fired when the browser has successfully installed a page as an application. |
| `OnBeforeInstallPrompt` | `ActionEvent<BeforeInstallPromptEvent>` | The beforeinstallprompt event fires when the browser has detected that a website can be installed as a Progressive Web App. |
| `OnBeforePrint` | `ActionEvent<Event>` | The beforeprint event is fired when the associated document is about to be printed or previewed for printing. |
| `OnBeforeUnload` | `ActionEvent<BeforeUnloadEvent>` | The beforeunload event is fired when the window, the document and its resources are about to be unloaded. The document is still visible and the event is still cancelable at this point. |
| `OnBlur` | `ActionEvent<FocusEvent>` | The blur event fires when an element has lost focus. |
| `OnCopy` | `ActionEvent<ClipboardEvent>` | The copy event fires when the user initiates a copy action through the browser's user interface. |
| `OnCut` | `ActionEvent<ClipboardEvent>` | The cut event is fired when the user has initiated a "cut" action through the browser's user interface. |
| `OnDeviceMotion` | `ActionEvent<DeviceMotionEvent>` | The devicemotion event is fired at a regular interval and indicates the amount of physical force of acceleration the device is receiving at that time. It also provides information about the rate of rotation, if available. |
| `OnDeviceOrientation` | `ActionEvent<DeviceOrientationEvent>` | The deviceorientation event is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device. |
| `OnDeviceOrientationAbsolute` | `ActionEvent<DeviceOrientationEvent>` | The deviceorientationabsolute event is sent to the ondeviceorientationabsolute event handler on a Window event when absolute device orientation changes. |
| `OnError` | `ActionEvent<ErrorEvent>` | The error event is fired on a Window object when a resource failed to load or couldn't be used - for example if a script has an execution error. |
| `OnFocus` | `ActionEvent<FocusEvent>` | The focus event fires when an element has received focus. |
| `OnGamepadConnected` | `ActionEvent<GamepadEvent>` | The gamepadconnected event is fired when the browser detects that a gamepad has been connected or the first time a button/axis of the gamepad is used. |
| `OnGamepadDisconnected` | `ActionEvent<GamepadEvent>` | The gamepaddisconnected event is fired when the browser detects that a gamepad has been disconnected. |
| `OnHashChange` | `ActionEvent<HashChangeEvent>` | The hashchange event is fired when the fragment identifier of the URL has changed (the part of the URL beginning with and following the # symbol). |
| `OnKeyDown` | `ActionEvent<KeyboardEvent>` | The keydown event is fired when a key is pressed. |
| `OnKeyUp` | `ActionEvent<KeyboardEvent>` | The keyup event is fired when a key is released. |
| `OnMouseMove` | `ActionEvent<MouseEvent>` | Fired when a pointing device (usually a mouse) is moved while over the window. https://developer.mozilla.org/en-US/docs/Web/API/Window/mousemove_event |
| `OnLanguageChange` | `ActionEvent<Event>` | The languagechange event is fired at the global scope object when the user's preferred language changes. |
| `OnLoad` | `ActionEvent<Event>` | The load event is fired when the whole page has loaded, including all dependent resources such as stylesheets, scripts, iframes, and images. This is in contrast to DOMContentLoaded, which is fired as soon as the page DOM has been loaded, without waiting for resources to finish loading. |
| `OnMessage` | `ActionEvent<MessageEvent>` | The message event is fired on a Window object when the window receives a message, for example from a call to Window.postMessage() from another browsing context. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | The messageerror event is fired on a Window object when it receives a message that can't be deserialized. |
| `OnOffline` | `ActionEvent<Event>` | The offline event of the Window interface is fired when the browser has lost access to the network and the value of Navigator.onLine switches to false |
| `OnOnline` | `ActionEvent<Event>` | The online event of the Window interface is fired when the browser has gained access to the network and the value of Navigator.onLine switches to true |
| `OnPageHide` | `ActionEvent<PageTransitionEvent>` | The pagehide event is sent to a Window when the browser hides the current page in the process of presenting a different page from the session's history |
| `OnPageShow` | `ActionEvent<PageTransitionEvent>` | The pageshow event is sent to a Window when the browser displays the window's document due to navigation. |
| `OnPaste` | `ActionEvent<ClipboardEvent>` | The paste event is fired when the user has initiated a "paste" action through the browser's user interface. |
| `OnPopState` | `ActionEvent<PopStateEvent>` | The popstate event of the Window interface is fired when the active history entry changes while the user navigates the session history. It changes the current history entry to that of the last page the user visited or, if history.pushState() has been used to add a history entry to the history stack, that history entry is used instead. |
| `OnRejectionHandled` | `ActionEvent<PromiseRejectionEvent>` | The rejectionhandled event is sent to the script's global scope (usually window but also Worker) whenever a rejected JavaScript Promise is handled late, i.e. when a handler is attached to the promise after its rejection had caused an unhandledrejection event. |
| `OnResize` | `ActionEvent<UIEvent>` | The resize event fires when the document view (window) has been resized. |
| `OnStorage` | `ActionEvent<StorageEvent>` | The storage event of the Window interface fires when a storage area (localStorage) has been modified in the context of another document. |
| `OnUnhandledRejection` | `ActionEvent<PromiseRejectionEvent>` | The unhandledrejection event is sent to the global scope of a script when a JavaScript Promise that has no rejection handler is rejected; typically, this is the window, but may also be a Worker. |
| `OnUnload` | `ActionEvent<Event>` | The unload event is fired when the document or a child resource is being unloaded. Warning: Developers should avoid using this event. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the document view is scrolled. |
| `OnScrollEnd` | `ActionEvent<Event>` | Fired when scrolling has completed. |
| `OnContextMenu` | `ActionEvent<MouseEvent>` | Fired when the right button of the mouse is clicked (before the context menu is displayed). |
| `OnMouseDown` | `ActionEvent<MouseEvent>` | Fired when a mouse button is pressed. |
| `OnMouseUp` | `ActionEvent<MouseEvent>` | Fired when a mouse button is released. |
| `OnClick` | `ActionEvent<MouseEvent>` | Fired when a mouse button is clicked (pressed and released). |
| `OnPointerDown` | `ActionEvent<PointerEvent>` | Fired when a pointer becomes active. |
| `OnPointerUp` | `ActionEvent<PointerEvent>` | Fired when a pointer is no longer active. |
| `OnPointerMove` | `ActionEvent<PointerEvent>` | Fired when a pointer changes coordinates. |
| `OnPointerCancel` | `ActionEvent<PointerEvent>` | Fired when a pointer event is canceled. |
| `OnTouchStart` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are placed on the touch surface. |
| `OnTouchEnd` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are removed from the touch surface. |
| `OnTouchMove` | `ActionEvent<TouchEvent>` | Fired when one or more touch points are moved along the touch surface. |
| `OnTouchCancel` | `ActionEvent<TouchEvent>` | Fired when one or more touch points have been disrupted in an implementation-specific manner. |
| `OnWheel` | `ActionEvent<WheelEvent>` | Fired when a wheel button of a pointing device is rotated. |
| `OnDrop` | `ActionEvent<DragEvent>` | Fired when a drag operation is being ended (by releasing a mouse button or hitting the escape key). |
| `OnDragOver` | `ActionEvent<DragEvent>` | Fired when an element or text selection is being dragged over a valid drop target. |

## Example

```csharp
// Get the Window object via BlazorJSRuntime
using var window = JS.Get<Window>("window");

// Read window dimensions
int innerWidth = window.InnerWidth;
int innerHeight = window.InnerHeight;
double pixelRatio = window.DevicePixelRatio;

// Access sub-objects
using var navigator = window.Navigator;
using var location = window.Location;
using var localStorage = window.LocalStorage;

// Navigate and manage history
using var history = window.History;

// Set timeouts and intervals
int timerId = window.SetTimeout(() =>
{
    Console.WriteLine("Timeout fired");
}, 1000);
window.ClearTimeout(timerId);

int intervalId = window.SetInterval(() =>
{
    Console.WriteLine("Interval tick");
}, 500);
window.ClearInterval(intervalId);

// Open a new window
using var popup = window.Open("https://example.com", "_blank");

// Show dialog boxes
window.Alert("Hello from BlazorJS!");
bool confirmed = window.Confirm("Proceed?");
string? input = window.Prompt("Enter your name:");

// Scroll the window
window.ScrollTo(0, 500);

// Request animation frame
window.RequestAnimationFrame((timestamp) =>
{
    Console.WriteLine($"Frame at {timestamp}ms");
});

// Listen for window events
window.OnResize += (e) =>
{
    Console.WriteLine($"Resized to {window.InnerWidth}x{window.InnerHeight}");
};

window.OnStorage += (e) =>
{
    Console.WriteLine($"Storage key changed: {e.Key}");
};

// Fetch API (via window or global)
using var response = await JS.CallAsync<Response>("fetch", "/api/data");
string json = await response.Text();
```


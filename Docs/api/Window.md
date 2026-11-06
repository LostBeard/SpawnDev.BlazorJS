# Window

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Window  
**MDN Reference:** [Window on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/Window.cs`

> The Window interface represents a browser window containing a DOM document. It provides access to the document, navigator, location, history, screen, storage, crypto, and performance APIs. In SpawnDev.BlazorJS, the Window instance for the current scope is available via `BlazorJSRuntime.WindowThis` when running in a window context.

## Constructor

```csharp
// From existing reference
public Window(IJSInProcessObjectReference _ref) : base(_ref) { }

// Get the global window instance
public Window() : base(JS.Get<IJSInProcessObjectReference>("window")) { }

// Via BlazorJSRuntime
var window = JS.WindowThis;         // Pre-created instance (may be null in workers)
var window = JS.Get<Window>("window"); // Explicit access
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Closed` | `bool` | Whether the referenced window is closed. |
| `Caches` | `CacheStorage` | The CacheStorage object for the current context. |
| `CookieStore` | `CookieStore?` | The CookieStore object, or null if not supported. |
| `CrossOriginIsolated` | `bool?` | Whether the site is in a cross-origin isolated state. |
| `Credentialless` | `bool?` | Whether loaded inside a credentialless iframe. |
| `Crypto` | `Crypto` | The browser Crypto object. |
| `DevicePixelRatio` | `double` | Ratio of physical pixels to CSS pixels (minimum 1.0). |
| `Document` | `Document` | The document contained in the window. |
| `DocumentPictureInPicture` | `DocumentPictureInPicture` | The document Picture-in-Picture window. |
| `FrameElement` | `Element?` | The element (iframe/object) this window is embedded in. |
| `History` | `History` | The browser session history. |
| `IndexedDB` | `IDBFactory` | The IndexedDB factory. |
| `InnerHeight` | `int` | Interior height in pixels (including horizontal scrollbar). |
| `InnerWidth` | `int` | Interior width in pixels (including vertical scrollbar). |
| `IsSecureContext` | `bool` | Whether the current context is secure (HTTPS). |
| `LaunchQueue` | `LaunchQueue` | PWA launch queue for custom launch handling. |
| `Length` | `int` | Number of frames (iframe/frame) in the window. |
| `LocalStorage` | `Storage` | The localStorage for the document's origin. |
| `Location` | `Location` | The Location object with current URL information. |
| `Name` | `string?` | Get/set the browsing context name. |
| `Navigator` | `Navigator` | The Navigator object with browser/device info. |
| `Opener` | `Window` | Reference to the window that opened this window. |
| `Origin` | `string` | The global object's origin, serialized as a string. |
| `OuterHeight` | `int` | Full browser window height including chrome. |
| `OuterWidth` | `int` | Full browser window width including chrome. |
| `PageXOffset` | `int` | Alias for ScrollX. |
| `PageYOffset` | `int` | Alias for ScrollY. |
| `Parent` | `Window` | Reference to the parent window (self if top-level). |
| `Performance` | `Performance` | The Performance object for timing/measurement. |
| `Screen` | `Screen` | The Screen object for display properties. |
| `ScreenLeft` | `int` | Horizontal distance from viewport to screen left edge. |
| `ScreenTop` | `int` | Vertical distance from viewport to screen top edge. |
| `ScreenX` | `int` | Horizontal distance of browser viewport to screen left. |
| `ScreenY` | `int` | Vertical distance of browser viewport to screen top. |
| `ScrollX` | `double` | Pixels scrolled horizontally (subpixel precise). |
| `ScrollY` | `double` | Pixels scrolled vertically (subpixel precise). |
| `SessionStorage` | `Storage` | The sessionStorage for the current origin. |
| `Top` | `Window?` | Reference to the topmost window. |
| `VisualViewport` | `VisualViewport` | The visual viewport for the window. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Alert(string msg = "")` | `void` | Display an alert dialog. |
| `SetTimeout(Callback cb, double delay)` | `long` | Schedule a callback after delay ms. Returns timer ID. |
| `SetTimeout(Action cb, double delay)` | `long` | Schedule an Action (auto-creates one-shot Callback). |
| `SetTimeout(Func<Task> cb, double delay)` | `long` | Schedule an async Action. |
| `SetInterval(Callback cb, double delay)` | `long` | Repeatedly call a callback at delay ms intervals. Returns interval ID. |
| `ClearInterval(long requestId)` | `void` | Cancel a setInterval. |
| `ClearTimeout(long requestId)` | `void` | Cancel a setTimeout. |
| `RequestAnimationFrame(Action<double> cb)` | `long` | Request a callback before the next repaint. Receives timestamp. |
| `RequestAnimationFrame(Action cb)` | `long` | Request a callback before the next repaint (no timestamp). |
| `RequestAnimationFrame(Func<double, Task> cb)` | `long` | Async variant with timestamp. |
| `CancelAnimationFrame(long requestId)` | `void` | Cancel a requestAnimationFrame. |
| `RequestIdleCallback(ActionCallback<IdleDeadline> cb)` | `long` | Queue work during browser idle periods. |
| `CreateImageBitmap(ImageBitmapSource image)` | `Task<ImageBitmap>` | Create a bitmap from a source. |
| `CreateImageBitmap(ImageBitmapSource, int sx, int sy, int sw, int sh)` | `Task<ImageBitmap>` | Create a cropped bitmap. |
| `Scroll(int x, int y)` | `void` | Scroll to absolute coordinates. |
| `Scroll(ScrollOptions options)` | `void` | Scroll with options (smooth/instant). |
| `ScrollBy(int x, int y)` | `void` | Scroll by relative amount. |
| `ScrollBy(ScrollOptions options)` | `void` | Scroll by with options. |
| `ScrollTo(ScrollOptions options)` | `void` | Scroll to with options. |
| `ResizeBy(int deltaX, int deltaY)` | `void` | Resize window by delta pixels. |
| `ResizeTo(int width, int height)` | `void` | Resize window to absolute size. |
| `MatchMedia(string query)` | `MediaQueryList` | Test a CSS media query. |
| `GetComputedStyle(Element el)` | `CSSStyleDeclaration` | Get the computed style of an element. |
| `Open(string url, string target, string features)` | `Window?` | Open a new browser window. |
| `Close()` | `void` | Close the window. |
| `Focus()` | `void` | Focus the window. |
| `Blur()` | `void` | Remove focus from the window. |
| `Print()` | `void` | Open the print dialog. |
| `PostMessage(object message, string targetOrigin)` | `void` | Send a message to another window. |
| `Fetch(string url)` | `Task<Response>` | Fetch API call. |
| `Stop()` | `void` | Stop loading resources. |
| `CreateImageBitmap(ImageBitmapSource image, int sx, int sy, int sw, int sh, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. |
| `CreateImageBitmap(ImageBitmapSource image, ImageBitmapOptions options)` | `Task<ImageBitmap>` | The createImageBitmap() method of the Window interface creates a bitmap from a given source, optionally cropped to contain only a portion of that source. It accepts a variety of different image sources, and returns a Promise which resolves to an ImageBitmap. |
| `RequestAnimationFrame(ActionCallback<double> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(ActionCallback callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `RequestAnimationFrame(Func<Task> callback)` | `long` | The window.requestAnimationFrame() method tells the browser you wish to perform an animation. It requests the browser to call a user-supplied callback function before the next repaint. |
| `StructuredClone<T>(object value, StructuredCloneOptions options)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. |
| `StructuredClone<T>(object value)` | `T` | The structuredClone() method of the Window interface creates a deep clone of a given value using the structured clone algorithm. The method also allows transferable objects in the original value to be transferred rather than cloned to the new object. Transferred objects are detached from the original object and attached to the new object; they are no longer accessible in the original object. |
| `ScrollTo(int xCoord, int yCoord)` | `void` | Window.scrollTo() scrolls to a particular set of coordinates in the document. |
| `RequestIdleCallback(Action<IdleDeadline> callback)` | `long` | The window.requestIdleCallback() method queues a function to be called during a browser's idle periods. This enables developers to perform background and low priority work on the main event loop, without impacting latency-critical events such as animation and input response. Functions are generally called in first-in-first-out order; however, callbacks which have a timeout specified may be called out-of-order if necessary in order to run them before the timeout elapses. |
| `CancelIdleCallback(long handle)` | `void` | Enables you to cancel a callback previously scheduled with Window.requestIdleCallback. |
| `Confirm()` | `bool` | window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog. |
| `Confirm(string message)` | `bool` | window.confirm() instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog. |
| `Fetch(Request resource)` | `Task<Response>` | Calls fetch |
| `Fetch(string resource, FetchOptions options)` | `Task<Response>` | Calls fetch |
| `GetComputedStyle(Element element, string? pseudoElement = null)` | `CSSStyleDeclaration` | Gets computed style for the specified element. Computed style indicates the computed values of all CSS properties of the element. |
| `GetSelection()` | `Selection?` | The getSelection() method of the Window interface returns the Selection object associated with the window's document, representing the range of text selected by the user or the current position of the caret. |
| `GetScreenDetails()` | `Task<ScreenDetails>` | Experimental state. Not supported in most browsers. (Works in Chrome) |
| `MoveBy(int deltaX, int deltaY)` | `void` | The moveBy() method of the Window interface moves the current window by a specified amount. Note: This function moves the window relative to its current location. In contrast, window.moveTo() moves the window to an absolute location. |
| `MoveTo(int x, int y)` | `void` | The moveTo() method of the Window interface moves the current window to the specified coordinates. Note: This function moves the window to an absolute location. In contrast, window.moveBy() moves the window relative to its current location. |
| `Open(string url, string target)` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. |
| `Open(string url)` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. |
| `Open()` | `Window?` | The open() method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name. |
| `PostMessage(object message, string targetOrigin, object[] transfer)` | `void` | The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it. |
| `PostMessage(object message)` | `void` | The window.postMessage() method safely enables cross-origin communication between Window objects; e.g., between a page and a pop-up that it spawned, or between a page and an iframe embedded within it. |
| `Prompt()` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. |
| `Prompt(string message)` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. |
| `Prompt(string message, string defaultValue)` | `string?` | window.prompt() instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog. |
| `QueueMicrotask(Action callback)` | `void` | The queueMicrotask() method of the Window interface queues a microtask to be executed at a safe time prior to control returning to the browser's event loop. |
| `ShowDirectoryPickerSupported()` | `bool` | Returns true if showDirectoryPicker is found |
| `ShowDirectoryPicker(ShowDirectoryPickerOptions? options = null)` | `Task<FileSystemDirectoryHandle>` | The showDirectoryPicker() method of the Window interface displays a directory picker which allows the user to select a directory. |
| `ShowOpenFilePicker(ShowOpenFilePickerOptions? options = null)` | `Task<Array<FileSystemFileHandle>>` | The showOpenFilePicker() method of the Window interface shows a file picker that allows a user to select a file or multiple files and returns a handle for the file(s). |
| `ShowSaveFilePicker(ShowSaveFilePickerOptions? options = null)` | `Task<FileSystemFileHandle>` | The showSaveFilePicker() method of the Window interface shows a file picker that allows a user to save a file. Either by selecting an existing file, or entering a name for a new file. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResize` | `ActionEvent<Event>` | Fired when the window is resized. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the document is scrolled. |
| `OnLoad` | `ActionEvent<Event>` | Fired when the page finishes loading. |
| `OnBeforeUnload` | `ActionEvent<Event>` | Fired before the window is about to unload. |
| `OnStorage` | `ActionEvent<StorageEvent>` | Fired when a storage area changes. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when the window receives a message. |
| `OnPopState` | `ActionEvent<PopStateEvent>` | Fired when the active history entry changes. |
| `OnHashChange` | `ActionEvent<HashChangeEvent>` | Fired when the URL hash changes. |
| `OnOnline` | `ActionEvent<Event>` | Fired when the browser gains network access. |
| `OnOffline` | `ActionEvent<Event>` | Fired when the browser loses network access. |
| `OnFocus` | `ActionEvent<FocusEvent>` | Fired when the window gains focus. |
| `OnBlur` | `ActionEvent<FocusEvent>` | Fired when the window loses focus. |
| `OnKeyDown` | `ActionEvent<KeyboardEvent>` | Fired when a key is pressed. |
| `OnKeyUp` | `ActionEvent<KeyboardEvent>` | Fired when a key is released. |
| `OnMouseMove` | `ActionEvent<MouseEvent>` | Fired when the mouse moves. |
| `OnClick` | `ActionEvent<MouseEvent>` | Fired on a click. |
| `OnContextMenu` | `ActionEvent<MouseEvent>` | Fired on right-click. |
| `OnGamepadConnected` | `ActionEvent<GamepadEvent>` | Fired when a gamepad is connected. |
| `OnGamepadDisconnected` | `ActionEvent<GamepadEvent>` | Fired when a gamepad is disconnected. |
| `OnAfterPrint` | `ActionEvent<Event>` | The afterprint event is fired after the associated document has started printing or the print preview has been closed. |
| `OnAppInstalled` | `ActionEvent<Event>` | The appinstalled event of the Web Manifest API is fired when the browser has successfully installed a page as an application. |
| `OnBeforeInstallPrompt` | `ActionEvent<BeforeInstallPromptEvent>` | The beforeinstallprompt event fires when the browser has detected that a website can be installed as a Progressive Web App. |
| `OnBeforePrint` | `ActionEvent<Event>` | The beforeprint event is fired when the associated document is about to be printed or previewed for printing. |
| `OnCopy` | `ActionEvent<ClipboardEvent>` | The copy event fires when the user initiates a copy action through the browser's user interface. |
| `OnCut` | `ActionEvent<ClipboardEvent>` | The cut event is fired when the user has initiated a "cut" action through the browser's user interface. |
| `OnDeviceMotion` | `ActionEvent<DeviceMotionEvent>` | The devicemotion event is fired at a regular interval and indicates the amount of physical force of acceleration the device is receiving at that time. It also provides information about the rate of rotation, if available. |
| `OnDeviceOrientation` | `ActionEvent<DeviceOrientationEvent>` | The deviceorientation event is fired when fresh data is available from an orientation sensor about the current orientation of the device as compared to the Earth coordinate frame. This data is gathered from a magnetometer inside the device. |
| `OnDeviceOrientationAbsolute` | `ActionEvent<DeviceOrientationEvent>` | The deviceorientationabsolute event is sent to the ondeviceorientationabsolute event handler on a Window event when absolute device orientation changes. |
| `OnError` | `ActionEvent<ErrorEvent>` | The error event is fired on a Window object when a resource failed to load or couldn't be used — for example if a script has an execution error. |
| `OnLanguageChange` | `ActionEvent<Event>` | The languagechange event is fired at the global scope object when the user's preferred language changes. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | The messageerror event is fired on a Window object when it receives a message that can't be deserialized. |
| `OnPageHide` | `ActionEvent<PageTransitionEvent>` | The pagehide event is sent to a Window when the browser hides the current page in the process of presenting a different page from the session's history |
| `OnPageShow` | `ActionEvent<PageTransitionEvent>` | The pageshow event is sent to a Window when the browser displays the window's document due to navigation. |
| `OnPaste` | `ActionEvent<ClipboardEvent>` | The paste event is fired when the user has initiated a "paste" action through the browser's user interface. |
| `OnRejectionHandled` | `ActionEvent<PromiseRejectionEvent>` | The rejectionhandled event is sent to the script's global scope (usually window but also Worker) whenever a rejected JavaScript Promise is handled late, i.e. when a handler is attached to the promise after its rejection had caused an unhandledrejection event. |
| `OnUnhandledRejection` | `ActionEvent<PromiseRejectionEvent>` | The unhandledrejection event is sent to the global scope of a script when a JavaScript Promise that has no rejection handler is rejected; typically, this is the window, but may also be a Worker. |
| `OnUnload` | `ActionEvent<Event>` | The unload event is fired when the document or a child resource is being unloaded. Warning: Developers should avoid using this event. |
| `OnScrollEnd` | `ActionEvent<Event>` | Fired when scrolling has completed. |
| `OnMouseDown` | `ActionEvent<MouseEvent>` | Fired when a mouse button is pressed. |
| `OnMouseUp` | `ActionEvent<MouseEvent>` | Fired when a mouse button is released. |
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

## Constructors

| Signature | Description |
|---|---|
| `Window()` | Gets the global Window instance |

## Example

```csharp
@inject BlazorJSRuntime JS
@implements IDisposable

@code {
    Window? window;

    protected override void OnInitialized()
    {
        window = JS.Get<Window>("window");
        window.OnResize += HandleResize;
        window.OnStorage += HandleStorage;
    }

    void HandleResize(Event e)
    {
        Console.WriteLine($"Window: {window!.InnerWidth}x{window.InnerHeight}");
        StateHasChanged();
    }

    void HandleStorage(StorageEvent e)
    {
        Console.WriteLine($"Storage changed: {e.Key}");
    }

    public void Dispose()
    {
        if (window != null)
        {
            window.OnResize -= HandleResize;
            window.OnStorage -= HandleStorage;
            window.Dispose();
        }
    }
}
```

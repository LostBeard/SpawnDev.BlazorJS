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

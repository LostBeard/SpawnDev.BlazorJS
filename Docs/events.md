# Events (ActionEvent / FuncEvent)

SpawnDev.BlazorJS provides a clean .NET-style event system for JavaScript events using `ActionEvent` and `FuncEvent`. These types allow you to subscribe to and unsubscribe from JavaScript events using the `+=` and `-=` operators, with automatic callback reference counting.

**Namespace:** `SpawnDev.BlazorJS`

---

## ActionEvent

`ActionEvent` wraps JavaScript events and exposes them as C# events that accept `Action` delegates. It handles all the reference management automatically - creating Callbacks when you subscribe, and disposing them when you unsubscribe.

### How It Works Internally

When you write `window.OnStorage += MyHandler`:

1. A `Callback` is created wrapping `MyHandler` (via `CallbackRef.RefAdd`)
2. The Callback is passed to JavaScript's `addEventListener`
3. The reference count for `MyHandler` is incremented

When you write `window.OnStorage -= MyHandler`:

1. The existing `Callback` for `MyHandler` is retrieved
2. It is passed to JavaScript's `removeEventListener`
3. The reference count is decremented
4. If the count reaches 0, the `Callback` is disposed

### Basic Usage

```csharp
// Get a Window reference
using var window = JS.Get<Window>("window");

// Subscribe to an event
window.OnStorage += Window_OnStorage;

// ... later, ALWAYS unsubscribe before disposing the parent object
window.OnStorage -= Window_OnStorage;

void Window_OnStorage(StorageEvent e)
{
    Console.WriteLine($"Storage changed: {e.Key}");
}
```

---

## The ActionEvent Property Pattern

When implementing `ActionEvent` properties in your own JSObject wrappers, use this pattern:

```csharp
public ActionEvent<StorageEvent> OnStorage
{
    get => new ActionEvent<StorageEvent>("storage", AddEventListener, RemoveEventListener);
    set { }
}
```

**Why `set { }` is required:** The `+=` operator in C# is syntactic sugar for `property = property + value`. Without a setter, `+=` cannot compile. The empty `set { }` satisfies the compiler while the actual subscription is handled by the `+` operator overload on `ActionEvent`.

**The constructor parameters:**

- `"storage"` - the JavaScript event name
- `AddEventListener` - method reference for subscribing (inherited from `EventTarget`)
- `RemoveEventListener` - method reference for unsubscribing (inherited from `EventTarget`)

### Alternative Constructor Form

For objects that do not inherit from `EventTarget`, you can pass lambda attach/detach callbacks:

```csharp
public ActionEvent<MessageEvent> OnMessage
{
    get => new ActionEvent<MessageEvent>(
        (callback) => JSRef!.CallVoid("addEventListener", "message", callback),
        (callback) => JSRef!.CallVoid("removeEventListener", "message", callback)
    );
    set { }
}
```

Or for APIs that use `on` and `off` instead of `addEventListener`/`removeEventListener`:

```csharp
public ActionEvent<string> OnData
{
    get => new ActionEvent<string>(
        (callback) => JSRef!.CallVoid("on", "data", callback),
        (callback) => JSRef!.CallVoid("off", "data", callback)
    );
    set { }
}
```

---

## The += and -= Operators

```csharp
using var videoEl = (HTMLVideoElement)videoRef;

// Subscribe
videoEl.OnLoadedMetadata += VideoEl_OnLoadedMetadata;
videoEl.OnError += VideoEl_OnError;
videoEl.OnAbort += VideoEl_OnAbort;

// ... use the element ...

// ALWAYS unsubscribe before disposing
videoEl.OnLoadedMetadata -= VideoEl_OnLoadedMetadata;
videoEl.OnError -= VideoEl_OnError;
videoEl.OnAbort -= VideoEl_OnAbort;

videoEl.Dispose();
```

---

## Optional Parameters

Event handler parameters are optional, just like in JavaScript. If you do not need the event arguments, you can omit them entirely. This improves performance because unused arguments are not deserialized from JavaScript.

```csharp
// Full event arguments
void Window_OnStorage(StorageEvent e)
{
    Console.WriteLine($"Key: {e.Key}, NewValue: {e.NewValue}");
}

// No arguments - still works with ActionEvent<StorageEvent>
void Window_OnStorage()
{
    Console.WriteLine("Storage changed");
}

// Both are valid for:
window.OnStorage += Window_OnStorage;
```

---

## On() and Off() Methods

`ActionEvent` also provides `On` and `Off` methods as an alternative to `+=` and `-=`. These methods support attaching handlers with different parameter signatures.

```csharp
using var window = JS.Get<Window>("window");

// Attach with On
window.OnStorage.On(Window_OnStorage);

// Detach with Off
window.OnStorage.Off(Window_OnStorage);

void Window_OnStorage()
{
    Console.WriteLine("Storage changed");
}
```

---

## Reference Counting

The Callback reference count is for the **delegate** and has nothing to do with which JSObject or event it is used with. Every `+=` increments the ref count for that delegate; every `-=` decrements it. When it reaches 0, the Callback is disposed. The same delegate used across different events on different objects still shares one Callback:

```csharp
// First += creates the Callback with RefCount = 1
window.OnOnline += HandleNetworkChange;

// Second += on a DIFFERENT event, same delegate - RefCount = 2
window.OnOffline += HandleNetworkChange;

// Third += on a DIFFERENT object, same delegate - RefCount = 3
using var document = JS.Get<Document>("document");
document.OnVisibilityChange += HandleNetworkChange;

// -= from any object decrements - RefCount = 2
document.OnVisibilityChange -= HandleNetworkChange;

// RefCount = 1
window.OnOnline -= HandleNetworkChange;

// RefCount = 0 - Callback is disposed
window.OnOffline -= HandleNetworkChange;
```

**Every `+=` MUST have a matching `-=`.** The total number of `+=` and `-=` calls must balance for each delegate. It does not matter which JSObject you use for `-=` - any reference to the same underlying JS object will work. Failing to balance leaks the Callback and the .NET object reference, and can cause calls into disposed objects that trigger Blazor error UI.

---

## FuncEvent

`FuncEvent` works identically to `ActionEvent` but supports `Func` delegates that return a value to JavaScript. Use this when the JavaScript event handler is expected to return something.

```csharp
// FuncEvent property pattern
public FuncEvent<BeforeUnloadEvent, string?> OnBeforeUnload
{
    get => new FuncEvent<BeforeUnloadEvent, string?>("beforeunload", AddEventListener, RemoveEventListener);
    set { }
}

// Usage
window.OnBeforeUnload += Window_OnBeforeUnload;

string? Window_OnBeforeUnload(BeforeUnloadEvent e)
{
    return "Are you sure you want to leave?";
}
```

---

## Named Methods vs Lambdas

Every `+=` creates an underlying `Callback` that is reference-counted by the delegate instance you pass in. To properly dispose that `Callback`, you must `-=` with the **same delegate instance**. This has an important consequence:

**Named methods** - can be unsubscribed because the same method reference is used for both `+=` and `-=`:
```csharp
ws.OnMessage += HandleMessage;   // creates Callback, ref count = 1
ws.OnMessage -= HandleMessage;   // same delegate - ref count = 0, Callback disposed

void HandleMessage(MessageEvent e) { /* ... */ }
```

**Lambdas** - cannot be unsubscribed because each lambda expression creates a new delegate instance:
```csharp
ws.OnMessage += (e) => Console.WriteLine(e.Data);   // creates Callback
ws.OnMessage -= (e) => Console.WriteLine(e.Data);   // DIFFERENT delegate - does nothing!
// The original Callback is now leaked - it can never be disposed
```

**When lambdas are OK:** If the event subscription lives for the entire lifetime of the application and never needs to be removed, a lambda is fine - the `Callback` will be cleaned up when the app exits. This is common for global event handlers set up once in `Program.cs` or long-lived singleton services.

**When named methods are required:** Any time you need to unsubscribe - components that dispose, short-lived objects, anything with a cleanup lifecycle. This is the more common case.

---

## How It Works Under the Hood

Understanding the internals helps you use ActionEvent correctly:

1. **`CallbackRef` is static.** All ActionEvent/FuncEvent instances share a single static `CallbackRef` that tracks Callbacks in a `Dictionary<Delegate, Callback>`, keyed by the delegate (your method).

2. **`+=` calls `CallbackRef.RefAdd(delegate)`** - looks up your delegate in the static dictionary. If found, increments `RefCount`. If not, creates a new `Callback` and stores it. Then calls `addEventListener` on the JS object.

3. **`-=` calls `CallbackRef.RefGet(delegate)` then `RefDel(delegate)`** - looks up your delegate in the same static dictionary, calls `removeEventListener` on the JS object, and decrements `RefCount`. When `RefCount` reaches 0, the `Callback` is disposed.

**Key insight:** The Callback reference count is purely about the **delegate** and has nothing to do with the JSObject it is used with. The JSObject is just a handle used to call `addEventListener`/`removeEventListener` on the underlying JavaScript object. This means:

- The `-=` does not need to happen on the same JSObject instance. Any reference to the same underlying JS object will work for calling `removeEventListener`.
- What matters for Callback disposal is that the total number of `-=` calls matches the total number of `+=` calls for that delegate.
- Disposing the JSObject does NOT automatically unsubscribe events or dispose Callbacks. The Callback lives in the static dictionary independently.

```csharp
using var window1 = JS.Get<Window>("window");
window1.OnResize += HandleResize;
window1.Dispose(); // The Callback is still alive in the static dictionary

// Later, get a new reference to the same JS window object
using var window2 = JS.Get<Window>("window");
window2.OnResize -= HandleResize; // This works! Same delegate = same Callback found and disposed

void HandleResize() => Console.WriteLine("Resized");
```

---

## Proper Disposal Pattern

Unsubscribe from events to dispose their underlying Callbacks. This can be done from any JSObject reference to the same underlying JavaScript object - it does not have to be the same JSObject instance you used for `+=`:

```csharp
@implements IDisposable

@code {
    HTMLVideoElement? videoEl;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            videoEl = (HTMLVideoElement)videoRef;
            videoEl.OnLoadedMetadata += VideoEl_OnLoadedMetadata;
            videoEl.OnAbort += VideoEl_OnAbort;
            videoEl.OnError += VideoEl_OnError;
        }
    }

    void VideoEl_OnLoadedMetadata()
    {
        Console.WriteLine($"Metadata loaded: {videoEl!.VideoWidth}x{videoEl!.VideoHeight}");
        StateHasChanged();
    }

    void VideoEl_OnAbort() { /* handle abort */ }
    void VideoEl_OnError() { /* handle error */ }

    public void Dispose()
    {
        if (videoEl != null)
        {
            // ALWAYS unsubscribe first
            videoEl.OnLoadedMetadata -= VideoEl_OnLoadedMetadata;
            videoEl.OnAbort -= VideoEl_OnAbort;
            videoEl.OnError -= VideoEl_OnError;

            // Then dispose
            videoEl.Dispose();
            videoEl = null;
        }
    }
}
```

---

## Implementing Events in Your Own Wrappers

Complete example for a WebSocket wrapper:

```csharp
public class WebSocket : EventTarget
{
    public WebSocket(IJSInProcessObjectReference _ref) : base(_ref) { }
    public WebSocket(string url) : base(JS.New("WebSocket", url)) { }

    // Events using ActionEvent pattern
    public ActionEvent OnOpen
    {
        get => new ActionEvent("open", AddEventListener, RemoveEventListener);
        set { }
    }

    public ActionEvent<CloseEvent> OnClose
    {
        get => new ActionEvent<CloseEvent>("close", AddEventListener, RemoveEventListener);
        set { }
    }

    public ActionEvent<MessageEvent> OnMessage
    {
        get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener);
        set { }
    }

    public ActionEvent<Event> OnError
    {
        get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener);
        set { }
    }

    // Methods
    public void Send(string data) => JSRef!.CallVoid("send", data);
    public void Send(ArrayBuffer data) => JSRef!.CallVoid("send", data);
    public void Close(int? code = null, string? reason = null)
    {
        if (code == null) JSRef!.CallVoid("close");
        else if (reason == null) JSRef!.CallVoid("close", code);
        else JSRef!.CallVoid("close", code, reason);
    }

    // Properties
    public int ReadyState => JSRef!.Get<int>("readyState");
    public string Url => JSRef!.Get<string>("url");
}
```

---

## See Also

- [Callbacks](callbacks.md) - Lower-level callback creation
- [JSObject](jsobject.md) - Base wrapper class
- [Disposal and Lifetime](disposal.md) - Full disposal guide

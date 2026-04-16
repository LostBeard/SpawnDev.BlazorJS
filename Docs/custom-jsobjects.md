# Custom JSObject Wrappers

This guide walks through building your own JSObject wrappers to use JavaScript libraries from Blazor without writing any JavaScript code.

---

## When to Build a Custom Wrapper

SpawnDev.BlazorJS includes 1,014 wrappers for standard browser APIs. Build a custom wrapper when you need to use:

- A third-party JavaScript library (Socket.IO, Three.js, PixiJS, SimplePeer, etc.)
- A custom JavaScript class from your own code
- A browser API not yet included in SpawnDev.BlazorJS

---

## Step-by-Step Guide

### Step 1: Identify the JavaScript API

Start by reading the documentation for the JavaScript library or API you want to wrap. Identify:

- The global constructor name (e.g., `Audio`, `WebSocket`, `io`)
- Properties (read-only and read-write)
- Methods (synchronous and asynchronous/Promise-returning)
- Events (what events are fired, what data they carry)

### Step 2: Create the Class

Inherit from `JSObject` or an appropriate parent (like `EventTarget` if the object dispatches events):

```csharp
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;

public class Audio : HTMLMediaElement
{
    // ...
}
```

### Step 3: Add the Deserialization Constructor (REQUIRED)

Every JSObject wrapper MUST have this constructor:

```csharp
public class Audio : HTMLMediaElement
{
    // REQUIRED - called by the interop system when deserializing JS objects
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
}
```

Without it, the type cannot be used as a return type from `Get<T>()`, `Call<T>()`, or `CallAsync<T>()`.

### Step 4: Add Creation Constructors (Optional)

Add constructors that create new JavaScript objects:

```csharp
public class Audio : HTMLMediaElement
{
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Creates: new Audio(url)
    public Audio(string url) : base(JS.New("Audio", url)) { }

    // Creates: new Audio()
    public Audio() : base(JS.New("Audio")) { }
}
```

The `JS` property is a protected static property inherited from `JSObject` that references the singleton `BlazorJSRuntime`.

### Step 5: Map Properties

Use `JSRef!.Get<T>()` and `JSRef!.Set()` to map properties:

```csharp
// Read-only property
public double Duration => JSRef!.Get<double>("duration");

// Read-write property
public double Volume
{
    get => JSRef!.Get<double>("volume");
    set => JSRef!.Set("volume", value);
}

// Nullable property
public double? CurrentTime => JSRef!.Get<double?>("currentTime");

// Property returning another JSObject (caller is responsible for disposal)
public AudioTrackList AudioTracks => JSRef!.Get<AudioTrackList>("audioTracks");

// String property
public string Src
{
    get => JSRef!.Get<string>("src");
    set => JSRef!.Set("src", value);
}
```

### Step 6: Map Methods

Use `JSRef!.Call<T>()`, `JSRef!.CallVoid()`, and `JSRef!.CallAsync<T>()`:

```csharp
// Synchronous void method
public void Play() => JSRef!.CallVoid("play");
public void Pause() => JSRef!.CallVoid("pause");

// Synchronous method with return value
public string CanPlayType(string type) => JSRef!.Call<string>("canPlayType", type);

// Async method (JS method returns a Promise)
public Task<MediaStream> CaptureStream() => JSRef!.CallAsync<MediaStream>("captureStream");

// Method with parameters
public void SetAttribute(string name, string value) => JSRef!.CallVoid("setAttribute", name, value);
public string GetAttribute(string name) => JSRef!.Call<string>("getAttribute", name);
```

### Step 7: Map Events

Use the `ActionEvent` pattern. If your class inherits from `EventTarget`, you have `AddEventListener` and `RemoveEventListener` available:

```csharp
// For classes that inherit from EventTarget
public ActionEvent OnPlay
{
    get => new ActionEvent("play", AddEventListener, RemoveEventListener);
    set { }
}

public ActionEvent<ErrorEvent> OnError
{
    get => new ActionEvent<ErrorEvent>("error", AddEventListener, RemoveEventListener);
    set { }
}

public ActionEvent OnEnded
{
    get => new ActionEvent("ended", AddEventListener, RemoveEventListener);
    set { }
}
```

For classes that do NOT inherit from `EventTarget` (e.g., they use `on`/`off` methods):

```csharp
// Socket.IO-style events
public ActionEvent<string> OnData
{
    get => new ActionEvent<string>(
        (cb) => JSRef!.CallVoid("on", "data", cb),
        (cb) => JSRef!.CallVoid("off", "data", cb)
    );
    set { }
}
```

### Step 8: Handle Disposal

`JSObject` has a finalizer, but always prefer explicit disposal:

```csharp
// Users of your wrapper should dispose it:
using var audio = new Audio("song.mp3");
audio.Play();
// Disposed at end of scope
```

If your wrapper needs to clean up additional resources, override `Dispose(bool)`:

```csharp
protected override void Dispose(bool disposing)
{
    if (disposing)
    {
        // Clean up managed resources
    }
    base.Dispose(disposing);
}
```

---

## Loading JavaScript Libraries

If your wrapper depends on a third-party JS library, load it before use:

```csharp
public class MyLibraryWrapper : JSObject
{
    private static bool _loaded = false;

    public MyLibraryWrapper(IJSInProcessObjectReference _ref) : base(_ref) { }

    public static async Task<MyLibraryWrapper> CreateAsync(string config)
    {
        if (!_loaded)
        {
            await JS.LoadScript("_content/MyPackage/my-library.min.js");
            _loaded = true;
        }
        return JS.New<MyLibraryWrapper>("MyLibrary", config);
    }
}
```

Or load in `Program.cs`:

```csharp
builder.Services.AddBlazorJSRuntime(out var JS);
if (JS.IsWindow)
{
    await JS.LoadScript("https://cdn.example.com/library.js");
}
```

---

## Complete Example: Audio Wrapper

```csharp
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Audio class wraps the HTML Audio element.
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement
    /// </summary>
    public class Audio : HTMLMediaElement
    {
        // Required deserialization constructor
        public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }

        // Creation constructor
        public Audio(string url) : base(JS.New("Audio", url)) { }
        public Audio() : base(JS.New("Audio")) { }

        // Properties
        public double Duration => JSRef!.Get<double>("duration");
        public double CurrentTime
        {
            get => JSRef!.Get<double>("currentTime");
            set => JSRef!.Set("currentTime", value);
        }
        public double Volume
        {
            get => JSRef!.Get<double>("volume");
            set => JSRef!.Set("volume", value);
        }
        public bool Paused => JSRef!.Get<bool>("paused");
        public bool Ended => JSRef!.Get<bool>("ended");
        public bool Loop
        {
            get => JSRef!.Get<bool>("loop");
            set => JSRef!.Set("loop", value);
        }

        // Methods
        public void Play() => JSRef!.CallVoid("play");
        public void Pause() => JSRef!.CallVoid("pause");
        public void Load() => JSRef!.CallVoid("load");

        // Events (inherited from HTMLMediaElement via EventTarget)
        public ActionEvent OnPlay
        {
            get => new ActionEvent("play", AddEventListener, RemoveEventListener);
            set { }
        }
        public ActionEvent OnPause
        {
            get => new ActionEvent("pause", AddEventListener, RemoveEventListener);
            set { }
        }
        public ActionEvent OnEnded
        {
            get => new ActionEvent("ended", AddEventListener, RemoveEventListener);
            set { }
        }
        public ActionEvent OnTimeUpdate
        {
            get => new ActionEvent("timeupdate", AddEventListener, RemoveEventListener);
            set { }
        }
    }
}
```

Usage:

```csharp
// Use a named method - lambdas cannot be properly unsubscribed
void OnSongEnded() => Console.WriteLine("Song finished!");

using var audio = new Audio("https://example.com/song.mp3");
audio.Volume = 0.8;
audio.OnEnded += OnSongEnded;
await audio.Play();

// Always unsubscribe before disposing to prevent callback leaks
audio.OnEnded -= OnSongEnded;
```

---

## Complete Example: Socket.IO Wrapper (Non-EventTarget)

```csharp
using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

public class Socket : JSObject
{
    public Socket(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Properties
    public string Id => JSRef!.Get<string>("id");
    public bool Connected => JSRef!.Get<bool>("connected");

    // Methods
    public void Emit(string eventName, params object[] args)
        => JSRef!.CallVoid("emit", new object[] { eventName }.Concat(args).ToArray());

    public void Disconnect() => JSRef!.CallVoid("disconnect");
    public void Connect() => JSRef!.CallVoid("connect");

    // Events (Socket.IO uses .on/.off, not addEventListener)
    public ActionEvent OnConnect
    {
        get => new ActionEvent(
            (cb) => JSRef!.CallVoid("on", "connect", cb),
            (cb) => JSRef!.CallVoid("off", "connect", cb)
        );
        set { }
    }

    public ActionEvent OnDisconnect
    {
        get => new ActionEvent(
            (cb) => JSRef!.CallVoid("on", "disconnect", cb),
            (cb) => JSRef!.CallVoid("off", "disconnect", cb)
        );
        set { }
    }

    public ActionEvent<string> OnMessage
    {
        get => new ActionEvent<string>(
            (cb) => JSRef!.CallVoid("on", "message", cb),
            (cb) => JSRef!.CallVoid("off", "message", cb)
        );
        set { }
    }
}

// Factory for creating Socket.IO connections
public static class SocketIO
{
    private static bool _loaded = false;

    public static async Task<Socket> ConnectAsync(string url)
    {
        if (!_loaded)
        {
            await BlazorJSRuntime.JS.LoadScript(
                "https://cdn.socket.io/4.7.4/socket.io.min.js");
            _loaded = true;
        }
        return BlazorJSRuntime.JS.Call<Socket>("io", url);
    }
}
```

---

## Tips

1. **Always check MDN** for the JavaScript API you are wrapping. Match property types, method signatures, and event names exactly.
2. **Use the correct call type** - `Call<T>` for sync, `CallAsync<T>` for Promise-returning methods.
3. **Return JSObject types** from properties/methods that return JS objects. The caller is responsible for disposal.
4. **Use nullable types** (`int?`, `string?`) for properties that can be null or undefined in JavaScript.
5. **Test your wrapper** with the actual JS library in a Blazor WASM project before publishing.

---

## See Also

- [JSObject](jsobject.md) - Base class reference
- [Events (ActionEvent / FuncEvent)](events.md) - Event pattern
- [Callbacks](callbacks.md) - Passing .NET methods to JS
- [BlazorJSRuntime](blazorjsruntime.md) - Global interop service

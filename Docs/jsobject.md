# JSObject

`JSObject` is the base class for all 1,014 typed JavaScript wrappers in SpawnDev.BlazorJS. It wraps an `IJSInProcessObjectReference` and provides strongly typed access to JavaScript object properties, methods, and events.

**Namespace:** `SpawnDev.BlazorJS`

---

## How JSObject Works

Every `JSObject` holds a reference to a JavaScript object via `IJSInProcessObjectReference` (stored in the `JSRef` property). When you call methods like `Get<T>()` or `CallVoid()` on `JSRef`, they invoke the corresponding JavaScript operations on the underlying object. When the `JSObject` is disposed, the JavaScript reference is released.

```
C# JSObject (Window)
    |
    +-- JSRef: IJSInProcessObjectReference -> JS: window
         |
         +-- .Get<string>("name")      -> window.name
         +-- .CallVoid("alert", "Hi")  -> window.alert("Hi")
         +-- .Set("name", "foo")       -> window.name = "foo"
```

---

## The Deserialization Constructor (REQUIRED)

Every class that inherits from `JSObject` **must** have a constructor that takes a single `IJSInProcessObjectReference` parameter. This is the deserialization constructor - it is called by the interop system when a JavaScript object is being returned to .NET.

```csharp
public class MyWrapper : JSObject
{
    // REQUIRED - the interop system calls this when deserializing JS objects to C#
    public MyWrapper(IJSInProcessObjectReference _ref) : base(_ref) { }
}
```

Without this constructor, the wrapper cannot be used as a return type from `Get<T>()`, `Call<T>()`, or `CallAsync<T>()`.

---

## The Creation Constructor (Optional)

Optionally, add constructors that create new JavaScript objects by calling `JS.New()`:

```csharp
public class Audio : JSObject
{
    // Deserialization constructor (required)
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Creation constructor - creates new Audio("url")
    public Audio(string url) : base(JS.New("Audio", url)) { }
}
```

The `JS` property used here is a protected static property on `JSObject` that refers to the singleton `BlazorJSRuntime` instance.

---

## JSRef Property

`JSRef` is the underlying `IJSInProcessObjectReference` that points to the JavaScript object:

```csharp
public class Window : EventTarget
{
    public Window(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Use JSRef to access JS properties and methods
    public string? Name
    {
        get => JSRef!.Get<string>("name");
        set => JSRef!.Set("name", value);
    }

    public void Alert(string message) => JSRef!.CallVoid("alert", message);
}
```

`JSRef` is `null` after disposal. The `!` null-forgiving operator is used because in normal usage JSRef is non-null.

---

## Mapping Properties

Map JavaScript properties to C# properties using `Get<T>` and `Set`:

```csharp
public class HTMLVideoElement : HTMLMediaElement
{
    public HTMLVideoElement(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Read-write property
    public int VideoWidth => JSRef!.Get<int>("videoWidth");
    public int VideoHeight => JSRef!.Get<int>("videoHeight");

    // Read-write string property
    public string Src
    {
        get => JSRef!.Get<string>("src");
        set => JSRef!.Set("src", value);
    }

    // Nullable property
    public double? Duration => JSRef!.Get<double?>("duration");

    // Property returning another JSObject (caller must dispose)
    public VideoPlaybackQuality GetVideoPlaybackQuality()
        => JSRef!.Call<VideoPlaybackQuality>("getVideoPlaybackQuality");
}
```

---

## Mapping Methods

Map JavaScript methods using `Call<T>`, `CallVoid`, and `CallAsync<T>`:

```csharp
public class Storage : JSObject
{
    public Storage(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Synchronous methods
    public string? GetItem(string key) => JSRef!.Call<string?>("getItem", key);
    public void SetItem(string key, string value) => JSRef!.CallVoid("setItem", key, value);
    public void RemoveItem(string key) => JSRef!.CallVoid("removeItem", key);
    public void Clear() => JSRef!.CallVoid("clear");
    public int Length => JSRef!.Get<int>("length");
}

public class MediaDevices : EventTarget
{
    public MediaDevices(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Async methods (Promise-returning in JS)
    public Task<MediaStream> GetUserMedia(object constraints)
        => JSRef!.CallAsync<MediaStream>("getUserMedia", constraints);

    public Task<MediaDeviceInfo[]> EnumerateDevices()
        => JSRef!.CallAsync<MediaDeviceInfo[]>("enumerateDevices");
}
```

---

## Mapping Events

Use the `ActionEvent` pattern to expose JavaScript events with `+=` and `-=` operators:

```csharp
public class Window : EventTarget
{
    public Window(IJSInProcessObjectReference _ref) : base(_ref) { }

    // ActionEvent pattern - the set { } is required for the += operator to work
    public ActionEvent<StorageEvent> OnStorage
    {
        get => new ActionEvent<StorageEvent>("storage", AddEventListener, RemoveEventListener);
        set { }
    }

    public ActionEvent OnOnline
    {
        get => new ActionEvent("online", AddEventListener, RemoveEventListener);
        set { }
    }

    public ActionEvent OnOffline
    {
        get => new ActionEvent("offline", AddEventListener, RemoveEventListener);
        set { }
    }
}
```

See [Events (ActionEvent / FuncEvent)](events.md) for full details.

---

## Disposal

`JSObject` implements `IDisposable` and has a finalizer. The finalizer will clean up the underlying `IJSInProcessObjectReference`, but you should always dispose explicitly:

```csharp
// Using statement (preferred)
using var window = JS.Get<Window>("window");
window.Alert("Hello!");
// window is disposed at end of scope

// Explicit disposal
var doc = JS.Get<Document>("document");
var title = doc.Title;
doc.Dispose();
```

The `IsWrapperDisposed` property indicates whether the wrapper has been disposed.

---

## Type Casting and Conversion

### JSRefAs\<T\>() / JSRefCopy\<T\>()

Returns a copy of the reference as type `T`. The original `JSObject` remains valid. Both methods are synonyms.

```csharp
using var eventTarget = JS.Get<EventTarget>("myElement");
using var element = eventTarget.JSRefAs<HTMLElement>();
// Both eventTarget and element point to the same JS object
// Both must be disposed
```

### JSRefMove\<T\>()

Moves the reference to type `T` and disposes the original wrapper. Use this when you want to convert a type without keeping the original.

```csharp
using var element = eventTarget.JSRefMove<HTMLElement>();
// eventTarget is now disposed - do not use it
// element owns the reference
```

### JSRefMove()

Returns the raw `IJSInProcessObjectReference` and disposes the wrapper:

```csharp
IJSInProcessObjectReference? rawRef = myJSObject.JSRefMove();
// myJSObject is disposed, you own rawRef and must dispose it yourself
```

### JSRefCopy()

Returns a copy of the `IJSInProcessObjectReference`:

```csharp
IJSInProcessObjectReference copy = myJSObject.JSRefCopy();
// myJSObject still valid, copy must be disposed separately
```

### JSRefIs\<T\>() - Type Testing

Test if a JSObject is of a specific JavaScript type:

```csharp
// Test by type name
if (myObj.JSRefIs<HTMLCanvasElement>())
{
    // The JS object's constructor.name == "HTMLCanvasElement"
}

// Test and convert in one step
if (myObj.JSRefIs<HTMLCanvasElement>(out HTMLCanvasElement canvas))
{
    canvas.Width = 800;
    canvas.Dispose();
}

// Test with custom constructor name
if (myObj.JSRefIs<JSObject>("MyCustomClass", out JSObject custom))
{
    // ...
}
```

### JSEquals(object? obj2, bool full = false)

Compare using JavaScript equality:

```csharp
bool equal = obj1.JSEquals(obj2);        // JS ==
bool strictEqual = obj1.JSEquals(obj2, true); // JS ===
```

---

## JSObject.Undefined\<T\>()

Creates an instance of type `T` that will be serialized to JavaScript as `undefined`:

```csharp
var undefinedWindow = JSObject.Undefined<Window>();
JS.Set("_undefinedWindow", undefinedWindow);
var isUndef = JS.IsUndefined("_undefinedWindow");
// isUndef == true
```

The generic `JSObject<T>` class provides a static `Undefined` property:

```csharp
// Equivalent to JSObject.Undefined<Window>()
var undef = JSObject<Window>.Undefined;
```

---

## The Static JS Property

All `JSObject` subclasses inherit a protected static `JS` property:

```csharp
protected static BlazorJSRuntime JS => BlazorJSRuntime.JS;
```

This lets constructors and static methods access the runtime without injection:

```csharp
public class IDBFactory : JSObject
{
    public IDBFactory(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Use JS.Get to create from a global property
    public IDBFactory() : base(JS.Get<IJSInProcessObjectReference>("indexedDB")) { }
}
```

---

## Inheritance Chains

JSObject wrappers follow the same inheritance hierarchy as their JavaScript counterparts:

```
JSObject
  -> EventTarget
       -> Node
            -> Element
                 -> HTMLElement
                      -> HTMLMediaElement
                           -> HTMLVideoElement
                           -> HTMLAudioElement
                      -> HTMLCanvasElement
                      -> HTMLInputElement
       -> Window
       -> Worker
       -> WebSocket
       -> RTCPeerConnection
       -> AudioNode
            -> GainNode
            -> AnalyserNode
            -> OscillatorNode
```

This means an `HTMLVideoElement` has access to all methods and events from `HTMLMediaElement`, `HTMLElement`, `Element`, `Node`, `EventTarget`, and `JSObject`.

---

## Building Custom Wrappers

### Step-by-Step: Wrapping a Third-Party JS Library

Here is a complete example wrapping a simple JS library (Audio):

```csharp
public class Audio : HTMLMediaElement
{
    // Step 1: Deserialization constructor (required)
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Step 2: Creation constructor
    public Audio(string url) : base(JS.New("Audio", url)) { }

    // Step 3: Map methods
    public void Play() => JSRef!.CallVoid("play");
    public void Pause() => JSRef!.CallVoid("pause");

    // Step 4: Map properties
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
}

// Usage:
var audio = new Audio("https://example.com/song.mp3");
audio.Volume = 0.5;
audio.Play();
```

For a more complex example with events and library loading, see [Custom JSObject Wrappers](custom-jsobjects.md).

---

## See Also

- [BlazorJSRuntime](blazorjsruntime.md)
- [Events (ActionEvent / FuncEvent)](events.md)
- [Custom JSObject Wrappers](custom-jsobjects.md)
- [Disposal and Lifetime](disposal.md)

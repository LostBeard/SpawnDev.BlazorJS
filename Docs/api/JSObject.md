# JSObject

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** JSObject  
**Source:** `SpawnDev.BlazorJS/JSObject.cs`

> JSObject is the base class for all typed JavaScript object wrappers in SpawnDev.BlazorJS. It wraps an `IJSInProcessObjectReference` and provides lifecycle management (IDisposable with finalizer), type conversion, and identity checking. Every browser API wrapper in the library (Window, Document, HTMLCanvasElement, etc.) inherits from JSObject. Custom wrappers for JS libraries should also extend JSObject.

## Constructor

```csharp
// Deserialization constructor - REQUIRED for all subclasses
public JSObject(IJSInProcessObjectReference _ref)
```

Every class that inherits from JSObject **must** have a constructor that accepts `IJSInProcessObjectReference`. This is used by the interop system during deserialization.

## Properties

| Property | Type | Description |
|---|---|---|
| `JSRef` | `IJSInProcessObjectReference?` | The underlying JavaScript object reference. Null after disposal. |
| `IsWrapperDisposed` | `bool` | True if the wrapper has been disposed and JSRef released. |
| `IsJSRefUndefined` | `bool` | True if the underlying JSRef is a JSInProcessObjectReferenceUndefined (sentinel for JS `undefined`). |

## Static Properties

| Property | Type | Description |
|---|---|---|
| `JS` | `BlazorJSRuntime` | Shortcut to `BlazorJSRuntime.JS`. Available in all subclasses via `protected static`. |
| `UndefinedRef` | `JSInProcessObjectReferenceUndefined?` | Static sentinel instance representing JS `undefined`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `JSRefMove<T>()` | `T` | Convert to type T and dispose this wrapper. If T is a JSObject, the reference is moved (not copied). |
| `JSRefMove()` | `IJSInProcessObjectReference?` | Extract the raw reference and dispose this wrapper. The caller takes ownership of the reference. |
| `JSRefCopy<T>()` | `T` | Return this object as type T. The reference is copied - both this and the new object remain valid. |
| `JSRefCopy()` | `IJSInProcessObjectReference` | Return a copy of the underlying IJSInProcessObjectReference. |
| `JSRefAs<T>()` | `T` | Synonym for JSRefCopy<T>. Returns this object as type T (copy semantics). |
| `JSRefIs<T>()` | `bool` | Returns true if the JS object's `constructor.name` matches `typeof(T).Name`. |
| `JSRefIs(string constructorName)` | `bool` | Returns true if the JS object's `constructor.name` matches the given string. |
| `JSRefIs<T>(out T value, bool moveJSRef = false)` | `bool` | If constructor name matches T, outputs the value as T and returns true. Optionally moves the ref. |
| `JSRefIs<T>(string constructorName, out T value, bool moveJSRef = false)` | `bool` | If constructor name matches, outputs the value and returns true. |
| `JSEquals(object? obj2, bool full = false)` | `bool` | JavaScript equality check. `full=true` uses `===`, `full=false` uses `==`. |
| `Dispose()` | `void` | Release the IJSInProcessObjectReference and suppress the finalizer. |

## Generic Variant: JSObject&lt;T&gt;

```csharp
public class JSObject<T> : JSObject where T : JSObject
```

Adds a static `Undefined` property that returns a singleton instance of T wrapping the undefined sentinel reference.

| Property | Type | Description |
|---|---|---|
| `Undefined` | `T` | Static singleton instance representing an undefined JSObject of type T. |

## Example - Creating a Custom Wrapper

```csharp
public class MyJSLibrary : JSObject
{
    // REQUIRED - deserialization constructor
    public MyJSLibrary(IJSInProcessObjectReference _ref) : base(_ref) { }

    // Constructor that creates a new JS object
    public MyJSLibrary(string config) : base(JS.New("MyJSLibrary", config)) { }

    // Properties map to JS properties
    public string Name
    {
        get => JSRef!.Get<string>("name");
        set => JSRef!.Set("name", value);
    }

    public bool IsReady => JSRef!.Get<bool>("isReady");

    // Synchronous methods
    public void Start() => JSRef!.CallVoid("start");
    public int GetCount() => JSRef!.Call<int>("getCount");

    // Async methods (for Promise-returning JS methods)
    public Task<string> FetchData() => JSRef!.CallAsync<string>("fetchData");

    // Events using ActionEvent pattern
    public ActionEvent<Event> OnReady
    {
        get => new ActionEvent<Event>("ready", AddEventListener, RemoveEventListener);
        set { }
    }
}
```

## Example - Using JSRefMove and JSRefCopy

```csharp
// JSRefMove transfers ownership - original is disposed
using var blob = await response.Blob();
var arrayBuffer = blob.JSRefMove<ArrayBuffer>(); // blob is now disposed
// ... use arrayBuffer ...
arrayBuffer.Dispose();

// JSRefCopy creates a shared reference - both remain valid
using var element = document.QuerySelector("#myDiv");
using var asNode = element.JSRefCopy<Node>(); // both element and asNode are valid

// JSRefIs for type checking
using var obj = JS.Get<JSObject>("someValue");
if (obj.JSRefIs<HTMLCanvasElement>(out var canvas))
{
    // canvas is the same ref, typed as HTMLCanvasElement
    var width = canvas.Width;
    canvas.Dispose();
}
```

## Example - Proper Disposal

```csharp
// Using statement (preferred)
using var doc = JS.Get<Document>("document");
var title = doc.Title;

// Explicit dispose
var window = JS.Get<Window>("window");
try
{
    var height = window.InnerHeight;
}
finally
{
    window.Dispose();
}

// FluentUsing pattern
JS.Get<Document>("document").Using(doc =>
{
    var title = doc.Title;
}); // doc is automatically disposed here
```

## Important Notes

- **Always dispose JSObjects** when done. While they have a finalizer, relying on GC for disposal is bad practice and can lead to JS reference leaks.
- **JSRef is null after disposal.** Accessing JSRef on a disposed wrapper throws ObjectDisposedException.
- The `FromReference` virtual method can be overridden in subclasses to perform post-deserialization initialization (e.g., attaching event listeners).
- In DEBUG builds, the static `OnJSObjectCreated` event fires whenever a JSObject is created - useful for tracking reference leaks.

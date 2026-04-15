# Disposal and Lifetime

Proper disposal is critical in SpawnDev.BlazorJS. JavaScript object references, callbacks, and event subscriptions consume memory on both the .NET and JavaScript sides. This guide covers the disposal rules for every disposable type in the library.

---

## Quick Reference

| Type | Has Finalizer? | Must Dispose? | What Happens If Not Disposed |
|---|---|---|---|
| `JSObject` | Yes | Should (best practice) | Finalizer cleans up, but timing is unpredictable |
| `Callback` | No | YES (unless `CreateOne`) | Leaks .NET object reference permanently |
| `IJSInProcessObjectReference` | No | YES | Leaks JavaScript reference permanently |
| `CallbackGroup` | N/A | Yes | Leaks all contained Callbacks |
| `ActionEvent` (+=) | N/A | MUST -= before parent disposal | Leaks Callback and can call into disposed objects |

---

## JSObject Disposal

`JSObject` implements `IDisposable` and has a finalizer. The finalizer will eventually clean up the underlying `IJSInProcessObjectReference`, but relying on it is bad practice - the GC timing is unpredictable.

### Using Statement (Preferred)

```csharp
// Disposed at end of scope
using var window = JS.Get<Window>("window");
var height = window.InnerHeight;

// Multiple objects
using var document = JS.Get<Document>("document");
using var body = document.Body;
```

### Explicit Dispose

```csharp
var window = JS.Get<Window>("window");
try
{
    var height = window.InnerHeight;
}
finally
{
    window.Dispose();
}
```

### Component Lifecycle

```csharp
@implements IDisposable

@code {
    HTMLVideoElement? videoEl;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            videoEl = (HTMLVideoElement)videoRef;
            videoEl.OnLoadedMetadata += OnMetadata;
        }
    }

    public void Dispose()
    {
        if (videoEl != null)
        {
            videoEl.OnLoadedMetadata -= OnMetadata;  // -= FIRST
            videoEl.Dispose();                         // Dispose SECOND
            videoEl = null;
        }
    }

    void OnMetadata() { /* ... */ }
}
```

### Checking Disposal State

```csharp
if (myJSObject.IsWrapperDisposed)
{
    // Object has been disposed - do not use JSRef
}
```

---

## Callback Disposal

Callbacks **do not have finalizers**. If you do not dispose them, they leak permanently.

### Callback.Create - Must Dispose

```csharp
// Create and use
var cb = Callback.Create<string>(msg => Console.WriteLine(msg));
JS.Set("myCallback", cb);

// When done, dispose
cb.Dispose();
```

### Callback.CreateOne - Auto-Disposes

```csharp
// Auto-disposes after first invocation - no manual disposal needed
JS.CallVoid("setTimeout", Callback.CreateOne(() =>
{
    Console.WriteLine("Fired once, auto-disposed");
}), 1000);
```

### CallbackGroup - Batch Disposal

```csharp
using var group = new CallbackGroup();

var cb1 = Callback.Create(() => DoThing1(), group);
var cb2 = Callback.Create<string>(msg => DoThing2(msg), group);
var cb3 = Callback.Create<int, int>((a, b) => a + b, group);

JS.CallVoid("addEventListener", "resize", cb1);
JS.Set("logMessage", cb2);
JS.Set("addNumbers", cb3);

// Later: dispose all at once
group.Dispose();
```

---

## IJSInProcessObjectReference Disposal

Raw `IJSInProcessObjectReference` objects (from `JS.New()`, `JS.Get<IJSInProcessObjectReference>()`, etc.) **do not have a finalizer**. They MUST be explicitly disposed or they leak.

```csharp
// If you get a raw reference, you MUST dispose it
var rawRef = JS.New("Worker", "worker.js");
try
{
    rawRef.CallVoid("postMessage", "hello");
}
finally
{
    rawRef.Dispose();
}

// Better: wrap in a typed JSObject which has a finalizer
using var worker = JS.New<Worker>("Worker", "worker.js");
worker.PostMessage("hello");
```

**Rule:** Prefer typed `JSObject` wrappers over raw `IJSInProcessObjectReference` whenever possible. JSObject has a finalizer as a safety net; raw references do not.

---

## ActionEvent += / -= and Reference Counting

`ActionEvent` uses `CallbackRef` for reference counting. Every `+=` increments the ref count, every `-=` decrements it. The Callback is disposed when the count reaches zero.

```csharp
// RefCount: 0 -> 1
window.OnStorage += HandleStorage;

// RefCount: 1 -> 2 (same handler, different event)
window.OnOnline += HandleStorage;

// RefCount: 2 -> 1
window.OnStorage -= HandleStorage;

// RefCount: 1 -> 0 (Callback disposed)
window.OnOnline -= HandleStorage;
```

**Every `+=` MUST have a matching `-=`.** Unsubscribe BEFORE disposing the parent JSObject.

---

## FluentUsing - Extension Methods

`FluentUsing` provides LINQ-style disposal patterns via extension methods on `IDisposable`, `IDisposable[]`, and `List<IDisposable>`.

### Using\<T\>(Action\<T\>)

Use a disposable object inline:

```csharp
JS.Get<Window>("window").Using(window =>
{
    Console.WriteLine($"Height: {window.InnerHeight}");
});
// window is disposed after the lambda returns
```

### Using\<T, TResult\>(Func\<T, TResult\>)

Use a disposable and return a value:

```csharp
int height = JS.Get<Window>("window").Using(window => window.InnerHeight);
// window is disposed, height is the return value
```

### UsingAsync

Async variants:

```csharp
await JS.Get<Navigator>("navigator").UsingAsync(async nav =>
{
    using var devices = nav.MediaDevices;
    var list = await devices.EnumerateDevices();
    // ...
});
```

### Array Disposal

```csharp
// Dispose all items in an array
JSObject[] items = GetManyObjects();
items.Using(); // disposes all

// Iterate and dispose
items.UsingEach(item =>
{
    Console.WriteLine(item.JSRef!.Get<string>("name"));
});
// All items disposed after iteration

// Filter, keeping some and disposing the rest
var kept = items.UsingWhere(item => item.JSRef!.Get<bool>("active"));
// Non-active items disposed, active items kept (caller must dispose later)

// Find first match, disposing all others
var first = items.UsingFirstOrDefault(item =>
    item.JSRef!.Get<string>("type") == "target");
// All items except the match are disposed
```

### UsingCount

Count items matching a predicate, then dispose all:

```csharp
long activeCount = items.UsingCount<JSObject, long>(item =>
    item.JSRef!.Get<bool>("active"));
// All items are disposed, activeCount holds the result
```

---

## Action/Func DisposeJS()

When passing `Action` or `Func` delegates directly to JavaScript, a `Callback` is auto-created. You must dispose it with the `DisposeJS()` extension method:

```csharp
var handler = () => Console.WriteLine("Fired");

// Auto-creates a Callback
JS.CallVoid("setTimeout", handler, 100);

// Dispose the auto-created Callback
handler.DisposeJS();
```

```csharp
var fn = new Func<int, int>(x => x * 2);

JS.Set("double", fn);
var readFn = JS.Get<Func<int, int>>("double");
var result = readFn(21);  // 42

// Dispose both
readFn.DisposeJS();  // Disposes the JS Function reference
fn.DisposeJS();      // Disposes the Callback
```

---

## Common Pitfalls

### Forgetting to Unsubscribe Events

```csharp
// BUG: Disposing without unsubscribing leaks the callback
// and can cause calls into disposed .NET objects
videoEl.Dispose();  // OnLoadedMetadata callback is still registered!

// CORRECT: Always -= before Dispose
videoEl.OnLoadedMetadata -= OnMetadata;
videoEl.Dispose();
```

### Forgetting to Dispose Raw References

```csharp
// BUG: Raw reference is never disposed - memory leak
var ref1 = JS.Get<IJSInProcessObjectReference>("someObj");
// ... ref1 never disposed

// CORRECT: Always dispose or wrap in JSObject
using var ref2 = JS.Get<IJSInProcessObjectReference>("someObj");
```

### Disposing a JSObject While Events Are Still Subscribed

```csharp
// BUG: Blazor error UI appears because JavaScript tries to
// call into a disposed .NET callback
window.OnStorage += HandleStorage;
window.Dispose();
// Later: storage event fires -> tries to call HandleStorage -> error

// CORRECT:
window.OnStorage -= HandleStorage;
window.Dispose();
```

---

## Worker Service Automatic Disposal

When using `SpawnDev.BlazorJS.WebWorkers`, `IDisposable` objects returned from worker service methods are automatically disposed after the data has been serialized and sent back to the calling thread. This prevents resource leaks in worker contexts where the caller cannot directly dispose the returned objects.

---

## See Also

- [JSObject](jsobject.md) - Base wrapper class
- [Callbacks](callbacks.md) - Callback lifecycle
- [Events (ActionEvent / FuncEvent)](events.md) - Event subscription patterns

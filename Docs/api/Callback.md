# Callback

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** Callback (abstract)  
**Concrete types:** `ActionCallback`, `ActionCallback<T1>` ... `ActionCallback<T1..T7>`, `FuncCallback<TResult>`, `FuncCallback<T1, TResult>` ... `FuncCallback<T1..T7, TResult>`  
**Source:** `SpawnDev.BlazorJS/Callback.cs`

> Callback makes .NET methods callable from plain JavaScript. When a Callback is serialized to JS, it carries a DotNetObjectReference, a unique callback ID, and parameter type metadata that tells the JS interop layer how to marshal arguments. Callbacks are reference-counted and implement IDisposable - they must be disposed when no longer needed to prevent .NET object reference leaks. Async methods that return Task are automatically converted to JS Promises.

## Static Factory Methods - Action (void return)

| Method | Return Type | Description |
|---|---|---|
| `Create(Action callback, CallbackGroup? group = null)` | `ActionCallback` | Create a reusable callback with no parameters. |
| `Create<T1>(Action<T1> callback, CallbackGroup? group = null)` | `ActionCallback<T1>` | Create a reusable callback with 1 parameter. |
| `Create<T1, T2>(Action<T1, T2> callback, ...)` | `ActionCallback<T1, T2>` | Create a reusable callback with 2 parameters. |
| `Create<T1...T7>(Action<T1...T7> callback, ...)` | `ActionCallback<T1...T7>` | Up to 7 parameters supported. |
| `CreateOne(Action callback)` | `ActionCallback` | Create a one-shot callback that auto-disposes after first invocation. |
| `CreateOne<T1>(Action<T1> callback)` | `ActionCallback<T1>` | One-shot with 1 parameter. |
| `CreateOne<T1...T7>(Action<T1...T7> callback)` | `ActionCallback<T1...T7>` | One-shot, up to 7 parameters. |

## Static Factory Methods - Func (with return value)

| Method | Return Type | Description |
|---|---|---|
| `Create<TResult>(Func<TResult> callback, CallbackGroup? group = null)` | `FuncCallback<TResult>` | Create a reusable callback that returns a value. |
| `Create<T1, TResult>(Func<T1, TResult> callback, ...)` | `FuncCallback<T1, TResult>` | Reusable with 1 parameter and return value. |
| `Create<T1...T7, TResult>(Func<T1...T7, TResult> callback, ...)` | `FuncCallback<T1...T7, TResult>` | Up to 7 parameters with return value. |
| `CreateOne<TResult>(Func<TResult> callback)` | `FuncCallback<TResult>` | One-shot with return value. |
| `CreateOne<T1, TResult>(Func<T1, TResult> callback)` | `FuncCallback<T1, TResult>` | One-shot with 1 parameter and return value. |
| `CreateOne<T1...T7, TResult>(Func<T1...T7, TResult> callback)` | `FuncCallback<T1...T7, TResult>` | One-shot, up to 7 parameters with return value. |

## Instance Properties

| Property | Type | Description |
|---|---|---|
| `IsDisposed` | `bool` | True if the callback has been disposed. Serialized as `isDisposed` in JSON. |
| `_callback` | `DotNetObjectReference<Callback>` | The .NET object reference used by JS to invoke the callback. |
| `_callbackId` | `string` | Unique identifier for this callback instance. |
| `_paramTypes` | `int[]` | Array of parameter type hints for JS interop marshaling. |
| `_returnVoid` | `bool` | True if the callback returns void (Action-based). |

## Instance Methods

| Method | Return Type | Description |
|---|---|---|
| `Dispose()` | `void` | Decrement RefCount by 1. If RefCount reaches 0, the callback is fully disposed. |
| `Dispose(bool force)` | `void` | If `force` is true, dispose immediately regardless of RefCount. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDisposed` | `Action` | Fired when the callback is fully disposed (RefCount reaches 0). |

## JSON Serialization

When a Callback is passed to JavaScript, it serializes as:

```json
{
    "_callback": { /* DotNetObjectReference */ },
    "_callbackId": "42",
    "_paramTypes": [0, 1],
    "_returnVoid": false
}
```

The JS interop layer uses this metadata to correctly invoke the .NET method with proper parameter marshaling.

## Example - Basic Action Callback

```csharp
// Simple void callback
using var cb = Callback.Create(() => Console.WriteLine("Called!"));
JS.CallVoid("setTimeout", cb, 1000);

// Callback with parameters
using var cb = Callback.Create<string, int>((name, count) =>
{
    Console.WriteLine($"{name}: {count}");
});
someJSObject.JSRef!.CallVoid("onData", cb);
```

## Example - One-Shot Callback

```csharp
// Auto-disposes after first call - perfect for one-time events
using var cb = Callback.CreateOne<Event>(e =>
{
    Console.WriteLine($"Loaded! Type: {e.Type}");
});
JS.CallVoid("addEventListener", "load", cb);
```

## Example - Func Callback (Return Value)

```csharp
// Callback that returns a value to JavaScript
using var validator = Callback.Create<string, bool>(input =>
{
    return input.Length > 3;
});
JS.CallVoid("myLib.setValidator", validator);

// Async callback - Task automatically converts to Promise in JS
using var fetcher = Callback.Create<string, Task<string>>(async url =>
{
    using var response = await JS.CallAsync<Response>("fetch", url);
    return await response.Text();
});
```

## Example - With CallbackGroup

```csharp
using var group = new CallbackGroup();

// All callbacks added to the group are disposed together
var onOpen = Callback.Create(() => Console.WriteLine("open"), group);
var onClose = Callback.Create(() => Console.WriteLine("close"), group);
var onError = Callback.Create<Event>(e => Console.WriteLine("error"), group);

ws.JSRef!.CallVoid("addEventListener", "open", onOpen);
ws.JSRef!.CallVoid("addEventListener", "close", onClose);
ws.JSRef!.CallVoid("addEventListener", "error", onError);

// group.Dispose() disposes all three callbacks at once
```

## Important Notes

- **Always dispose Callbacks.** Each Callback holds a DotNetObjectReference that pins .NET objects in memory. Leaking Callbacks leaks memory.
- **CreateOne auto-disposes** after the first invocation - ideal for one-time event handlers, Promise resolve/reject callbacks, etc.
- **RefCount-based disposal:** Calling Dispose() decrements the reference count. The callback is only truly disposed when RefCount reaches 0. This supports sharing a single callback across multiple listeners via CallbackRef.
- **Async support:** If a Callback wraps a `Func` that returns `Task` or `Task<T>`, the return value is automatically converted to a JavaScript Promise.

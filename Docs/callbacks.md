# Callbacks

The `Callback` system makes .NET methods callable from JavaScript. When a `Callback` is created, it wraps a .NET delegate in a `DotNetObjectReference` and registers it with the JavaScript interop layer so that JavaScript code can invoke the .NET method.

**Namespace:** `SpawnDev.BlazorJS`

---

## Overview

| Type | Purpose |
|---|---|
| `Callback` | Abstract base class for all callbacks |
| `ActionCallback` / `ActionCallback<T1, ...>` | Callbacks that return void |
| `FuncCallback<TResult>` / `FuncCallback<T1, ..., TResult>` | Callbacks that return a value |
| `CallbackGroup` | Container for batch disposal of multiple callbacks |

---

## Callback.Create - Persistent Callbacks

`Callback.Create` creates a callback that persists until explicitly disposed. Use this when the callback will be called multiple times.

### Action Callbacks (void return)

```csharp
// No parameters
using var cb = Callback.Create(() => Console.WriteLine("Called!"));

// One parameter
using var cb = Callback.Create<string>(msg => Console.WriteLine($"Got: {msg}"));

// Multiple parameters
using var cb = Callback.Create<string, int>((msg, count) =>
{
    Console.WriteLine($"Got {msg} x{count}");
});

// Pass to JavaScript
JS.Set("myCallback", cb);
// JS can now call: myCallback("hello", 5)
```

### Func Callbacks (with return value)

```csharp
// Returns a value
using var cb = Callback.Create<int, string>(x => $"Number is {x}");

// Returns a computed value
using var cb = Callback.Create<int, int, int>((a, b) => a + b);

// Pass to JavaScript
JS.Set("myFn", cb);
// JS: var result = myFn(20, 22); // result == 42
```

### With CallbackGroup

Pass a `CallbackGroup` to `Create` for batch disposal:

```csharp
var group = new CallbackGroup();
var cb1 = Callback.Create(() => DoThing1(), group);
var cb2 = Callback.Create<string>(msg => DoThing2(msg), group);

// Dispose all at once
group.Dispose();
```

---

## Callback.CreateOne - One-Shot Callbacks

`Callback.CreateOne` creates a callback that automatically disposes itself after the first invocation. Use this for callbacks that should only fire once, like `setTimeout` or one-time event handlers.

### Action (void)

```csharp
// setTimeout with auto-disposing callback
JS.CallVoid("setTimeout", Callback.CreateOne(() =>
{
    Console.WriteLine("Timeout fired - callback auto-disposed");
}), 1000);

// No need to track or dispose - it cleans itself up after firing
```

### Func (with return value)

```csharp
// One-shot callback with return value
var cb = Callback.CreateOne<Lock, Promise>((lockObj) => new Promise(async () =>
{
    Console.WriteLine("Lock acquired");
    await Task.Delay(5000);
    Console.WriteLine("Lock released");
}));
```

---

## Async Callbacks (Task -> Promise)

When a callback's delegate returns a `Task` or `Task<T>`, SpawnDev.BlazorJS automatically converts the return value to a JavaScript `Promise`. This lets you use async .NET methods as JavaScript async functions.

```csharp
// Async callback - returns a Promise to JavaScript
JS.Set("fetchData", Callback.CreateOne<string, Task<string>>(async (url) =>
{
    await Task.Delay(1000);
    return $"Data from {url}";
}));
```

```javascript
// In JavaScript:
var result = await fetchData("https://example.com");
// result == "Data from https://example.com"
```

### Real Example: Web Locks API

```csharp
using var navigator = JS.Get<Navigator>("navigator");
using var locks = navigator.Locks;

// The callback returns a Promise, which keeps the lock held until resolved
using var waitLock = locks.Request("my_lock",
    Callback.CreateOne((Lock lockObj) => new Promise(async () =>
    {
        Console.WriteLine("Lock acquired");
        await Task.Delay(5000);
        Console.WriteLine("Lock released");
    }))
);
```

---

## Reference Counting

`Callback` objects use reference counting for lifetime management:

- Starts with `RefCount = 1` when created
- `Dispose()` decrements `RefCount` by 1
- The callback is actually disposed when `RefCount` reaches 0
- `Dispose(true)` force-disposes regardless of `RefCount`

This matters when the same callback is shared across multiple subscribers (which `ActionEvent` does automatically via `CallbackRef`).

---

## CallbackGroup

`CallbackGroup` is a container that holds multiple `Callback` objects and disposes them all at once. It implements `IDisposable`.

```csharp
using var group = new CallbackGroup();

// Create callbacks and add them to the group
var cb1 = Callback.Create(() => Console.WriteLine("Callback 1"), group);
var cb2 = Callback.Create<string>(msg => Console.WriteLine(msg), group);
var cb3 = Callback.Create<int, int>((a, b) => a + b, group);

// Pass callbacks to JS
JS.CallVoid("addEventListener", "resize", cb1);
JS.Set("logMessage", cb2);
JS.Set("addNumbers", cb3);

// ... when done, dispose the group to clean up all callbacks
group.Dispose();
// All three callbacks are now disposed
```

You can also add callbacks to the group manually:

```csharp
var group = new CallbackGroup();
var cb = Callback.Create(() => DoSomething());
group.Add(cb);
```

`CallbackGroup.Clear()` disposes all callbacks and empties the list. `Dispose()` calls `Clear()`.

---

## Action and Func Serialization

SpawnDev.BlazorJS supports direct serialization of `Action` and `Func` delegates. When you pass an `Action` or `Func` to JavaScript, a `Callback` is automatically created and associated with it.

**Important:** You MUST call the `.DisposeJS()` extension method on these delegates to dispose the auto-created callback.

### Action Example

```csharp
var callback = () =>
{
    Console.WriteLine("Timer fired");
};

// Passing an Action to JS auto-creates a Callback
JS.CallVoid("setTimeout", callback, 100);

// After use, dispose the auto-created Callback
callback.DisposeJS();
```

### Func Example

```csharp
int testValue = 42;
var origFunc = new Func<int, int>((val) => val);

// Set as a global JS function - auto-creates a Callback
JS.Set("_funcCallback", origFunc);

// Read it back - auto-creates a JS Function reference
var readFunc = JS.Get<Func<int, int>>("_funcCallback");
var result = readFunc(testValue);
// result == 42

// Dispose auto-created references
readFunc.DisposeJS();   // Disposes the JS Function reference
origFunc.DisposeJS();   // Disposes the Callback
```

---

## When to Use Callback vs ActionEvent

| Scenario | Use |
|---|---|
| Subscribing to JSObject events (addEventListener) | `ActionEvent` with `+=` / `-=` |
| Passing a callback to a JS API (setTimeout, requestAnimationFrame) | `Callback.Create` or `Callback.CreateOne` |
| One-time callbacks (event fires once, then done) | `Callback.CreateOne` |
| Multiple callbacks that need batch disposal | `CallbackGroup` |
| Passing .NET delegates directly to JS | Direct `Action`/`Func` serialization + `DisposeJS()` |

**General rule:** Use `ActionEvent` for DOM events, use `Callback.Create`/`CreateOne` for everything else.

---

## Callback Lifetime Rules

1. **ALWAYS dispose Callbacks** unless created with `CreateOne`. Undisposed Callbacks leak .NET object references.
2. **`CreateOne` auto-disposes** after the first invocation - no manual disposal needed.
3. **CallbackGroup** simplifies cleanup when you have many callbacks.
4. **ActionEvent manages callbacks internally** - you do not need to manually create or dispose Callbacks when using `+=` / `-=`.
5. **Disposed callbacks cannot be called.** If JavaScript tries to invoke a disposed callback, it will be a no-op.
6. **The `IsDisposed` property** indicates whether the callback has been disposed.

---

## Type Overloads

`Callback.Create` and `Callback.CreateOne` support up to 7 parameters:

- `Callback.Create(Action)` through `Callback.Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1..T7>)`
- `Callback.Create<TResult>(Func<TResult>)` through `Callback.Create<T1..T7, TResult>(Func<T1..T7, TResult>)`
- Same for `CreateOne`

---

## See Also

- [Events (ActionEvent / FuncEvent)](events.md) - Event subscription system built on Callbacks
- [Disposal and Lifetime](disposal.md) - Comprehensive disposal guide
- [JSObject](jsobject.md) - Base wrapper class

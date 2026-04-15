# Promises

`Promise` and `Promise<T>` are JSObject wrappers for the JavaScript `Promise` class. They allow creating JavaScript Promises from .NET code - wrapping async methods, Tasks, or TaskCompletionSource instances.

**Namespace:** `SpawnDev.BlazorJS.JSObjects`

---

## Overview

JavaScript Promises are the async primitive - the equivalent of .NET's `Task`. SpawnDev.BlazorJS lets you:

1. **Create Promises from .NET** to pass to JavaScript APIs that expect them
2. **Await Promises** returned from JavaScript
3. **Bridge Task and Promise** for seamless async interop

---

## Creating Promises

### From an Async Lambda (void)

```csharp
var promise = new Promise(async () =>
{
    await Task.Delay(5000);
    // Promise resolves when the lambda completes
});
// Pass to a JS API that expects a Promise
```

### From an Async Lambda with Return Value

```csharp
var promise = new Promise<string>(async () =>
{
    await Task.Delay(5000);
    return "Hello world!";
});
// Promise resolves with the return value
```

### From a Synchronous Lambda

```csharp
var promise = new Promise(() =>
{
    // Synchronous work - resolves immediately
});
```

### From a Task

```csharp
var taskSource = new TaskCompletionSource<string>();
var promise = new Promise<string>(taskSource.Task);

// Pass promise to JavaScript API immediately
JS.Set("myPromise", promise);

// Resolve later
taskSource.TrySetResult("Hello world!");
```

### From an Existing Task

```csharp
Task<byte[]> downloadTask = httpClient.GetByteArrayAsync(url);
var promise = new Promise<byte[]>(downloadTask);
```

---

## Awaiting Promises

### ThenAsync()

Await the resolution of a Promise from JavaScript:

```csharp
// Get a Promise from JavaScript
using var promise = JS.Call<Promise<string>>("fetchData", "/api/items");

// Await the result
string result = await promise.ThenAsync();
```

### Using CallAsync

The more common pattern is to use `CallAsync<T>`, which handles the Promise awaiting internally:

```csharp
// This is equivalent to getting the Promise and calling ThenAsync
string result = await JS.CallAsync<string>("fetchData", "/api/items");
```

### Using Call\<Task\<T\>\>

Another alternative:

```csharp
string result = await JS.Call<Task<string>>("fetchData", "/api/items");
```

---

## Passing Promises to JavaScript APIs

Some JavaScript APIs accept Promises as parameters. The Web Locks API is a good example - the lock is held until the Promise you return resolves.

### Web Locks API Example

```csharp
using var navigator = JS.Get<Navigator>("navigator");
using var locks = navigator.Locks;

Console.WriteLine("Requesting lock...");

// Request a lock - the callback must return a Promise
// The lock is held until the Promise resolves
using var waitLock = locks.Request("my_lock",
    Callback.CreateOne((Lock lockObj) => new Promise(async () =>
    {
        Console.WriteLine("Lock acquired");
        await Task.Delay(5000);
        Console.WriteLine("Lock released");
    }))
);

// Request the same lock - will wait until the first one releases
using var waitLock2 = locks.Request("my_lock",
    Callback.CreateOne((Lock lockObj) => new Promise(async () =>
    {
        Console.WriteLine("Second lock acquired");
        await Task.Delay(5000);
        Console.WriteLine("Second lock released");
    }))
);
```

Output:
```
Requesting lock...
Lock acquired
Lock released
Second lock acquired
Second lock released
```

---

## Promise and async Callbacks

When a `Callback` wraps an async method (returning `Task` or `Task<T>`), the return value is automatically converted to a JavaScript Promise:

```csharp
// This callback returns a Promise to JavaScript
JS.Set("myAsyncFn", Callback.CreateOne<string, Task<string>>(async (input) =>
{
    await Task.Delay(1000);
    return $"Processed: {input}";
}));
```

```javascript
// JavaScript:
var result = await myAsyncFn("test");
// result == "Processed: test"
```

---

## Promise Properties and Methods

| Member | Description |
|---|---|
| `ThenAsync()` | Awaits the Promise resolution and returns the result |
| Constructor `Promise(Action)` | Create from sync void lambda |
| Constructor `Promise(Func<Task>)` | Create from async void lambda |
| Constructor `Promise<T>(Func<Task<T>>)` | Create from async lambda with return value |
| Constructor `Promise<T>(Task<T>)` | Create from an existing Task |

---

## See Also

- [BlazorJSRuntime](blazorjsruntime.md) - CallAsync for awaiting Promise-returning JS methods
- [Callbacks](callbacks.md) - Async callbacks auto-convert to Promises

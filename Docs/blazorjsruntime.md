# BlazorJSRuntime

`BlazorJSRuntime` is the central JavaScript interop service in SpawnDev.BlazorJS. It provides synchronous and asynchronous access to the JavaScript global scope, including property access, method calls, object creation, type checking, script loading, and scope detection.

**Namespace:** `SpawnDev.BlazorJS`

---

## Registration

Register in `Program.cs`:

```csharp
builder.Services.AddBlazorJSRuntime();
```

Or with early access (the `out var JS` pattern):

```csharp
builder.Services.AddBlazorJSRuntime(out var JS);
// JS is available immediately for scope detection, script loading, etc.
```

---

## Injection

### In Components

```csharp
[Inject]
BlazorJSRuntime JS { get; set; }
```

### In Services

```csharp
public class MyService
{
    private readonly BlazorJSRuntime _js;
    public MyService(BlazorJSRuntime js) => _js = js;
}
```

### Static Access (from JSObject subclasses)

All `JSObject` subclasses have access to a protected static `JS` property that refers to the singleton `BlazorJSRuntime`:

```csharp
public class MyWrapper : JSObject
{
    // This static JS property is provided by JSObject base class
    // It is equivalent to BlazorJSRuntime.JS
    public MyWrapper(string url) : base(JS.New("MyClass", url)) { }
    public MyWrapper(IJSInProcessObjectReference _ref) : base(_ref) { }
}
```

The static `BlazorJSRuntime.JS` property is also accessible from anywhere:

```csharp
var height = BlazorJSRuntime.JS.Get<int>("window.innerHeight");
```

---

## Property Access

### Get\<T\>(string propertyPath)

Reads a JavaScript property and deserializes it to type `T`. Supports dot notation and null-conditional `?.` operator.

```csharp
// Primitive types
int height = JS.Get<int>("window.innerHeight");
string title = JS.Get<string>("document.title");
bool hidden = JS.Get<bool>("document.hidden");
double ratio = JS.Get<double>("window.devicePixelRatio");

// JSObject types - REMEMBER to dispose
using var window = JS.Get<Window>("window");
using var document = JS.Get<Document>("document");
using var navigator = JS.Get<Navigator>("navigator");
using var localStorage = JS.Get<Storage>("localStorage");

// Nullable with null-conditional
int? size = JS.Get<int?>("fruit.options?.size");
string? theme = JS.Get<string?>("app?.config?.theme");

// IJSInProcessObjectReference (raw reference)
var rawRef = JS.Get<IJSInProcessObjectReference>("someObject");
```

### Set(string propertyPath, object? value)

Sets a JavaScript property.

```csharp
JS.Set("document.title", "My App");
JS.Set("myGlobalVar", 42);
JS.Set("myGlobalObj", new { name = "test", count = 5 });

// Set to null
JS.Set("myVar", null);
```

### Delete(string propertyPath)

Deletes a JavaScript property (equivalent to the `delete` operator).

```csharp
JS.Delete("myGlobalVar");
```

---

## Method Calls

### Call\<T\>(string methodPath, params object?[] args)

Calls a synchronous JavaScript method and returns the result as type `T`.

```csharp
// Returns a value
string? item = JS.Call<string?>("localStorage.getItem", "myKey");
int max = JS.Call<int>("Math.max", 10, 20);
double random = JS.Call<double>("Math.random");
string json = JS.Call<string>("JSON.stringify", myObject);

// Returns a JSObject type
using var parsed = JS.Call<JSObject>("JSON.parse", jsonString);
```

### CallVoid(string methodPath, params object?[] args)

Calls a synchronous JavaScript method that returns void.

```csharp
JS.CallVoid("console.log", "Hello from Blazor!");
JS.CallVoid("localStorage.setItem", "key", "value");
JS.CallVoid("localStorage.removeItem", "key");
JS.CallVoid("alert", "Warning!");
```

### CallAsync\<T\>(string methodPath, params object?[] args)

Calls a JavaScript method that returns a Promise, awaits it, and returns the resolved value as type `T`.

```csharp
// Fetch API
using var response = await JS.CallAsync<Response>("fetch", "/api/data");

// Any async/Promise-returning function
string result = await JS.CallAsync<string>("myAsyncFunction", arg1);
```

---

## Sync vs Async - CRITICAL Rules

SpawnDev.BlazorJS is a 1:1 mapping to JavaScript. Using the wrong call type **throws an error**.

| JavaScript Returns | Correct C# Call | Wrong Call |
|---|---|---|
| Value (synchronous) | `JS.Call<T>()` or `JS.Get<T>()` | `JS.CallAsync<T>()` THROWS |
| Promise (asynchronous) | `JS.CallAsync<T>()` | `JS.Call<T>()` returns a Promise object, not the value |
| void (synchronous) | `JS.CallVoid()` | - |
| void Promise (asynchronous) | `JS.CallVoidAsync()` | `JS.CallVoid()` won't await the Promise |

**Examples of correct usage:**

```csharp
// Synchronous JS function
// function addNum(a, b) { return a + b; }
var total = JS.Call<int>("addNum", 20, 22);

// Asynchronous JS function
// async function fetchData(url) { ... }
var data = await JS.CallAsync<string>("fetchData", "/api/items");

// Alternative for async: get the Promise, then await it
using var promise = JS.Call<Promise<string>>("fetchData", "/api/items");
var data = await promise.ThenAsync();

// Alternative for async: use Task<T>
var data = await JS.Call<Task<string>>("fetchData", "/api/items");
```

---

## Object Creation

### New(string constructorName, params object?[] args)

Creates a new JavaScript object using the given constructor and returns an `IJSInProcessObjectReference`.

```csharp
var workerRef = JS.New("Worker", "my-worker.js");
```

### New\<T\>(string constructorName, params object?[] args)

Creates a new JavaScript object and wraps it in a typed JSObject wrapper.

```csharp
using var audio = JS.New<Audio>("Audio", "song.mp3");
using var ws = JS.New<WebSocket>("WebSocket", "wss://example.com");
using var re = JS.New<RegExp>("RegExp", "\\d+", "g");
```

---

## Type Checking

### TypeOf(string expression)

Returns the JavaScript `typeof` result as a string.

```csharp
string type = JS.TypeOf("someVar");
// Returns: "object", "function", "number", "string", "boolean", "undefined", "symbol", "bigint"
```

### IsUndefined(string expression)

Returns `true` if the JavaScript expression evaluates to `undefined`.

```csharp
bool isUndef = JS.IsUndefined("someVar");
bool hasFeature = !JS.IsUndefined("navigator.gpu");
```

### ConstructorName(string expression)

Returns the `constructor.name` of a JavaScript object.

```csharp
string name = JS.ConstructorName("someVar");
// Returns: "Array", "Date", "Object", "HTMLDivElement", etc.
```

### ConstructorNames(params string[] expressions)

Returns constructor names for multiple expressions in a single call.

```csharp
string[] names = JS.ConstructorNames("var1", "var2", "var3");
```

---

## Script Loading

### LoadScript(string src)

Loads a JavaScript file by adding a `<script>` tag to the document and waiting for it to load.

```csharp
await JS.LoadScript("https://cdn.example.com/library.js");
await JS.LoadScript("js/my-utils.js");
await JS.LoadScript("_content/MyPackage/interop.js");
```

### Import(string moduleUrl)

Loads an ES module using dynamic `import()`.

```csharp
using var module = await JS.Import("./my-module.js");
```

---

## Fetch

### Fetch(string url)

Convenience wrapper for the Fetch API.

```csharp
using var response = await JS.Fetch("/api/data");
var text = await response.Text();
```

---

## Scope Detection Properties

These properties detect the current JavaScript global scope. Critical for apps that run in both Window and Worker contexts.

| Property | Type | Description |
|---|---|---|
| `IsWindow` | `bool` | `true` if running in a browser Window |
| `IsWorker` | `bool` | `true` if running in any Worker scope |
| `IsDedicatedWorkerGlobalScope` | `bool` | `true` if running in a dedicated Worker |
| `IsSharedWorkerGlobalScope` | `bool` | `true` if running in a shared Worker |
| `IsServiceWorkerGlobalScope` | `bool` | `true` if running in a service Worker |
| `GlobalScope` | `GlobalScope` (enum) | The current scope as an enum value |
| `GlobalThisTypeName` | `string` | The `constructor.name` of `globalThis` |
| `CrossOriginIsolated` | `bool?` | Whether the site is cross-origin isolated (needed for SharedArrayBuffer) |
| `IsBrowser` | `bool` | `true` if running in a browser (shortcut for `OperatingSystem.IsBrowser()`) |

### IsScope(GlobalScope scope)

Tests if the current scope matches the given scope flags:

```csharp
if (JS.IsScope(GlobalScope.Window | GlobalScope.DedicatedWorker))
{
    // Running in either Window or DedicatedWorker
}
```

---

## Scope Object Properties

| Property | Type | Description |
|---|---|---|
| `GlobalThis` | `JSObject?` | The `globalThis` object |
| `WindowThis` | `Window?` | Non-null when `IsWindow` is true |
| `DedicateWorkerThis` | `DedicatedWorkerGlobalScope?` | Non-null when `IsDedicatedWorkerGlobalScope` is true |
| `SharedWorkerThis` | `SharedWorkerGlobalScope?` | Non-null when `IsSharedWorkerGlobalScope` is true |
| `ServiceWorkerThis` | `ServiceWorkerGlobalScope?` | Non-null when `IsServiceWorkerGlobalScope` is true |

---

## Other Properties and Methods

### Log(params object?[] args)

Convenience wrapper for `console.log`:

```csharp
JS.Log("Hello", myObject, 42);
```

### InstanceId

A unique hex string generated when the app starts, useful for identifying instances:

```csharp
string id = JS.InstanceId; // e.g. "A1B2-C3D4-E5F6-7890"
```

### ReadyTime

Elapsed time (in milliseconds) until all background services have started.

### HasInProcessRuntime

Returns `true` if the IJSInProcessRuntime is available (always true in Blazor WASM).

---

## Null-Conditional Support

The `?.` operator in property paths prevents errors when intermediate properties are null or undefined:

```csharp
// Safely access nested properties
var size = JS.Get<int?>("fruit.options?.size");
// If fruit.options is null/undefined, returns null instead of throwing

// Multiple null-conditional operators
var value = JS.Get<string?>("app?.config?.settings?.theme");
```

This works with `Get<T>`, `Set`, `Call<T>`, `CallVoid`, and `CallAsync<T>`.

---

## See Also

- [Getting Started](getting-started.md)
- [JSObject](jsobject.md)
- [Worker Scope Detection](worker-scopes.md)

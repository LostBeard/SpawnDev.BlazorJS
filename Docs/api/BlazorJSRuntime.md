# BlazorJSRuntime

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** BlazorJSRuntime  
**Source:** `SpawnDev.BlazorJS/BlazorJSRuntime.cs`, `SpawnDev.BlazorJS/BlazorJSRuntimeExt.cs`

> BlazorJSRuntime is the central interop singleton that provides synchronous and asynchronous access to the JavaScript environment from Blazor WebAssembly. It wraps the IJSInProcessRuntime and adds typed property access, method invocation, object construction, scope detection, and module loading. All property paths support dot notation and null-conditional (`?.`) syntax. This is the primary entry point for all JS interop in SpawnDev.BlazorJS - never use IJSRuntime or IJSInProcessRuntime directly.

## Setup

Register and start the runtime in `Program.cs`:

```csharp
builder.Services.AddBlazorJSRuntime();
await builder.Build().BlazorJSRunAsync(); // NOT RunAsync()
```

## Accessing the Runtime

```csharp
// Via dependency injection (preferred)
[Inject] BlazorJSRuntime JS { get; set; }

// Via static property on JSObject
BlazorJSRuntime js = JSObject.JS;

// Via static property on BlazorJSRuntime itself
BlazorJSRuntime js = BlazorJSRuntime.JS;
```

## Properties

| Property | Type | Description |
|---|---|---|
| `JS` | `BlazorJSRuntime` | Static singleton instance. Accessible from anywhere. |
| `GlobalThis` | `JSObject?` | The globalThis JSObject instance for the current scope. |
| `WindowThis` | `Window?` | If globalThis is a Window, refers to globalThis; otherwise null. |
| `DedicateWorkerThis` | `DedicatedWorkerGlobalScope?` | If globalThis is a DedicatedWorkerGlobalScope; otherwise null. |
| `SharedWorkerThis` | `SharedWorkerGlobalScope?` | If globalThis is a SharedWorkerGlobalScope; otherwise null. |
| `ServiceWorkerThis` | `ServiceWorkerGlobalScope?` | If globalThis is a ServiceWorkerGlobalScope; otherwise null. |
| `GlobalThisTypeName` | `string` | The `constructor.name` of globalThis (e.g., "Window", "DedicatedWorkerGlobalScope"). |
| `GlobalScope` | `GlobalScope` | Enum value representing the current scope type. |
| `IsWindow` | `bool` | True if globalThis is a Window. |
| `IsWorker` | `bool` | True if globalThis is any worker (Dedicated, Shared, or Service). |
| `IsDedicatedWorkerGlobalScope` | `bool` | True if globalThis is a DedicatedWorkerGlobalScope. |
| `IsSharedWorkerGlobalScope` | `bool` | True if globalThis is a SharedWorkerGlobalScope. |
| `IsServiceWorkerGlobalScope` | `bool` | True if globalThis is a ServiceWorkerGlobalScope. |
| `IsBrowser` | `bool` | True if running in a browser (OperatingSystem.IsBrowser()). |
| `HasInProcessRuntime` | `bool` | True if the in-process JS runtime is available. |
| `CrossOriginIsolated` | `bool?` | Whether the site is in a cross-origin isolated state (COOP/COEP). |
| `InstanceId` | `string` | Unique hex instance ID generated at startup. |
| `ReadyTime` | `double` | Milliseconds elapsed until all background services started. |
| `EnvironmentVersion` | `string` | The .NET Environment.Version string. |
| `FrameworkVersion` | `string` | The .NET runtime framework description (version number). |
| `InformationalVersion` | `string` | The BlazorJSRuntime assembly informational version. |
| `FileVersion` | `string` | The BlazorJSRuntime assembly file version. |

## Methods - Property Access

| Method | Return Type | Description |
|---|---|---|
| `Get<T>(string key)` | `T` | Get a global property value. Supports dot notation and `?.` null-conditional. |
| `Get(Type returnType, string key)` | `object?` | Get a global property value as the specified Type. |
| `GetAsync<T>(string key)` | `Task<T>` | Get a global property value that returns a Promise. |
| `Set(string key, object? value)` | `void` | Set a global property value. Supports dot notation. |
| `Delete(string key)` | `bool` | Delete a global property. |
| `In(string key)` | `bool` | Returns true if the key exists in globalThis (`key in target`). |
| `Keys(bool hasOwnProperty = false)` | `List<string>` | Returns property string keys of globalThis. |
| `Keys(string key, bool hasOwnProperty = false)` | `List<string>` | Returns property string keys of the target object at `key`. |

## Methods - Type Checking

| Method | Return Type | Description |
|---|---|---|
| `TypeOf(string key)` | `string` | Returns the `typeof` result ("object", "function", "undefined", etc.). |
| `IsUndefined(string key)` | `bool` | Returns true if `typeof key === "undefined"`. |
| `ConstructorName()` | `string?` | Returns the `constructor.name` of globalThis. |
| `ConstructorName(string key)` | `string?` | Returns the `constructor.name` of the target at `key`. |
| `ConstructorNames()` | `string[]` | Returns constructor names from the entire prototype chain of globalThis. |
| `ConstructorNames(string key)` | `string[]` | Returns constructor names from the entire prototype chain at `key`. |
| `JSEquals(string key, object? obj2, bool full = false)` | `bool` | JS equality check. `full=true` uses `===`, `full=false` uses `==`. |

## Methods - Synchronous Calls

| Method | Return Type | Description |
|---|---|---|
| `Call<T>(string key, ...)` | `T` | Call a global method synchronously (0-10 args). |
| `CallApply<T>(string key, object?[]? args)` | `T` | Call a global method with an args array. |
| `CallVoid(string key, ...)` | `void` | Call a global void method synchronously (0-10 args). |
| `CallApplyVoid(string key, object?[]? args)` | `void` | Call a global void method with an args array. |

## Methods - Async Calls

| Method | Return Type | Description |
|---|---|---|
| `CallAsync<T>(string key, ...)` | `Task<T>` | Call a global method that returns a Promise (0-10 args). |
| `CallApplyAsync<T>(string key, object?[]? args)` | `Task<T>` | Call a Promise-returning method with an args array. |
| `CallApplyVoidAsync(string key, object?[]? args)` | `Task` | Call a void Promise-returning method with an args array. |

## Methods - Object Construction

| Method | Return Type | Description |
|---|---|---|
| `New(string className, ...)` | `IJSInProcessObjectReference` | Create a new JS object (0-10 args). Returns raw reference. |
| `New<T>(string className, ...)` | `T` | Create a new JS object and return as typed wrapper (0-10 args). |
| `NewApply(string className, object?[]? args)` | `IJSInProcessObjectReference` | Create a new JS object with args array. |
| `NewApply<T>(string className, object?[]? args)` | `T` | Create a new typed JS object with args array. |

## Methods - Script Loading

| Method | Return Type | Description |
|---|---|---|
| `LoadScript(string src)` | `Task` | Load a script. Uses script element in Window, importScripts in workers. |
| `LoadScript(string src, string? ifThisGlobalVarIsUndefined)` | `Task` | Load a script only if the specified global variable is undefined. |
| `LoadScripts(string[] sources)` | `Task` | Load multiple scripts in parallel. |
| `Import(string moduleName)` | `Task<ModuleNamespaceObject>` | Dynamic ES module import (`import()`). |
| `Import(string name, string moduleName)` | `Task<ModuleNamespaceObject>` | Import and assign to a global variable. |
| `Import<T>(string moduleName)` | `Task<T>` | Dynamic import returning a typed module. |
| `Import<T>(string name, string moduleName)` | `Task<T>` | Import as typed and assign to global variable. |

## Methods - Convenience

| Method | Return Type | Description |
|---|---|---|
| `Log(params object?[] args)` | `void` | Write to `console.log`. |
| `LogError(params object?[] args)` | `void` | Write to `console.error`. |
| `LogWarn(params object?[] args)` | `void` | Write to `console.warn`. |
| `Fetch(string resource)` | `Task<Response>` | Call the Fetch API. |
| `Fetch(string resource, FetchOptions options)` | `Task<Response>` | Call the Fetch API with options. |
| `Fetch(Request resource)` | `Task<Response>` | Call the Fetch API with a Request object. |
| `SetTimeout(Action callback, int msDelay)` | `void` | Call setTimeout with a .NET Action (auto-creates one-shot Callback). |
| `SetTimeout(Callback callback, int msDelay)` | `void` | Call setTimeout with an existing Callback. |
| `GetWindow()` | `Window?` | Returns the window object or null. |
| `GetDocument()` | `Document?` | Returns the document object or null. |
| `GetDocumentHead()` | `HTMLHeadElement?` | Returns document.head or null. |
| `GetDocumentBody()` | `HTMLBodyElement?` | Returns document.body or null. |
| `DocumentHeadAppendChild(Element element)` | `void` | Append an element to document.head. |
| `DocumentBodyAppendChild(Element element)` | `void` | Append an element to document.body. |
| `DocumentCreateElement<T>(string elementType)` | `T` | Create a DOM element of the specified type. |
| `ReturnMe<T>(object? obj)` | `T` | Re-import an object from JS as the specified type. |
| `ToJSRef(ElementReference elementRef)` | `IJSInProcessObjectReference` | Convert a Blazor ElementReference to a JSRef. |
| `IsScope(GlobalScope scope)` | `bool` | Returns true if the current scope matches the supplied GlobalScope flag. |
| `IsDisplayModeStandalone()` | `bool` | Returns true if running as a standalone PWA. |

## Example - Basic Property Access

```csharp
@inject BlazorJSRuntime JS

// Read global properties with dot notation
var height = JS.Get<int>("window.innerHeight");
var userAgent = JS.Get<string>("navigator.userAgent");

// Null-conditional paths - returns null instead of throwing
var size = JS.Get<int?>("fruit.options?.size");

// Set global properties
JS.Set("myApp.config.debug", true);

// Check types
bool isUndef = JS.IsUndefined("someVar");
string jsType = JS.TypeOf("document");        // "object"
string ctorName = JS.ConstructorName("document"); // "HTMLDocument"
```

## Example - Method Invocation

```csharp
// Synchronous call
JS.CallVoid("console.log", "Hello from Blazor!");
var result = JS.Call<string>("btoa", "Hello");

// Async call (Promise-returning methods)
using var response = await JS.CallAsync<Response>("fetch", "/api/data");
using var json = await response.Json();

// Object construction
using var audio = JS.New<Audio>("Audio", "song.mp3");
using var url = JS.New<URL>("URL", "https://spawndev.com");
```

## Example - Scope Detection

```csharp
if (JS.IsWindow)
{
    // Running in the main browser window
    var doc = JS.WindowThis!.Document;
}
else if (JS.IsDedicatedWorkerGlobalScope)
{
    // Running in a dedicated web worker
    JS.DedicateWorkerThis!.PostMessage("worker ready");
}
else if (JS.IsServiceWorkerGlobalScope)
{
    // Running in a service worker
}
```

## Example - Module Loading

```csharp
// Dynamic ES module import
using var module = await JS.Import("https://cdn.example.com/lib.js");

// Import and assign to a global variable (cached on subsequent calls)
using var acorn = await JS.Import("acorn", "https://cdn.jsdelivr.net/npm/acorn/+esm");
```

# Getting Started with SpawnDev.BlazorJS

This guide covers everything you need to start using SpawnDev.BlazorJS in your Blazor WebAssembly application.

---

## Installation

Install from NuGet:

```bash
dotnet add package SpawnDev.BlazorJS
```

Or add directly to your `.csproj`:

```xml
<PackageReference Include="SpawnDev.BlazorJS" Version="3.*" />
```

**Supported frameworks:** .NET 8, .NET 9, .NET 10

---

## Program.cs Setup

Two changes are required in `Program.cs`:

1. Register `BlazorJSRuntime` with `AddBlazorJSRuntime()`
2. Replace `RunAsync()` with `BlazorJSRunAsync()`

### Minimal Setup

```csharp
using SpawnDev.BlazorJS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add BlazorJSRuntime singleton service
builder.Services.AddBlazorJSRuntime();

// IMPORTANT: Use BlazorJSRunAsync instead of RunAsync
await builder.Build().BlazorJSRunAsync();
```

### Setup with Worker Scope Detection (out var JS)

The `AddBlazorJSRuntime` method has an overload that outputs the `BlazorJSRuntime` instance immediately. This lets you detect the current scope (Window, Worker, etc.) before the app finishes building - critical for apps that run in both Window and Worker contexts.

```csharp
using SpawnDev.BlazorJS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Get BlazorJSRuntime immediately via out parameter
builder.Services.AddBlazorJSRuntime(out var JS);

// Only add root components when running in a Window scope
// Workers do not have a DOM - adding components there would fail
if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

// Register your services
builder.Services.AddSingleton<MyAppService>();

await builder.Build().BlazorJSRunAsync();
```

This is the standard pattern used across all SpawnDev projects. The same `Program.cs` runs in both the browser Window and any Web Worker contexts. `BlazorJSRunAsync()` handles the difference automatically - in a Window it calls `RunAsync()` to start the Blazor renderer, in a Worker it enters a service-only mode.

### Setup with WebWorkerService

When using [SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers) for multi-threaded workers:

```csharp
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBlazorJSRuntime(out var JS);

if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

// Add WebWorkerService for spawning workers from .NET
builder.Services.AddWebWorkerService();

// Register services - these are available in both Window and Worker scopes
builder.Services.AddSingleton<MyComputeService>();

await builder.Build().BlazorJSRunAsync();
```

### Loading a JavaScript Library Before App Start

Some JS libraries need to be loaded before the app starts. You can do this using the `BlazorJSRuntime` instance from `out var JS`:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorJSRuntime(out var JS);

if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    // Load a JS library before the app starts
    await JS.LoadScript("_content/MyLibrary/my-library.js");
}

await builder.Build().BlazorJSRunAsync();
```

---

## Injecting BlazorJSRuntime

### In Razor Components

```csharp
@inject BlazorJSRuntime JS

<h3>Window Height: @windowHeight</h3>

@code {
    int windowHeight;

    protected override void OnInitialized()
    {
        windowHeight = JS.Get<int>("window.innerHeight");
    }
}
```

Or using the `[Inject]` attribute in code-behind:

```csharp
[Inject]
BlazorJSRuntime JS { get; set; }
```

### In Services

```csharp
public class MyService
{
    private readonly BlazorJSRuntime _js;

    public MyService(BlazorJSRuntime js)
    {
        _js = js;
    }

    public string GetUserAgent()
    {
        return _js.Get<string>("navigator.userAgent");
    }
}
```

### Static Access from JSObject Classes

Inside any class that inherits from `JSObject`, you can access `BlazorJSRuntime` via the protected static `JS` property:

```csharp
public class MyWrapper : JSObject
{
    public MyWrapper(IJSInProcessObjectReference _ref) : base(_ref) { }

    // JS.New calls the BlazorJSRuntime static instance
    public MyWrapper(string url) : base(JS.New("MyClass", url)) { }
}
```

---

## Basic Operations

### Get and Set Global Properties

```csharp
// Get a property value (supports dot notation)
var height = JS.Get<int>("window.innerHeight");
var title = JS.Get<string>("document.title");
var userAgent = JS.Get<string>("navigator.userAgent");

// Set a property value
JS.Set("document.title", "My Blazor App");
JS.Set("myGlobalVar", 42);

// Get a typed JSObject wrapper
using var window = JS.Get<Window>("window");
using var document = JS.Get<Document>("document");
using var navigator = JS.Get<Navigator>("navigator");
```

### Call Synchronous Methods

Use `Call<T>` for methods that return a value, `CallVoid` for void methods:

```csharp
// Call a method that returns a value
var item = JS.Call<string?>("localStorage.getItem", "myKey");

// Call a void method
JS.CallVoid("localStorage.setItem", "myKey", "myValue");
JS.CallVoid("console.log", "Hello from Blazor!");

// Call with multiple arguments
var sum = JS.Call<int>("Math.max", 10, 20);
```

### Call Asynchronous Methods (Promise-returning)

Use `CallAsync<T>` for JavaScript methods that return a Promise:

```csharp
// Fetch API - returns a Promise
using var response = await JS.CallAsync<Response>("fetch", "/api/data");
var text = await response.Text();

// Any Promise-returning method
var result = await JS.CallAsync<string>("myAsyncFunction", arg1, arg2);
```

**CRITICAL:** Using `CallAsync` on a synchronous JS method will THROW. Using `Call` on an async/Promise method will return a `Promise` object, not the resolved value. Match the call type to the JS method type.

### Create New JavaScript Objects

```csharp
// Create a new JS object using the constructor name
using var audio = JS.New<Audio>("Audio", "https://example.com/song.mp3");
using var ws = JS.New<WebSocket>("WebSocket", "wss://example.com/ws");

// Or get the IJSInProcessObjectReference directly
var rawRef = JS.New("Worker", "my-worker.js");
```

---

## Null-Conditional Operator Support

BlazorJSRuntime supports the null-conditional member access operator `?.` in JavaScript interop paths. This prevents errors when accessing properties on objects that might not exist.

```csharp
// WITHOUT null-conditional - THROWS if fruit.options does not exist
var size = JS.Get<int?>("fruit.options.size");

// WITH null-conditional - returns null (default) if fruit.options is null/undefined
var size = JS.Get<int?>("fruit.options?.size");

// Multiple levels of null-conditional
var value = JS.Get<string?>("app?.config?.settings?.theme");
```

---

## Type Checking

```csharp
// TypeOf - returns the JavaScript typeof result
string type = JS.TypeOf("someVar"); // "object", "function", "number", "undefined", etc.

// IsUndefined - check if a property is undefined
bool isUndef = JS.IsUndefined("someVar");

// ConstructorName - returns the constructor.name of a JS object
string ctorName = JS.ConstructorName("someVar"); // "Array", "Date", "Object", etc.

// ConstructorNames - returns constructor names for an array of expressions
string[] ctorNames = JS.ConstructorNames("var1", "var2", "var3");
```

---

## Loading JavaScript Scripts

```csharp
// Load a script by URL (adds a <script> tag and waits for it to load)
await JS.LoadScript("https://cdn.example.com/library.js");

// Load from wwwroot
await JS.LoadScript("js/my-script.js");

// Load from a NuGet content path
await JS.LoadScript("_content/MyPackage/my-library.js");

// ES Module import
var module = await JS.Import("./my-module.js");
```

---

## Scope Detection

When running in Web Worker contexts, you can detect the current scope:

```csharp
if (JS.IsWindow)
{
    // Running in a browser window - DOM is available
}
if (JS.IsWorker)
{
    // Running in any worker (Dedicated, Shared, or Service)
}
if (JS.IsDedicatedWorkerGlobalScope)
{
    // Running in a dedicated web worker
}
if (JS.IsSharedWorkerGlobalScope)
{
    // Running in a shared worker
}
if (JS.IsServiceWorkerGlobalScope)
{
    // Running in a service worker
}
```

See [Worker Scope Detection](worker-scopes.md) for full details.

---

## Complete Working Component Example

Below is a complete Blazor component that demonstrates the most common SpawnDev.BlazorJS patterns:

```csharp
@page "/blazorjs-demo"
@implements IDisposable
@inject BlazorJSRuntime JS

<h3>BlazorJS Demo</h3>

<div>
    <p>Window Size: @windowWidth x @windowHeight</p>
    <p>Title: @title</p>
    <p>Local Storage Value: @storedValue</p>
</div>

<div>
    <video style="width: 320px; height: 240px;" controls @ref=videoRef></video>
</div>

<pre>@log</pre>

@code {
    int windowWidth;
    int windowHeight;
    string title = "";
    string storedValue = "";
    string log = "";

    ElementReference videoRef;
    HTMLVideoElement? videoEl;

    protected override void OnInitialized()
    {
        // Get global JS properties
        windowWidth = JS.Get<int>("window.innerWidth");
        windowHeight = JS.Get<int>("window.innerHeight");
        title = JS.Get<string>("document.title");

        // Use Storage API
        using var localStorage = JS.Get<Storage>("localStorage");
        localStorage.SetItem("demo-key", "Hello from BlazorJS!");
        storedValue = localStorage.GetItem("demo-key") ?? "(empty)";

        Log("Component initialized");
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            // Convert Blazor ElementReference to typed JSObject
            videoEl = (HTMLVideoElement)videoRef;
            videoEl.OnLoadedMetadata += VideoEl_OnLoadedMetadata;
            videoEl.OnError += VideoEl_OnError;

            videoEl.Src = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
            Log("Video element ready");
        }
    }

    void VideoEl_OnLoadedMetadata()
    {
        Log($"Video metadata loaded: {videoEl!.VideoWidth}x{videoEl!.VideoHeight}");
        StateHasChanged();
    }

    void VideoEl_OnError()
    {
        Log("Video error occurred");
        StateHasChanged();
    }

    public void Dispose()
    {
        if (videoEl != null)
        {
            // IMPORTANT: Always -= before disposing
            videoEl.OnLoadedMetadata -= VideoEl_OnLoadedMetadata;
            videoEl.OnError -= VideoEl_OnError;
            videoEl.Dispose();
            videoEl = null;
        }
    }

    void Log(string message)
    {
        log += $"{DateTime.Now:HH:mm:ss} - {message}\n";
    }
}
```

---

## Next Steps

- [BlazorJSRuntime Reference](blazorjsruntime.md) - Full API reference for the interop service
- [JSObject Guide](jsobject.md) - Learn how typed wrappers work
- [Events Guide](events.md) - Master the ActionEvent pattern
- [Custom JSObject Wrappers](custom-jsobjects.md) - Wrap any JavaScript library

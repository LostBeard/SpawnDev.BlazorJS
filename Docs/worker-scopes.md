# Worker Scope Detection

SpawnDev.BlazorJS detects the JavaScript global scope at startup and exposes it through `BlazorJSRuntime`. This is critical for applications that run in both browser Window and Web Worker contexts - the same `Program.cs` handles both, but different code paths execute depending on the scope.

**Namespace:** `SpawnDev.BlazorJS`

---

## GlobalScope Enum

```csharp
public enum GlobalScope
{
    None = 0,
    Default = 0,
    Window = 1,
    DedicatedWorker = 2,
    SharedWorker = 4,
    ServiceWorker = 8,
}
```

The enum supports flags, allowing you to test for multiple scopes at once.

---

## Boolean Scope Properties

| Property | Returns `true` when... |
|---|---|
| `JS.IsWindow` | Running in a browser Window (DOM available) |
| `JS.IsWorker` | Running in any Worker scope |
| `JS.IsDedicatedWorkerGlobalScope` | Running in a Dedicated Worker |
| `JS.IsSharedWorkerGlobalScope` | Running in a Shared Worker |
| `JS.IsServiceWorkerGlobalScope` | Running in a Service Worker |

```csharp
if (JS.IsWindow)
{
    // DOM is available - can add components, access document, etc.
}

if (JS.IsWorker)
{
    // No DOM - service-only mode
    // This is true for ALL worker types
}

if (JS.IsDedicatedWorkerGlobalScope)
{
    // Dedicated Worker - has a single parent
}

if (JS.IsSharedWorkerGlobalScope)
{
    // Shared Worker - can be accessed from multiple pages
}

if (JS.IsServiceWorkerGlobalScope)
{
    // Service Worker - intercepts network requests
}
```

---

## IsScope() Method

Test for specific scope flags:

```csharp
// True if running in a Window OR a DedicatedWorker
if (JS.IsScope(GlobalScope.Window | GlobalScope.DedicatedWorker))
{
    // ...
}
```

---

## GlobalScope Property

Access the raw enum value:

```csharp
GlobalScope scope = JS.GlobalScope;

switch (scope)
{
    case GlobalScope.Window:
        Console.WriteLine("Browser window");
        break;
    case GlobalScope.DedicatedWorker:
        Console.WriteLine("Dedicated worker");
        break;
    case GlobalScope.SharedWorker:
        Console.WriteLine("Shared worker");
        break;
    case GlobalScope.ServiceWorker:
        Console.WriteLine("Service worker");
        break;
}
```

---

## Scope-Specific Global Objects

BlazorJSRuntime provides typed references to the global object based on scope:

| Property | Type | Non-null when... |
|---|---|---|
| `JS.GlobalThis` | `JSObject?` | Always (the globalThis object) |
| `JS.WindowThis` | `Window?` | `IsWindow == true` |
| `JS.DedicateWorkerThis` | `DedicatedWorkerGlobalScope?` | `IsDedicatedWorkerGlobalScope == true` |
| `JS.SharedWorkerThis` | `SharedWorkerGlobalScope?` | `IsSharedWorkerGlobalScope == true` |
| `JS.ServiceWorkerThis` | `ServiceWorkerGlobalScope?` | `IsServiceWorkerGlobalScope == true` |

---

## Program.cs Pattern

The standard pattern for scope-aware `Program.cs`:

```csharp
using SpawnDev.BlazorJS;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Get BlazorJSRuntime immediately for scope detection
builder.Services.AddBlazorJSRuntime(out var JS);

// Only add root components in Window scope
// Workers don't have a DOM - adding components would fail
if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

// Register services (available in ALL scopes)
builder.Services.AddSingleton<MyService>();

// BlazorJSRunAsync handles the difference:
// - In Window: calls RunAsync() to start Blazor renderer
// - In Worker: enters service-only mode (awaits forever)
await builder.Build().BlazorJSRunAsync();
```

### With WebWorkerService

```csharp
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazorJSRuntime(out var JS);

if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

// WebWorkerService lets you spawn workers from .NET
builder.Services.AddWebWorkerService();

// Services registered here run in BOTH Window and Worker scopes
builder.Services.AddSingleton<ComputeService>();

await builder.Build().BlazorJSRunAsync();
```

### Scope-Conditional Service Registration

```csharp
builder.Services.AddBlazorJSRuntime(out var JS);

if (JS.IsWindow)
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    // Window-only services
    builder.Services.AddSingleton<UIService>();
    builder.Services.AddSingleton<NavigationService>();
}

if (JS.IsWorker)
{
    // Worker-only services
    builder.Services.AddSingleton<BackgroundProcessingService>();
}

// Services for all scopes
builder.Services.AddSingleton<DataService>();
builder.Services.AddSingleton<CryptoService>();
```

---

## How BlazorJSRunAsync Works

`BlazorJSRunAsync()` is a scope-aware replacement for `RunAsync()`. It:

1. Starts all background services (IBackgroundService, IAsyncBackgroundService, and services registered with compatible GlobalScope values)
2. If running in a **Window** scope: calls `RunAsync()` to start the Blazor renderer
3. If running in a **Worker** scope: enters an infinite await (service-only mode) - no renderer, no components, just services

This means the same compiled WASM binary runs in both contexts, with the scope determining which code paths execute.

---

## CrossOriginIsolated

Some features (like `SharedArrayBuffer`) require cross-origin isolation:

```csharp
if (JS.CrossOriginIsolated == true)
{
    // SharedArrayBuffer is available
    // Required for multi-threaded workers with shared memory
}
```

Cross-origin isolation requires the server to send:
- `Cross-Origin-Opener-Policy: same-origin`
- `Cross-Origin-Embedder-Policy: require-corp`

---

## See Also

- [Getting Started](getting-started.md) - Program.cs setup
- [BlazorJSRuntime](blazorjsruntime.md) - Full runtime reference

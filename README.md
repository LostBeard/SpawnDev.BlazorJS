# SpawnDev.BlazorJS
[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS) 

Full Blazor WebAssembly and JavaScript interop. Over 930 strongly typed C# wrappers for browser APIs - create JavaScript objects, access properties, call methods, and handle events the .NET way without writing JavaScript.

**[Full API Documentation](Docs/README.md)** - Complete MDN-style API reference with guides, 930+ typed wrapper references, and real C# examples.

[Live Demo](https://blazorjs.spawndev.com/)

### Supported .NET Versions
- .NET 8, 9, and 10
- Blazor WebAssembly Standalone App
- Blazor Web App - Interactive WebAssembly mode without prerendering

**Note:** Version 3.x dropped support for .NET 6 and 7. Use version 2.x for those targets.

**[SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers)** is now in a separate repo.

---

## Quick Start

Two changes to `Program.cs`:

```csharp
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();

// Use BlazorJSRunAsync instead of RunAsync
await builder.Build().BlazorJSRunAsync();
```

Inject into any component or service:
```csharp
[Inject]
BlazorJSRuntime JS { get; set; }
```

Basic usage:
```csharp
// Get and Set global properties
var innerHeight = JS.Get<int>("window.innerHeight");
JS.Set("document.title", "Hello World!");

// Call global methods
var item = JS.Call<string?>("localStorage.getItem", "key");
JS.CallVoid("console.log", "Hello from Blazor!");

// Async methods (Promise-returning)
var response = await JS.CallAsync<Response>("fetch", "/api/data");

// Create new JS objects
using var audio = new Audio("song.mp3");
audio.Play();

// Typed browser API access
using var window = JS.Get<Window>("window");
window.OnResize += () => Console.WriteLine("Window resized!");

// Null-conditional member access
var size = JS.Get<int?>("fruit.options?.size");
```

For full setup details including worker scope detection and WebWorkerService, see the [Getting Started Guide](Docs/getting-started.md).

---

## Key Features

| Feature | Description | Docs |
|---|---|---|
| **930+ Typed Wrappers** | Every major browser API - DOM, WebGPU, WebRTC, WebAudio, Crypto, WebXR, and more | [API Reference](Docs/api/_index.md) |
| **BlazorJSRuntime** | Get, Set, Call, CallAsync, New - with null-conditional (`?.`) support | [Guide](Docs/blazorjsruntime.md) |
| **JSObject** | Base class for typed JS wrappers with automatic disposal | [Guide](Docs/jsobject.md) |
| **ActionEvent** | Type-safe event subscription with `+=` / `-=` and automatic ref counting | [Guide](Docs/events.md) |
| **Callbacks** | Pass .NET methods to JS - Create, CreateOne, CallbackGroup | [Guide](Docs/callbacks.md) |
| **Union Types** | TypeScript-style discriminated unions with Match, Map, Reduce | [Guide](Docs/union-types.md) |
| **Undefinable** | Distinguish `null` from `undefined` in JS interop | [Guide](Docs/undefinable.md) |
| **TypedArrays** | Full typed array support - Uint8Array, Float32Array, ArrayBuffer, etc. | [Guide](Docs/typed-arrays.md) |
| **HeapView** | Zero-copy data sharing by pinning .NET arrays in WASM memory | [Guide](Docs/heapview.md) |
| **Promises** | JS Promise wrapper - create from Task, lambda, or TaskCompletionSource | [Guide](Docs/promises.md) |
| **Worker Scopes** | Detect Window, DedicatedWorker, SharedWorker, ServiceWorker contexts | [Guide](Docs/worker-scopes.md) |
| **Custom Wrappers** | Wrap any JS library in typed C# - step-by-step guide | [Guide](Docs/custom-jsobjects.md) |
| **Disposal** | Managing JSObject, Callback, and reference lifetimes | [Guide](Docs/disposal.md) |
| **EnumString** | Bidirectional enum-to-JS-string mapping | [Guide](Docs/enumstring.md) |
| **Blazor Web App** | .NET 8+ compatibility with prerendering support | [Guide](Docs/blazor-web-app.md) |

---

## Sync vs Async - Important

SpawnDev.BlazorJS is a 1:1 mapping to JavaScript. Use the correct call type or it will throw:

| JS Method Returns | C# Call | Wrong |
|---|---|---|
| Value (sync) | `JS.Call<T>()`, `JS.Get<T>()` | `CallAsync` on sync method throws |
| Promise (async) | `JS.CallAsync<T>()` | `Call` on Promise returns wrong type |
| void (sync) | `JS.CallVoid()` | - |
| void Promise (async) | `JS.CallVoidAsync()` | `CallVoid` on async method won't await |

```csharp
// Sync JS method - use sync call
var total = JS.Call<int>("addNumbers", 20, 22);

// Async JS method or Promise-returning - use async call
var data = await JS.CallAsync<string>("fetchData");

// Async void (Promise with no return value)
await JS.CallVoidAsync("someAsyncVoidMethod");
```

See the [BlazorJSRuntime Guide](Docs/blazorjsruntime.md) for full details.

---

## Browser API Examples

### WebSocket
```csharp
using var ws = new WebSocket("wss://echo.websocket.org");
ws.BinaryType = "arraybuffer";
ws.OnOpen += () => ws.Send("Hello!");
ws.OnMessage += (MessageEvent msg) =>
{
    var data = msg.Data;
    Console.WriteLine($"Received: {data}");
};
ws.OnClose += (CloseEvent e) => Console.WriteLine($"Closed: {e.Code}");
```

### Fetch API
```csharp
using var response = await JS.CallAsync<Response>("fetch", "/api/data");
if (response.Ok)
{
    var text = await response.Text();
    Console.WriteLine(text);
}
```

### IndexedDB
```csharp
using var idbFactory = new IDBFactory();
using var db = await idbFactory.OpenAsync("myDB", 1, (evt) =>
{
    using var request = evt.Target;
    using var database = request.Result;
    database.CreateObjectStore<string, MyData>("store", new IDBObjectStoreCreateOptions { KeyPath = "id" });
});
using var tx = db.Transaction("store", "readwrite");
using var store = tx.ObjectStore<string, MyData>("store");
await store.PutAsync(new MyData { Id = "1", Name = "Test" });
```

### Web Crypto
```csharp
using var crypto = new Crypto();
using var subtle = crypto.Subtle;
using var keys = await subtle.GenerateKey<CryptoKeyPair>(
    new EcKeyGenParams { Name = "ECDSA", NamedCurve = "P-384" },
    false, new[] { "sign", "verify" });
using var signature = await subtle.Sign(
    new EcdsaParams { Hash = "SHA-384" }, keys.PrivateKey!, testData);
var valid = await subtle.Verify(
    new EcdsaParams { Hash = "SHA-384" }, keys.PublicKey!, signature, testData);
```

### ActionEvent (Event Handling)
```csharp
using var window = JS.Get<Window>("window");

// Attach event handler - reference counting is automatic
window.OnStorage += HandleStorageEvent;

// Detach - IMPORTANT: always detach before disposing to prevent leaks
window.OnStorage -= HandleStorageEvent;

void HandleStorageEvent(StorageEvent e)
{
    Console.WriteLine($"Storage changed: {e.Key}");
}
```

### Custom JSObject Wrapper
```csharp
// Wrap any JS library without writing JavaScript
public class Audio : JSObject
{
    public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
    public Audio(string url) : base(JS.New("Audio", url)) { }
    
    public string Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
    public double Volume { get => JSRef!.Get<double>("volume"); set => JSRef!.Set("volume", value); }
    public void Play() => JSRef!.CallVoid("play");
    public void Pause() => JSRef!.CallVoid("pause");
    
    public ActionEvent OnEnded { get => new ActionEvent("ended", AddEventListener, RemoveEventListener); set { } }
}
```

See the [Custom JSObject Guide](Docs/custom-jsobjects.md) for the full walkthrough.

For 930+ more typed wrappers, see the [Complete API Reference](Docs/api/_index.md).

---

## Unit Testing

This project uses Playwright .NET for unit testing in a real browser with an actual JavaScript environment.
- `SpawnDev.BlazorJS.Demo` - Demo project with unit test methods
- `PlaywrightTestRunner` - Playwright test runner project
- `PlaywrightTestRunner/_test.bat` / `_test.sh` - Build and run tests on Windows / Linux
- `.github/workflows/playwright-test-runner.yml` - CI testing on GitHub Actions

---

## Issues and Feature Requests
If you find a bug or missing properties, methods, or JavaScript objects please submit an issue [here](https://github.com/LostBeard/SpawnDev.BlazorJS/issues) on GitHub. I will help as soon as possible.

Create a new [discussion](https://github.com/LostBeard/SpawnDev.BlazorJS/discussions) to show off your projects and post your ideas.

## Support for Us
Sponsor us via GitHub Sponsors to give us more time to work on SpawnDev.BlazorJS and other open source projects. Or buy us a cup of coffee via PayPal. All support is greatly appreciated!

[![GitHub Sponsor](https://img.shields.io/github/sponsors/LostBeard?label=Sponsor&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/LostBeard)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7QTATH4UGGY9U)

Thank you to everyone who has helped support SpawnDev.BlazorJS and related projects financially, by filing issues, and by improving the code. Every bit helps!

## Demos
BlazorJS and WebWorkers Demo: https://blazorjs.spawndev.com/

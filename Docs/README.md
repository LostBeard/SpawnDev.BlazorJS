# SpawnDev.BlazorJS API Reference

Complete C# API documentation for browser APIs via Blazor WebAssembly. SpawnDev.BlazorJS provides over 1,000 strongly typed C# wrappers that mirror the [MDN Web API](https://developer.mozilla.org/en-US/docs/Web/API) surface, giving Blazor WebAssembly applications full access to every browser API without writing a single line of JavaScript.

> **MDN Mapping:** Every type listed in this documentation maps directly to its equivalent on [MDN Web Docs](https://developer.mozilla.org/en-US/docs/Web/API). Where an MDN page exists for a JavaScript API, the corresponding SpawnDev.BlazorJS wrapper implements the same properties, methods, and events with C#-idiomatic naming. When in doubt, check the MDN page for the underlying JS behavior.

[![NuGet](https://img.shields.io/nuget/dt/SpawnDev.BlazorJS.svg?label=SpawnDev.BlazorJS)](https://www.nuget.org/packages/SpawnDev.BlazorJS)

**Supported .NET Versions:** .NET 8, 9, and 10

**Live Demo:** [blazorjs.spawndev.com](https://blazorjs.spawndev.com/)

---

## Getting Started

Two changes to `Program.cs` are all you need:

```csharp
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1. Add BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();

// 2. Use BlazorJSRunAsync instead of RunAsync
await builder.Build().BlazorJSRunAsync();
```

Then inject `BlazorJSRuntime` into any component or service:

```csharp
[Inject]
BlazorJSRuntime JS { get; set; }
```

For full setup details including worker scope detection and WebWorkerService, see [Getting Started](getting-started.md).

---

## Core Concepts

These guides cover the foundational types and patterns that every SpawnDev.BlazorJS developer should understand.

| Guide | Description |
|---|---|
| [Getting Started](getting-started.md) | Installation, Program.cs setup, scope detection, first component |
| [BlazorJSRuntime](blazorjsruntime.md) | The central interop service - Get, Set, Call, CallAsync, New, and more |
| [JSObject](jsobject.md) | Base class for all typed JS wrappers - constructors, properties, methods, disposal |
| [Events (ActionEvent / FuncEvent)](events.md) | Type-safe event subscription with += / -= operators and automatic ref counting |
| [Callbacks](callbacks.md) | Making .NET methods callable from JavaScript - Create, CreateOne, CallbackGroup |
| [Union Types](union-types.md) | TypeScript-style discriminated unions - Match, Map, Reduce |
| [Undefinable](undefinable.md) | Distinguishing null from undefined in JavaScript interop |
| [TypedArrays and Data Transfer](typed-arrays.md) | Uint8Array, Float32Array, ArrayBuffer, and all typed array types |
| [HeapView (Zero-Copy)](heapview.md) | Pin .NET arrays for zero-copy JavaScript access |
| [Promises](promises.md) | JavaScript Promise wrapper - create from Task, lambda, or TaskCompletionSource |
| [Worker Scope Detection](worker-scopes.md) | IsWindow, IsWorker, GlobalScope detection for multi-context apps |
| [Custom JSObject Wrappers](custom-jsobjects.md) | Step-by-step guide to wrapping any JavaScript library |
| [Disposal and Lifetime](disposal.md) | Managing JSObject, Callback, and IJSInProcessObjectReference lifetimes |
| [EnumString](enumstring.md) | Bidirectional enum-to-string mapping for JavaScript string constants |
| [DynamicJSObject](dynamic-jsobject.md) | DynamicObject wrapper for JavaScript-like dynamic property access |
| [Blazor Web App Compatibility](blazor-web-app.md) | .NET 8+ hosting model, prerendering, and InteractiveWebAssembly render mode |

---

## Web API Reference

**[Complete Class Index (1,014 types)](api/_index.md)** - Every type documented, organized by category.

Organized by category, mirroring the [MDN Web API index](https://developer.mozilla.org/en-US/docs/Web/API) and the source folder structure. Each category links to a folder containing every class, interface, enum, and options type for that API.

| Category | Types | Key Classes |
|---|---|---|
| [DOM](api/DOM/) | 53 | [Window](api/DOM/Window.md), [Document](api/DOM/Document.md), [Element](api/DOM/Element.md), [Node](api/DOM/Node.md), [EventTarget](api/DOM/EventTarget.md), [HTMLElement](api/DOM/HTMLElement.md), [HTMLCanvasElement](api/DOM/HTMLCanvasElement.md), [HTMLVideoElement](api/DOM/HTMLVideoElement.md) |
| [WebGPU](api/WebGPU/) | 93 | [GPU](api/WebGPU/GPU.md), [GPUDevice](api/WebGPU/GPUDevice.md), [GPUBuffer](api/WebGPU/GPUBuffer.md), [GPURenderPipeline](api/WebGPU/GPURenderPipeline.md), [GPUComputePipeline](api/WebGPU/GPUComputePipeline.md), [GPUShaderModule](api/WebGPU/GPUShaderModule.md), [GPUQueue](api/WebGPU/GPUQueue.md), [GPUTexture](api/WebGPU/GPUTexture.md) |
| [WebXR](api/WebXR/) | 64 | [XRSystem](api/WebXR/XRSystem.md), [XRSession](api/WebXR/XRSession.md), [XRFrame](api/WebXR/XRFrame.md), [XRView](api/WebXR/XRView.md), [XRWebGLLayer](api/WebXR/XRWebGLLayer.md), [XRHand](api/WebXR/XRHand.md) |
| [WebAudio](api/WebAudio/) | 45 | [AudioContext](api/WebAudio/AudioContext.md), [AudioNode](api/WebAudio/AudioNode.md), [GainNode](api/WebAudio/GainNode.md), [AnalyserNode](api/WebAudio/AnalyserNode.md), [OscillatorNode](api/WebAudio/OscillatorNode.md) |
| [WebCodecs](api/WebCodecs/) | 35 | [VideoEncoder](api/WebCodecs/VideoEncoder.md), [VideoDecoder](api/WebCodecs/VideoDecoder.md), [VideoFrame](api/WebCodecs/VideoFrame.md), [AudioEncoder](api/WebCodecs/AudioEncoder.md) |
| [WebRTC](api/WebRTC/) | 31 | [RTCPeerConnection](api/WebRTC/RTCPeerConnection.md), [RTCDataChannel](api/WebRTC/RTCDataChannel.md), [RTCSessionDescription](api/WebRTC/RTCSessionDescription.md), [RTCIceCandidate](api/WebRTC/RTCIceCandidate.md) |
| [Cryptography](api/Cryptography/) | 25 | [Crypto](api/Cryptography/Crypto.md), [SubtleCrypto](api/Cryptography/SubtleCrypto.md), [CryptoKey](api/Cryptography/CryptoKey.md), [CryptoKeyPair](api/Cryptography/CryptoKeyPair.md) |
| [WebGL](api/WebGL/) | 19 | [WebGLRenderingContext](api/WebGL/WebGLRenderingContext.md), [WebGL2RenderingContext](api/WebGL/WebGL2RenderingContext.md), [WebGLBuffer](api/WebGL/WebGLBuffer.md), [WebGLProgram](api/WebGL/WebGLProgram.md) |
| [USB](api/USB/) | 16 | [USB](api/USB/USB.md), [USBDevice](api/USB/USBDevice.md), [USBConfiguration](api/USB/USBConfiguration.md), [USBInterface](api/USB/USBInterface.md) |
| [TypedArrays](api/TypedArrays/) | 13 | [TypedArray](api/TypedArrays/TypedArray.md), [Uint8Array](api/TypedArrays/Uint8Array.md), [Float32Array](api/TypedArrays/Float32Array.md), [Int32Array](api/TypedArrays/Int32Array.md) |
| [Bluetooth](api/Bluetooth/) | 12 | [Bluetooth](api/Bluetooth/Bluetooth.md), [BluetoothDevice](api/Bluetooth/BluetoothDevice.md), [BluetoothRemoteGATTServer](api/Bluetooth/BluetoothRemoteGATTServer.md) |
| [Speech](api/Speech/) | 12 | [SpeechRecognition](api/Speech/SpeechRecognition.md), [SpeechSynthesis](api/Speech/SpeechSynthesis.md), [SpeechSynthesisUtterance](api/Speech/SpeechSynthesisUtterance.md) |
| [Serial](api/Serial/) | 10 | [Serial](api/Serial/Serial.md), [SerialPort](api/Serial/SerialPort.md) |
| [Presentation](api/Presentation/) | 8 | [Presentation](api/Presentation/Presentation.md), [PresentationConnection](api/Presentation/PresentationConnection.md) |
| [MediaSession](api/MediaSession/) | 6 | [MediaSession](api/MediaSession/MediaSession.md), [MediaMetadata](api/MediaSession/MediaMetadata.md) |
| [PaymentRequest](api/PaymentRequest/) | 6 | [PaymentRequest](api/PaymentRequest/PaymentRequest.md), [PaymentResponse](api/PaymentRequest/PaymentResponse.md) |
| [Reporting](api/Reporting/) | 7 | [ReportingObserver](api/Reporting/ReportingObserver.md), [Report](api/Reporting/Report.md) |
| [ShapeDetection](api/ShapeDetection/) | 5 | [BarcodeDetector](api/BarcodeDetector.md), [FaceDetector](api/ShapeDetection/FaceDetector.md) |
| [WebTransport](api/WebTransport/) | 5 | [WebTransport](api/WebTransport/WebTransport.md) |
| [Performance](api/Performance/) | 4 | [Performance](api/Performance.md), [PerformanceEntry](api/Performance/PerformanceEntry.md) |
| [IntersectionObserver](api/IntersectionObserver/) | 3 | [IntersectionObserver](api/IntersectionObserver/IntersectionObserver.md) |
| [EyeDropper](api/EyeDropper/) | 3 | [EyeDropper](api/EyeDropper/EyeDropper.md) |
| [Compression](api/Compression/) | 2 | [CompressionStream](api/Compression/CompressionStream.md), [DecompressionStream](api/Compression/DecompressionStream.md) |
| [PictureInPicture](api/PictureInPicture/) | 2 | [PictureInPictureWindow](api/PictureInPicture/PictureInPictureWindow.md) |
| [IdleDetection](api/IdleDetection/) | 2 | [IdleDetector](api/IdleDetection/IdleDetector.md) |
| [General (Root)](api/) | 530+ | [WebSocket](api/WebSocket.md), [Worker](api/Worker.md), [Blob](api/Blob.md), [File](api/File.md), [Request](api/Request.md), [Response](api/Response.md), [Navigator](api/Navigator.md), [URL](api/URL.md), [Promise](api/Promise.md), [Array](api/Array.md), [Atomics](api/Atomics.md), [Cache](api/Cache.md), [Notification](api/Notification.md), [MediaStream](api/MediaStream.md), [Gamepad](api/Gamepad.md), and [many more...](api/_index.md) |

---

## SpawnDev.BlazorJS Core Types

These are library-specific types that provide the interop foundation.

| Type | Description |
|---|---|
| [BlazorJSRuntime](api/BlazorJSRuntime.md) | Central interop service - global JS access, scope detection, script loading |
| [JSObject](api/JSObject.md) | Base class for all 1,000+ typed JavaScript wrappers |
| [Callback](api/Callback.md) | Makes .NET methods callable from JavaScript - ref-counted, disposable |
| [ActionEvent](api/ActionEvent.md) | Event subscription with += / -= operators for Action delegates |
| [FuncEvent](api/FuncEvent.md) | Event subscription with += / -= operators for Func delegates |
| [CallbackGroup](api/CallbackGroup.md) | Batch disposal container for multiple Callbacks |
| [Union](api/Union.md) | TypeScript-style discriminated union types (Union\<T1,T2\> through Union\<T1...T8\>) |
| [Undefinable](api/Undefinable.md) | Distinguish JavaScript null from undefined |
| [EnumString](api/EnumString.md) | Bidirectional enum-to-JS-string mapping |
| [DynamicJSObject](api/DynamicJSObject.md) | DynamicObject wrapper for JavaScript-like dynamic access |
| [EpochDateTime](api/EpochDateTime.md) | Unix epoch timestamp conversion |
| [FluentUsing](api/FluentUsing.md) | LINQ-style IDisposable extension methods |

---

## Additional Resources

- **GitHub:** [github.com/LostBeard/SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS)
- **NuGet:** [nuget.org/packages/SpawnDev.BlazorJS](https://www.nuget.org/packages/SpawnDev.BlazorJS)
- **Live Demo:** [blazorjs.spawndev.com](https://blazorjs.spawndev.com/)
- **Issues:** [github.com/LostBeard/SpawnDev.BlazorJS/issues](https://github.com/LostBeard/SpawnDev.BlazorJS/issues)
- **Web Workers:** [github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers) (separate package)

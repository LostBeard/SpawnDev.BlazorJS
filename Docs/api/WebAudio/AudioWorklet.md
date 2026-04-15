# AudioWorklet

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/AudioWorklet.cs`  
**MDN Reference:** [AudioWorklet on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioWorklet)

> The AudioWorklet interface of the Web Audio API is used to supply custom audio processing scripts that execute in a separate thread to provide very low latency audio processing. https://developer.mozilla.org/en-US/docs/Web/API/AudioWorklet

## Constructors

| Signature | Description |
|---|---|
| `AudioWorklet(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AddModule(string moduleURL)` | `Task` | Adds the module at the specified URL to the AudioWorklet scope. A string containing the URL of a JavaScript module to add. |
| `AddModule(string moduleURL, object options)` | `Task` | Adds the module at the specified URL to the AudioWorklet scope. A string containing the URL of a JavaScript module to add. An object that can contain the credentials property with a value of "omit", "same-origin", or "include". |


# AudioTimestamp

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/AudioTimestamp.cs`  
**MDN Reference:** [AudioTimestamp on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/getOutputTimestamp#return_value)

> Returned from AudioContext.GetOutputTimestamp() https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/getOutputTimestamp#return_value

## Constructors

| Signature | Description |
|---|---|
| `AudioTimestamp(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ContextTime` | `double` | get | contextTime: A point in the time coordinate system of the currentTime for the BaseAudioContext; the time after the audio context was first created. |
| `PerformanceTime` | `double` | get | performanceTime: A point in the time coordinate system of a Performance interface; the time after the document containing the audio context was first rendered |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioTimestamp>(...)` or constructor `new AudioTimestamp(...)`

```js
// Press the play button
playBtn.addEventListener("click", () => {
  // We can create the audioCtx as there has been some user action
  audioCtx ??= new AudioContext();
  source = new AudioBufferSourceNode(audioCtx);
  getData();
  source.start(0);
  playBtn.disabled = true;
  stopBtn.disabled = false;
  rAF = requestAnimationFrame(outputTimestamps);
});

// Press the stop button
stopBtn.addEventListener("click", () => {
  source.stop(0);
  playBtn.disabled = false;
  stopBtn.disabled = true;
  cancelAnimationFrame(rAF);
});

// Helper function to output timestamps
function outputTimestamps() {
  const ts = audioCtx.getOutputTimestamp();
  output.textContent = `Context time: ${ts.contextTime} | Performance time: ${ts.performanceTime}`;
  rAF = requestAnimationFrame(outputTimestamps); // Reregister itself
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/getOutputTimestamp)*


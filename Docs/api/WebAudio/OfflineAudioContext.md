# OfflineAudioContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `BaseAudioContext`  
**Source:** `JSObjects/WebAudio/OfflineAudioContext.cs`  
**MDN Reference:** [OfflineAudioContext on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioContext)

> The OfflineAudioContext interface is an AudioContext interface representing an audio-processing graph built from linked together AudioNodes. In contrast to a standard AudioContext, an OfflineAudioContext doesn't render the audio to the device hardware; instead, it generates it, as fast as it can, and outputs the result to an AudioBuffer. https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioContext

## Constructors

| Signature | Description |
|---|---|
| `OfflineAudioContext(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `OfflineAudioContext(int numberOfChannels, long length, float sampleRate)` | Creates a new OfflineAudioContext instance. An integer specifying the number of channels for this context. An integer specifying the length of the buffer to be created, in sample-frames. A floating-point number specifying the sample-rate, in samples per second, of the audio data. |
| `OfflineAudioContext(OfflineAudioContextOptions options)` | Creates a new OfflineAudioContext instance. An object specifying the options for the new context. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `long` | get | Returns a integer representing the length of the buffer in sample-frames. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Suspend(double suspendTime)` | `Task` | Schedules a suspension of the time progression in the audio context at the specified time and returns a promise. A floating-point number specifying the time in seconds at which the context should be suspended. |
| `StartRendering()` | `Task<AudioBuffer>` | Starts rendering the audio graph, taking into account the current connections and the current scheduled changes. A Promise that resolves with a rendered AudioBuffer. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnComplete` | `ActionEvent<OfflineAudioCompletionEvent>` | Fired when the render is complete. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<OfflineAudioContext>(...)` or constructor `new OfflineAudioContext(...)`

### Playing audio with an offline audio context

```js
// Define both online and offline audio contexts
let audioCtx; // Must be initialized after a user interaction
const offlineCtx = new OfflineAudioContext(2, 44100 * 40, 44100);

// Define constants for dom nodes
const play = document.querySelector("#play");

function getData() {
  // Fetch an audio track, decode it and stick it in a buffer.
  // Then we put the buffer into the source and can play it.
  fetch("viper.ogg")
    .then((response) => response.arrayBuffer())
    .then((downloadedBuffer) => audioCtx.decodeAudioData(downloadedBuffer))
    .then((decodedBuffer) => {
      console.log("File downloaded successfully.");
      const source = new AudioBufferSourceNode(offlineCtx, {
        buffer: decodedBuffer,
      });
      source.connect(offlineCtx.destination);
      return source.start();
    })
    .then(() => offlineCtx.startRendering())
    .then((renderedBuffer) => {
      console.log("Rendering completed successfully.");
      play.disabled = false;
      const song = new AudioBufferSourceNode(audioCtx, {
        buffer: renderedBuffer,
      });
      song.connect(audioCtx.destination);

      // Start the song
      song.start();
    })
    .catch((err) => {
      console.error(`Error encountered: ${err}`);
    });
}

// Activate the play button
play.onclick = () => {
  play.disabled = true;
  // We can initialize the context as the user clicked.
  audioCtx = new AudioContext();

  // Fetch the data and start the song
  getData();
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioContext)*


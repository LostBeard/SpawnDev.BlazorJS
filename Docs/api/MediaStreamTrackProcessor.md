# MediaStreamTrackProcessor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaStreamTrackProcessor.cs`  
**MDN Reference:** [MediaStreamTrackProcessor on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackProcessor)

> The MediaStreamTrackProcessor interface of the Insertable Streams for MediaStreamTrack API consumes a video MediaStreamTrack object's source and generates a stream of VideoFrame objects. https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackProcessor

## Constructors

| Signature | Description |
|---|---|
| `MediaStreamTrackProcessor(MediaStreamTrackProcessorOptions options)` | The MediaStreamTrackProcessor() constructor creates a new MediaStreamTrackProcessor object which consumes a video MediaStreamTrack object's source and generates a stream of VideoFrames. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Readable` | `ReadableStream` | get | The readable property of the MediaStreamTrackProcessor interface returns a ReadableStream of VideoFrames. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaStreamTrackProcessor>(...)` or constructor `new MediaStreamTrackProcessor(...)`

```js
const stream = await navigator.mediaDevices.getUserMedia({ video: true });
const [track] = stream.getVideoTracks();
const worker = new Worker("worker.js");
worker.postMessage({ track }, [track]);
const { data } = await new Promise((r) => {
  worker.onmessage = r;
});
video.srcObject = new MediaStream([data.track]);
```

```js
onmessage = async ({ data: { track } }) => {
  const vtg = new VideoTrackGenerator();
  self.postMessage({ track: vtg.track }, [vtg.track]);
  const { readable } = new MediaStreamTrackProcessor({ track });
  await readable
    .pipeThrough(new TransformStream({ transform }))
    .pipeTo(vtg.writable);
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackProcessor)*


# VideoTrackGenerator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/VideoTrackGenerator.cs`  
**MDN Reference:** [VideoTrackGenerator on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackGenerator)

> The VideoTrackGenerator interface of the Insertable Streams for MediaStreamTrack API has a WritableStream property that acts as a MediaStreamTrack source, by consuming a stream of VideoFrames as input. https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackGenerator

## Constructors

| Signature | Description |
|---|---|
| `VideoTrackGenerator()` | The VideoTrackGenerator() constructor creates a new VideoTrackGenerator object which consumes a stream of media frames and exposes a MediaStreamTrack. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Muted` | `bool` | get | A Boolean property to temporarily halt or resume the generation of video frames in the output track. |
| `MediaStreamTrack` | `MediaStreamTrack` | get | The output MediaStreamTrack. |
| `Writable` | `WritableStream` | get | The input WritableStream. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoTrackGenerator>(...)` or constructor `new VideoTrackGenerator(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackGenerator)*


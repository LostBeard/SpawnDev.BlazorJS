# MediaStreamTrackGenerator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MediaStreamTrack`  
**Source:** `JSObjects/MediaStreamTrackGenerator.cs`  
**MDN Reference:** [MediaStreamTrackGenerator on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator)

> The MediaStreamTrackGenerator interface of the Insertable Streams for MediaStreamTrack API creates a WritableStream that acts as a MediaStreamTrack source. The object consumes a stream of media frames as input, which can be audio or video frames. https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator

## Constructors

| Signature | Description |
|---|---|
| `MediaStreamTrackGenerator(MediaStreamTrackGeneratorOptions options)` | The MediaStreamTrackGenerator() constructor creates a new MediaStreamTrackGenerator object which consumes a stream of media frames and exposes a MediaStreamTrack. An object containing the property kind |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Writable` | `WritableStream` | get | The writable property of the MediaStreamTrackGenerator interface returns a WritableStream. This allows the writing of media frames to the MediaStreamTrackGenerator. The frames will be audio or video. The type is dictated by the kind of MediaStreamTrackGenerator that was created. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaStreamTrackGenerator>(...)` or constructor `new MediaStreamTrackGenerator(...)`

```js
const stream = await getUserMedia({ video: true });
const videoTrack = stream.getVideoTracks()[0];

const trackProcessor = new MediaStreamTrackProcessor({ track: videoTrack });
const trackGenerator = new MediaStreamTrackGenerator({ kind: "video" });

const transformer = new TransformStream({
  async transform(videoFrame, controller) {
    const barcodes = await detectBarcodes(videoFrame);
    const newFrame = highlightBarcodes(videoFrame, barcodes);
    videoFrame.close();
    controller.enqueue(newFrame);
  },
});

trackProcessor.readable
  .pipeThrough(transformer)
  .pipeTo(trackGenerator.writable);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator)*


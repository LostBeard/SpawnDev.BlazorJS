# SourceBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/SourceBuffer.cs`  
**MDN Reference:** [SourceBuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SourceBuffer)

> The SourceBuffer interface represents a chunk of media to be passed into an HTMLMediaElement and played, via a MediaSource object. This can be made up of one or several media segments. https://developer.mozilla.org/en-US/docs/Web/API/SourceBuffer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AppendWindowEnd` | `double` | get | Controls the timestamp for the end of the append window. |
| `AppendWindowStart` | `double` | get | Controls the timestamp for the start of the append window. This is a timestamp range that can be used to filter what media data is appended to the SourceBuffer. Coded media frames with timestamps within this range will be appended, whereas those outside the range will be filtered out. |
| `AudioTracks` | `AudioTrackList` | get | A list of the audio tracks currently contained inside the SourceBuffer. |
| `Buffered` | `TimeRanges` | get | Returns the time ranges that are currently buffered in the SourceBuffer. |
| `Mode` | `string` | get | Controls how the order of media segments in the SourceBuffer is handled, in terms of whether they can be appended in any order, or they have to be kept in a strict sequence. The two available values are: segments - The media segment timestamps determine the order in which the segments are played.The segments can be appended to the SourceBuffer in any order. sequence - The order in which the segments are appended to the SourceBuffer determines the order in which they are played. Segment timestamps are generated automatically for the segments that observe this order. |
| `TextTracks` | `TextTrackList` | get | A list of the text tracks currently contained inside the SourceBuffer. |
| `TimestampOffset` | `double` | get | Controls the offset applied to timestamps inside media segments that are subsequently appended to the SourceBuffer. |
| `Updating` | `bool` | get | A boolean indicating whether the SourceBuffer is currently being updated - i.e., whether an appendBuffer() or remove() operation is currently in progress. |
| `VideoTracks` | `VideoTrackList` | get | A list of the video tracks currently contained inside the SourceBuffer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Abort()` | `void` | Aborts the current segment and resets the segment parser. |
| `AppendBuffer(ArrayBuffer source)` | `void` | Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. |
| `AppendBuffer(TypedArray source)` | `void` | Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. |
| `AppendBuffer(byte[] source)` | `void` | Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. |
| `AppendBuffer(DataView source)` | `void` | Appends media segment data from an ArrayBuffer, a TypedArray or a DataView object to the SourceBuffer. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. |
| `AppendBufferAsync(ArrayBuffer source)` | `Task` | Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated. |
| `AppendBufferAsync(TypedArray source)` | `Task` | Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated. |
| `AppendBufferAsync(byte[] source)` | `Task` | Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated. |
| `AppendBufferAsync(DataView source)` | `Task` | Starts the process of asynchronously appending the specified buffer to the SourceBuffer. Returns a Promise which is fulfilled once the buffer has been appended. Either an ArrayBuffer, a TypedArray or a DataView object that contains the media segment data you want to add to the SourceBuffer. A Promise which is fulfilled when the buffer has been added successfully to the SourceBuffer object, or null, if the request could not be initiated. |
| `ChangeType(string type)` | `void` | Changes the MIME type that future calls to appendBuffer() will expect the new data to conform to. A string specifying the MIME type that future buffers will conform to. |
| `Remove(double start, double end)` | `void` | Removes media segments within a specific time range from the SourceBuffer. A double representing the start of the time range, in seconds. A double representing the end of the time range, in seconds. |
| `RemoveAsync(double start, double end)` | `Task` | Starts the process of asynchronously removing media segments in the specified range from the SourceBuffer. Returns a Promise which is fulfilled once all matching segments have been removed. A double representing the start of the time range, in seconds. A double representing the end of the time range, in seconds. A Promise whose fulfillment handler is executed once the buffers in the specified time range have been removed from the SourceBuffer. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<Event>` | Fired when the buffer appending is aborted, because the SourceBuffer.abort() or MediaSource.removeSourceBuffer() method is called while the SourceBuffer.appendBuffer() algorithm is still running. SourceBuffer.updating changes from true to false. |
| `OnError` | `ActionEvent<Event>` | Fired when an error occurs during the processing of an appendBuffer() operation. SourceBuffer.updating changes from true to false. |
| `OnUpdate` | `ActionEvent<Event>` | Fired whenever SourceBuffer.appendBuffer() or SourceBuffer.remove() completes. SourceBuffer.updating changes from true to false. |
| `OnUpdateEnd` | `ActionEvent<Event>` | Fired after the (not necessarily successful) completion of an appendBuffer() or remove() operation. This event is fired after the update, error, or abort events. |
| `OnUpdateStart` | `ActionEvent<Event>` | Fired when an appendBuffer() or remove() operation begins. updating changes from false to true. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SourceBuffer>(...)` or constructor `new SourceBuffer(...)`

### Loading a video chunk by chunk

```js
const video = document.querySelector("video");

const assetURL = "frag_bunny.mp4";
// Need to be specific for Blink regarding codecs
const mimeCodec = 'video/mp4; codecs="avc1.42E01E, mp4a.40.2"';

function loadVideo() {
  if (MediaSource.isTypeSupported(mimeCodec)) {
    const mediaSource = new MediaSource();
    console.log(mediaSource.readyState); // closed
    video.src = URL.createObjectURL(mediaSource);
    mediaSource.addEventListener("sourceopen", sourceOpen);
  } else {
    console.error("Unsupported MIME type or codec: ", mimeCodec);
  }
}

async function sourceOpen() {
  console.log(this.readyState); // open
  const sourceBuffer = this.addSourceBuffer(mimeCodec);
  const response = await fetch(assetURL);
  const buffer = await response.arrayBuffer();
  sourceBuffer.addEventListener("updateend", () => {
    this.endOfStream();
    video.play();
    console.log(this.readyState); // ended
  });
  sourceBuffer.appendBuffer(buffer);
}

const load = document.querySelector("#load");
load.addEventListener("click", loadVideo);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SourceBuffer)*


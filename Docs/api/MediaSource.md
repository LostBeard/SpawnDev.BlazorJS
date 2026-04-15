# MediaSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MediaSource.cs`  
**MDN Reference:** [MediaSource on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaSource)

> The MediaSource interface of the Media Source Extensions API represents a source of media data for an HTMLMediaElement object. A MediaSource object can be attached to a HTMLMediaElement to be played in the user agent. https://developer.mozilla.org/en-US/docs/Web/API/MediaSource

## Constructors

| Signature | Description |
|---|---|
| `MediaSource(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MediaSource()` | The MediaSource() constructor of the MediaSource interface constructs and returns a new MediaSource object with no associated source buffers. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ActiveSourceBuffers` | `SourceBufferList` | get | Returns a SourceBufferList object containing a subset of the SourceBuffer objects contained within MediaSource.sourceBuffers - the list of objects providing the selected video track, enabled audio tracks, and shown/hidden text tracks. |
| `Duration` | `double` | get | Gets and sets the duration of the current media being presented. |
| `Handle` | `MediaSourceHandle?` | get | Inside a dedicated worker, returns a MediaSourceHandle object, a proxy for the MediaSource that can be transferred from the worker back to the main thread and attached to a media element via its HTMLMediaElement.srcObject property. |
| `ReadyState` | `string` | get | Returns an enum representing the state of the current MediaSource, whether it is not currently attached to a media element (closed), attached and ready to receive SourceBuffer objects (open), or attached but the stream has been ended via MediaSource.endOfStream() (ended.) |
| `SourceBuffers` | `SourceBufferList` | get | Returns a SourceBufferList object containing the list of SourceBuffer objects associated with this MediaSource. |
| `CanConstructInDedicatedWorker` | `bool` | get | A boolean; returns true if MediaSource worker support is implemented, providing a low-latency feature detection mechanism. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsTypeSupported(string type)` | `bool` | Returns a boolean value indicating if the given MIME type is supported by the current user agent - this is, if it can successfully create SourceBuffer objects for that MIME type. |
| `AddSourceBuffer(string mimeType)` | `SourceBuffer` | The addSourceBuffer() method of the MediaSource interface creates a new SourceBuffer of the given MIME type and adds it to the MediaSource's sourceBuffers list. The new SourceBuffer is also returned. A string specifying the MIME type of the SourceBuffer to create and add to the MediaSource. A SourceBuffer object representing the new source buffer that has been created and added to the media source. |
| `ClearLiveSeekableRange()` | `void` | The clearLiveSeekableRange() method of the MediaSource interface clears a seekable range previously set with a call to setLiveSeekableRange(). |
| `EndOfStream(string endOfStreamError)` | `void` | The endOfStream() method of the MediaSource interface signals the end of the stream. A string representing an error to throw when the end of the stream is reached. The possible values are: network - Terminates playback and signals that a network error has occurred.This can be used create a custom error handler related to media streams.For example, you might have a function that handles media chunk requests, separate from other network requests.When you make a fetch() request for a media chunk and receive a network error, you might want to call endOfStream('network'), display a descriptive message in the UI, and maybe retry the network request immediately or wait until the network is back up(via some kind of polling.) decode - Terminates playback and signals that a decoding error has occurred.This can be used to indicate that a parsing error has occurred while fetching media data; maybe the data is corrupt, or is encoded using a codec that the browser doesn't know how to decode. |
| `EndOfStream()` | `void` | The endOfStream() method of the MediaSource interface signals the end of the stream. |
| `RemoveSourceStream(SourceBuffer sourceBuffer)` | `void` | The removeSourceBuffer() method of the MediaSource interface removes the given SourceBuffer from the SourceBufferList associated with this MediaSource object. |
| `SetLiveSeekableRange(double start, double end)` | `void` | The setLiveSeekableRange() method of the MediaSource interface sets the range that the user can seek to in the media element. The start of the seekable range to set in seconds measured from the beginning of the source. If the duration of the media source is positive infinity, then the TimeRanges object returned by the HTMLMediaElement.seekable property will have a start timestamp no greater than this value. The end of the seekable range to set in seconds measured from the beginning of the source. If the duration of the media source is positive infinity, then the TimeRanges object returned by the HTMLMediaElement.seekable property will have an end timestamp no less than this value. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnSourceClose` | `ActionEvent<Event>` | Fired when the MediaSource instance is not attached to a media element anymore. |
| `OnSourceEnded` | `ActionEvent<Event>` | Fired when the MediaSource instance is still attached to a media element, but endOfStream() has been called. |
| `OnSourceOpen` | `ActionEvent<Event>` | Fired when the MediaSource instance has been opened by a media element and is ready for data to be appended to the SourceBuffer objects in sourceBuffers. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaSource>(...)` or constructor `new MediaSource(...)`

### Complete basic example

```js
const video = document.querySelector("video");

const assetURL = "frag_bunny.mp4";
// Need to be specific for Blink regarding codecs
// ./mp4info frag_bunny.mp4 | grep Codec
const mimeCodec = 'video/mp4; codecs="avc1.42E01E, mp4a.40.2"';
let mediaSource;

if ("MediaSource" in window && MediaSource.isTypeSupported(mimeCodec)) {
  mediaSource = getMediaSource();
  console.log(mediaSource.readyState); // closed
  video.src = URL.createObjectURL(mediaSource);
  mediaSource.addEventListener("sourceopen", sourceOpen);
} else {
  console.error("Unsupported MIME type or codec: ", mimeCodec);
}

function sourceOpen() {
  console.log(this.readyState); // open
  const sourceBuffer = mediaSource.addSourceBuffer(mimeCodec);
  fetchAB(assetURL, (buf) => {
    sourceBuffer.addEventListener("updateend", () => {
      mediaSource.endOfStream();
      video.play();
      console.log(mediaSource.readyState); // ended
    });
    sourceBuffer.appendBuffer(buf);
  });
}

function fetchAB(url, cb) {
  console.log(url);
  const xhr = new XMLHttpRequest();
  xhr.open("get", url);
  xhr.responseType = "arraybuffer";
  xhr.onload = () => {
    cb(xhr.response);
  };
  xhr.send();
}
```

### Constructing a `MediaSource` in a dedicated worker and passing it to the main thread

```js
// Inside dedicated worker
let mediaSource = new MediaSource();
let handle = mediaSource.handle;
// Transfer the handle to the context that created the worker
postMessage({ arg: handle }, [handle]);

mediaSource.addEventListener("sourceopen", () => {
  // Await sourceopen on MediaSource before creating SourceBuffers
  // and populating them with fetched media — MediaSource won't
  // accept creation of SourceBuffers until it is attached to the
  // HTMLMediaElement and its readyState is "open"
});
```

### Constructing a `MediaSource` in a dedicated worker and passing it to the main thread

```js
worker.addEventListener("message", (msg) => {
  let mediaSourceHandle = msg.data.arg;
  video.srcObject = mediaSourceHandle;
  video.play();
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaSource)*


# TrackEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/TrackEvent.cs`  
**MDN Reference:** [TrackEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TrackEvent)

> The TrackEvent interface of the HTML DOM API is used for events which represent changes to a set of available tracks on an HTML media element; these events are addtrack and removetrack. https://developer.mozilla.org/en-US/docs/Web/API/TrackEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Track` | `MediaTrack` | get | The DOM track object the event is in reference to. If not null, this is always an object of one of the media track types: AudioTrack, VideoTrack, or TextTrack). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<TrackEvent>(...)` or constructor `new TrackEvent(...)`

```js
const videoElem = document.querySelector("video");

videoElem.videoTracks.addEventListener("addtrack", handleTrackEvent);
videoElem.videoTracks.addEventListener("removetrack", handleTrackEvent);
videoElem.audioTracks.addEventListener("addtrack", handleTrackEvent);
videoElem.audioTracks.addEventListener("removetrack", handleTrackEvent);
videoElem.textTracks.addEventListener("addtrack", handleTrackEvent);
videoElem.textTracks.addEventListener("removetrack", handleTrackEvent);

function handleTrackEvent(event) {
  let trackKind;

  if (event.target instanceof VideoTrackList) {
    trackKind = "video";
  } else if (event.target instanceof AudioTrackList) {
    trackKind = "audio";
  } else if (event.target instanceof TextTrackList) {
    trackKind = "text";
  } else {
    trackKind = "unknown";
  }

  switch (event.type) {
    case "addtrack":
      console.log(`Added a ${trackKind} track`);
      break;
    case "removetrack":
      console.log(`Removed a ${trackKind} track`);
      break;
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TrackEvent)*


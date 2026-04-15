# VideoTrackList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IEnumerable<VideoTrack>`  
**Source:** `JSObjects/VideoTrackList.cs`  
**MDN Reference:** [VideoTrackList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackList)

> The VideoTrackList interface is used to represent a list of the video tracks contained within a &lt;video> element, with each track represented by a separate VideoTrack object in the list. Retrieve an instance of this object with HTMLMediaElement.videoTracks. The individual tracks can be accessed using array syntax or functions such as forEach() for example. https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of track objects in the list. |
| `SelectedIndex` | `int` | get | The index of the currently selected track, if any, or −1 otherwise. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<VideoTrack>` |  |
| `GetTrackById(string id)` | `VideoTrack?` | Returns the track found within the list whose id matches the specified string. If no match is found, null is returned. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAddTrack` | `ActionEvent<TrackEvent>` | Fired when a new track has been added to the media element. |
| `OnChange` | `ActionEvent<Event>` | Fired when a track has been enabled or disabled. |
| `OnRemoveTrack` | `ActionEvent<TrackEvent>` | Fired when a track has been removed from the media element. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoTrackList>(...)` or constructor `new VideoTrackList(...)`

### Getting a media element's video track list

```js
const videoTracks = document.querySelector("video").videoTracks;
```

### Monitoring track count changes

```js
videoTracks.onaddtrack = updateTrackCount;
videoTracks.onremovetrack = updateTrackCount;

function updateTrackCount(event) {
  trackCount = videoTracks.length;
  drawTrackCountIndicator(trackCount);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackList)*


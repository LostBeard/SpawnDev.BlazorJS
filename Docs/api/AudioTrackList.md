# AudioTrackList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IEnumerable<AudioTrack>`  
**Source:** `JSObjects/AudioTrackList.cs`  
**MDN Reference:** [AudioTrackList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioTrackList)

> The AudioTrackList interface is used to represent a list of the audio tracks contained within a given HTML media element, with each track represented by a separate AudioTrack object in the list. Retrieve an instance of this object with HTMLMediaElement.audioTracks. The individual tracks can be accessed using array syntax. https://developer.mozilla.org/en-US/docs/Web/API/AudioTrackList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of track objects in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<AudioTrack>` |  |
| `GetTrackById(string id)` | `AudioTrack?` | Returns the track found within the list whose id matches the specified string. If no match is found, null is returned. |

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
> - Access via `JS.Get<AudioTrackList>(...)` or constructor `new AudioTrackList(...)`

### Getting a media element's audio track list

```js
const audioTracks = document.querySelector("video").audioTracks;
```

### Monitoring track count changes

```js
audioTracks.onaddtrack = updateTrackCount;
audioTracks.onremovetrack = updateTrackCount;

function updateTrackCount(event) {
  trackCount = audioTracks.length;
  drawTrackCountIndicator(trackCount);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioTrackList)*


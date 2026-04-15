# TextTrackList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IEnumerable<TextTrack>`  
**Source:** `JSObjects/TextTrackList.cs`  
**MDN Reference:** [TextTrackList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextTrackList)

> The TextTrackList interface is used to represent a list of the text tracks defined for the associated video or audio element, with each track represented by a separate TextTrack object in the list. Text tracks can be added to a media element declaratively using the &lt;track> element or programmatically using the HTMLMediaElement.addTextTrack() method. An instance of this object can be retrieved using the textTracks property of an HTMLMediaElement object. https://developer.mozilla.org/en-US/docs/Web/API/TextTrackList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of track objects in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<TextTrack>` |  |
| `GetTrackById(string id)` | `TextTrack?` | Returns the track found within the list whose id matches the specified string. If no match is found, null is returned. |

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
> - Access via `JS.Get<TextTrackList>(...)` or constructor `new TextTrackList(...)`

### Getting a video element's text track list

```js
const textTracks = document.querySelector("video").textTracks;
```

### Monitoring track count changes

```js
textTracks.onaddtrack = updateTrackCount;
textTracks.onremovetrack = updateTrackCount;

function updateTrackCount(event) {
  trackCount = textTracks.length;
  drawTrackCountIndicator(trackCount);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextTrackList)*


# TextTrackCueList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`, `IEnumerable<TextTrackCue>`  
**Source:** `JSObjects/TextTrackCueList.cs`  
**MDN Reference:** [TextTrackCueList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCueList)

> The TextTrackCueList interface of the WebVTT API is an array-like object that represents a dynamically updating list of TextTrackCue objects. An instance of this type is obtained from TextTrack.cues in order to get all the cues in the TextTrack object. This interface has no constructor. https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCueList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | An unsigned long that is the number of cues in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<TextTrackCue>` |  |
| `GetCueById(string id)` | `TextTrackCue?` | Returns the first TextTrackCue object with the identifier passed to it. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<TextTrackCueList>(...)` or constructor `new TextTrackCueList(...)`

```js
const video = document.getElementById("video");
video.onplay = () => {
  console.log(video.textTracks[0].cues);
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCueList)*


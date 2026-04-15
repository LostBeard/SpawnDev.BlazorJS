# VTTCue

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `TextTrackCue`  
**Source:** `JSObjects/VTTCue.cs`  
**MDN Reference:** [VTTCue on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VTTCue)

> The VTTCue interface of the WebVTT API represents a cue that can be added to the text track associated with a particular video (or other media). A cue defines the text to display in a particular timeslice of a video or audio track, along with display properties such as its size, alignment, and position. https://developer.mozilla.org/en-US/docs/Web/API/VTTCue

## Constructors

| Signature | Description |
|---|---|
| `VTTCue(double startTime, double endTime, string text)` | Creates a new VTTCue object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Region` | `VTTRegion?` | get/set | The VTTRegion to which the cue belongs, or null if it doesn't belong to any. |
| `Vertical` | `string` | get | A string that represents the vertical setting of the cue. |
| `SnapToLines` | `bool` | get | A boolean for whether the line is relative to the video or is an absolute line number. |
| `Line` | `Union<double, string>` | get/set | A double that represents the line number or the percentage of the video height. |
| `LineAlign` | `string` | get | A string that represents the line alignment of the cue. |
| `Position` | `Union<double, string>` | get | A double that represents the position of the cue as a percentage of the video width (or height if vertical). |
| `PositionAlign` | `string` | get | A string that represents the position alignment of the cue. |
| `Size` | `double` | get/set | A double that represents the size of the cue as a percentage of the video width (or height if vertical). |
| `Align` | `string` | get/set | A string that represents the alignment of the cue. |
| `Text` | `string` | get | A string that represents the text of the cue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCueAsHTML()` | `DocumentFragment` | Returns the cue text as an HTML DocumentFragment. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VTTCue>(...)` or constructor `new VTTCue(...)`

### JavaScript

```js
let video = document.querySelector("video");
let track = video.addTextTrack("captions", "Captions", "en");
track.mode = "showing";
track.addCue(new VTTCue(0, 0.9, "Hildy!"));
track.addCue(new VTTCue(1, 1.4, "How are you?"));
track.addCue(new VTTCue(1.5, 2.9, "Tell me, is the lord of the universe in?"));
track.addCue(new VTTCue(3, 4.2, "Yes, he's in - in a bad humor"));
track.addCue(new VTTCue(4.3, 6, "Somebody must've stolen the crown jewels"));
console.log(track.cues);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VTTCue)*


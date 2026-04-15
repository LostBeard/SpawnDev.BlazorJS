# VTTRegion

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/VTTRegion.cs`  
**MDN Reference:** [VTTRegion on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VTTRegion)

> The VTTRegion interface of the WebVTT API represents a portion of the video representation where a VTTCue can be rendered. https://developer.mozilla.org/en-US/docs/Web/API/VTTRegion

## Constructors

| Signature | Description |
|---|---|
| `VTTRegion()` | Creates a new VTTRegion object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string that identifies the region. |
| `Width` | `double` | get/set | A double that represents the width of the region as a percentage of the video width. |
| `Lines` | `double` | get | A double that represents the number of lines the region has. |
| `RegionAnchorX` | `double` | get | A double that represents the region anchor X offset as a percentage of the region width. |
| `RegionAnchorY` | `double` | get | A double that represents the region anchor Y offset as a percentage of the region height. |
| `ViewportAnchorX` | `double` | get | A double that represents the viewport anchor X offset as a percentage of the video width. |
| `ViewportAnchorY` | `double` | get/set | A double that represents the viewport anchor Y offset as a percentage of the video height. |
| `Scroll` | `string` | get | A string that represents the scroll setting of the region. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VTTRegion>(...)` or constructor `new VTTRegion(...)`

```js
const region = new VTTRegion();
region.width = 50; // Use 50% of the video width
region.lines = 4; // Use 4 lines of height.
region.viewportAnchorX = 25; // Have the region start at 25% from the left.
const cue = new VTTCue(2, 3, "Cool text to be displayed");
cue.region = region; // This cue will be drawn only within this region.
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VTTRegion)*


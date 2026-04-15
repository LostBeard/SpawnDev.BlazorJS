# MediaStreamTrackGeneratorOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaStreamTrackGeneratorOptions.cs`  
**MDN Reference:** [MediaStreamTrackGeneratorOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator/MediaStreamTrackGenerator#options)

> Options for the MediaStreamTrackProcessor constructor. https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator/MediaStreamTrackGenerator#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaStreamTrackGeneratorOptions` | `class` | get | Options for the MediaStreamTrackProcessor constructor. https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator/MediaStreamTrackGenerator#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaStreamTrackGeneratorOptions>(...)` or constructor `new MediaStreamTrackGeneratorOptions(...)`

```js
const trackGenerator = new MediaStreamTrackGenerator({ kind: "video" });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator/MediaStreamTrackGenerator)*


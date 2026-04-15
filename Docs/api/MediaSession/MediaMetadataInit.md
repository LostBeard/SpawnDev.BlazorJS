# MediaMetadataInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaSession/MediaMetadataInit.cs`  
**MDN Reference:** [MediaMetadataInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata/MediaMetadata)

> The MediaMetadataInit dictionary of the Media Session API provides initialization data for the MediaMetadata interface. https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata/MediaMetadata

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaMetadataInit` | `class` | get | The MediaMetadataInit dictionary of the Media Session API provides initialization data for the MediaMetadata interface. https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata/MediaMetadata |
| `Artist` | `string?` | get |  |
| `Album` | `string?` | get |  |
| `Artwork` | `MediaImage[]?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaMetadataInit>(...)` or constructor `new MediaMetadataInit(...)`

```js
if ("mediaSession" in navigator) {
  navigator.mediaSession.metadata = new MediaMetadata({
    title: "Unforgettable",
    artist: "Nat King Cole",
    album: "The Ultimate Collection (Remastered)",
    artwork: [
      {
        src: "https://dummyimage.com/96x96",
        sizes: "96x96",
        type: "image/png",
      },
      {
        src: "https://dummyimage.com/128x128",
        sizes: "128x128",
        type: "image/png",
      },
      {
        src: "https://dummyimage.com/192x192",
        sizes: "192x192",
        type: "image/png",
      },
      {
        src: "https://dummyimage.com/256x256",
        sizes: "256x256",
        type: "image/png",
      },
      {
        src: "https://dummyimage.com/384x384",
        sizes: "384x384",
        type: "image/png",
      },
      {
        src: "https://dummyimage.com/512x512",
        sizes: "512x512",
        type: "image/png",
      },
    ],
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata/MediaMetadata)*


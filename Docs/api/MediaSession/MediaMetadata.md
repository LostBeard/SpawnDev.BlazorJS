# MediaMetadata

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaSession/MediaMetadata.cs`  
**MDN Reference:** [MediaMetadata on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata)

> The MediaMetadata interface of the Media Session API allows a web page to provide rich media metadata for display in a platform UI. https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata

## Constructors

| Signature | Description |
|---|---|
| `MediaMetadata(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MediaMetadata(MediaMetadataInit init)` | Creates a new MediaMetadata object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Title` | `string` | get | The title of the media to be played. |
| `Artist` | `string` | get | The name of the artist, group, creator, etc., of the media to be played. |
| `Album` | `string` | get | The name of the album or collection containing the media to be played. |
| `Artwork` | `MediaImage[]` | get | An array of MediaImage objects, each of which contains information about an image associated with the media. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaMetadata>(...)` or constructor `new MediaMetadata(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaMetadata)*


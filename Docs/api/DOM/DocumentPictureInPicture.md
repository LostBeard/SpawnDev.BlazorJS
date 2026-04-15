# DocumentPictureInPicture

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/DOM/DocumentPictureInPicture.cs`  
**MDN Reference:** [DocumentPictureInPicture on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DocumentPictureInPicture)

> The DocumentPictureInPicture interface of the Document Picture-in-Picture API is the entry point for creating and handling document picture-in-picture windows. https://developer.mozilla.org/en-US/docs/Web/API/DocumentPictureInPicture

## Constructors

| Signature | Description |
|---|---|
| `DocumentPictureInPicture(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Window` | `Window?` | get | Returns a Window instance representing the browsing context inside the Picture-in-Picture window. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestWindow()` | `Task<Window>` | Opens the Picture-in-Picture window for the current main browsing context. Returns a Promise that fulfills with a Window instance representing the browsing context inside the Picture-in-Picture window. |
| `RequestWindow(PIPRequestWindowOptions options)` | `Task<Window>` | Opens the Picture-in-Picture window for the current main browsing context. Returns a Promise that fulfills with a Window instance representing the browsing context inside the Picture-in-Picture window. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnter` | `ActionEvent<DocumentPictureInPictureEvent>` | Fired when the Picture-in-Picture window is successfully opened. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DocumentPictureInPicture>(...)` or constructor `new DocumentPictureInPicture(...)`

```js
const videoPlayer = document.getElementById("player");

// …

// Open a Picture-in-Picture window.
const pipWindow = await window.documentPictureInPicture.requestWindow({
  width: videoPlayer.clientWidth,
  height: videoPlayer.clientHeight,
});

// …
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DocumentPictureInPicture)*


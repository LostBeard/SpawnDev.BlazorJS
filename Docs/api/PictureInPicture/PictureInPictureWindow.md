# PictureInPictureWindow

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/PictureInPicture/PictureInPictureWindow.cs`  
**MDN Reference:** [PictureInPictureWindow on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PictureInPictureWindow)

> The PictureInPictureWindow interface represents an object able to programmatically obtain the Width and Height of the floating video window. An object with this interface is obtained by the promise returned by the HTMLVideoElement.requestPictureInPicture() method. https://developer.mozilla.org/en-US/docs/Web/API/PictureInPictureWindow

## Constructors

| Signature | Description |
|---|---|
| `PictureInPictureWindow(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `int` | get | The width of the floating video window. |
| `Height` | `int` | get | The height of the floating video window. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResize` | `ActionEvent<Event>` | Fired when the floating video window is resized. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PictureInPictureWindow>(...)` or constructor `new PictureInPictureWindow(...)`

```js
const button = document.querySelector("button");
const video = document.querySelector("video");

function printPipWindowDimensions(evt) {
  const pipWindow = evt.target;
  console.log(
    `The floating window dimensions are: ${pipWindow.width}x${pipWindow.height}px`,
  );
  // will print:
  // The floating window dimensions are: 640x360px
}

button.onclick = () => {
  video.requestPictureInPicture().then((pictureInPictureWindow) => {
    pictureInPictureWindow.onresize = printPipWindowDimensions;
  });
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PictureInPictureWindow)*


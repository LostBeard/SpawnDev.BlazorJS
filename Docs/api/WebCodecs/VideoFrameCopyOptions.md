# VideoFrameCopyOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/VideoFrameCopyOptions.cs`  
**MDN Reference:** [VideoFrameCopyOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/copyTo#options)

> VideoFrame.CopyTo() options https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/copyTo#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoFrameCopyOptions` | `class` | get | VideoFrame.CopyTo() options https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/copyTo#options |
| `Layout` | `List<VideoFrameLayout>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoFrameCopyOptions>(...)` or constructor `new VideoFrameCopyOptions(...)`

```js
let buffer = new Uint8Array(videoFrame.allocationSize());
let layout = await videoFrame.copyTo(buffer);
```

```js
const videoRect = {
  x: 100,
  y: 100,
  width: 80,
  height: 60,
};
const options = {
  rect: videoRect,
  format: "RGBX",
  colorSpace: "display-p3",
};
const size = videoFrame.allocationSize(options);
const buffer = new ArrayBuffer(size);
const layout = await videoFrame.copyTo(buffer, options);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/copyTo)*


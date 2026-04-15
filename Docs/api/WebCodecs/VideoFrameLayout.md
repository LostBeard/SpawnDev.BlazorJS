# VideoFrameLayout

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/VideoFrameLayout.cs`  
**MDN Reference:** [VideoFrameLayout on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#layout)

> Describes a video plane layout for a VideoFrame https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#layout

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoFrameLayout` | `class` | get | Describes a video plane layout for a VideoFrame https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#layout |
| `Stride` | `int` | get | An integer representing the number of bytes, including padding, used by each row of the plane. Planes may not overlap. If no layout is specified, the planes will be tightly packed. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoFrameLayout>(...)` or constructor `new VideoFrameLayout(...)`

```js
const cnv = document.createElement("canvas");
// draw something on the canvas
// …
const frameFromCanvas = new VideoFrame(cnv, { timestamp: 0 });
```

```js
const pixelSize = 4;
const init = {
  timestamp: 0,
  codedWidth: 320,
  codedHeight: 200,
  format: "RGBA",
};
const data = new Uint8Array(init.codedWidth * init.codedHeight * pixelSize);
for (let x = 0; x < init.codedWidth; x++) {
  for (let y = 0; y < init.codedHeight; y++) {
    const offset = (y * init.codedWidth + x) * pixelSize;
    data[offset] = 0x7f; // Red
    data[offset + 1] = 0xff; // Green
    data[offset + 2] = 0xd4; // Blue
    data[offset + 3] = 0x0ff; // Alpha
  }
}
init.transfer = [data.buffer];
const frame = new VideoFrame(data, init);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame)*


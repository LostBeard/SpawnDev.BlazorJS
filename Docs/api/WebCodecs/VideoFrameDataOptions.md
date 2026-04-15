# VideoFrameDataOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/VideoFrameDataOptions.cs`  
**MDN Reference:** [VideoFrameDataOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#options_2)

> Options used when creating a new VideoFrame using ArrayBuffer, TypedArray, or DataView data https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#options_2

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoFrameDataOptions` | `class` | get | Options used when creating a new VideoFrame using ArrayBuffer, TypedArray, or DataView data https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#options_2 |
| `CodedWidth` | `int` | get | Width of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments. |
| `CodedHeight` | `int` | get/set | Height of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments. |
| `Timestamp` | `long` | get | An integer representing the timestamp of the frame in microseconds. |
| `Duration` | `long?` | get |  |
| `Layout` | `List<VideoFrameLayout>?` | get |  |
| `VisibleRect` | `VideoFrameRect?` | get |  |
| `DisplayWidth` | `int?` | get |  |
| `DisplayHeight` | `int?` | get |  |
| `ColorSpace` | `VideoColorSpaceOptions?` | get |  |
| `Transfer` | `ArrayBuffer[]?` | get | An array of ArrayBuffers that VideoFrame will detach and take ownership of. If the array contains the ArrayBuffer backing data, VideoFrame will use that buffer directly instead of copying from it. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoFrameDataOptions>(...)` or constructor `new VideoFrameDataOptions(...)`

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


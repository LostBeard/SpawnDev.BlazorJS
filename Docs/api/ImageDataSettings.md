# ImageDataSettings

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ImageDataSettings.cs`  
**MDN Reference:** [ImageDataSettings on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ImageData/ImageData#settings)

> Settings used when creating an ImageData instance https://developer.mozilla.org/en-US/docs/Web/API/ImageData/ImageData#settings

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ImageDataSettings` | `class` | get | Settings used when creating an ImageData instance https://developer.mozilla.org/en-US/docs/Web/API/ImageData/ImageData#settings |
| `PixelFormat` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ImageDataSettings>(...)` or constructor `new ImageDataSettings(...)`

### Creating a blank ImageData object

```js
let imageData = new ImageData(200, 100);
// ImageData { width: 200, height: 100, data: Uint8ClampedArray[80000] }
```

### ImageData using the display-p3 color space

```js
let imageData = new ImageData(200, 100, { colorSpace: "display-p3" });
```

### Floating-point pixel data for wide gamuts and high dynamic range (HDR)

```js
let floatArray = new Float16Array(4 * 200 * 200);
let imageData = new ImageData(floatArray, 200, 200, {
  pixelFormat: "rgba-float16",
});
console.log(imageData.pixelFormat); // "rgba-float16"
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ImageData/ImageData)*


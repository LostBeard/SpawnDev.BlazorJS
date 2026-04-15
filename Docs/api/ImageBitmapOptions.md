# ImageBitmapOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ImageBitmapOptions.cs`  
**MDN Reference:** [ImageBitmapOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/createImageBitmap#options)

> An object that sets options for the image's extraction when using Window.CreateImageBitmap https://developer.mozilla.org/en-US/docs/Web/API/Window/createImageBitmap#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ImageBitmapOptions` | `class` | get | An object that sets options for the image's extraction when using Window.CreateImageBitmap https://developer.mozilla.org/en-US/docs/Web/API/Window/createImageBitmap#options |
| `PremultiplyAlpha` | `string?` | get |  |
| `ColorSpaceConversion` | `string?` | get |  |
| `ResizeWidth` | `int?` | get |  |
| `ResizeHeight` | `int?` | get |  |
| `ResizeQuality` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ImageBitmapOptions>(...)` or constructor `new ImageBitmapOptions(...)`

### Creating sprites from a sprite sheet

```js
const canvas = document.getElementById("myCanvas"),
  ctx = canvas.getContext("2d"),
  image = new Image();

// Wait for the sprite sheet to load
image.onload = () => {
  Promise.all([
    // Cut out two sprites from the sprite sheet
    createImageBitmap(image, 0, 0, 32, 32),
    createImageBitmap(image, 32, 0, 32, 32),
    createImageBitmap(image, 0, 0, 50, 50, { imageOrientation: "flipY" }),
  ]).then((sprites) => {
    // Draw each sprite onto the canvas
    ctx.drawImage(sprites[0], 0, 0);
    ctx.drawImage(sprites[1], 32, 32);
    ctx.drawImage(sprites[2], 64, 64);
  });
};

// Load the sprite sheet from an image file
image.src = "50x50.jpg";
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/createImageBitmap)*


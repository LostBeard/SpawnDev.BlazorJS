# DetectedBarcode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DetectedBarcode.cs`  
**MDN Reference:** [DetectedBarcode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/detect)

> Returned in array from BarcodeDetector.Detect() https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/detect

## Constructors

| Signature | Description |
|---|---|
| `DetectedBarcode(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BoundingBox` | `DOMRectReadOnly` | get | boundingBox: A DOMRectReadOnly, which returns the dimensions of a rectangle representing the extent of a detected barcode, aligned with the image |
| `CornerPoints` | `Point2D` | get | The x and y co-ordinates of the four corner points of the detected barcode relative to the image, starting with the top left and working clockwise. This may not be square due to perspective distortions within the image. |
| `Format` | `string` | get | The detected barcode format. |
| `RawValue` | `string` | get | A string decoded from the barcode data |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DetectedBarcode>(...)` or constructor `new DetectedBarcode(...)`

```js
barcodeDetector
  .detect(imageEl)
  .then((barcodes) => {
    barcodes.forEach((barcode) => console.log(barcode.rawValue));
  })
  .catch((err) => {
    console.error(err);
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/detect)*


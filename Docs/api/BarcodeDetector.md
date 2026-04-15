# BarcodeDetector

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/BarcodeDetector.cs`  
**MDN Reference:** [BarcodeDetector on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector)

> The BarcodeDetector interface of the Barcode Detection API allows detection of linear and two dimensional barcodes in images. https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector

## Constructors

| Signature | Description |
|---|---|
| `BarcodeDetector()` | The BarcodeDetector() constructor creates a new BarcodeDetector object which detects linear and two-dimensional barcodes in images. |
| `BarcodeDetector(BarcodeDetectorOptions options)` | The BarcodeDetector() constructor creates a new BarcodeDetector object which detects linear and two-dimensional barcodes in images. |
| `BarcodeDetector(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetSupportedFormats()` | `Task<List<string>>` | The getSupportedFormats() static method of the BarcodeDetector interface returns a Promise which fulfills with an Array of supported barcode format types. |
| `IsDefined()` | `bool` | Checks if BarcodeDetector is defined in the global scope |
| `Detect(Union<Blob, Element, ImageData, ImageBitmap, OffscreenCanvas> imageBitmapSource)` | `Task<Array<DetectedBarcode>>` | The detect() method of the BarcodeDetector interface returns a Promise which fulfills with an Array of detected barcodes within an image. Receives an ImageBitmapSource as a parameter. This can be an element, a Blob of type image or an ImageData object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BarcodeDetector>(...)` or constructor `new BarcodeDetector(...)`

### Creating A Detector

```js
// check compatibility
if (!("BarcodeDetector" in globalThis)) {
  console.log("Barcode Detector is not supported by this browser.");
} else {
  console.log("Barcode Detector supported!");

  // create new detector
  const barcodeDetector = new BarcodeDetector({
    formats: ["code_39", "codabar", "ean_13"],
  });
}
```

### Getting Supported Formats

```js
// check supported types
BarcodeDetector.getSupportedFormats().then((supportedFormats) => {
  supportedFormats.forEach((format) => console.log(format));
});
```

### Detect Barcodes

```js
barcodeDetector
  .detect(imageEl)
  .then((barcodes) => {
    barcodes.forEach((barcode) => console.log(barcode.rawValue));
  })
  .catch((err) => {
    console.log(err);
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector)*


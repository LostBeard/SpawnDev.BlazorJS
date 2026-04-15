# BarcodeDetectorOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/BarcodeDetectorOptions.cs`  
**MDN Reference:** [BarcodeDetectorOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/BarcodeDetector#options)

> An options object containing a series of BarcodeFormats to search for in the subsequent detect() calls. https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/BarcodeDetector#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BarcodeDetectorOptions` | `class` | get | An options object containing a series of BarcodeFormats to search for in the subsequent detect() calls. https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/BarcodeDetector#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BarcodeDetectorOptions>(...)` or constructor `new BarcodeDetectorOptions(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector/BarcodeDetector)*


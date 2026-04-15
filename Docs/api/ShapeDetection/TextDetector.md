# TextDetector

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ShapeDetection/TextDetector.cs`  

> The TextDetector interface of the Text Detection API detects text in images.

## Constructors

| Signature | Description |
|---|---|
| `TextDetector(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `TextDetector()` | Creates a new TextDetector object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Detect(Union<Blob, Element, ImageData, ImageBitmap, OffscreenCanvas> imageBitmapSource)` | `Task<List<DetectedText>>` | Detects text in the specified image. The image to detect text in. A Promise that returns an array of DetectedText objects. |


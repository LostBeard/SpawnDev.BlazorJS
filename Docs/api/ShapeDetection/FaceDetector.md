# FaceDetector

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ShapeDetection/FaceDetector.cs`  

> The FaceDetector interface of the Face Detection API detects faces in images.

## Constructors

| Signature | Description |
|---|---|
| `FaceDetector(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `FaceDetector(FaceDetectorOptions? options)` | Creates a new FaceDetector object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Detect(Union<Blob, Element, ImageData, ImageBitmap, OffscreenCanvas> imageBitmapSource)` | `Task<List<DetectedFace>>` | Detects faces in the specified image. The image to detect faces in. A Promise that returns an array of DetectedFace objects. |


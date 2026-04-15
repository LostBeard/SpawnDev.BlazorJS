# DetectedText

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ShapeDetection/DetectedText.cs`  

> The DetectedText interface of the Text Detection API represents a text detected by the TextDetector.detect() method.

## Constructors

| Signature | Description |
|---|---|
| `DetectedText(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BoundingBox` | `DOMRectReadOnly` | get | A DOMRectReadOnly object indicating the dimensions and position of the detected text. |
| `RawValue` | `string` | get | A string corresponding to the raw string detected in the image. |
| `CornerPoints` | `List<DOMPointReadOnly>?` | get | An array of 4 Point2D objects representing the four corner points of the detected text. |


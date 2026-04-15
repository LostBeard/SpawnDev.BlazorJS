# DetectedFace

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ShapeDetection/DetectedFace.cs`  

> The DetectedFace interface of the Mask Detection API represents a face detected by the FaceDetector.detect() method.

## Constructors

| Signature | Description |
|---|---|
| `DetectedFace(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BoundingBox` | `DOMRectReadOnly` | get | A DOMRectReadOnly object indicating the dimensions and position of the detected face. |
| `Landmarks` | `List<JSObject>?` | get | An array of Landmark objects, each representing a detection of a particular landmark. |


# DOMPointReadOnly

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMPointReadOnly.cs`  
**MDN Reference:** [DOMPointReadOnly on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly)

> The DOMPointReadOnly interface specifies the coordinate and perspective fields used by DOMPoint to define a 2D or 3D point in a coordinate system. There are two ways to create a new DOMPointReadOnly instance. First, you can use its constructor, passing in the values of the parameters for each dimension and, optionally, the perspective. https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly

## Constructors

| Signature | Description |
|---|---|
| `DOMPointReadOnly()` | The DOMPointReadOnly() constructor creates a new DOMPointReadOnly object representing a 2D or 3D point in a coordinate system. |
| `DOMPointReadOnly(double x, double y, double z, double w)` | The DOMPointReadOnly() constructor creates a new DOMPointReadOnly object representing a 2D or 3D point in a coordinate system. The x-coordinate of the point. Default is 0. The y-coordinate of the point. Default is 0. The z-coordinate of the point. Default is 0. The perspective value of the point. Default is 1. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `FromPoint(object point)` | `DOMPointReadOnly` | Create a new DOMPointReadOnly from an object containing x, y, z, and/or w. |
| `FromPoint(DOMPointInit point)` | `DOMPointReadOnly` | The DOMPointReadOnly.fromPoint() method creates a new DOMPointReadOnly object given a source point. A DOMPointInit dictionary or another DOMPointReadOnly object to initialize the new point with. A new DOMPointReadOnly object. |
| `FromPoint(DOMPoint point)` | `DOMPointReadOnly` | Create a new DOMPointReadOnly from a DOMPoint. |
| `FromPoint(DOMPointReadOnly point)` | `DOMPointReadOnly` | Create a new DOMPointReadOnly from a DOMPointReadOnly. |
| `MatrixTransform()` | `DOMPointReadOnly` | The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix. A new DOMPointReadOnly object. |
| `MatrixTransform(DOMMatrixInit matrix)` | `DOMPointReadOnly` | The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with. A new DOMPointReadOnly object. |
| `MatrixTransform(DOMMatrix matrix)` | `DOMPointReadOnly` | The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with. A new DOMPointReadOnly object. |
| `MatrixTransform(DOMMatrixReadOnly matrix)` | `DOMPointReadOnly` | The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with. A new DOMPointReadOnly object. |


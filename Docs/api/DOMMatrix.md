# DOMMatrix

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> DOMMatrixReadOnly -> DOMMatrix  
**MDN Reference:** [DOMMatrix on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/DOMMatrix.cs`

> The DOMMatrix interface represents a 4x4 homogeneous matrix for 2D and 3D transformations. It is the mutable variant of DOMMatrixReadOnly. DOMMatrix is used by CSS transforms, canvas transformations, and the WebXR API.

## Constructor

```csharp
// From existing reference
public DOMMatrix(IJSInProcessObjectReference _ref)

// From CSS transform string
public DOMMatrix(string transformList) // e.g., "translate(50px, 50px) rotate(45deg)"

// From matrix values (6 values for 2D, 16 for 3D)
public DOMMatrix(double[] values)
```

## Properties - 2D Matrix (a-f)

| Property | Type | Description |
|---|---|---|
| `A` | `double` | Scale X (same as M11). |
| `B` | `double` | Skew Y (same as M12). |
| `C` | `double` | Skew X (same as M21). |
| `D` | `double` | Scale Y (same as M22). |
| `E` | `double` | Translate X (same as M41). |
| `F` | `double` | Translate Y (same as M42). |

## Properties - 4x4 Matrix

| Property | Type | Description |
|---|---|---|
| `M11` through `M44` | `double` | The 16 values of the 4x4 matrix (row-major). |
| `Is2D` | `bool` | Whether this is a 2D matrix. |
| `IsIdentity` | `bool` | Whether this is the identity matrix. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Multiply(DOMMatrix other)` | `DOMMatrix` | Post-multiply by another matrix. Modifies this matrix. |
| `MultiplySelf(DOMMatrix other)` | `DOMMatrix` | Same as Multiply - post-multiply in place. |
| `PreMultiplySelf(DOMMatrix other)` | `DOMMatrix` | Pre-multiply by another matrix in place. |
| `Translate(double tx, double ty)` | `DOMMatrix` | Apply a translation. |
| `Translate(double tx, double ty, double tz)` | `DOMMatrix` | Apply a 3D translation. |
| `TranslateSelf(double tx, double ty)` | `DOMMatrix` | Translate in place. |
| `Scale(double scaleX, double scaleY)` | `DOMMatrix` | Apply a scale. |
| `ScaleSelf(double scaleX, double scaleY)` | `DOMMatrix` | Scale in place. |
| `Scale3dSelf(double scale)` | `DOMMatrix` | Uniform 3D scale in place. |
| `Rotate(double rotX, double rotY, double rotZ)` | `DOMMatrix` | Apply a rotation (degrees). |
| `RotateSelf(double rotX, double rotY, double rotZ)` | `DOMMatrix` | Rotate in place. |
| `RotateAxisAngleSelf(double x, double y, double z, double angle)` | `DOMMatrix` | Rotate around an axis in place. |
| `SkewX(double sx)` | `DOMMatrix` | Apply a horizontal skew. |
| `SkewY(double sy)` | `DOMMatrix` | Apply a vertical skew. |
| `Invert()` | `DOMMatrix` | Return the inverse matrix. |
| `InvertSelf()` | `DOMMatrix` | Invert in place. |
| `TransformPoint(DOMPoint point)` | `DOMPoint` | Transform a point by this matrix. |
| `ToFloat32Array()` | `Float32Array` | Get the matrix values as a Float32Array. |
| `ToFloat64Array()` | `Float64Array` | Get the matrix values as a Float64Array. |

## Example

```csharp
using var matrix = new DOMMatrix("translate(100px, 50px) rotate(45deg)");
Console.WriteLine($"Is2D: {matrix.Is2D}");
Console.WriteLine($"Translate: ({matrix.E}, {matrix.F})");

// Chain transformations
matrix.TranslateSelf(10, 20);
matrix.ScaleSelf(2, 2);
matrix.RotateSelf(0, 0, 90);
```

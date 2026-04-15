# DOMMatrix

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `DOMMatrixReadOnly`  
**Source:** `JSObjects/DOM/DOMMatrix.cs`  

> The DOMMatrix interface represents 4x4 matrices, suitable for 2D and 3D operations.

## Constructors

| Signature | Description |
|---|---|
| `DOMMatrix(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `DOMMatrix()` | The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix. |
| `DOMMatrix(string init)` | The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix. A string representing a transform list or a DOMMatrixInit dictionary to initialize the matrix with. |
| `DOMMatrix(DOMMatrixInit init)` | The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix. A DOMMatrixInit dictionary to initialize the matrix with. |
| `DOMMatrix(double[] array)` | The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix. A double array representing a 4x4 matrix. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `M11` | `double` | get/set | The m11 component of the matrix. |
| `M12` | `double` | get/set | The m12 component of the matrix. |
| `M13` | `double` | get/set | The m13 component of the matrix. |
| `M14` | `double` | get/set | The m14 component of the matrix. |
| `M21` | `double` | get/set | The m21 component of the matrix. |
| `M22` | `double` | get/set | The m22 component of the matrix. |
| `M23` | `double` | get/set | The m23 component of the matrix. |
| `M24` | `double` | get/set | The m24 component of the matrix. |
| `M31` | `double` | get/set | The m31 component of the matrix. |
| `M32` | `double` | get/set | The m32 component of the matrix. |
| `M33` | `double` | get/set | The m33 component of the matrix. |
| `M34` | `double` | get/set | The m34 component of the matrix. |
| `M41` | `double` | get/set | The m41 component of the matrix. |
| `M42` | `double` | get/set | The m42 component of the matrix. |
| `M43` | `double` | get/set | The m43 component of the matrix. |
| `M44` | `double` | get | The m44 component of the matrix. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `MultiplySelf(DOMMatrixInit other)` | `DOMMatrix` | The DOMMatrix.multiplySelf() method multiplies the current matrix by another matrix and returns the result. A DOMMatrixInit dictionary or another DOMMatrix object to multiply the matrix by. The current DOMMatrix object. |
| `PreMultiplySelf(DOMMatrixInit other)` | `DOMMatrix` | The DOMMatrix.preMultiplySelf() method pre-multiplies the current matrix by another matrix and returns the result. A DOMMatrixInit dictionary or another DOMMatrix object to pre-multiply the matrix by. The current DOMMatrix object. |
| `TranslateSelf(double tx, double ty, double tz)` | `DOMMatrix` | The DOMMatrix.translateSelf() method translates the current matrix by the specified x, y, and z values and returns the result. The x-axis translation value. The y-axis translation value. The z-axis translation value. The current DOMMatrix object. |
| `ScaleSelf(double scaleX, double scaleY, double scaleZ, double originX, double originY, double originZ)` | `DOMMatrix` | The DOMMatrix.scaleSelf() method scales the current matrix by the specified x, y, and z values and returns the result. The x-axis scaling value. The y-axis scaling value. The z-axis scaling value. The x-axis coordinate of the origin point for the scaling operation. The y-axis coordinate of the origin point for the scaling operation. The z-axis coordinate of the origin point for the scaling operation. The current DOMMatrix object. |
| `Scale3dSelf(double scale, double originX, double originY, double originZ)` | `DOMMatrix` | The DOMMatrix.scale3dSelf() method scales the current matrix by the specified scale factor and returns the result. The scaling factor. The x-axis coordinate of the origin point for the scaling operation. The y-axis coordinate of the origin point for the scaling operation. The z-axis coordinate of the origin point for the scaling operation. The current DOMMatrix object. |
| `RotateSelf(double rotX, double rotY, double rotZ)` | `DOMMatrix` | The DOMMatrix.rotateSelf() method rotates the current matrix by the specified angle and returns the result. The x-axis rotation value. The y-axis rotation value. The z-axis rotation value. The current DOMMatrix object. |
| `RotateFromVectorSelf(double x, double y)` | `DOMMatrix` | The DOMMatrix.rotateFromVectorSelf() method rotates the current matrix by the specified vector and returns the result. The x component of the vector. The y component of the vector. The current DOMMatrix object. |
| `RotateAxisAngleSelf(double x, double y, double z, double angle)` | `DOMMatrix` | The DOMMatrix.rotateAxisAngleSelf() method rotates the current matrix by the specified angle around the specified axis and returns the result. The x-axis coordinate of the axis of rotation. The y-axis coordinate of the axis of rotation. The z-axis coordinate of the axis of rotation. The angle of rotation, in degrees. The current DOMMatrix object. |
| `SkewXSelf(double sx)` | `DOMMatrix` | The DOMMatrix.skewXSelf() method skews the current matrix along the x-axis by the specified angle and returns the result. The angle of skewing along the x-axis, in degrees. The current DOMMatrix object. |
| `SkewYSelf(double sy)` | `DOMMatrix` | The DOMMatrix.skewYSelf() method skews the current matrix along the y-axis by the specified angle and returns the result. The angle of skewing along the y-axis, in degrees. The current DOMMatrix object. |
| `InvertSelf()` | `DOMMatrix` | The DOMMatrix.invertSelf() method inverts the current matrix and returns the result. The current DOMMatrix object. |
| `SetMatrixValue(string transformList)` | `DOMMatrix` | The DOMMatrix.setMatrixValue() method sets the current matrix to the specified transform list and returns the result. A string representing a transform list. The current DOMMatrix object. |


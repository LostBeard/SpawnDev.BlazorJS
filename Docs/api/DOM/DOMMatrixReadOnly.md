# DOMMatrixReadOnly

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMMatrixReadOnly.cs`  
**MDN Reference:** [DOMMatrixReadOnly on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly)

> https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly https://www.w3.org/TR/geometry-1/#dommatrixreadonly

## Constructors

| Signature | Description |
|---|---|
| `DOMMatrixReadOnly(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `DOMMatrixReadOnly()` | The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix. |
| `DOMMatrixReadOnly(string init)` | The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix. A string representing a transform list or a DOMMatrixInit dictionary to initialize the matrix with. |
| `DOMMatrixReadOnly(DOMMatrixInit init)` | The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix. A DOMMatrixInit dictionary to initialize the matrix with. |
| `DOMMatrixReadOnly(double[] array)` | The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix. A double array representing a 4x4 matrix. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Is2D` | `bool` | get | The DOMMatrixReadOnly.is2D property returns a boolean value indicating whether the matrix is 2D or 3D. |
| `IsIdentity` | `bool` | get | The DOMMatrixReadOnly.isIdentity property returns a boolean value indicating whether the matrix is the identity matrix. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `FromMatrix(DOMMatrixInit other)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.fromMatrix() method creates a new DOMMatrixReadOnly object given an existing matrix or a DOMMatrixInit dictionary. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to initialize the new matrix with. A new DOMMatrixReadOnly object. |
| `FromFloat32Array(Float32Array array32)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.fromFloat32Array() method creates a new DOMMatrixReadOnly object given a Float32Array representing a 4x4 matrix. A Float32Array representing a 4x4 matrix. A new DOMMatrixReadOnly object. |
| `FromFloat64Array(Float64Array array64)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.fromFloat64Array() method creates a new DOMMatrixReadOnly object given a Float64Array representing a 4x4 matrix. A Float64Array representing a 4x4 matrix. A new DOMMatrixReadOnly object. |
| `Translate(double tx, double ty, double tz)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.translate() method returns a new DOMMatrixReadOnly object which is the result of the translation of the matrix by the specified x, y, and z values. The x-axis translation value. The y-axis translation value. The z-axis translation value. A new DOMMatrixReadOnly object. |
| `Scale(double scaleX, double scaleY, double scaleZ, double originX, double originY, double originZ)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.scale() method returns a new DOMMatrixReadOnly object which is the result of the scaling of the matrix by the specified x, y, and z values. The x-axis scaling value. The y-axis scaling value. The z-axis scaling value. The x-axis coordinate of the origin point for the scaling operation. The y-axis coordinate of the origin point for the scaling operation. The z-axis coordinate of the origin point for the scaling operation. A new DOMMatrixReadOnly object. |
| `ScaleNonUniform(double scaleX, double scaleY, double scaleZ)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.scaleNonUniform() method returns a new DOMMatrixReadOnly object which is the result of the non-uniform scaling of the matrix by the specified x, y, and z values. The x-axis scaling value. The y-axis scaling value. The z-axis scaling value. A new DOMMatrixReadOnly object. |
| `Rotate(double rotX, double rotY, double rotZ)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.rotate() method returns a new DOMMatrixReadOnly object which is the result of the rotation of the matrix by the specified angle. The x-axis rotation value. The y-axis rotation value. The z-axis rotation value. A new DOMMatrixReadOnly object. |
| `RotateAxisAngle(double x, double y, double z, double angle)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.rotateAxisAngle() method returns a new DOMMatrixReadOnly object which is the result of the rotation of the matrix by the specified angle around the specified axis. The x-axis coordinate of the axis of rotation. The y-axis coordinate of the axis of rotation. The z-axis coordinate of the axis of rotation. The angle of rotation, in degrees. A new DOMMatrixReadOnly object. |
| `SkewX(double sx)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.skewX() method returns a new DOMMatrixReadOnly object which is the result of the skewing of the matrix along the x-axis by the specified angle. The angle of skewing along the x-axis, in degrees. A new DOMMatrixReadOnly object. |
| `SkewY(double sy)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.skewY() method returns a new DOMMatrixReadOnly object which is the result of the skewing of the matrix along the y-axis by the specified angle. The angle of skewing along the y-axis, in degrees. A new DOMMatrixReadOnly object. |
| `Multiply(DOMMatrixInit other)` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.multiply() method returns a new DOMMatrixReadOnly object which is the result of the multiplication of the matrix by the specified matrix. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to multiply the matrix by. A new DOMMatrixReadOnly object. |
| `FlipX()` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.flipX() method returns a new DOMMatrixReadOnly object which is the result of the flipping of the matrix along the x-axis. A new DOMMatrixReadOnly object. |
| `FlipY()` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.flipY() method returns a new DOMMatrixReadOnly object which is the result of the flipping of the matrix along the y-axis. A new DOMMatrixReadOnly object. |
| `Inverse()` | `DOMMatrixReadOnly` | The DOMMatrixReadOnly.inverse() method returns a new DOMMatrixReadOnly object which is the result of the inversion of the matrix. A new DOMMatrixReadOnly object. |
| `TransformPoint(DOMPointInit point)` | `DOMPoint` | The DOMMatrixReadOnly.transformPoint() method returns a new DOMPoint object which is the result of the transformation of the specified point by the matrix. A DOMPointInit dictionary or another DOMPoint object to transform. A new DOMPoint object. |
| `ToFloat32Array()` | `Float32Array` | The DOMMatrixReadOnly.toFloat32Array() method returns a new Float32Array object which is the result of the conversion of the matrix to a 4x4 matrix. A new Float32Array object. |
| `ToFloat64Array()` | `Float64Array` | The DOMMatrixReadOnly.toFloat64Array() method returns a new Float64Array object which is the result of the conversion of the matrix to a 4x4 matrix. A new Float64Array object. |


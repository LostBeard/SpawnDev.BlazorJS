using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly<br/>
    /// https://www.w3.org/TR/geometry-1/#dommatrixreadonly
    /// </summary>
    public class DOMMatrixReadOnly : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMMatrixReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix.
        /// </summary>
        public DOMMatrixReadOnly() : base(JS.New("DOMMatrixReadOnly")) { }

        /// <summary>
        /// The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="init">A string representing a transform list or a DOMMatrixInit dictionary to initialize the matrix with.</param>
        public DOMMatrixReadOnly(string init) : base(JS.New("DOMMatrixReadOnly", init)) { }

        /// <summary>
        /// The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="init">A DOMMatrixInit dictionary to initialize the matrix with.</param>
        public DOMMatrixReadOnly(DOMMatrixInit init) : base(JS.New("DOMMatrixReadOnly", init)) { }

        /// <summary>
        /// The DOMMatrixReadOnly() constructor creates a new DOMMatrixReadOnly object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="array">A double array representing a 4x4 matrix.</param>
        public DOMMatrixReadOnly(double[] array) : base(JS.New("DOMMatrixReadOnly", array)) { }

        /// <summary>
        /// The DOMMatrixReadOnly.fromMatrix() method creates a new DOMMatrixReadOnly object given an existing matrix or a DOMMatrixInit dictionary.
        /// </summary>
        /// <param name="other">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to initialize the new matrix with.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public static DOMMatrixReadOnly FromMatrix(DOMMatrixInit other) => JS.New<DOMMatrixReadOnly>("DOMMatrixReadOnly", other);

        /// <summary>
        /// The DOMMatrixReadOnly.fromFloat32Array() method creates a new DOMMatrixReadOnly object given a Float32Array representing a 4x4 matrix.
        /// </summary>
        /// <param name="array32">A Float32Array representing a 4x4 matrix.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public static DOMMatrixReadOnly FromFloat32Array(Float32Array array32) => JS.New<DOMMatrixReadOnly>("DOMMatrixReadOnly", array32);

        /// <summary>
        /// The DOMMatrixReadOnly.fromFloat64Array() method creates a new DOMMatrixReadOnly object given a Float64Array representing a 4x4 matrix.
        /// </summary>
        /// <param name="array64">A Float64Array representing a 4x4 matrix.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public static DOMMatrixReadOnly FromFloat64Array(Float64Array array64) => JS.New<DOMMatrixReadOnly>("DOMMatrixReadOnly", array64);

        /// <summary>
        /// The DOMMatrixReadOnly.is2D property returns a boolean value indicating whether the matrix is 2D or 3D.
        /// </summary>
        public bool Is2D => JSRef!.Get<bool>("is2D");

        /// <summary>
        /// The DOMMatrixReadOnly.isIdentity property returns a boolean value indicating whether the matrix is the identity matrix.
        /// </summary>
        public bool IsIdentity => JSRef!.Get<bool>("isIdentity");

        /// <summary>
        /// The DOMMatrixReadOnly.translate() method returns a new DOMMatrixReadOnly object which is the result of the translation of the matrix by the specified x, y, and z values.
        /// </summary>
        /// <param name="tx">The x-axis translation value.</param>
        /// <param name="ty">The y-axis translation value.</param>
        /// <param name="tz">The z-axis translation value.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly Translate(double tx, double ty, double tz = 0) => JSRef!.Call<DOMMatrixReadOnly>("translate", tx, ty, tz);

        /// <summary>
        /// The DOMMatrixReadOnly.scale() method returns a new DOMMatrixReadOnly object which is the result of the scaling of the matrix by the specified x, y, and z values.
        /// </summary>
        /// <param name="scaleX">The x-axis scaling value.</param>
        /// <param name="scaleY">The y-axis scaling value.</param>
        /// <param name="scaleZ">The z-axis scaling value.</param>
        /// <param name="originX">The x-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originY">The y-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originZ">The z-axis coordinate of the origin point for the scaling operation.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly Scale(double scaleX, double scaleY = 1, double scaleZ = 1, double originX = 0, double originY = 0, double originZ = 0) => JSRef!.Call<DOMMatrixReadOnly>("scale", scaleX, scaleY, scaleZ, originX, originY, originZ);

        /// <summary>
        /// The DOMMatrixReadOnly.scaleNonUniform() method returns a new DOMMatrixReadOnly object which is the result of the non-uniform scaling of the matrix by the specified x, y, and z values.
        /// </summary>
        /// <param name="scaleX">The x-axis scaling value.</param>
        /// <param name="scaleY">The y-axis scaling value.</param>
        /// <param name="scaleZ">The z-axis scaling value.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly ScaleNonUniform(double scaleX, double scaleY = 1, double scaleZ = 1) => JSRef!.Call<DOMMatrixReadOnly>("scaleNonUniform", scaleX, scaleY, scaleZ);

        /// <summary>
        /// The DOMMatrixReadOnly.rotate() method returns a new DOMMatrixReadOnly object which is the result of the rotation of the matrix by the specified angle.
        /// </summary>
        /// <param name="rotX">The x-axis rotation value.</param>
        /// <param name="rotY">The y-axis rotation value.</param>
        /// <param name="rotZ">The z-axis rotation value.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly Rotate(double rotX, double rotY = 0, double rotZ = 0) => JSRef!.Call<DOMMatrixReadOnly>("rotate", rotX, rotY, rotZ);

        /// <summary>
        /// The DOMMatrixReadOnly.rotateAxisAngle() method returns a new DOMMatrixReadOnly object which is the result of the rotation of the matrix by the specified angle around the specified axis.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the axis of rotation.</param>
        /// <param name="y">The y-axis coordinate of the axis of rotation.</param>
        /// <param name="z">The z-axis coordinate of the axis of rotation.</param>
        /// <param name="angle">The angle of rotation, in degrees.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly RotateAxisAngle(double x, double y, double z, double angle) => JSRef!.Call<DOMMatrixReadOnly>("rotateAxisAngle", x, y, z, angle);

        /// <summary>
        /// The DOMMatrixReadOnly.skewX() method returns a new DOMMatrixReadOnly object which is the result of the skewing of the matrix along the x-axis by the specified angle.
        /// </summary>
        /// <param name="sx">The angle of skewing along the x-axis, in degrees.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly SkewX(double sx) => JSRef!.Call<DOMMatrixReadOnly>("skewX", sx);

        /// <summary>
        /// The DOMMatrixReadOnly.skewY() method returns a new DOMMatrixReadOnly object which is the result of the skewing of the matrix along the y-axis by the specified angle.
        /// </summary>
        /// <param name="sy">The angle of skewing along the y-axis, in degrees.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly SkewY(double sy) => JSRef!.Call<DOMMatrixReadOnly>("skewY", sy);

        /// <summary>
        /// The DOMMatrixReadOnly.multiply() method returns a new DOMMatrixReadOnly object which is the result of the multiplication of the matrix by the specified matrix.
        /// </summary>
        /// <param name="other">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to multiply the matrix by.</param>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly Multiply(DOMMatrixInit other) => JSRef!.Call<DOMMatrixReadOnly>("multiply", other);

        /// <summary>
        /// The DOMMatrixReadOnly.flipX() method returns a new DOMMatrixReadOnly object which is the result of the flipping of the matrix along the x-axis.
        /// </summary>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly FlipX() => JSRef!.Call<DOMMatrixReadOnly>("flipX");

        /// <summary>
        /// The DOMMatrixReadOnly.flipY() method returns a new DOMMatrixReadOnly object which is the result of the flipping of the matrix along the y-axis.
        /// </summary>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly FlipY() => JSRef!.Call<DOMMatrixReadOnly>("flipY");

        /// <summary>
        /// The DOMMatrixReadOnly.inverse() method returns a new DOMMatrixReadOnly object which is the result of the inversion of the matrix.
        /// </summary>
        /// <returns>A new DOMMatrixReadOnly object.</returns>
        public DOMMatrixReadOnly Inverse() => JSRef!.Call<DOMMatrixReadOnly>("inverse");

        /// <summary>
        /// The DOMMatrixReadOnly.transformPoint() method returns a new DOMPoint object which is the result of the transformation of the specified point by the matrix.
        /// </summary>
        /// <param name="point">A DOMPointInit dictionary or another DOMPoint object to transform.</param>
        /// <returns>A new DOMPoint object.</returns>
        public DOMPoint TransformPoint(DOMPointInit point) => JSRef!.Call<DOMPoint>("transformPoint", point);

        /// <summary>
        /// The DOMMatrixReadOnly.toFloat32Array() method returns a new Float32Array object which is the result of the conversion of the matrix to a 4x4 matrix.
        /// </summary>
        /// <returns>A new Float32Array object.</returns>
        public Float32Array ToFloat32Array() => JSRef!.Call<Float32Array>("toFloat32Array");

        /// <summary>
        /// The DOMMatrixReadOnly.toFloat64Array() method returns a new Float64Array object which is the result of the conversion of the matrix to a 4x4 matrix.
        /// </summary>
        /// <returns>A new Float64Array object.</returns>
        public Float64Array ToFloat64Array() => JSRef!.Call<Float64Array>("toFloat64Array");
    }
}

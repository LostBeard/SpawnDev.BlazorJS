using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DOMMatrix : DOMMatrixReadOnly
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DOMMatrix(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix.
        /// </summary>
        public DOMMatrix() : base(JS.New("DOMMatrix")) { }

        /// <summary>
        /// The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="init">A string representing a transform list or a DOMMatrixInit dictionary to initialize the matrix with.</param>
        public DOMMatrix(string init) : base(JS.New("DOMMatrix", init)) { }

        /// <summary>
        /// The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="init">A DOMMatrixInit dictionary to initialize the matrix with.</param>
        public DOMMatrix(DOMMatrixInit init) : base(JS.New("DOMMatrix", init)) { }

        /// <summary>
        /// The DOMMatrix() constructor creates a new DOMMatrix object representing a 2D or 3D transformation matrix.
        /// </summary>
        /// <param name="array">A double array representing a 4x4 matrix.</param>
        public DOMMatrix(double[] array) : base(JS.New("DOMMatrix", array)) { }

        /// <summary>
        /// The m11 component of the matrix.
        /// </summary>
        public double M11
        {
            get => JSRef!.Get<double>("m11");
            set => JSRef!.Set("m11", value);
        }

        /// <summary>
        /// The m12 component of the matrix.
        /// </summary>
        public double M12
        {
            get => JSRef!.Get<double>("m12");
            set => JSRef!.Set("m12", value);
        }

        /// <summary>
        /// The m13 component of the matrix.
        /// </summary>
        public double M13
        {
            get => JSRef!.Get<double>("m13");
            set => JSRef!.Set("m13", value);
        }

        /// <summary>
        /// The m14 component of the matrix.
        /// </summary>
        public double M14
        {
            get => JSRef!.Get<double>("m14");
            set => JSRef!.Set("m14", value);
        }

        /// <summary>
        /// The m21 component of the matrix.
        /// </summary>
        public double M21
        {
            get => JSRef!.Get<double>("m21");
            set => JSRef!.Set("m21", value);
        }

        /// <summary>
        /// The m22 component of the matrix.
        /// </summary>
        public double M22
        {
            get => JSRef!.Get<double>("m22");
            set => JSRef!.Set("m22", value);
        }

        /// <summary>
        /// The m23 component of the matrix.
        /// </summary>
        public double M23
        {
            get => JSRef!.Get<double>("m23");
            set => JSRef!.Set("m23", value);
        }

        /// <summary>
        /// The m24 component of the matrix.
        /// </summary>
        public double M24
        {
            get => JSRef!.Get<double>("m24");
            set => JSRef!.Set("m24", value);
        }

        /// <summary>
        /// The m31 component of the matrix.
        /// </summary>
        public double M31
        {
            get => JSRef!.Get<double>("m31");
            set => JSRef!.Set("m31", value);
        }

        /// <summary>
        /// The m32 component of the matrix.
        /// </summary>
        public double M32
        {
            get => JSRef!.Get<double>("m32");
            set => JSRef!.Set("m32", value);
        }

        /// <summary>
        /// The m33 component of the matrix.
        /// </summary>
        public double M33
        {
            get => JSRef!.Get<double>("m33");
            set => JSRef!.Set("m33", value);
        }

        /// <summary>
        /// The m34 component of the matrix.
        /// </summary>
        public double M34
        {
            get => JSRef!.Get<double>("m34");
            set => JSRef!.Set("m34", value);
        }

        /// <summary>
        /// The m41 component of the matrix.
        /// </summary>
        public double M41
        {
            get => JSRef!.Get<double>("m41");
            set => JSRef!.Set("m41", value);
        }

        /// <summary>
        /// The m42 component of the matrix.
        /// </summary>
        public double M42
        {
            get => JSRef!.Get<double>("m42");
            set => JSRef!.Set("m42", value);
        }

        /// <summary>
        /// The m43 component of the matrix.
        /// </summary>
        public double M43
        {
            get => JSRef!.Get<double>("m43");
            set => JSRef!.Set("m43", value);
        }

        /// <summary>
        /// The m44 component of the matrix.
        /// </summary>
        public double M44
        {
            get => JSRef!.Get<double>("m44");
            set => JSRef!.Set("m44", value);
        }
        /// <summary>
        /// The DOMMatrix.multiplySelf() method multiplies the current matrix by another matrix and returns the result.
        /// </summary>
        /// <param name="other">A DOMMatrixInit dictionary or another DOMMatrix object to multiply the matrix by.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix MultiplySelf(DOMMatrixInit other) => JSRef!.Call<DOMMatrix>("multiplySelf", other);

        /// <summary>
        /// The DOMMatrix.preMultiplySelf() method pre-multiplies the current matrix by another matrix and returns the result.
        /// </summary>
        /// <param name="other">A DOMMatrixInit dictionary or another DOMMatrix object to pre-multiply the matrix by.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix PreMultiplySelf(DOMMatrixInit other) => JSRef!.Call<DOMMatrix>("preMultiplySelf", other);

        /// <summary>
        /// The DOMMatrix.translateSelf() method translates the current matrix by the specified x, y, and z values and returns the result.
        /// </summary>
        /// <param name="tx">The x-axis translation value.</param>
        /// <param name="ty">The y-axis translation value.</param>
        /// <param name="tz">The z-axis translation value.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix TranslateSelf(double tx, double ty, double tz = 0) => JSRef!.Call<DOMMatrix>("translateSelf", tx, ty, tz);

        /// <summary>
        /// The DOMMatrix.scaleSelf() method scales the current matrix by the specified x, y, and z values and returns the result.
        /// </summary>
        /// <param name="scaleX">The x-axis scaling value.</param>
        /// <param name="scaleY">The y-axis scaling value.</param>
        /// <param name="scaleZ">The z-axis scaling value.</param>
        /// <param name="originX">The x-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originY">The y-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originZ">The z-axis coordinate of the origin point for the scaling operation.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix ScaleSelf(double scaleX, double scaleY = 1, double scaleZ = 1, double originX = 0, double originY = 0, double originZ = 0) => JSRef!.Call<DOMMatrix>("scaleSelf", scaleX, scaleY, scaleZ, originX, originY, originZ);

        /// <summary>
        /// The DOMMatrix.scale3dSelf() method scales the current matrix by the specified scale factor and returns the result.
        /// </summary>
        /// <param name="scale">The scaling factor.</param>
        /// <param name="originX">The x-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originY">The y-axis coordinate of the origin point for the scaling operation.</param>
        /// <param name="originZ">The z-axis coordinate of the origin point for the scaling operation.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix Scale3dSelf(double scale, double originX = 0, double originY = 0, double originZ = 0) => JSRef!.Call<DOMMatrix>("scale3dSelf", scale, originX, originY, originZ);

        /// <summary>
        /// The DOMMatrix.rotateSelf() method rotates the current matrix by the specified angle and returns the result.
        /// </summary>
        /// <param name="rotX">The x-axis rotation value.</param>
        /// <param name="rotY">The y-axis rotation value.</param>
        /// <param name="rotZ">The z-axis rotation value.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix RotateSelf(double rotX, double rotY = 0, double rotZ = 0) => JSRef!.Call<DOMMatrix>("rotateSelf", rotX, rotY, rotZ);

        /// <summary>
        /// The DOMMatrix.rotateFromVectorSelf() method rotates the current matrix by the specified vector and returns the result.
        /// </summary>
        /// <param name="x">The x component of the vector.</param>
        /// <param name="y">The y component of the vector.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix RotateFromVectorSelf(double x, double y) => JSRef!.Call<DOMMatrix>("rotateFromVectorSelf", x, y);

        /// <summary>
        /// The DOMMatrix.rotateAxisAngleSelf() method rotates the current matrix by the specified angle around the specified axis and returns the result.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the axis of rotation.</param>
        /// <param name="y">The y-axis coordinate of the axis of rotation.</param>
        /// <param name="z">The z-axis coordinate of the axis of rotation.</param>
        /// <param name="angle">The angle of rotation, in degrees.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix RotateAxisAngleSelf(double x, double y, double z, double angle) => JSRef!.Call<DOMMatrix>("rotateAxisAngleSelf", x, y, z, angle);

        /// <summary>
        /// The DOMMatrix.skewXSelf() method skews the current matrix along the x-axis by the specified angle and returns the result.
        /// </summary>
        /// <param name="sx">The angle of skewing along the x-axis, in degrees.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix SkewXSelf(double sx) => JSRef!.Call<DOMMatrix>("skewXSelf", sx);

        /// <summary>
        /// The DOMMatrix.skewYSelf() method skews the current matrix along the y-axis by the specified angle and returns the result.
        /// </summary>
        /// <param name="sy">The angle of skewing along the y-axis, in degrees.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix SkewYSelf(double sy) => JSRef!.Call<DOMMatrix>("skewYSelf", sy);

        /// <summary>
        /// The DOMMatrix.invertSelf() method inverts the current matrix and returns the result.
        /// </summary>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix InvertSelf() => JSRef!.Call<DOMMatrix>("invertSelf");

        /// <summary>
        /// The DOMMatrix.setMatrixValue() method sets the current matrix to the specified transform list and returns the result.
        /// </summary>
        /// <param name="transformList">A string representing a transform list.</param>
        /// <returns>The current DOMMatrix object.</returns>
        public DOMMatrix SetMatrixValue(string transformList) => JSRef!.Call<DOMMatrix>("setMatrixValue", transformList);


    }


}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DOMPointReadOnly interface specifies the coordinate and perspective fields used by DOMPoint to define a 2D or 3D point in a coordinate system.<br/>
    /// There are two ways to create a new DOMPointReadOnly instance. First, you can use its constructor, passing in the values of the parameters for each dimension and, optionally, the perspective.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMPointReadOnly
    /// </summary>
    public class DOMPointReadOnly : JSObject
    {
        /// <inheritdoc/>
        public DOMPointReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The DOMPointReadOnly() constructor creates a new DOMPointReadOnly object representing a 2D or 3D point in a coordinate system.
        /// </summary>
        public DOMPointReadOnly() : base(JS.New("DOMPointReadOnly")) { }

        /// <summary>
        /// The DOMPointReadOnly() constructor creates a new DOMPointReadOnly object representing a 2D or 3D point in a coordinate system.
        /// </summary>
        /// <param name="x">The x-coordinate of the point. Default is 0.</param>
        /// <param name="y">The y-coordinate of the point. Default is 0.</param>
        /// <param name="z">The z-coordinate of the point. Default is 0.</param>
        /// <param name="w">The perspective value of the point. Default is 1.</param>
        public DOMPointReadOnly(double x, double y = 0, double z = 0, double w = 1) : base(JS.New("DOMPointReadOnly", x, y, z, w)) { }

        /// <summary>
        /// Create a new DOMPointReadOnly from an object containing x, y, z, and/or w.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static DOMPointReadOnly FromPoint(object point) => JS.Call<DOMPointReadOnly>($"{nameof(DOMPointReadOnly)}.fromPoint", point);

        /// <summary>
        /// The DOMPointReadOnly.fromPoint() method creates a new DOMPointReadOnly object given a source point.
        /// </summary>
        /// <param name="point">A DOMPointInit dictionary or another DOMPointReadOnly object to initialize the new point with.</param>
        /// <returns>A new DOMPointReadOnly object.</returns>
        public static DOMPointReadOnly FromPoint(DOMPointInit point) => JS.New<DOMPointReadOnly>(nameof(DOMPointReadOnly), point);

        /// <summary>
        /// Create a new DOMPointReadOnly from a DOMPoint.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static DOMPointReadOnly FromPoint(DOMPoint point) => JS.Call<DOMPointReadOnly>($"{nameof(DOMPointReadOnly)}.fromPoint", point);

        /// <summary>
        /// Create a new DOMPointReadOnly from a DOMPointReadOnly.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static DOMPointReadOnly FromPoint(DOMPointReadOnly point) => JS.Call<DOMPointReadOnly>($"{nameof(DOMPointReadOnly)}.fromPoint", point);

        /// <summary>
        /// The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix.
        /// </summary>
        /// <returns>A new DOMPointReadOnly object.</returns>
        public DOMPointReadOnly MatrixTransform() => JSRef!.Call<DOMPointReadOnly>("matrixTransform");

        /// <summary>
        /// The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix.
        /// </summary>
        /// <param name="matrix">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with.</param>
        /// <returns>A new DOMPointReadOnly object.</returns>
        public DOMPointReadOnly MatrixTransform(DOMMatrixInit matrix) => JSRef!.Call<DOMPointReadOnly>("matrixTransform", matrix);

        /// <summary>
        /// The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix.
        /// </summary>
        /// <param name="matrix">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with.</param>
        /// <returns>A new DOMPointReadOnly object.</returns>
        public DOMPointReadOnly MatrixTransform(DOMMatrix matrix) => JSRef!.Call<DOMPointReadOnly>("matrixTransform", matrix);

        /// <summary>
        /// The DOMPointReadOnly.matrixTransform() method returns a new DOMPointReadOnly object which is the result of the transformation of the point by the specified matrix.
        /// </summary>
        /// <param name="matrix">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with.</param>
        /// <returns>A new DOMPointReadOnly object.</returns>
        public DOMPointReadOnly MatrixTransform(DOMMatrixReadOnly matrix) => JSRef!.Call<DOMPointReadOnly>("matrixTransform", matrix);

        /// <summary>
        /// The x coordinate of the point in space.
        /// </summary>
        public double X => JSRef!.Get<double>("x");

        /// <summary>
        /// The y coordinate of the point in space.
        /// </summary>
        public double Y => JSRef!.Get<double>("y");

        /// <summary>
        /// The z coordinate of the point in space.
        /// </summary>
        public double Z => JSRef!.Get<double>("z");

        /// <summary>
        /// The w coordinate of the point in space.
        /// </summary>
        public double W => JSRef!.Get<double>("w");
    }
}

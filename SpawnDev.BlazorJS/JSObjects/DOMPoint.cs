using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMPoint
    /// </summary>
    public class DOMPoint : DOMPointReadOnly
    {
        /// <inheritdoc/>
        public DOMPoint(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The DOMPoint() constructor creates a new DOMPoint object representing a 2D or 3D point in a coordinate system.
        /// </summary>
        /// <param name="x">The x-coordinate of the point. Default is 0.</param>
        /// <param name="y">The y-coordinate of the point. Default is 0.</param>
        /// <param name="z">The z-coordinate of the point. Default is 0.</param>
        /// <param name="w">The perspective value of the point. Default is 1.</param>
        public DOMPoint(double x = 0, double y = 0, double z = 0, double w = 1) : base(JS.New("DOMPoint", x, y, z, w)) { }

        /// <summary>
        /// The x coordinate of the point in space.
        /// </summary>
        public new double X
        {
            get => JSRef!.Get<double>("x");
            set => JSRef!.Set("x", value);
        }

        /// <summary>
        /// The y coordinate of the point in space.
        /// </summary>
        public new double Y
        {
            get => JSRef!.Get<double>("y");
            set => JSRef!.Set("y", value);
        }

        /// <summary>
        /// The z coordinate of the point in space.
        /// </summary>
        public new double Z
        {
            get => JSRef!.Get<double>("z");
            set => JSRef!.Set("z", value);
        }

        /// <summary>
        /// The w coordinate of the point in space.
        /// </summary>
        public new double W
        {
            get => JSRef!.Get<double>("w");
            set => JSRef!.Set("w", value);
        }
        /// <summary>
        /// The DOMPoint.fromPoint() method creates a new DOMPoint object given a source point.
        /// </summary>
        /// <param name="point">A DOMPointInit dictionary or another DOMPoint object to initialize the new point with.</param>
        /// <returns>A new DOMPoint object.</returns>
        public static new DOMPoint FromPoint(DOMPointInit point) => JS.New<DOMPoint>("DOMPoint", point);

        /// <summary>
        /// The DOMPoint.matrixTransform() method returns a new DOMPoint object which is the result of the transformation of the point by the specified matrix.
        /// </summary>
        /// <param name="matrix">A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with.</param>
        /// <returns>A new DOMPoint object.</returns>
        public new DOMPoint MatrixTransform(DOMMatrixInit matrix) => JSRef!.Call<DOMPoint>("matrixTransform", matrix);
    }


}

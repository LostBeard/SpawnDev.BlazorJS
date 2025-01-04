using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Path2D interface of the Canvas 2D API is used to declare a path that can then be used on a CanvasRenderingContext2D object. The path methods of the CanvasRenderingContext2D interface are also present on this interface, which gives you the convenience of being able to retain and replay your path whenever desired.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Path2D
    /// </summary>
    public class Path2D : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Path2D(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object.
        /// </summary>
        public Path2D() : base(JS.New("Path2D")) { }

        /// <summary>
        /// The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object.
        /// </summary>
        /// <param name="path">A Path2D object to clone.</param>
        public Path2D(Path2D path) : base(JS.New("Path2D", path)) { }

        /// <summary>
        /// The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object.
        /// </summary>
        /// <param name="d">A string consisting of SVG path data.</param>
        public Path2D(string d) : base(JS.New("Path2D", d)) { }

        /// <summary>
        /// The Path2D.addPath() method of the Path2D interface adds to the current path.
        /// </summary>
        /// <param name="path">A Path2D object to add.</param>
        /// <param name="transform">An optional DOMMatrix object which, if specified, is used to transform the path when it is added.</param>
        public void AddPath(Path2D path, DOMMatrix? transform = null) => JSRef!.CallVoid("addPath", path, transform);

        /// <summary>
        /// The Path2D.closePath() method of the Canvas 2D API attempts to add a straight line from the current point to the start of the current sub-path.
        /// </summary>
        public void ClosePath() => JSRef!.CallVoid("closePath");

        /// <summary>
        /// The Path2D.moveTo() method of the Canvas 2D API begins a new sub-path at the point specified by the given (x, y) coordinates.
        /// </summary>
        /// <param name="x">The x-axis (horizontal) coordinate of the point.</param>
        /// <param name="y">The y-axis (vertical) coordinate of the point.</param>
        public void MoveTo(double x, double y) => JSRef!.CallVoid("moveTo", x, y);

        /// <summary>
        /// The Path2D.lineTo() method of the Canvas 2D API adds a straight line to the current sub-path by connecting the sub-path's last point to the specified (x, y) coordinates.
        /// </summary>
        /// <param name="x">The x-axis (horizontal) coordinate of the point.</param>
        /// <param name="y">The y-axis (vertical) coordinate of the point.</param>
        public void LineTo(double x, double y) => JSRef!.CallVoid("lineTo", x, y);

        /// <summary>
        /// The Path2D.arc() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the arc's center.</param>
        /// <param name="y">The y-axis coordinate of the arc's center.</param>
        /// <param name="radius">The arc's radius. Must be positive.</param>
        /// <param name="startAngle">The angle at which the arc starts, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="endAngle">The angle at which the arc ends, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="anticlockwise">An optional Boolean which, if true, causes the arc to be drawn counter-clockwise between the two angles. By default it is drawn clockwise.</param>
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise = false) => JSRef!.CallVoid("arc", x, y, radius, startAngle, endAngle, anticlockwise);

        /// <summary>
        /// The Path2D.arcTo() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line.
        /// </summary>
        /// <param name="x1">The x-axis coordinate of the first control point.</param>
        /// <param name="y1">The y-axis coordinate of the first control point.</param>
        /// <param name="x2">The x-axis coordinate of the second control point.</param>
        /// <param name="y2">The y-axis coordinate of the second control point.</param>
        /// <param name="radius">The arc's radius. Must be positive.</param>
        public void ArcTo(double x1, double y1, double x2, double y2, double radius) => JSRef!.CallVoid("arcTo", x1, y1, x2, y2, radius);

        /// <summary>
        /// The Path2D.quadraticCurveTo() method of the Canvas 2D API adds a quadratic Bézier curve to the current sub-path.
        /// </summary>
        /// <param name="cpx">The x-axis coordinate of the control point.</param>
        /// <param name="cpy">The y-axis coordinate of the control point.</param>
        /// <param name="x">The x-axis coordinate of the end point.</param>
        /// <param name="y">The y-axis coordinate of the end point.</param>
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) => JSRef!.CallVoid("quadraticCurveTo", cpx, cpy, x, y);

        /// <summary>
        /// The Path2D.bezierCurveTo() method of the Canvas 2D API adds a cubic Bézier curve to the current sub-path.
        /// </summary>
        /// <param name="cp1x">The x-axis coordinate of the first control point.</param>
        /// <param name="cp1y">The y-axis coordinate of the first control point.</param>
        /// <param name="cp2x">The x-axis coordinate of the second control point.</param>
        /// <param name="cp2y">The y-axis coordinate of the second control point.</param>
        /// <param name="x">The x-axis coordinate of the end point.</param>
        /// <param name="y">The y-axis coordinate of the end point.</param>
        public void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y) => JSRef!.CallVoid("bezierCurveTo", cp1x, cp1y, cp2x, cp2y, x, y);

        /// <summary>
        /// The Path2D.rect() method of the Canvas 2D API adds a rectangle to the current path.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
        /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
        /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
        public void Rect(double x, double y, double width, double height) => JSRef!.CallVoid("rect", x, y, width, height);

        /// <summary>
        /// The Path2D.ellipse() method of the Canvas 2D API adds an elliptical arc to the path which is centered at (x, y) position with the radii radiusX and radiusY starting at startAngle and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise).
        /// </summary>
        /// <param name="x">The x-axis coordinate of the ellipse's center.</param>
        /// <param name="y">The y-axis coordinate of the ellipse's center.</param>
        /// <param name="radiusX">The ellipse's major-axis radius. Must be non-negative.</param>
        /// <param name="radiusY">The ellipse's minor-axis radius. Must be non-negative.</param>
        /// <param name="rotation">The rotation for this ellipse, expressed in radians.</param>
        /// <param name="startAngle">The angle at which the ellipse starts, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="endAngle">The angle at which the ellipse ends, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="anticlockwise">An optional Boolean which, if true, causes the ellipse to be drawn counter-clockwise between the two angles. By default it is drawn clockwise.</param>
        public void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise = false) => JSRef!.CallVoid("ellipse", x, y, radiusX, radiusY, rotation, startAngle, endAngle, anticlockwise);
    }
}

# Path2D

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Path2D.cs`  
**MDN Reference:** [Path2D on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Path2D)

> The Path2D interface of the Canvas 2D API is used to declare a path that can then be used on a CanvasRenderingContext2D object. The path methods of the CanvasRenderingContext2D interface are also present on this interface, which gives you the convenience of being able to retain and replay your path whenever desired. https://developer.mozilla.org/en-US/docs/Web/API/Path2D

## Constructors

| Signature | Description |
|---|---|
| `Path2D(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Path2D()` | The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object. |
| `Path2D(Path2D path)` | The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object. A Path2D object to clone. |
| `Path2D(string d)` | The Path2D() constructor of the Path2D interface returns a newly instantiated Path2D object. A string consisting of SVG path data. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AddPath(Path2D path, DOMMatrix? transform)` | `void` | The Path2D.addPath() method of the Path2D interface adds to the current path. A Path2D object to add. An optional DOMMatrix object which, if specified, is used to transform the path when it is added. |
| `ClosePath()` | `void` | The Path2D.closePath() method of the Canvas 2D API attempts to add a straight line from the current point to the start of the current sub-path. |
| `MoveTo(double x, double y)` | `void` | The Path2D.moveTo() method of the Canvas 2D API begins a new sub-path at the point specified by the given (x, y) coordinates. The x-axis (horizontal) coordinate of the point. The y-axis (vertical) coordinate of the point. |
| `LineTo(double x, double y)` | `void` | The Path2D.lineTo() method of the Canvas 2D API adds a straight line to the current sub-path by connecting the sub-path's last point to the specified (x, y) coordinates. The x-axis (horizontal) coordinate of the point. The y-axis (vertical) coordinate of the point. |
| `Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise)` | `void` | The Path2D.arc() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line. The x-axis coordinate of the arc's center. The y-axis coordinate of the arc's center. The arc's radius. Must be positive. The angle at which the arc starts, measured clockwise from the positive x-axis and expressed in radians. The angle at which the arc ends, measured clockwise from the positive x-axis and expressed in radians. An optional Boolean which, if true, causes the arc to be drawn counter-clockwise between the two angles. By default it is drawn clockwise. |
| `ArcTo(double x1, double y1, double x2, double y2, double radius)` | `void` | The Path2D.arcTo() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line. The x-axis coordinate of the first control point. The y-axis coordinate of the first control point. The x-axis coordinate of the second control point. The y-axis coordinate of the second control point. The arc's radius. Must be positive. |
| `QuadraticCurveTo(double cpx, double cpy, double x, double y)` | `void` | The Path2D.quadraticCurveTo() method of the Canvas 2D API adds a quadratic Bézier curve to the current sub-path. The x-axis coordinate of the control point. The y-axis coordinate of the control point. The x-axis coordinate of the end point. The y-axis coordinate of the end point. |
| `BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)` | `void` | The Path2D.bezierCurveTo() method of the Canvas 2D API adds a cubic Bézier curve to the current sub-path. The x-axis coordinate of the first control point. The y-axis coordinate of the first control point. The x-axis coordinate of the second control point. The y-axis coordinate of the second control point. The x-axis coordinate of the end point. The y-axis coordinate of the end point. |
| `Rect(double x, double y, double width, double height)` | `void` | The Path2D.rect() method of the Canvas 2D API adds a rectangle to the current path. The x-axis coordinate of the rectangle's starting point. The y-axis coordinate of the rectangle's starting point. The rectangle's width. Positive values are to the right, and negative to the left. The rectangle's height. Positive values are down, and negative are up. |
| `Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise)` | `void` | The Path2D.ellipse() method of the Canvas 2D API adds an elliptical arc to the path which is centered at (x, y) position with the radii radiusX and radiusY starting at startAngle and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise). The x-axis coordinate of the ellipse's center. The y-axis coordinate of the ellipse's center. The ellipse's major-axis radius. Must be non-negative. The ellipse's minor-axis radius. Must be non-negative. The rotation for this ellipse, expressed in radians. The angle at which the ellipse starts, measured clockwise from the positive x-axis and expressed in radians. The angle at which the ellipse ends, measured clockwise from the positive x-axis and expressed in radians. An optional Boolean which, if true, causes the ellipse to be drawn counter-clockwise between the two angles. By default it is drawn clockwise. |


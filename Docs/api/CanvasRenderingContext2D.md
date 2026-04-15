# CanvasRenderingContext2D

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/CanvasRenderingContext2D.cs`  
**MDN Reference:** [CanvasRenderingContext2D on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D)

> The CanvasRenderingContext2D interface, part of the Canvas API, provides the 2D rendering context for the drawing surface of a &lt;canvas&gt; element. It is used for drawing shapes, text, images, and other objects. https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D

## Constructors

| Signature | Description |
|---|---|
| `CanvasRenderingContext2D(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ImageSmoothingEnabled` | `bool` | get | Image smoothing mode; if disabled, images will not be smoothed if scaled. |
| `Canvas` | `HTMLCanvasElement` | get | The CanvasRenderingContext2D.canvas property, part of the Canvas API, is a read-only reference to the HTMLCanvasElement object that is associated with a given context. It might be null if there is no associated canvas element. |
| `FillStyle` | `string` | get | Color or style to use inside shapes. Default #000 (black). |
| `LineCap` | `string` | get | The CanvasRenderingContext2D.lineCap property of the Canvas 2D API determines the shape used to draw the end points of lines. |
| `LineJoin` | `string` | get | The CanvasRenderingContext2D.lineJoin property of the Canvas 2D API determines the shape used to join two line segments where they meet. |
| `MiterLimit` | `double` | get | The CanvasRenderingContext2D.miterLimit property of the Canvas 2D API sets the miter limit ratio. |
| `ShadowBlur` | `double` | get | The CanvasRenderingContext2D.shadowBlur property of the Canvas 2D API specifies the level of blur applied to shadows. |
| `ShadowColor` | `string` | get | The CanvasRenderingContext2D.shadowColor property of the Canvas 2D API specifies the color of shadows. |
| `ShadowOffsetX` | `double` | get | The CanvasRenderingContext2D.shadowOffsetX property of the Canvas 2D API specifies the distance that shadows will be offset horizontally. |
| `ShadowOffsetY` | `double` | get | The CanvasRenderingContext2D.shadowOffsetY property of the Canvas 2D API specifies the distance that shadows will be offset vertically. |
| `StrokeStyle` | `string` | get | The CanvasRenderingContext2D.strokeStyle property of the Canvas 2D API specifies the color or style to use for the lines around shapes. |
| `LineWidth` | `double` | get | The CanvasRenderingContext2D.lineWidth property of the Canvas 2D API sets the thickness of lines in space units. |
| `GlobalAlpha` | `double` | get | The CanvasRenderingContext2D.globalAlpha property of the Canvas 2D API specifies the alpha value that is applied to shapes and images before they are drawn onto the canvas. |
| `GlobalCompositeOperation` | `string` | get | The CanvasRenderingContext2D.globalCompositeOperation property of the Canvas 2D API sets the type of compositing operation to apply when drawing new shapes. |
| `LineDashOffset` | `double` | get | The CanvasRenderingContext2D.lineDashOffset property of the Canvas 2D API sets the phase (offset) of the current line dash pattern. |
| `TextAlign` | `string` | get | The CanvasRenderingContext2D.textAlign property of the Canvas 2D API specifies the current text alignment. |
| `TextBaseline` | `string` | get | The CanvasRenderingContext2D.textBaseline property of the Canvas 2D API specifies the current text baseline used when drawing text. |
| `Direction` | `string` | get/set | The CanvasRenderingContext2D.direction property of the Canvas 2D API specifies the current text direction used when drawing text. |
| `ImageSmoothingQuality` | `string` | get | The CanvasRenderingContext2D.imageSmoothingQuality property of the Canvas 2D API allows you to set the quality of image smoothing. |
| `Filter` | `string` | get | The CanvasRenderingContext2D.filter property of the Canvas 2D API provides filter effects like blurring and grayscale. |
| `CurrentTransform` | `DOMMatrix` | get | The CanvasRenderingContext2D.currentTransform property of the Canvas 2D API returns or sets the current transformation matrix being applied to the context. |
| `FontKerning` | `string` | get | The CanvasRenderingContext2D.fontKerning property of the Canvas 2D API controls the use of kerning when drawing text. |
| `LetterSpacing` | `string` | get | The CanvasRenderingContext2D.letterSpacing property of the Canvas 2D API sets the spacing between text characters when drawing text. |
| `TextRendering` | `string` | get | The CanvasRenderingContext2D.textRendering property of the Canvas 2D API provides a hint to the browser about what aspects of text rendering are most important. |
| `WordSpacing` | `string` | get | The CanvasRenderingContext2D.wordSpacing property of the Canvas 2D API sets the spacing between words when drawing text. |
| `Font` | `string` | get | The CanvasRenderingContext2D.font property of the Canvas 2D API specifies the current text style to use when drawing text. This string uses the same syntax as the CSS font specifier. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetFillStyle(CanvasGradient gradient)` | `void` | Sets fillStyle to a CanvasGradient. A CanvasGradient object to use as the fill style. |
| `SetFillStyle(CanvasPattern pattern)` | `void` | Sets fillStyle to a CanvasPattern. A CanvasPattern object to use as the fill style. |
| `SetStrokeStyle(CanvasGradient gradient)` | `void` | Sets strokeStyle to a CanvasGradient. A CanvasGradient object to use as the stroke style. |
| `SetStrokeStyle(CanvasPattern pattern)` | `void` | Sets strokeStyle to a CanvasPattern. A CanvasPattern object to use as the stroke style. |
| `GetImageData()` | `ImageData?` | Returns the ImageData for the entire canvas |
| `MeasureText(string text)` | `TextMetrics` | The CanvasRenderingContext2D.measureText() method returns a TextMetrics object that contains information about the measured text (such as its width, for example). |
| `GetImageBytes()` | `byte[]?` |  |
| `GetImageBytes(double x, double y, double width, double height)` | `byte[]?` | Returns a byte[] from GetImageData |
| `PutImageBytes(byte[] srcBytes, double srcWidth, double srcHeight, double dx, double dy)` | `void` | PutImageData using byte[] |
| `PutImageBytes(byte[] imageBytes, double srcWidth, double srcHeight, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight)` | `void` | PutImageData using byte[] |
| `DrawImage(CanvasImageSource imageData, double dx, double dy)` | `void` | Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use. An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame. The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image. |
| `DrawImage(CanvasImageSource imageData, double dx, double dy, double dWidth, double dHeight)` | `void` | Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use. An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame. The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax. The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax. |
| `DrawImage(CanvasImageSource imageData, double sx, double sy, double sWidth, double sHeight, double dx, double dy, double dWidth, double dHeight)` | `void` | Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use. An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame. The x-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument. The y-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument. The width of the sub-rectangle of the source image to draw into the destination context. If not specified, the entire rectangle from the coordinates specified by sx and sy to the bottom-right corner of the image is used. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image. The height of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image. The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax. The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax. |
| `FillRect(double x, double y, double width, double height)` | `void` | Draws a filled rectangle at (x, y) position whose size is determined by width and height. The x-axis coordinate of the rectangle's starting point. The y-axis coordinate of the rectangle's starting point. The rectangle's width. Positive values are to the right, and negative to the left. The rectangle's height. Positive values are down, and negative are up. |
| `ClearRect(double x, double y, double width, double height)` | `void` | Sets all pixels in the rectangle defined by starting point (x, y) and size (width, height) to transparent black, erasing any previously drawn content. The x-axis coordinate of the rectangle's starting point. The y-axis coordinate of the rectangle's starting point. The rectangle's width. Positive values are to the right, and negative to the left. The rectangle's height. Positive values are down, and negative are up. |
| `StrokeRect(double x, double y, double width, double height)` | `void` | Paints a rectangle which has a starting point at (x, y) and has a w width and an h height onto the canvas, using the current stroke style. The x-axis coordinate of the rectangle's starting point. The y-axis coordinate of the rectangle's starting point. The rectangle's width. Positive values are to the right, and negative to the left. The rectangle's height. Positive values are down, and negative are up. |
| `FillText(string text, double x, double y)` | `void` | Fills a given text at the given (x,y) position. Optionally with a maximum width to draw. |
| `FillText(string text, double x, double y, double maxWidth)` | `void` | Fills a given text at the given (x,y) position. Optionally with a maximum width to draw. |
| `StrokeText(string text, double x, double y)` | `void` | Draws (strokes) a given text at the given (x, y) position. |
| `StrokeText(string text, double x, double y, double maxWidth)` | `void` | Draws (strokes) a given text at the given (x, y) position. |
| `CreateImageData(double width, double height)` | `ImageData` | The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black. The width to give the new ImageData object. A negative value flips the rectangle around the vertical axis. The height to give the new ImageData object. A negative value flips the rectangle around the horizontal axis. |
| `CreateImageData(double width, double height, ImageDataSettings settings)` | `ImageData` | The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black. The width to give the new ImageData object. A negative value flips the rectangle around the vertical axis. The height to give the new ImageData object. A negative value flips the rectangle around the horizontal axis. |
| `CreateImageData(ImageData imageData)` | `ImageData` | The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black. An existing ImageData object from which to copy the width and height. The image itself is not copied. |
| `BeginPath()` | `void` | The CanvasRenderingContext2D.beginPath() method of the Canvas 2D API starts a new path by emptying the list of sub-paths. |
| `ClosePath()` | `void` | The CanvasRenderingContext2D.closePath() method of the Canvas 2D API attempts to add a straight line from the current point to the start of the current sub-path. |
| `MoveTo(double x, double y)` | `void` | The CanvasRenderingContext2D.moveTo() method of the Canvas 2D API begins a new sub-path at the point specified by the given (x, y) coordinates. The x-axis (horizontal) coordinate of the point. The y-axis (vertical) coordinate of the point. |
| `LineTo(double x, double y)` | `void` | The CanvasRenderingContext2D.lineTo() method of the Canvas 2D API adds a straight line to the current sub-path by connecting the sub-path's last point to the specified (x, y) coordinates. The x-axis (horizontal) coordinate of the point. The y-axis (vertical) coordinate of the point. |
| `Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise)` | `void` | The CanvasRenderingContext2D.arc() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line. The x-axis coordinate of the arc's center. The y-axis coordinate of the arc's center. The arc's radius. Must be positive. The angle at which the arc starts, measured clockwise from the positive x-axis and expressed in radians. The angle at which the arc ends, measured clockwise from the positive x-axis and expressed in radians. An optional Boolean which, if true, causes the arc to be drawn counter-clockwise between the two angles. By default it is drawn clockwise. |
| `ArcTo(double x1, double y1, double x2, double y2, double radius)` | `void` | The CanvasRenderingContext2D.arcTo() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line. The x-axis coordinate of the first control point. The y-axis coordinate of the first control point. The x-axis coordinate of the second control point. The y-axis coordinate of the second control point. The arc's radius. Must be positive. |
| `QuadraticCurveTo(double cpx, double cpy, double x, double y)` | `void` | The CanvasRenderingContext2D.quadraticCurveTo() method of the Canvas 2D API adds a quadratic Bézier curve to the current sub-path. The x-axis coordinate of the control point. The y-axis coordinate of the control point. The x-axis coordinate of the end point. The y-axis coordinate of the end point. |
| `BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y)` | `void` | The CanvasRenderingContext2D.bezierCurveTo() method of the Canvas 2D API adds a cubic Bézier curve to the current sub-path. The x-axis coordinate of the first control point. The y-axis coordinate of the first control point. The x-axis coordinate of the second control point. The y-axis coordinate of the second control point. The x-axis coordinate of the end point. The y-axis coordinate of the end point. |
| `Rect(double x, double y, double width, double height)` | `void` | The CanvasRenderingContext2D.rect() method of the Canvas 2D API adds a rectangle to the current path. The x-axis coordinate of the rectangle's starting point. The y-axis coordinate of the rectangle's starting point. The rectangle's width. Positive values are to the right, and negative to the left. The rectangle's height. Positive values are down, and negative are up. |
| `Fill()` | `void` | The CanvasRenderingContext2D.fill() method of the Canvas 2D API fills the current or given path with the current fill style. |
| `Fill(Path2D path)` | `void` | The CanvasRenderingContext2D.fill() method of the Canvas 2D API fills the current or given path with the current fill style. A Path2D object to fill. If not specified, the current path is filled. |
| `Stroke()` | `void` | The CanvasRenderingContext2D.stroke() method of the Canvas 2D API strokes (outlines) the current or given path with the current stroke style. |
| `Stroke(Path2D path)` | `void` | The CanvasRenderingContext2D.stroke() method of the Canvas 2D API strokes (outlines) the current or given path with the current stroke style. A Path2D object to stroke. If not specified, the current path is stroked. |
| `Clip()` | `void` | The CanvasRenderingContext2D.clip() method of the Canvas 2D API turns the path currently being built into the current clipping path. |
| `Clip(Path2D path)` | `void` | The CanvasRenderingContext2D.clip() method of the Canvas 2D API turns the path currently being built into the current clipping path. A Path2D object to clip. If not specified, the current path is clipped. |
| `IsPointInPath(double x, double y)` | `bool` | The CanvasRenderingContext2D.isPointInPath() method of the Canvas 2D API reports whether or not the specified point is contained in the current path. The x-axis coordinate of the point to check. The y-axis coordinate of the point to check. True if the specified point is contained in the current path; otherwise, false. |
| `IsPointInPath(Path2D path, double x, double y)` | `bool` | The CanvasRenderingContext2D.isPointInPath() method of the Canvas 2D API reports whether or not the specified point is contained in the current path. A Path2D object to check. If not specified, the current path is checked. The x-axis coordinate of the point to check. The y-axis coordinate of the point to check. True if the specified point is contained in the current path; otherwise, false. |
| `IsPointInStroke(double x, double y)` | `bool` | The CanvasRenderingContext2D.isPointInStroke() method of the Canvas 2D API reports whether or not the specified point is inside the area contained by the stroking of a path. The x-axis coordinate of the point to check. The y-axis coordinate of the point to check. True if the specified point is inside the area contained by the stroking of a path; otherwise, false. |
| `IsPointInStroke(Path2D path, double x, double y)` | `bool` | The CanvasRenderingContext2D.isPointInStroke() method of the Canvas 2D API reports whether or not the specified point is inside the area contained by the stroking of a path. A Path2D object to check. If not specified, the current path is checked. The x-axis coordinate of the point to check. The y-axis coordinate of the point to check. True if the specified point is inside the area contained by the stroking of a path; otherwise, false. |
| `Rotate(double angle)` | `void` | The CanvasRenderingContext2D.rotate() method of the Canvas 2D API adds a rotation to the transformation matrix. The angle to rotate the context, in radians. |
| `Scale(double x, double y)` | `void` | The CanvasRenderingContext2D.scale() method of the Canvas 2D API adds a scaling transformation to the canvas units by x horizontally and by y vertically. Scaling factor in the horizontal direction. A negative value flips pixels across the vertical axis. A value of 1 results in no horizontal scaling. Scaling factor in the vertical direction. A negative value flips pixels across the horizontal axis. A value of 1 results in no vertical scaling. |
| `Translate(double x, double y)` | `void` | The CanvasRenderingContext2D.translate() method of the Canvas 2D API adds a translation transformation to the current matrix. Distance to move in the horizontal direction. Positive values are to the right, and negative to the left. Distance to move in the vertical direction. Positive values are down, and negative are up. |
| `Transform(double a, double b, double c, double d, double e, double f)` | `void` | The CanvasRenderingContext2D.transform() method of the Canvas 2D API multiplies the current transformation with the matrix described by the arguments of this method. Horizontal scaling. A value of 1 results in no scaling. Horizontal skewing. Vertical skewing. Vertical scaling. A value of 1 results in no scaling. Horizontal translation. Vertical translation. |
| `SetTransform(double a, double b, double c, double d, double e, double f)` | `void` | The CanvasRenderingContext2D.setTransform() method of the Canvas 2D API resets (overrides) the current transformation to the identity matrix, and then invokes a transformation described by the arguments of this method. Horizontal scaling. A value of 1 results in no scaling. Horizontal skewing. Vertical skewing. Vertical scaling. A value of 1 results in no scaling. Horizontal translation. Vertical translation. |
| `ResetTransform()` | `void` | The CanvasRenderingContext2D.resetTransform() method of the Canvas 2D API resets the current transform to the identity matrix. |
| `Save()` | `void` | The CanvasRenderingContext2D.save() method of the Canvas 2D API saves the entire state of the canvas by pushing the current state onto a stack. |
| `Restore()` | `void` | The CanvasRenderingContext2D.restore() method of the Canvas 2D API restores the most recently saved canvas state by popping the top entry in the drawing state stack. If there is no saved state, this method does nothing. |
| `GetLineDash()` | `double[]` | The CanvasRenderingContext2D.getLineDash() method of the Canvas 2D API returns the current line dash pattern array containing an even number of non-negative numbers. An array of numbers that specifies distances to alternately draw a line and a gap (in coordinate space units). |
| `SetLineDash(double[] segments)` | `void` | The CanvasRenderingContext2D.setLineDash() method of the Canvas 2D API sets the current line dash pattern. An array of numbers that specifies distances to alternately draw a line and a gap (in coordinate space units). |
| `CreatePattern(HTMLImageElement image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(SVGImageElement image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(HTMLVideoElement image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(HTMLCanvasElement image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(ImageBitmap image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(OffscreenCanvas image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreatePattern(VideoFrame image, string repetition)` | `CanvasPattern` | The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument. A CanvasImageSource to be used as the image to repeat. A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat". A CanvasPattern object that can be used as a fill or stroke style. |
| `CreateLinearGradient(double x0, double y0, double x1, double y1)` | `CanvasGradient` | The CanvasRenderingContext2D.createLinearGradient() method of the Canvas 2D API creates a linear gradient along the line connecting two given coordinates. The x-axis coordinate of the start point. The y-axis coordinate of the start point. The x-axis coordinate of the end point. The y-axis coordinate of the end point. A CanvasGradient object representing the linear gradient. |
| `CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1)` | `CanvasGradient` | The CanvasRenderingContext2D.createRadialGradient() method of the Canvas 2D API creates a radial gradient using the size and coordinates of two circles. The x-axis coordinate of the start circle's center. The y-axis coordinate of the start circle's center. The radius of the start circle. The x-axis coordinate of the end circle's center. The y-axis coordinate of the end circle's center. The radius of the end circle. A CanvasGradient object representing the radial gradient. |
| `DrawFocusIfNeeded(Element element)` | `void` | The CanvasRenderingContext2D.drawFocusIfNeeded() method of the Canvas 2D API draws a focus ring around the current path if the element is focused. The element to check for focus. |
| `GetTransform()` | `DOMMatrix` | The CanvasRenderingContext2D.getTransform() method of the Canvas 2D API returns a copy of the current transformation matrix being applied to the context. A DOMMatrix object representing the current transformation matrix. |
| `Reset()` | `void` | The CanvasRenderingContext2D.reset() method of the Canvas 2D API resets the rendering context to its default state. |
| `ScrollPathIntoView()` | `void` | The CanvasRenderingContext2D.scrollPathIntoView() method of the Canvas 2D API scrolls the current path or a given path into the view. |
| `ScrollPathIntoView(Path2D path)` | `void` | The CanvasRenderingContext2D.scrollPathIntoView() method of the Canvas 2D API scrolls the current path or a given path into the view. A Path2D object to scroll into view. |
| `GetImageData(double sx, double sy, double sw, double sh)` | `ImageData` | The CanvasRenderingContext2D.getImageData() method of the Canvas 2D API returns an ImageData object representing the underlying pixel data for a specified portion of the canvas. The x-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted. The y-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted. The width of the rectangle from which the ImageData will be extracted. The height of the rectangle from which the ImageData will be extracted. An ImageData object representing the underlying pixel data for the specified portion of the canvas. |
| `PutImageData(ImageData imageData, double dx, double dy)` | `void` | The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas. An ImageData object containing the image data to be painted onto the canvas. The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image. |
| `PutImageData(ImageData imageData, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight)` | `void` | The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas. An ImageData object containing the image data to be painted onto the canvas. The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image. The x-axis coordinate of the top-left corner of the rectangle to be painted. The y-axis coordinate of the top-left corner of the rectangle to be painted. The width of the rectangle to be painted. The height of the rectangle to be painted. |
| `GetImageData(double sx, double sy, double sw, double sh, ImageDataSettings settings)` | `ImageData` | The CanvasRenderingContext2D.getImageData() method of the Canvas 2D API returns an ImageData object representing the underlying pixel data for a specified portion of the canvas. The x-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted. The y-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted. The width of the rectangle from which the ImageData will be extracted. The height of the rectangle from which the ImageData will be extracted. An optional ImageDataSettings object to specify additional settings. An ImageData object representing the underlying pixel data for the specified portion of the canvas. |
| `GetContextAttributes()` | `CanvasRenderingContext2DSettings` | The CanvasRenderingContext2D.getContextAttributes() method of the Canvas 2D API returns an object that contains the actual context parameters. An object containing the actual context parameters. |

## Example

```csharp
// Get a 2D context from a canvas
using var canvas = new HTMLCanvasElement(canvasRef);
canvas.Width = 640;
canvas.Height = 480;
using var ctx = canvas.Get2DContext();

// Draw filled and stroked rectangles
ctx.FillStyle = "#3498db";
ctx.FillRect(10, 10, 200, 100);

ctx.StrokeStyle = "#e74c3c";
ctx.LineWidth = 3;
ctx.StrokeRect(10, 10, 200, 100);

// Clear a region
ctx.ClearRect(50, 50, 50, 50);

// Draw text
ctx.Font = "24px Arial";
ctx.FillStyle = "black";
ctx.FillText("Hello, Canvas!", 10, 180);

ctx.StrokeStyle = "navy";
ctx.StrokeText("Outlined text", 10, 220);

// Draw paths - a triangle
ctx.BeginPath();
ctx.MoveTo(300, 10);
ctx.LineTo(350, 100);
ctx.LineTo(250, 100);
ctx.ClosePath();
ctx.FillStyle = "#2ecc71";
ctx.Fill();
ctx.Stroke();

// Draw an arc (circle)
ctx.BeginPath();
ctx.Arc(450, 60, 50, 0, 2 * Math.PI);
ctx.FillStyle = "#9b59b6";
ctx.Fill();

// Save and restore state
ctx.Save();
ctx.GlobalAlpha = 0.5;
ctx.FillStyle = "red";
ctx.FillRect(400, 150, 100, 100);
ctx.Restore();
// GlobalAlpha is back to 1.0 after Restore()

// Draw a video frame or image onto the canvas
using var video = new HTMLVideoElement(videoRef);
ctx.DrawImage(video, 0, 0, 640, 480);

// Read pixel data
using var imageData = ctx.GetImageData(0, 0, 640, 480);
using var pixelData = imageData.Data;

// Write pixel data back
ctx.PutImageData(imageData, 0, 0);

// Measure text width
using var metrics = ctx.MeasureText("Sample text");
```


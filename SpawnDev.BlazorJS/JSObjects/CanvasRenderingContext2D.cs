using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;
using System.Data.SqlTypes;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CanvasRenderingContext2D interface, part of the Canvas API, provides the 2D rendering context for the drawing surface of a &lt;canvas&gt; element. It is used for drawing shapes, text, images, and other objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D
    /// </summary>
    public class CanvasRenderingContext2D : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CanvasRenderingContext2D(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Image smoothing mode; if disabled, images will not be smoothed if scaled.
        /// </summary>
        public bool ImageSmoothingEnabled { get => JSRef!.Get<bool>("imageSmoothingEnabled"); set => JSRef!.Set("imageSmoothingEnabled", value); }
        /// <summary>
        /// The CanvasRenderingContext2D.canvas property, part of the Canvas API, is a read-only reference to the HTMLCanvasElement object that is associated with a given context. It might be null if there is no associated canvas element.
        /// </summary>
        public HTMLCanvasElement Canvas => JSRef!.Get<HTMLCanvasElement>("canvas");
        /// <summary>
        /// Color or style to use inside shapes. Default #000 (black).
        /// </summary>
        public string FillStyle { get => JSRef!.Get<string>("fillStyle"); set => JSRef!.Set("fillStyle", value); }
        /// <summary>
        /// The CanvasRenderingContext2D.lineCap property of the Canvas 2D API determines the shape used to draw the end points of lines.
        /// </summary>
        public string LineCap { get => JSRef!.Get<string>("lineCap"); set => JSRef!.Set("lineCap", value); }
        /// <summary>
        /// The CanvasRenderingContext2D.lineJoin property of the Canvas 2D API determines the shape used to join two line segments where they meet.
        /// </summary>
        public string LineJoin { get => JSRef!.Get<string>("lineJoin"); set => JSRef!.Set("lineJoin", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.miterLimit property of the Canvas 2D API sets the miter limit ratio.
        /// </summary>
        public double MiterLimit { get => JSRef!.Get<double>("miterLimit"); set => JSRef!.Set("miterLimit", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.shadowBlur property of the Canvas 2D API specifies the level of blur applied to shadows.
        /// </summary>
        public double ShadowBlur { get => JSRef!.Get<double>("shadowBlur"); set => JSRef!.Set("shadowBlur", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.shadowColor property of the Canvas 2D API specifies the color of shadows.
        /// </summary>
        public string ShadowColor { get => JSRef!.Get<string>("shadowColor"); set => JSRef!.Set("shadowColor", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.shadowOffsetX property of the Canvas 2D API specifies the distance that shadows will be offset horizontally.
        /// </summary>
        public double ShadowOffsetX { get => JSRef!.Get<double>("shadowOffsetX"); set => JSRef!.Set("shadowOffsetX", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.shadowOffsetY property of the Canvas 2D API specifies the distance that shadows will be offset vertically.
        /// </summary>
        public double ShadowOffsetY { get => JSRef!.Get<double>("shadowOffsetY"); set => JSRef!.Set("shadowOffsetY", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.strokeStyle property of the Canvas 2D API specifies the color or style to use for the lines around shapes.
        /// </summary>
        public string StrokeStyle { get => JSRef!.Get<string>("strokeStyle"); set => JSRef!.Set("strokeStyle", value); }

        /// <summary>
        /// The CanvasRenderingContext2D.lineWidth property of the Canvas 2D API sets the thickness of lines in space units.
        /// </summary>
        public double LineWidth { get => JSRef!.Get<double>("lineWidth"); set => JSRef!.Set("lineWidth", value); }
        /// <summary>
        /// The CanvasRenderingContext2D.globalAlpha property of the Canvas 2D API specifies the alpha value that is applied to shapes and images before they are drawn onto the canvas.
        /// </summary>
        public double GlobalAlpha
        {
            get => JSRef!.Get<double>("globalAlpha");
            set => JSRef!.Set("globalAlpha", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.globalCompositeOperation property of the Canvas 2D API sets the type of compositing operation to apply when drawing new shapes.
        /// </summary>
        public string GlobalCompositeOperation
        {
            get => JSRef!.Get<string>("globalCompositeOperation");
            set => JSRef!.Set("globalCompositeOperation", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.lineDashOffset property of the Canvas 2D API sets the phase (offset) of the current line dash pattern.
        /// </summary>
        public double LineDashOffset
        {
            get => JSRef!.Get<double>("lineDashOffset");
            set => JSRef!.Set("lineDashOffset", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.textAlign property of the Canvas 2D API specifies the current text alignment.
        /// </summary>
        public string TextAlign
        {
            get => JSRef!.Get<string>("textAlign");
            set => JSRef!.Set("textAlign", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.textBaseline property of the Canvas 2D API specifies the current text baseline used when drawing text.
        /// </summary>
        public string TextBaseline
        {
            get => JSRef!.Get<string>("textBaseline");
            set => JSRef!.Set("textBaseline", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.direction property of the Canvas 2D API specifies the current text direction used when drawing text.
        /// </summary>
        public string Direction
        {
            get => JSRef!.Get<string>("direction");
            set => JSRef!.Set("direction", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.imageSmoothingQuality property of the Canvas 2D API allows you to set the quality of image smoothing.
        /// </summary>
        public string ImageSmoothingQuality
        {
            get => JSRef!.Get<string>("imageSmoothingQuality");
            set => JSRef!.Set("imageSmoothingQuality", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.filter property of the Canvas 2D API provides filter effects like blurring and grayscale.
        /// </summary>
        public string Filter
        {
            get => JSRef!.Get<string>("filter");
            set => JSRef!.Set("filter", value);
        }
        /// <summary>
        /// The CanvasRenderingContext2D.currentTransform property of the Canvas 2D API returns or sets the current transformation matrix being applied to the context.
        /// </summary>
        public DOMMatrix CurrentTransform
        {
            get => JSRef!.Get<DOMMatrix>("currentTransform");
            set => JSRef!.Set("currentTransform", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.fontKerning property of the Canvas 2D API controls the use of kerning when drawing text.
        /// </summary>
        public string FontKerning
        {
            get => JSRef!.Get<string>("fontKerning");
            set => JSRef!.Set("fontKerning", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.letterSpacing property of the Canvas 2D API sets the spacing between text characters when drawing text.
        /// </summary>
        public string LetterSpacing
        {
            get => JSRef!.Get<string>("letterSpacing");
            set => JSRef!.Set("letterSpacing", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.textRendering property of the Canvas 2D API provides a hint to the browser about what aspects of text rendering are most important.
        /// </summary>
        public string TextRendering
        {
            get => JSRef!.Get<string>("textRendering");
            set => JSRef!.Set("textRendering", value);
        }

        /// <summary>
        /// The CanvasRenderingContext2D.wordSpacing property of the Canvas 2D API sets the spacing between words when drawing text.
        /// </summary>
        public string WordSpacing
        {
            get => JSRef!.Get<string>("wordSpacing");
            set => JSRef!.Set("wordSpacing", value);
        }


        /// <summary>
        /// Returns the ImageData for the entire canvas
        /// </summary>
        /// <returns></returns>
        public ImageData? GetImageData()
        {
            using var canvas = Canvas;
            return GetImageData(0, 0, canvas.Width, canvas.Height);
        }
        /// <summary>
        /// Returns an ImageData object representing the underlying pixel data for the area of the canvas denoted by the rectangle which starts at (sx, sy) and has an sw width and sh height.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ImageData GetImageData(int x, int y, int width, int height) => JSRef!.Call<ImageData>("getImageData", x, y, width, height);
        /// <summary>
        /// The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas. If a dirty rectangle is provided, only the pixels from that rectangle are painted. This method is not affected by the canvas transformation matrix.
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void PutImageData(ImageData imageData, int dx, int dy) => JSRef!.CallVoid("putImageData", imageData, dx, dy);
        /// <summary>
        /// The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas. If a dirty rectangle is provided, only the pixels from that rectangle are painted. This method is not affected by the canvas transformation matrix.
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dirtyX"></param>
        /// <param name="dirtyY"></param>
        /// <param name="dirtyWidth"></param>
        /// <param name="dirtyHeight"></param>
        public void PutImageData(ImageData imageData, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight) => JSRef!.CallVoid("putImageData", imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        /// <summary>
        /// The CanvasRenderingContext2D.font property of the Canvas 2D API specifies the current text style to use when drawing text. This string uses the same syntax as the CSS font specifier.
        /// </summary>
        public string Font { get => JSRef!.Get<string>("font"); set => JSRef!.Set("font", value); }
        /// <summary>
        /// The CanvasRenderingContext2D.measureText() method returns a TextMetrics object that contains information about the measured text (such as its width, for example).
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public TextMetrics MeasureText(string text) => JSRef!.Call<TextMetrics>("measureText", text);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[]? GetImageBytes()
        {
            using var canvas = Canvas;
            return GetImageBytes(0, 0, canvas.Width, canvas.Height);
        }
        /// <summary>
        /// Returns a byte[] from GetImageData
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public byte[]? GetImageBytes(int x, int y, int width, int height)
        {
            byte[]? ret = null;
            using ImageData? frameData = GetImageData(x, y, width, height);
            if (frameData != null)
            {
                using var frameDataData = frameData.Data;
                ret = frameDataData.ReadBytes();
            }
            return ret;
        }
        /// <summary>
        /// PutImageData using byte[]
        /// </summary>
        /// <param name="srcBytes"></param>
        /// <param name="srcWidth"></param>
        /// <param name="srcHeight"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void PutImageBytes(byte[] srcBytes, int srcWidth, int srcHeight, int dx = 0, int dy = 0)
        {
            // using a SharedByteArray prevents a copy of the data from being made before the draw. 
            using var sharedUint8Array = (SharedByteArray)srcBytes;
            using var imageData = ImageData.FromUint8Array(sharedUint8Array, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy);
        }
        /// <summary>
        /// PutImageData using byte[]
        /// </summary>
        public void PutImageBytes(byte[] imageBytes, int srcWidth, int srcHeight, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight)
        {
            // using a SharedByteArray prevents a copy of the data from being made before the draw. 
            using var sharedUint8Array = (SharedByteArray)imageBytes;
            using var imageData = ImageData.FromUint8Array(sharedUint8Array, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        }
        /// <summary>
        /// Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use.
        /// </summary>
        /// <param name="imageData">An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        public void DrawImage(CanvasImageSource imageData, int dx = 0, int dy = 0) => JSRef!.CallVoid("drawImage", imageData, dx, dy);
        /// <summary>
        /// Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use.
        /// </summary>
        /// <param name="imageData">An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dWidth">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        /// <param name="dHeight">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        public void DrawImage(CanvasImageSource imageData, int dx, int dy, int dWidth, int dHeight) => JSRef!.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        /// <summary>
        /// Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use.
        /// </summary>
        /// <param name="imageData">An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame.</param>
        /// <param name="sx">The x-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument.</param>
        /// <param name="sy">The y-axis coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument.</param>
        /// <param name="sWidth">The width of the sub-rectangle of the source image to draw into the destination context. If not specified, the entire rectangle from the coordinates specified by sx and sy to the bottom-right corner of the image is used. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image.</param>
        /// <param name="sHeight">The height of the sub-rectangle of the source image to draw into the destination context. Use the 3- or 5-argument syntax to omit this argument. A negative value will flip the image.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dWidth">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        /// <param name="dHeight">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        public void DrawImage(CanvasImageSource imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef!.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);
        /// <summary>
        /// Draws a filled rectangle at (x, y) position whose size is determined by width and height.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
        /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
        /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
        public void FillRect(int x, int y, int width, int height) => JSRef!.CallVoid("fillRect", x, y, width, height);
        /// <summary>
        /// Sets all pixels in the rectangle defined by starting point (x, y) and size (width, height) to transparent black, erasing any previously drawn content.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
        /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
        /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
        public void ClearRect(int x, int y, int width, int height) => JSRef!.CallVoid("clearRect", x, y, width, height);
        /// <summary>
        /// Paints a rectangle which has a starting point at (x, y) and has a w width and an h height onto the canvas, using the current stroke style.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
        /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
        /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
        public void StrokeRect(int x, int y, int width, int height) => JSRef!.CallVoid("strokeRect", x, y, width, height);
        /// <summary>
        /// Fills a given text at the given (x,y) position. Optionally with a maximum width to draw.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FillText(string text, int x, int y) => JSRef!.CallVoid("fillText", text, x, y);
        /// <summary>
        /// Fills a given text at the given (x,y) position. Optionally with a maximum width to draw.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="maxWidth"></param>
        public void FillText(string text, int x, int y, int maxWidth) => JSRef!.CallVoid("fillText", text, x, y, maxWidth);
        /// <summary>
        /// Draws (strokes) a given text at the given (x, y) position.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void StrokeText(string text, int x, int y) => JSRef!.CallVoid("strokeText", text, x, y);
        /// <summary>
        /// Draws (strokes) a given text at the given (x, y) position.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="maxWidth"></param>
        public void StrokeText(string text, int x, int y, int maxWidth) => JSRef!.CallVoid("strokeText", text, x, y, maxWidth);
        /// <summary>
        /// The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black.
        /// </summary>
        /// <param name="width">The width to give the new ImageData object. A negative value flips the rectangle around the vertical axis.</param>
        /// <param name="height">The height to give the new ImageData object. A negative value flips the rectangle around the horizontal axis.</param>
        /// <returns></returns>
        public ImageData CreateImageData(int width, int height) => JSRef!.Call<ImageData>("createImageData", width, height);
        /// <summary>
        /// The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black.
        /// </summary>
        /// <param name="width">The width to give the new ImageData object. A negative value flips the rectangle around the vertical axis.</param>
        /// <param name="height">The height to give the new ImageData object. A negative value flips the rectangle around the horizontal axis.</param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public ImageData CreateImageData(int width, int height, ImageDataSettings settings) => JSRef!.Call<ImageData>("createImageData", width, height, settings);
        /// <summary>
        /// The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black.
        /// </summary>
        /// <param name="imageData">An existing ImageData object from which to copy the width and height. The image itself is not copied.</param>
        /// <returns></returns>
        public ImageData CreateImageData(ImageData imageData) => JSRef!.Call<ImageData>("createImageData", imageData);
        /// <summary>
        /// The CanvasRenderingContext2D.beginPath() method of the Canvas 2D API starts a new path by emptying the list of sub-paths.
        /// </summary>
        public void BeginPath() => JSRef!.CallVoid("beginPath");

        /// <summary>
        /// The CanvasRenderingContext2D.closePath() method of the Canvas 2D API attempts to add a straight line from the current point to the start of the current sub-path.
        /// </summary>
        public void ClosePath() => JSRef!.CallVoid("closePath");

        /// <summary>
        /// The CanvasRenderingContext2D.moveTo() method of the Canvas 2D API begins a new sub-path at the point specified by the given (x, y) coordinates.
        /// </summary>
        /// <param name="x">The x-axis (horizontal) coordinate of the point.</param>
        /// <param name="y">The y-axis (vertical) coordinate of the point.</param>
        public void MoveTo(double x, double y) => JSRef!.CallVoid("moveTo", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.lineTo() method of the Canvas 2D API adds a straight line to the current sub-path by connecting the sub-path's last point to the specified (x, y) coordinates.
        /// </summary>
        /// <param name="x">The x-axis (horizontal) coordinate of the point.</param>
        /// <param name="y">The y-axis (vertical) coordinate of the point.</param>
        public void LineTo(double x, double y) => JSRef!.CallVoid("lineTo", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.arc() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the arc's center.</param>
        /// <param name="y">The y-axis coordinate of the arc's center.</param>
        /// <param name="radius">The arc's radius. Must be positive.</param>
        /// <param name="startAngle">The angle at which the arc starts, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="endAngle">The angle at which the arc ends, measured clockwise from the positive x-axis and expressed in radians.</param>
        /// <param name="anticlockwise">An optional Boolean which, if true, causes the arc to be drawn counter-clockwise between the two angles. By default it is drawn clockwise.</param>
        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise = false) => JSRef!.CallVoid("arc", x, y, radius, startAngle, endAngle, anticlockwise);

        /// <summary>
        /// The CanvasRenderingContext2D.arcTo() method of the Canvas 2D API adds an arc to the path with the given control points and radius, connected to the previous point by a straight line.
        /// </summary>
        /// <param name="x1">The x-axis coordinate of the first control point.</param>
        /// <param name="y1">The y-axis coordinate of the first control point.</param>
        /// <param name="x2">The x-axis coordinate of the second control point.</param>
        /// <param name="y2">The y-axis coordinate of the second control point.</param>
        /// <param name="radius">The arc's radius. Must be positive.</param>
        public void ArcTo(double x1, double y1, double x2, double y2, double radius) => JSRef!.CallVoid("arcTo", x1, y1, x2, y2, radius);

        /// <summary>
        /// The CanvasRenderingContext2D.quadraticCurveTo() method of the Canvas 2D API adds a quadratic Bézier curve to the current sub-path.
        /// </summary>
        /// <param name="cpx">The x-axis coordinate of the control point.</param>
        /// <param name="cpy">The y-axis coordinate of the control point.</param>
        /// <param name="x">The x-axis coordinate of the end point.</param>
        /// <param name="y">The y-axis coordinate of the end point.</param>
        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) => JSRef!.CallVoid("quadraticCurveTo", cpx, cpy, x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.bezierCurveTo() method of the Canvas 2D API adds a cubic Bézier curve to the current sub-path.
        /// </summary>
        /// <param name="cp1x">The x-axis coordinate of the first control point.</param>
        /// <param name="cp1y">The y-axis coordinate of the first control point.</param>
        /// <param name="cp2x">The x-axis coordinate of the second control point.</param>
        /// <param name="cp2y">The y-axis coordinate of the second control point.</param>
        /// <param name="x">The x-axis coordinate of the end point.</param>
        /// <param name="y">The y-axis coordinate of the end point.</param>
        public void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y) => JSRef!.CallVoid("bezierCurveTo", cp1x, cp1y, cp2x, cp2y, x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.rect() method of the Canvas 2D API adds a rectangle to the current path.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the rectangle's starting point.</param>
        /// <param name="y">The y-axis coordinate of the rectangle's starting point.</param>
        /// <param name="width">The rectangle's width. Positive values are to the right, and negative to the left.</param>
        /// <param name="height">The rectangle's height. Positive values are down, and negative are up.</param>
        public void Rect(double x, double y, double width, double height) => JSRef!.CallVoid("rect", x, y, width, height);

        /// <summary>
        /// The CanvasRenderingContext2D.fill() method of the Canvas 2D API fills the current or given path with the current fill style.
        /// </summary>
        public void Fill() => JSRef!.CallVoid("fill");

        /// <summary>
        /// The CanvasRenderingContext2D.fill() method of the Canvas 2D API fills the current or given path with the current fill style.
        /// </summary>
        /// <param name="path">A Path2D object to fill. If not specified, the current path is filled.</param>
        public void Fill(Path2D path) => JSRef!.CallVoid("fill", path);

        /// <summary>
        /// The CanvasRenderingContext2D.stroke() method of the Canvas 2D API strokes (outlines) the current or given path with the current stroke style.
        /// </summary>
        public void Stroke() => JSRef!.CallVoid("stroke");

        /// <summary>
        /// The CanvasRenderingContext2D.stroke() method of the Canvas 2D API strokes (outlines) the current or given path with the current stroke style.
        /// </summary>
        /// <param name="path">A Path2D object to stroke. If not specified, the current path is stroked.</param>
        public void Stroke(Path2D path) => JSRef!.CallVoid("stroke", path);

        /// <summary>
        /// The CanvasRenderingContext2D.clip() method of the Canvas 2D API turns the path currently being built into the current clipping path.
        /// </summary>
        public void Clip() => JSRef!.CallVoid("clip");

        /// <summary>
        /// The CanvasRenderingContext2D.clip() method of the Canvas 2D API turns the path currently being built into the current clipping path.
        /// </summary>
        /// <param name="path">A Path2D object to clip. If not specified, the current path is clipped.</param>
        public void Clip(Path2D path) => JSRef!.CallVoid("clip", path);

        /// <summary>
        /// The CanvasRenderingContext2D.isPointInPath() method of the Canvas 2D API reports whether or not the specified point is contained in the current path.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the point to check.</param>
        /// <param name="y">The y-axis coordinate of the point to check.</param>
        /// <returns>True if the specified point is contained in the current path; otherwise, false.</returns>
        public bool IsPointInPath(double x, double y) => JSRef!.Call<bool>("isPointInPath", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.isPointInPath() method of the Canvas 2D API reports whether or not the specified point is contained in the current path.
        /// </summary>
        /// <param name="path">A Path2D object to check. If not specified, the current path is checked.</param>
        /// <param name="x">The x-axis coordinate of the point to check.</param>
        /// <param name="y">The y-axis coordinate of the point to check.</param>
        /// <returns>True if the specified point is contained in the current path; otherwise, false.</returns>
        public bool IsPointInPath(Path2D path, double x, double y) => JSRef!.Call<bool>("isPointInPath", path, x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.isPointInStroke() method of the Canvas 2D API reports whether or not the specified point is inside the area contained by the stroking of a path.
        /// </summary>
        /// <param name="x">The x-axis coordinate of the point to check.</param>
        /// <param name="y">The y-axis coordinate of the point to check.</param>
        /// <returns>True if the specified point is inside the area contained by the stroking of a path; otherwise, false.</returns>
        public bool IsPointInStroke(double x, double y) => JSRef!.Call<bool>("isPointInStroke", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.isPointInStroke() method of the Canvas 2D API reports whether or not the specified point is inside the area contained by the stroking of a path.
        /// </summary>
        /// <param name="path">A Path2D object to check. If not specified, the current path is checked.</param>
        /// <param name="x">The x-axis coordinate of the point to check.</param>
        /// <param name="y">The y-axis coordinate of the point to check.</param>
        /// <returns>True if the specified point is inside the area contained by the stroking of a path; otherwise, false.</returns>
        public bool IsPointInStroke(Path2D path, double x, double y) => JSRef!.Call<bool>("isPointInStroke", path, x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.rotate() method of the Canvas 2D API adds a rotation to the transformation matrix.
        /// </summary>
        /// <param name="angle">The angle to rotate the context, in radians.</param>
        public void Rotate(double angle) => JSRef!.CallVoid("rotate", angle);

        /// <summary>
        /// The CanvasRenderingContext2D.scale() method of the Canvas 2D API adds a scaling transformation to the canvas units by x horizontally and by y vertically.
        /// </summary>
        /// <param name="x">Scaling factor in the horizontal direction. A negative value flips pixels across the vertical axis. A value of 1 results in no horizontal scaling.</param>
        /// <param name="y">Scaling factor in the vertical direction. A negative value flips pixels across the horizontal axis. A value of 1 results in no vertical scaling.</param>
        public void Scale(double x, double y) => JSRef!.CallVoid("scale", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.translate() method of the Canvas 2D API adds a translation transformation to the current matrix.
        /// </summary>
        /// <param name="x">Distance to move in the horizontal direction. Positive values are to the right, and negative to the left.</param>
        /// <param name="y">Distance to move in the vertical direction. Positive values are down, and negative are up.</param>
        public void Translate(double x, double y) => JSRef!.CallVoid("translate", x, y);

        /// <summary>
        /// The CanvasRenderingContext2D.transform() method of the Canvas 2D API multiplies the current transformation with the matrix described by the arguments of this method.
        /// </summary>
        /// <param name="a">Horizontal scaling. A value of 1 results in no scaling.</param>
        /// <param name="b">Horizontal skewing.</param>
        /// <param name="c">Vertical skewing.</param>
        /// <param name="d">Vertical scaling. A value of 1 results in no scaling.</param>
        /// <param name="e">Horizontal translation.</param>
        /// <param name="f">Vertical translation.</param>
        public void Transform(double a, double b, double c, double d, double e, double f) => JSRef!.CallVoid("transform", a, b, c, d, e, f);

        /// <summary>
        /// The CanvasRenderingContext2D.setTransform() method of the Canvas 2D API resets (overrides) the current transformation to the identity matrix, and then invokes a transformation described by the arguments of this method.
        /// </summary>
        /// <param name="a">Horizontal scaling. A value of 1 results in no scaling.</param>
        /// <param name="b">Horizontal skewing.</param>
        /// <param name="c">Vertical skewing.</param>
        /// <param name="d">Vertical scaling. A value of 1 results in no scaling.</param>
        /// <param name="e">Horizontal translation.</param>
        /// <param name="f">Vertical translation.</param>
        public void SetTransform(double a, double b, double c, double d, double e, double f) => JSRef!.CallVoid("setTransform", a, b, c, d, e, f);

        /// <summary>
        /// The CanvasRenderingContext2D.resetTransform() method of the Canvas 2D API resets the current transform to the identity matrix.
        /// </summary>
        public void ResetTransform() => JSRef!.CallVoid("resetTransform");

        /// <summary>
        /// The CanvasRenderingContext2D.save() method of the Canvas 2D API saves the entire state of the canvas by pushing the current state onto a stack.
        /// </summary>
        public void Save() => JSRef!.CallVoid("save");

        /// <summary>
        /// The CanvasRenderingContext2D.restore() method of the Canvas 2D API restores the most recently saved canvas state by popping the top entry in the drawing state stack. If there is no saved state, this method does nothing.
        /// </summary>
        public void Restore() => JSRef!.CallVoid("restore");
        /// <summary>
        /// The CanvasRenderingContext2D.getLineDash() method of the Canvas 2D API returns the current line dash pattern array containing an even number of non-negative numbers.
        /// </summary>
        /// <returns>An array of numbers that specifies distances to alternately draw a line and a gap (in coordinate space units).</returns>
        public double[] GetLineDash() => JSRef!.Call<double[]>("getLineDash");

        /// <summary>
        /// The CanvasRenderingContext2D.setLineDash() method of the Canvas 2D API sets the current line dash pattern.
        /// </summary>
        /// <param name="segments">An array of numbers that specifies distances to alternately draw a line and a gap (in coordinate space units).</param>
        public void SetLineDash(double[] segments) => JSRef!.CallVoid("setLineDash", segments);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(HTMLImageElement image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(SVGImageElement image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(HTMLVideoElement image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(HTMLCanvasElement image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(ImageBitmap image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(OffscreenCanvas image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createPattern() method of the Canvas 2D API creates a pattern using the specified image (a CanvasImageSource). It repeats the source in the directions specified by the repetition argument.
        /// </summary>
        /// <param name="image">A CanvasImageSource to be used as the image to repeat.</param>
        /// <param name="repetition">A string indicating how to repeat the image. Possible values are: "repeat", "repeat-x", "repeat-y", and "no-repeat".</param>
        /// <returns>A CanvasPattern object that can be used as a fill or stroke style.</returns>
        public CanvasPattern CreatePattern(VideoFrame image, string repetition) => JSRef!.Call<CanvasPattern>("createPattern", image, repetition);

        /// <summary>
        /// The CanvasRenderingContext2D.createLinearGradient() method of the Canvas 2D API creates a linear gradient along the line connecting two given coordinates.
        /// </summary>
        /// <param name="x0">The x-axis coordinate of the start point.</param>
        /// <param name="y0">The y-axis coordinate of the start point.</param>
        /// <param name="x1">The x-axis coordinate of the end point.</param>
        /// <param name="y1">The y-axis coordinate of the end point.</param>
        /// <returns>A CanvasGradient object representing the linear gradient.</returns>
        public CanvasGradient CreateLinearGradient(double x0, double y0, double x1, double y1) => JSRef!.Call<CanvasGradient>("createLinearGradient", x0, y0, x1, y1);

        /// <summary>
        /// The CanvasRenderingContext2D.createRadialGradient() method of the Canvas 2D API creates a radial gradient using the size and coordinates of two circles.
        /// </summary>
        /// <param name="x0">The x-axis coordinate of the start circle's center.</param>
        /// <param name="y0">The y-axis coordinate of the start circle's center.</param>
        /// <param name="r0">The radius of the start circle.</param>
        /// <param name="x1">The x-axis coordinate of the end circle's center.</param>
        /// <param name="y1">The y-axis coordinate of the end circle's center.</param>
        /// <param name="r1">The radius of the end circle.</param>
        /// <returns>A CanvasGradient object representing the radial gradient.</returns>
        public CanvasGradient CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1) => JSRef!.Call<CanvasGradient>("createRadialGradient", x0, y0, r0, x1, y1, r1);

        /// <summary>
        /// The CanvasRenderingContext2D.drawFocusIfNeeded() method of the Canvas 2D API draws a focus ring around the current path if the element is focused.
        /// </summary>
        /// <param name="element">The element to check for focus.</param>
        public void DrawFocusIfNeeded(Element element) => JSRef!.CallVoid("drawFocusIfNeeded", element);

        /// <summary>
        /// The CanvasRenderingContext2D.getTransform() method of the Canvas 2D API returns a copy of the current transformation matrix being applied to the context.
        /// </summary>
        /// <returns>A DOMMatrix object representing the current transformation matrix.</returns>
        public DOMMatrix GetTransform() => JSRef!.Call<DOMMatrix>("getTransform");

        /// <summary>
        /// The CanvasRenderingContext2D.reset() method of the Canvas 2D API resets the rendering context to its default state.
        /// </summary>
        public void Reset() => JSRef!.CallVoid("reset");

        /// <summary>
        /// The CanvasRenderingContext2D.scrollPathIntoView() method of the Canvas 2D API scrolls the current path or a given path into the view.
        /// </summary>
        public void ScrollPathIntoView() => JSRef!.CallVoid("scrollPathIntoView");

        /// <summary>
        /// The CanvasRenderingContext2D.scrollPathIntoView() method of the Canvas 2D API scrolls the current path or a given path into the view.
        /// </summary>
        /// <param name="path">A Path2D object to scroll into view.</param>
        public void ScrollPathIntoView(Path2D path) => JSRef!.CallVoid("scrollPathIntoView", path);

        /// <summary>
        /// The CanvasRenderingContext2D.getImageData() method of the Canvas 2D API returns an ImageData object representing the underlying pixel data for a specified portion of the canvas.
        /// </summary>
        /// <param name="sx">The x-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sy">The y-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sh">The height of the rectangle from which the ImageData will be extracted.</param>
        /// <returns>An ImageData object representing the underlying pixel data for the specified portion of the canvas.</returns>
        public ImageData GetImageData(double sx, double sy, double sw, double sh) => JSRef!.Call<ImageData>("getImageData", sx, sy, sw, sh);

        /// <summary>
        /// The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas.
        /// </summary>
        /// <param name="imagedata">An ImageData object containing the image data to be painted onto the canvas.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        public void PutImageData(ImageData imagedata, double dx, double dy) => JSRef!.CallVoid("putImageData", imagedata, dx, dy);

        /// <summary>
        /// The CanvasRenderingContext2D.putImageData() method of the Canvas 2D API paints data from the given ImageData object onto the canvas.
        /// </summary>
        /// <param name="imagedata">An ImageData object containing the image data to be painted onto the canvas.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dirtyX">The x-axis coordinate of the top-left corner of the rectangle to be painted.</param>
        /// <param name="dirtyY">The y-axis coordinate of the top-left corner of the rectangle to be painted.</param>
        /// <param name="dirtyWidth">The width of the rectangle to be painted.</param>
        /// <param name="dirtyHeight">The height of the rectangle to be painted.</param>
        public void PutImageData(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight) => JSRef!.CallVoid("putImageData", imagedata, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);

        /// <summary>
        /// The CanvasRenderingContext2D.createImageData() method of the Canvas 2D API creates a new, blank ImageData object with the specified dimensions. All of the pixels in the new object are transparent black.
        /// </summary>
        /// <param name="sw">The width to give the new ImageData object.</param>
        /// <param name="sh">The height to give the new ImageData object.</param>
        /// <returns>A new ImageData object with the specified dimensions.</returns>
        public ImageData CreateImageData(double sw, double sh) => JSRef!.Call<ImageData>("createImageData", sw, sh);
        /// <summary>
        /// The CanvasRenderingContext2D.getImageData() method of the Canvas 2D API returns an ImageData object representing the underlying pixel data for a specified portion of the canvas.
        /// </summary>
        /// <param name="sx">The x-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sy">The y-axis coordinate of the top-left corner of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sw">The width of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="sh">The height of the rectangle from which the ImageData will be extracted.</param>
        /// <param name="settings">An optional ImageDataSettings object to specify additional settings.</param>
        /// <returns>An ImageData object representing the underlying pixel data for the specified portion of the canvas.</returns>
        public ImageData GetImageData(double sx, double sy, double sw, double sh, ImageDataSettings settings) => JSRef!.Call<ImageData>("getImageData", sx, sy, sw, sh, settings);
        /// <summary>
        /// The CanvasRenderingContext2D.getContextAttributes() method of the Canvas 2D API returns an object that contains the actual context parameters.
        /// </summary>
        /// <returns>An object containing the actual context parameters.</returns>
        public CanvasRenderingContext2DSettings GetContextAttributes() => JSRef!.Call<CanvasRenderingContext2DSettings>("getContextAttributes");

    }
}

using Microsoft.JSInterop;

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
            using var imageData = ImageData.FromBytes(srcBytes, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy);
        }
        /// <summary>
        /// PutImageData using byte[]
        /// </summary>
        public void PutImageBytes(byte[] imageBytes, int srcWidth, int srcHeight, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight)
        {
            using var imageData = ImageData.FromBytes(imageBytes, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        }
        /// <summary>
        /// Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use.
        /// </summary>
        /// <param name="imageData">An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        public void DrawImage(Union<HTMLVideoElement, HTMLImageElement, HTMLCanvasElement, OffscreenCanvas, SVGImageElement, ImageBitmap, VideoFrame> imageData, int dx = 0, int dy = 0) => JSRef!.CallVoid("drawImage", imageData, dx, dy);
        /// <summary>
        /// Draws the specified image. This method is available in multiple formats, providing a great deal of flexibility in its use.
        /// </summary>
        /// <param name="imageData">An element to draw into the context. The specification permits any canvas image source, specifically, an HTMLImageElement, an SVGImageElement, an HTMLVideoElement, an HTMLCanvasElement, an ImageBitmap, an OffscreenCanvas, or a VideoFrame.</param>
        /// <param name="dx">The x-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dy">The y-axis coordinate in the destination canvas at which to place the top-left corner of the source image.</param>
        /// <param name="dWidth">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        /// <param name="dHeight">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn. Note that this argument is not included in the 3-argument syntax.</param>
        public void DrawImage(Union<HTMLVideoElement, HTMLImageElement, HTMLCanvasElement, OffscreenCanvas, SVGImageElement, ImageBitmap, VideoFrame> imageData, int dx, int dy, int dWidth, int dHeight) => JSRef!.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
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
        public void DrawImage(Union<HTMLVideoElement, HTMLImageElement, HTMLCanvasElement, OffscreenCanvas, SVGImageElement, ImageBitmap, VideoFrame> imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef!.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);
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
    }
}

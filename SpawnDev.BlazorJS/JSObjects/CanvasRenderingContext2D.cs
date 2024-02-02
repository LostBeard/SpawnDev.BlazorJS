using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CanvasRenderingContext2D interface, part of the Canvas API, provides the 2D rendering context for the drawing surface of a &lt;canvas&gt; element. It is used for drawing shapes, text, images, and other objects.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D
    /// </summary>
    public class CanvasRenderingContext2D : JSObject
    {
        public bool ImageSmoothingEnabled { get => JSRef.Get<bool>("imageSmoothingEnabled"); set => JSRef.Set("imageSmoothingEnabled", value); }
        public CanvasRenderingContext2D(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLCanvasElement Canvas => JSRef.Get<HTMLCanvasElement>("canvas");
        public ImageData? GetImageData()
        {
            using var canvas = Canvas;
            return GetImageData(0, 0, canvas.Width, canvas.Height);
        }
        public ImageData GetImageData(int x, int y, int width, int height) => JSRef.Call<ImageData>("getImageData", x, y, width, height);
        public void PutImageData(ImageData imageData, int dx, int dy) => JSRef.CallVoid("putImageData", imageData, dx, dy);
        public void PutImageData(ImageData imageData, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight) => JSRef.CallVoid("putImageData", imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);

        public string Font { get => JSRef.Get<string>("font"); set => JSRef.Set("font", value); }

        public TextMetrics MeasureText(string text) => JSRef.Call<TextMetrics>("measureText", text);

        public byte[]? GetImageBytes()
        {
            using var canvas = Canvas;
            return GetImageBytes(0, 0, canvas.Width, canvas.Height);
        }

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

        public void PutImageBytes(byte[] srcBytes, int srcWidth, int srcHeight, int dx = 0, int dy = 0)
        {
            using var imageData = ImageData.FromBytes(srcBytes, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy);
        }

        public void PutImageBytes(byte[] imageBytes, int srcWidth, int srcHeight, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight)
        {
            using var imageData = ImageData.FromBytes(imageBytes, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);
        }

        public void DrawImage(HTMLVideoElement imageData, int dx = 0, int dy = 0) => JSRef.CallVoid("drawImage", imageData, dx, dy);
        public void DrawImage(HTMLVideoElement imageData, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        public void DrawImage(HTMLVideoElement imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public void DrawImage(HTMLImageElement imageData, int dx = 0, int dy = 0) => JSRef.CallVoid("drawImage", imageData, dx, dy);
        public void DrawImage(HTMLImageElement imageData, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        public void DrawImage(HTMLImageElement imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public void DrawImage(HTMLCanvasElement imageData, int dx = 0, int dy = 0) => JSRef.CallVoid("drawImage", imageData, dx, dy);
        public void DrawImage(HTMLCanvasElement imageData, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        public void DrawImage(HTMLCanvasElement imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public void DrawImage(OffscreenCanvas imageData, int dx = 0, int dy = 0) => JSRef.CallVoid("drawImage", imageData, dx, dy);
        public void DrawImage(OffscreenCanvas imageData, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        public void DrawImage(OffscreenCanvas imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public void DrawImage(SVGImageElement imageData, int dx = 0, int dy = 0) => JSRef.CallVoid("drawImage", imageData, dx, dy);
        public void DrawImage(SVGImageElement imageData, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, dx, dy, dWidth, dHeight);
        public void DrawImage(SVGImageElement imageData, int sx, int sy, int sWidth, int sHeight, int dx, int dy, int dWidth, int dHeight) => JSRef.CallVoid("drawImage", imageData, sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight);

        public void FillRect(int x, int y, int width, int height) => JSRef.CallVoid("fillRect", x, y, width, height);
        public void ClearRect(int x, int y, int width, int height) => JSRef.CallVoid("clearRect", x, y, width, height);
        public void StrokeRect(int x, int y, int width, int height) => JSRef.CallVoid("strokeRect", x, y, width, height);

        public string FillStyle { get => JSRef.Get<string>("fillStyle"); set => JSRef.Set("fillStyle", value); }

        /// <summary>
        /// Fills a given text at the given (x,y) position. Optionally with a maximum width to draw.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FillText(string text, int x, int y) => JSRef.CallVoid("fillText", text, x, y);
        /// <summary>
        /// Fills a given text at the given (x,y) position. Optionally with a maximum width to draw.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="maxWidth"></param>
        public void FillText(string text, int x, int y, int maxWidth) => JSRef.CallVoid("fillText", text, x, y, maxWidth);
        /// <summary>
        /// Draws (strokes) a given text at the given (x, y) position.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void StrokeText(string text, int x, int y) => JSRef.CallVoid("strokeText", text, x, y);
        /// <summary>
        /// Draws (strokes) a given text at the given (x, y) position.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="maxWidth"></param>
        public void StrokeText(string text, int x, int y, int maxWidth) => JSRef.CallVoid("strokeText", text, x, y, maxWidth);
    }
}

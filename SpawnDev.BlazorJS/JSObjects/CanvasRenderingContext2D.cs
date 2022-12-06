using Microsoft.JSInterop;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D
    [JsonConverter(typeof(JSObjectConverter<CanvasRenderingContext2D>))]
    public class CanvasRenderingContext2D : JSObject
    {
        public bool ImageSmoothingEnabled
        {
            get => JSRef.Get<bool>("imageSmoothingEnabled");
            set => JSRef.Set("imageSmoothingEnabled", value);
        }
        public CanvasRenderingContext2D(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLCanvasElement Canvas => JSRef.Get<HTMLCanvasElement>("canvas");
        //public ImageData GetImageData() => _ref.Call<ImageData>("getImageData");
        public ImageData GetImageData(int x, int y, int width, int height) => JSRef.Call<ImageData>("getImageData", x, y, width, height);
        public void PutImageData(ImageData imageData, int dx, int dy) => JSRef.CallVoid("putImageData", imageData, dx, dy);
        public void PutImageData(ImageData imageData, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight) => JSRef.CallVoid("putImageData", imageData, dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight);

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
            using var imageData = new ImageData(srcBytes, srcWidth, srcHeight);
            PutImageData(imageData, dx, dy);
        }

        public void PutImageBytes(byte[] imageBytes, int srcWidth, int srcHeight, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight)
        {
            using var imageData = new ImageData(imageBytes, srcWidth, srcHeight);
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

    }
}

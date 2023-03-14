using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class ImageData : JSObject
    {
        public string ColorSpace => JSRef.Get<string>("colorSpace");
        public int Height => JSRef.Get<int>("height");
        public int Width => JSRef.Get<int>("width");
        public Uint8ClampedArray Data => JSRef.Get<Uint8ClampedArray>("data");
        public ImageData(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ImageData(int width, int height) : base(JS.New(nameof(ImageData), width, height)) { }
        public ImageData(Uint8ClampedArray array, int width, int height) : base(JS.New(nameof(ImageData), array, width, height)) { }
        public static ImageData FromUint8Array(Uint8Array uint8, int width, int height)
        {
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            return new ImageData(uint8Clamped, width, height);
        }
        public static ImageData FromBytes(byte[] rgbaBytes, int width, int height)
        {
            using var uint8 = new Uint8Array(rgbaBytes);
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            return new ImageData(uint8Clamped, width, height);
        }
    }
}

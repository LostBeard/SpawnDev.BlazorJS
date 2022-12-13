using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ImageData>))]
    public class ImageData : JSObject
    {
        public string ColorSpace => JSRef.Get<string>("colorSpace");
        public ulong Height => JSRef.Get<ulong>("height");
        public ulong Width => JSRef.Get<ulong>("width");
        public Uint8ClampedArray Data => JSRef.Get<Uint8ClampedArray>("data");
        public ImageData(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ImageData(int width, int height) : base("ImageData", width, height) { }
        public ImageData(Uint8ClampedArray array, int width, int height) : base("ImageData", array, width, height) { }
        public ImageData(Uint8Array uint8, int width, int height) : base(NullRef)
        {
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            FromReference(JS.New("ImageData", uint8Clamped, width, height));
        }
        public ImageData(byte[] rgbaBytes, int width, int height) : base(NullRef)
        {
            using var uint8 = new Uint8Array(rgbaBytes);
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            FromReference(JS.New("ImageData", uint8Clamped, width, height));
        }
    }
}

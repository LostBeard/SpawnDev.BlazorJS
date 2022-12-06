using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ImageData>))]
    public class ImageData : JSObject
    {
        public string ColorSpace => _ref.Get<string>("colorSpace");
        public ulong Height => _ref.Get<ulong>("height");
        public ulong Width => _ref.Get<ulong>("width");
        public Uint8ClampedArray Data => _ref.Get<Uint8ClampedArray>("data");
        public ImageData(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ImageData(int width, int height) : base("ImageData", width, height) { }
        public ImageData(Uint8ClampedArray array, int width, int height) : base("ImageData", array, width, height) { }
        public ImageData(Uint8Array uint8, int width, int height) : base(NullRef)
        {
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            FromReference(JS.CreateNew("ImageData", uint8Clamped, width, height));
        }
        public ImageData(byte[] rgbaBytes, int width, int height) : base(NullRef)
        {
            using var uint8 = new Uint8Array(rgbaBytes);
            using var uint8Clamped = new Uint8ClampedArray(uint8);
            FromReference(JS.CreateNew("ImageData", uint8Clamped, width, height));
        }
    }
}

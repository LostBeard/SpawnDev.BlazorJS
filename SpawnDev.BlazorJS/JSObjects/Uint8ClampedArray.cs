using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using SpawnDev.BlazorJS;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Uint8ClampedArray>))]
    public class Uint8ClampedArray : JSObject
    {
        public Uint8ClampedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer Buffer => _ref.Get<ArrayBuffer>("buffer");
        public int ByteLength => _ref.Get<int>("byteLength");
        //public byte this[int index]
        //{
        //    get => _ref.Get<byte>(index);
        //    set => _ref.Set(index, value);
        //}
        public Uint8ClampedArray(byte[] bytes) : base(NullRef)
        {
            using var arrayBuffer = new Uint8Array(bytes);
            FromReference(JS.CreateNew("Uint8ClampedArray", arrayBuffer));
        }
        public Uint8ClampedArray(Uint8Array uint8Array) : base("Uint8ClampedArray", uint8Array) { }
        public Uint8ClampedArray(int length) : base("Uint8ClampedArray", length) { }
        public byte[] ReadBytes()
        {
            using var buffer = Buffer;
            using var tmp = new Uint8Array(buffer);
            return tmp.ReadBytes();
        }
        public override void Dispose()
        {
            //Console.WriteLine("Uint8ClampedArray.Dispose();");
            base.Dispose();
        }
    }
}

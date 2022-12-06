using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ArrayBuffer>))]
    public class ArrayBuffer : JSObject
    {
        public ArrayBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int ByteLength => JSRef.Get<int>("byteLength");
        public ArrayBuffer(long length) : base("ArrayBuffer", length) { }
        public byte[] ReadBytes()
        {
            using var uint8array = new Uint8Array(this);
            return uint8array.ReadBytes();
        }
    }
}

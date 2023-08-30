using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ArrayBuffer : JSObject {
        public long ByteLength => JSRef.Get<long>("byteLength");
        public ArrayBuffer(long length) : base(JS.New(nameof(ArrayBuffer), length)) { }
        public ArrayBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        public byte[] ReadBytes() {
            using var uint8array = new Uint8Array(this);
            return uint8array.ReadBytes();
        }
    }
}

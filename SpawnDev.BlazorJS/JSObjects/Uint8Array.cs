using Microsoft.JSInterop;
using System;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Uint8Array>))]
    public class Uint8Array : JSObject
    {
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        // https://github.com/dotnet/aspnetcore/issues/35597
        // MS improved their .Net byte[] <-> JS Uint8Array recently but there is a bug ...
        // their implementation leaves the byte array on the heap, and the resulting Uint8Array has a ridiculously large "buffer" property (ArrayBuffer) which breaks most uses
        // last version checked that had MS bug .Net 6 preview 7 .. commit to fix was issued July 22, should be in .Net6 RC 1
        // set below value to false when MS finally fixes issue

        // UDPATE: Fixed in DotNet 6 RC 1
        static readonly bool UseCustomInterop = false;
        public Uint8Array(ArrayBuffer arrayBuffer) : base("Uint8Array", arrayBuffer) { }
        public Uint8Array(int length) : base("Uint8Array", length) { }
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        public ArrayBuffer Buffer => IsWrapperDisposed || _ref == null ? null : _ref.Get<ArrayBuffer>("buffer");
        public long ByteLength => _ref.Get<long>("byteLength");
        public long ByteOffset => _ref.Get<long>("byteOffset");
        public bool IsPartialView => _ref.Get<long>("buffer.byteLength") != _ref.Get<long>("byteLength");
        public byte[] ReadBytes()
        {
            return JS.ReturnMe<byte[]>(_ref);
        }
    }
}

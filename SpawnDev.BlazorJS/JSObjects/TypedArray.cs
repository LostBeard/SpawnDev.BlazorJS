using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    public abstract class TypedArray : JSObject
    {
        public TypedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer Buffer => JSRef.Get<ArrayBuffer>("buffer");
        public long ByteLength => JSRef.Get<long>("byteLength");
        public long Length => JSRef.Get<long>("length");
        public long ByteOffset => JSRef.Get<long>("byteOffset");
        public bool IsPartialView => JSRef.Get<long>("buffer.byteLength") != JSRef.Get<long>("byteLength");
        public virtual byte[] ReadBytes()
        {
            using var buffer = Buffer;
            using var uint8Array = new Uint8Array(buffer);
            return uint8Array.ReadBytes();
        }
        public void Set(byte[] typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(byte[] typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        public void Set(TypedArray typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(TypedArray typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        public void Set(Array typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(Array typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
    }
}

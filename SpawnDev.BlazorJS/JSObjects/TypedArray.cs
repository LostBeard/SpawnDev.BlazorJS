using Microsoft.JSInterop;
using System.Runtime.InteropServices;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    /// </summary>
    public abstract class TypedArray : JSObject
    {
        public TypedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer Buffer => JSRef.Get<ArrayBuffer>("buffer");
        public long ByteLength => JSRef.Get<long>("byteLength");
        public long Length => JSRef.Get<long>("length");
        public long ByteOffset => JSRef.Get<long>("byteOffset");
        public bool IsPartialView => JSRef.Get<long>("buffer.byteLength") != JSRef.Get<long>("byteLength");
        public void Set(byte[] typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(byte[] typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        public void Set(TypedArray typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(TypedArray typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        public void Set(Array typedArray) => JSRef.CallVoid("set", typedArray);
        public void Set(Array typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// Returns a copy of the TypedArray as a byte array
        /// </summary>
        /// <returns></returns>
        public virtual byte[] ReadBytes()
        {
            using var buffer = Buffer;
            using var uint8Array = new Uint8Array(buffer, ByteOffset, ByteLength);
            return uint8Array.ReadBytes();
        }
        public T[] ToArray<T>() where T : struct
        {
            var bytes = ReadBytes();
            var typeofT = typeof(T);
            if (typeofT == typeof(byte))
            {
                return (T[])(object)bytes;
            }
            var size = Marshal.SizeOf(typeofT);
            var pcmDataNet = System.Array.CreateInstance(typeofT, bytes.Length / size);
            System.Buffer.BlockCopy(bytes, 0, pcmDataNet, 0, bytes.Length);
            return (T[])pcmDataNet;
        }
    }
}

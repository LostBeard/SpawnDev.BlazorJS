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
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TypedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the ArrayBuffer referenced by the typed array.
        /// </summary>
        public ArrayBuffer Buffer => JSRef.Get<ArrayBuffer>("buffer");
        /// <summary>
        /// Returns the length (in bytes) of the typed array.
        /// </summary>
        public long ByteLength => JSRef.Get<long>("byteLength");
        /// <summary>
        /// Returns the number of elements held in the typed array.
        /// </summary>
        public long Length => JSRef.Get<long>("length");
        /// <summary>
        /// Returns the offset (in bytes) of the typed array from the start of its ArrayBuffer.
        /// </summary>
        public long ByteOffset => JSRef.Get<long>("byteOffset");
        /// <summary>
        /// Returns true if the underlying ArrayBuffer is not the same size as the TypedArray
        /// </summary>
        public bool IsPartialView => JSRef.Get<long>("buffer.byteLength") != JSRef.Get<long>("byteLength");
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(byte[] typedArray) => JSRef.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
        public void Set(byte[] typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(TypedArray typedArray) => JSRef.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
        public void Set(TypedArray typedArray, long targetOffset) => JSRef.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(Array typedArray) => JSRef.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
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
            var array = (T[])System.Array.CreateInstance(typeofT, bytes.Length / size);
            System.Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return array;
        }
    }
}

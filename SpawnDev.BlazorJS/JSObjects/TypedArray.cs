using Microsoft.JSInterop;
using System.Runtime.InteropServices;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    /// </summary>
    /// <typeparam name="TElement">The TypedArray element .Net type</typeparam>
    public abstract class TypedArray<TElement> : TypedArray where TElement : struct
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public TypedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The TypedArray element type .Net Type
        /// </summary>
        public Type ElementType => typeof(TElement);
        /// <summary>
        /// Returns a number value of the element size.
        /// </summary>
        public static int BYTES_PER_ELEMENT = Marshal.SizeOf<TElement>();
        /// <summary>
        /// Takes an integer value and returns the item at that index. This method allows for negative integers, which count back from the last item.
        /// </summary>
        /// <param name="index">Zero-based index of the typed array element to be returned, converted to an integer. Negative index counts back from the end of the typed array — if index &lt; 0, index + array.length is accessed.</param>
        /// <returns>The element in the typed array matching the given index. Always returns undefined if index &lt; -array.length or index &gt;= array.length without attempting to access the corresponding property.</returns>
        public virtual TElement At(long index) => JSRef!.Call<TElement>("at", index);
        /// <summary>
        /// Gets or sets the element at the given index
        /// </summary>
        /// <param name="i">the index of the element to get or set</param>
        /// <returns>The value of the element at the given index if getting</returns>
        public virtual TElement this[long i]
        {
            get => JSRef!.Get<TElement>(i);
            set => JSRef!.Set(i, value);
        }
        /// <summary>
        /// Returns an array of type TElement
        /// </summary>
        /// <returns>An array of type TElement</returns>
        public virtual TElement[] ToArray() => ToArray<TElement>();
        /// <summary>
        /// Returns an array of type TElement
        /// </summary>
        /// <param name="start">The TElement index to start at</param>
        /// <returns>An array of type TElement</returns>
        public virtual TElement[] ToArray(long start) => ToArray<TElement>(start * BYTES_PER_ELEMENT);
        /// <summary>
        /// Returns an array of type TElement
        /// </summary>
        /// <param name="start">The TElement index to start at</param>
        /// <param name="length">The number of TElements to return</param>
        /// <returns>An array of type TElement</returns>
        public virtual TElement[] ToArray(long start, long length) => ToArray<TElement>(start * BYTES_PER_ELEMENT, length);
    }
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
        public ArrayBuffer Buffer => JSRef!.Get<ArrayBuffer>("buffer");
        /// <summary>
        /// Returns the length (in bytes) of the typed array.
        /// </summary>
        public long ByteLength => JSRef!.Get<long>("byteLength");
        /// <summary>
        /// Returns the number of elements held in the typed array.
        /// </summary>
        public long Length => JSRef!.Get<long>("length");
        /// <summary>
        /// Returns the offset (in bytes) of the typed array from the start of its ArrayBuffer.
        /// </summary>
        public long ByteOffset => JSRef!.Get<long>("byteOffset");
        /// <summary>
        /// Returns true if the underlying ArrayBuffer is not the same size as the TypedArray
        /// </summary>
        public bool IsPartialView => JSRef!.Get<long>("buffer.byteLength") != JSRef!.Get<long>("byteLength");
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(byte[] typedArray) => JSRef!.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
        public void Set(byte[] typedArray, long targetOffset) => JSRef!.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(TypedArray typedArray) => JSRef!.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
        public void Set(TypedArray typedArray, long targetOffset) => JSRef!.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Set(Array typedArray) => JSRef!.CallVoid("set", typedArray);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="targetOffset"></param>
        public void Set(Array typedArray, long targetOffset) => JSRef!.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <returns></returns>
        public virtual byte[] ReadBytes()
        {
            using var buffer = Buffer;
            using var uint8Array = new Uint8Array(buffer, ByteOffset, ByteLength);
            return uint8Array.ReadBytes();
        }
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes(long byteOffset)
        {
            using var buffer = Buffer;
            using var uint8Array = new Uint8Array(buffer, ByteOffset + byteOffset, ByteLength - byteOffset);
            return uint8Array.ReadBytes();
        }
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes(long byteOffset, long byteLength)
        {
            using var buffer = Buffer;
            using var uint8Array = new Uint8Array(buffer, ByteOffset + byteOffset, byteLength);
            return uint8Array.ReadBytes();
        }
        /// <summary>
        /// Returns an array of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>() where T : struct
        {
            var bytes = ReadBytes();
            var typeofT = typeof(T);
            if (typeofT == typeof(byte)) return (T[])(object)bytes;
            var size = Marshal.SizeOf<T>();
            var array = (T[])System.Array.CreateInstance(typeofT, bytes.Length / size);
            System.Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return array;
        }
        /// <summary>
        /// Read an array of type T starting at this TypedArray's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="byteOffset"></param>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>(long byteOffset) where T : struct
        {
            var typeofT = typeof(T);
            var bytes = ReadBytes(byteOffset);
            if (typeofT == typeof(byte)) return (T[])(object)bytes;
            var size = Marshal.SizeOf<T>();
            var array = (T[])System.Array.CreateInstance(typeofT, bytes.Length / size);
            System.Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return array;
        }
        /// <summary>        
        /// Read an array of type T starting at this TypedArray's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="byteOffset">The byte position offset to add to this TypeArray's ByteOffset</param>
        /// <param name="count">Number of type T to read</param>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>(long byteOffset, long count) where T : struct
        {
            var typeofT = typeof(T);
            var size = Marshal.SizeOf<T>();
            var byteLength = count * size;
            var bytes = ReadBytes(byteOffset, byteLength);
            if (typeofT == typeof(byte)) return (T[])(object)bytes;
            var array = (T[])System.Array.CreateInstance(typeofT, bytes.Length / size);
            System.Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
            return array;
        }
    }
}

using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;
using System.Runtime.InteropServices;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type.<br/>
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
        public virtual TElement[] ToArray(long start) => ToArray<TElement>(start);
        /// <summary>
        /// Returns an array of type TElement
        /// </summary>
        /// <param name="start">The TElement index to start at</param>
        /// <param name="length">The number of TElements to return</param>
        /// <returns>An array of type TElement</returns>
        public virtual TElement[] ToArray(long start, long length) => ToArray<TElement>(start, length);
        /// <summary>
        /// Returns a value iterator 
        /// </summary>
        /// <returns>A Span of type TElement</returns>
        public Iterator<TElement> Values() => JSRef!.Call<Iterator<TElement>>("values");
        /// <summary>
        /// Fills all the elements of an array from a start index to an end index with a static value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual TypedArray Fill(TElement value) => JSRef!.Call<TypedArray>("fill", value);
        /// <summary>
        /// Fills all the elements of an array from a start index to an end index with a static value.
        /// </summary>
        /// <param name="value"></param>
        public virtual void FillVoid(TElement value) => JSRef!.CallVoid("fill", value);
    }
    /// <summary>
    /// A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    /// </summary>
    public abstract class TypedArray : JSObject
    {
        /// <summary>
        /// Create a new typed array starting at this typed array's ByteOffset + byteOffset, returning length number of items in the resulting typed array
        /// </summary>
        /// <param name="typedArray"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public TypedArray ReCast(Type typedArray, long byteOffset, long length) => Buffer.Using(o => (TypedArray)Activator.CreateInstance(typedArray, o, ByteOffset + byteOffset, length)!);
        /// <summary>
        /// Create a new typed array starting at this typed array's ByteOffset + byteOffset
        /// </summary>
        /// <param name="typedArray"></param>
        /// <returns></returns>
        public TypedArray ReCast(Type typedArray) => Buffer.Using(o => (TypedArray)Activator.CreateInstance(typedArray, o, ByteOffset, ByteLength)!);
        /// <summary>
        /// Create a new typed array starting at this typed array's ByteOffset + byteOffset, returning length number of items in the resulting typed array
        /// </summary>
        /// <typeparam name="TTypedArray"></typeparam>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public TTypedArray ReCast<TTypedArray>(long byteOffset, long length) where TTypedArray : TypedArray => Buffer.Using(o => (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), o, ByteOffset + byteOffset, length)!);
        /// <summary>
        /// Create a new typed array starting at this typed array's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="TTypedArray"></typeparam>
        /// <returns></returns>
        public TTypedArray ReCast<TTypedArray>() where TTypedArray : TypedArray => Buffer.Using(o => (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), o, ByteOffset, ByteLength)!);
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
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(sbyte[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(byte[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(short[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(ushort[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(int[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(uint[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(long[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(ulong[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(Half[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(float[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetOffset"></param>
        public void Set(double[] array, long targetOffset = 0) => JSRef!.CallVoid("set", (HeapView)array, targetOffset);
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
        public void Set(Array typedArray, long targetOffset = 0) => JSRef!.CallVoid("set", typedArray, targetOffset);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes(long byteOffset = 0) => Read<byte>(byteOffset);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes(long byteOffset, long byteLength) => Read<byte>(byteOffset, byteLength);
        /// <summary>
        /// Write bytes to the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteOffset"></param>
        public virtual void WriteBytes(byte[] data, long byteOffset = 0) => Write(data, byteOffset);
        /// <summary>
        /// The set() method of TypedArray instances stores multiple values in the typed array, reading input values from a specified array.
        /// </summary>
        public void Write<T>(T[] srcData, long destByteOffset = 0) where T : struct
        {
            if (destByteOffset < 0) new IndexOutOfRangeException(nameof(destByteOffset));
            var tSize = Marshal.SizeOf<T>();
            var bytesToCopy = srcData.LongLength * tSize;
            var bytesMax = ByteLength - destByteOffset;
            if (bytesMax < bytesToCopy) throw new NotImplementedException($"Write out of bounds: {typeof(T).Name}");
            // create a TypedArray that starts at destByteOffset and with an element of type T
            using var thisTyped = ReCast<Uint8Array>(destByteOffset, bytesToCopy);
            using var heapView = HeapView.Create(srcData);
            using var typedArray = heapView.As<Uint8Array>();
            thisTyped.Set(typedArray);
        }
        /// <summary>
        /// Copies an array of type T from this TypedArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="srcByteOffset"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long Read<T>(long srcByteOffset, T[] buffer, long offset, long count) where T : struct
        {
            if (srcByteOffset < 0) new IndexOutOfRangeException(nameof(srcByteOffset));
            var tSize = Marshal.SizeOf<T>();
            var bytesMax = ByteLength - srcByteOffset;
            if (bytesMax <= 0) return 0;
            var countMax = (long)Math.Floor((double)bytesMax / (double)tSize);
            count = Math.Clamp(count, 0, countMax);
            if (count > 0)
            {
                var byteLength = count * tSize;
                using var thisTyped = ReCast<Uint8Array>(srcByteOffset, byteLength);
                using var heapView = HeapView.Create(buffer);
                using var typedArray = heapView.As<Uint8Array>();
                typedArray.Set(thisTyped, offset);
            }
            return count;
        }
        /// <summary>
        /// Read type T from this TypedArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="srcByteOffset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T[] Read<T>(long srcByteOffset, long count) where T : struct
        {
            if (srcByteOffset < 0) new IndexOutOfRangeException(nameof(srcByteOffset));
            var tSize = Marshal.SizeOf<T>();
            var bytesMax = ByteLength - srcByteOffset;
            if (bytesMax <= 0) return new T[0];
            var countMax = (long)Math.Floor((double)bytesMax / (double)tSize);
            count = Math.Clamp(count, 0, countMax);
            var buffer = new T[count];
            if (count > 0)
            {
                var byteLength = count * tSize;
                using var sourceUint8Array = ReCast<Uint8Array>(srcByteOffset, byteLength);
                using var heapView = HeapView.Create(buffer);
                using var typedArray = heapView.As<Uint8Array>();
                typedArray.Set(sourceUint8Array);
            }
            return buffer;
        }
        /// <summary>
        /// Read type T from this TypedArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="srcByteOffset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T[] Read<T>(long srcByteOffset = 0) where T : struct
        {
            if (srcByteOffset < 0) new IndexOutOfRangeException(nameof(srcByteOffset));
            var tSize = Marshal.SizeOf<T>();
            var bytesMax = ByteLength - srcByteOffset;
            if (bytesMax <= 0) return new T[0];
            var count = (long)Math.Floor((double)bytesMax / (double)tSize);
            var buffer = new T[count];
            if (count > 0)
            {
                var byteLength = count * tSize;
                using var sourceUint8Array = ReCast<Uint8Array>(srcByteOffset, byteLength);
                using var heapView = HeapView.Create(buffer);
                using var typedArray = heapView.As<Uint8Array>();
                typedArray.Set(sourceUint8Array);
            }
            return buffer;
        }
        /// <summary>
        /// Read an array of type T starting at this TypedArray's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>() where T : struct => Read<T>();
        /// <summary>
        /// Read an array of type T starting at this TypedArray's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start">Element Index to start</param>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>(long start) where T : struct => Read<T>(start * Marshal.SizeOf<T>());
        /// <summary>        
        /// Read an array of type T starting at this TypedArray's ByteOffset + byteOffset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start">Element Index to start</param>
        /// <param name="count">Number of type T to read</param>
        /// <returns>Array of type T</returns>
        public T[] ToArray<T>(long start, long count) where T : struct => Read<T>(start * Marshal.SizeOf<T>(), count);
        static Dictionary<Type, int> TypedArrayElementSize = new Dictionary<Type, int>
        {
            { typeof(Uint8ClampedArray), 1 },
            { typeof(Uint8Array), 1 },
            { typeof(Uint16Array), 2 },
            { typeof(Uint32Array), 4 },
            { typeof(BigUint64Array), 8 },
            { typeof(Int8Array), 1 },
            { typeof(Int16Array), 2 },
            { typeof(Int32Array), 4 },
            { typeof(BigInt64Array), 8 },
            { typeof(Float16Array), 2 },
            { typeof(Float32Array), 4 },
            { typeof(Float64Array), 8 },
        };
        static Dictionary<Type, Type> TypeDefaultTypedArrayType = new Dictionary<Type, Type>
        {
            { typeof(byte), typeof(Uint8Array) },
            { typeof(ushort), typeof(Uint16Array) },
            { typeof(uint), typeof(Uint32Array) },
            { typeof(ulong), typeof(BigUint64Array) },
            { typeof(sbyte), typeof(Int8Array) },
            { typeof(short), typeof(Int16Array) },
            { typeof(int), typeof(Int32Array) },
            { typeof(long), typeof(BigInt64Array) },
            { typeof(Half), typeof(Float16Array) },
            { typeof(float), typeof(Float32Array) },
            { typeof(double), typeof(Float64Array) },
        };
        /// <summary>
        /// Returns the Javascript native array type for the specified struct type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type? GetTypeDefaultTypedArrayType<T>() where T : struct => TypeDefaultTypedArrayType.TryGetValue(typeof(T), out var typedArrayType) ? typedArrayType : null;
        /// <summary>
        /// Returns the Javascript native array type for the specified struct type
        /// </summary>
        /// <param name="unmanagedType"></param>
        /// <returns></returns>
        public static Type? GetTypeDefaultTypedArrayType(Type unmanagedType) => TypeDefaultTypedArrayType.TryGetValue(unmanagedType, out var typedArrayType) ? typedArrayType : null;
        /// <summary>
        /// Returns the size of the specified TypedArray type
        /// </summary>
        /// <typeparam name="TTypedArray"></typeparam>
        /// <returns></returns>
        public static int GetTypedArrayElementSize<TTypedArray>() where TTypedArray : TypedArray => TypedArrayElementSize.TryGetValue(typeof(TTypedArray), out var size) ? size : 0;
        /// <summary>
        /// Returns the size of the specified TypedArray type
        /// </summary>
        /// <param name="typedArrayType"></param>
        /// <returns></returns>
        public static int GetTypedArrayElementSize(Type typedArrayType) => TypedArrayElementSize.TryGetValue(typedArrayType, out var size) ? size : 0;
    }
}

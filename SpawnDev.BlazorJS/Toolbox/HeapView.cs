using SpawnDev.BlazorJS.JSObjects;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <inheritdoc/>
    [JsonConverter(typeof(HeapViewConverter))]
    public sealed class HeapView<TElement> : HeapView where TElement : struct
    {
        /// <summary>
        /// Pinned data that can be shared with Javascript
        /// </summary>
        public TElement[] Data { get; private set; }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <param name="length">The number of elements to include</param>
        public HeapView(TElement[] data, long offset, long length) : base()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var maxCount = data.Length - offset;
            if (offset < 0 || length > maxCount) throw new ArgumentOutOfRangeException(nameof(offset));
            ElementSize = Marshal.SizeOf<TElement>();
            Offset = offset;
            DataType = data.GetType();
            ElementType = typeof(TElement);
            Data = data;
            handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
            Pointer = new IntPtr(handle.AddrOfPinnedObject().ToInt64() + (Offset * ElementSize));
            Address = Pointer.ToInt64();
            Length = length;
            ByteLength = ElementSize * Length;
        }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        public HeapView(TElement[] data, long offset = 0) : this(data, offset, data.Length - offset) { }
    }
    /// <inheritdoc/>
    [JsonConverter(typeof(HeapViewConverter))]
    [RequiresUnreferencedCode("")]
    public sealed class HeapViewString : HeapView
    {
        /// <summary>
        /// Pinned data that can be shared with Javascript
        /// </summary>
        public string Data { get; private set; }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <param name="length">The number of characters to include</param>
        [DynamicDependency("Helper", "MyType", "System")]
        public HeapViewString(string data, long offset, long length) : base()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var maxCount = data.Length - offset;
            if (offset < 0 || length > maxCount) throw new ArgumentOutOfRangeException(nameof(offset));
            ElementSize = 2;
            Offset = offset;
            DataType = data.GetType();
            ElementType = typeof(char);
            Data = data;
            handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
            Pointer = new IntPtr(handle.AddrOfPinnedObject().ToInt64() + (Offset * ElementSize));
            Address = Pointer.ToInt64();
            Length = length;
            ByteLength = ElementSize * length;
        }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        public HeapViewString(string data, long offset = 0) : this(data, offset, data.Length - offset) { }
    }
    /// <summary>
    /// Pins the Data in memory so that it can be passed to Javascript and used directly without a copy operation using implicit conversion or the As() methods.<br/>
    /// Javascript can modify the Blazor .Net TElement[] directly by modifying the passed TypedArray or DataView.<br/>
    /// Fast copies are also supported using the To() methods.<br/>
    /// When this object is disposed the memory will be unpinned and all created views will be disposed.<br/>
    /// WARNING 1: The TTypedArray will point to a small region of the Blazor .Net memory heap ArrayBuffer.<br/>
    /// If using the TTypedArray.buffer, make sure to only use the region specified by the TTypedArray.byteOffset and length properties.<br/>
    /// WARNING 2: .Net frequently resizes the Heap, and when it does the old heap ArrayBuffer will become detached.<br/>
    /// All TypedArray views on the Heap will become invalid.
    /// </summary>
    [JsonConverter(typeof(HeapViewConverter))]
    public class HeapView : IDisposable
    {
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(string data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(byte[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(ushort[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(uint[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(ulong[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(sbyte[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(short[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(int[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(long[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(Half[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(float[] data) => Create(data);
        /// <summary>
        /// Explicit conversion to HeapView
        /// </summary>
        /// <param name="data">Data to pin</param>
        public static explicit operator HeapView(double[] data) => Create(data);
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator BigInt64Array(HeapView heapView) => heapView.As<BigInt64Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator BigUint64Array(HeapView heapView) => heapView.As<BigUint64Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Float16Array(HeapView heapView) => heapView.As<Float16Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Float32Array(HeapView heapView) => heapView.As<Float32Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Float64Array(HeapView heapView) => heapView.As<Float64Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Int16Array(HeapView heapView) => heapView.As<Int16Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Int32Array(HeapView heapView) => heapView.As<Int32Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Int8Array(HeapView heapView) => heapView.As<Int8Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Uint16Array(HeapView heapView) => heapView.As<Uint16Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Uint32Array(HeapView heapView) => heapView.As<Uint32Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Uint8Array(HeapView heapView) => heapView.As<Uint8Array>();
        /// <summary>
        /// Implicit conversion to a TypedArray
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator Uint8ClampedArray(HeapView heapView) => heapView.As<Uint8ClampedArray>();
        /// <summary>
        /// Implicit conversion to a DataView
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator DataView(HeapView heapView) => heapView.AsDataView();
        /// <summary>
        /// Implicit conversion to an ArrayBuffer copy
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator ArrayBuffer(HeapView heapView) => heapView.ToArrayBuffer();
        /// <summary>
        /// Implicit conversion to a SharedArrayBuffer copy
        /// </summary>
        /// <param name="heapView">HeapView</param>
        public static implicit operator SharedArrayBuffer(HeapView heapView) => heapView.ToSharedArrayBuffer();

        /// <summary>
        /// Returns a TypedArray based on the ElementType
        /// </summary>
        /// <returns></returns>
        public TypedArray AsTypedArray()
        {
            var typedArrayType = TypedArray.GetTypeDefaultTypedArrayType(ElementType) ?? typeof(Uint8Array);
            return As(typedArrayType);
        }
        /// <summary>
        /// Returns a TypedArray copy based on the ElementType
        /// </summary>
        /// <returns></returns>
        public TypedArray ToTypedArray()
        {
            var typedArrayType = TypedArray.GetTypeDefaultTypedArrayType(ElementType) ?? typeof(Uint8Array);
            return To(typedArrayType);
        }
        /// <summary>
        /// Returns a JSObject based on the ElementType<br/>
        /// </summary>
        /// <returns></returns>
        public JSObject AsNativeView()
        {
            if (DataType == typeof(string))
            {
                // ArrayBuffer does not have a string viewer so it must be copied using TextDecoder
                using var textDecoder = new TextDecoder("utf-16");
                var jsString = textDecoder.DecodeToPrimitive((Uint8Array)this);
                return jsString;
            }
            else
            {
                var typedArrayType = TypedArray.GetTypeDefaultTypedArrayType(ElementType) ?? typeof(Uint8Array);
                return As(typedArrayType);
            }
        }
        /// <summary>
        /// Returns a TypedArray copy based on the ElementType
        /// </summary>
        /// <returns></returns>
        public JSObject ToNativeView()
        {
            if (DataType == typeof(string))
            {
                using var textDecoder = new TextDecoder("utf-16");
                var jsString = textDecoder.JSRef!.Call<StringPrimitive>("decode", (Uint8Array)this);
                return jsString;
            }
            else
            {
                var typedArrayType = TypedArray.GetTypeDefaultTypedArrayType(ElementType) ?? typeof(Uint8Array);
                return To(typedArrayType);
            }
        }
        /// <summary>
        /// The number of elements in Data
        /// </summary>
        public long Offset { get; protected set; }
        /// <summary>
        /// The number of elements in Data - Offset
        /// </summary>
        public long Length { get; protected set; }
        /// <summary>
        /// Data element type
        /// </summary>
        public Type ElementType { get; protected set; }
        /// <summary>
        /// Data type
        /// </summary>
        public Type DataType { get; protected set; }
        /// <summary>
        /// Creates a new HeapView of the provided array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <param name="length">The number of elements to include</param>
        /// <returns></returns>
        public static HeapView Create<T>(T[] data, long offset, long length) where T : struct => new HeapView<T>(data, offset, length);
        /// <summary>
        /// Creates a new HeapView of the provided array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <returns></returns>
        public static HeapView Create<T>(T[] data, long offset = 0) where T : struct => new HeapView<T>(data, offset);
        /// <summary>
        /// Creates a new HeapView of the provided string
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <param name="length">The number of characters to include</param>
        /// <returns></returns>
        public static HeapView Create(string data, long offset, long length) => new HeapViewString(data, offset, length);
        /// <summary>
        /// Creates a new HeapView of the provided string
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset">Start index in the data</param>
        /// <returns></returns>
        public static HeapView Create(string data, long offset = 0) => new HeapViewString(data, offset);
        /// <summary>
        /// The size of Data in bytes
        /// </summary>
        public long ByteLength { get; protected set; }
        /// <summary>
        /// The element size in bytes
        /// </summary>
        public int ElementSize { get; protected set; }
        /// <summary>
        /// True if the object has been disposed
        /// </summary>
        public bool Disposed { get; protected set; }
        /// <summary>
        /// Memory in address as a long
        /// </summary>
        public long Address { get; protected set; }
        /// <summary>
        /// Pointer to the memory region
        /// </summary>
        public IntPtr Pointer { get; protected set; }
        /// <summary>
        /// GSHandle of the memory region
        /// </summary>
        protected GCHandle handle;
        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            Disposed = true;
#if DEBUG
            Console.WriteLine($"HeapView.Dispose({disposing})");
#endif
            Address = 0;
            handle.Free();
            Pointer = IntPtr.Zero;
            var disposables = DisposableViews.ToList();
            DisposableViews.Clear();
            foreach (var disposable in disposables)
            {
                try
                {
                    disposable.Dispose();
                }
                catch { }
            }
        }
        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            if (Disposed) return;
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        /// <summary>
        /// Finalize object
        /// </summary>
        ~HeapView()
        {
            Dispose(false);
        }
        static string? _ModulePath = null;
        static string ModulePath
        {
            get
            {
                if (string.IsNullOrEmpty(_ModulePath))
                {
                    var modulePaths = new string[]{
                        "Module",                   // .Net 8 and earlier
                        "Blazor.runtime.Module" ,   // .Net 9 and up
                    };
                    foreach (var mPath in modulePaths)
                    {
                        if (!JS.IsUndefined(mPath))
                        {
                            _ModulePath = mPath;
                            break;
                        }
                    }
                }
                if (string.IsNullOrEmpty(_ModulePath))
                {
                    throw new Exception("SpawnDev.BlazorJS.HeapView: Unsupported .Net version. Module not found.");
                }
                return _ModulePath;
            }
        }

        static Lazy<string> HeapName = new Lazy<string>(() => $"{ModulePath}.HEAPU8");

        static Lazy<string> HeapBufferName = new Lazy<string>(() => $"{HeapName.Value}.buffer");
        /// <summary>
        /// Returns the current ArrayBuffer the Heap is using
        /// </summary>
        /// <returns></returns>
        public static ArrayBuffer GetHeapBuffer() => JS.Get<ArrayBuffer>(HeapBufferName.Value);
        /// <summary>
        /// Returns the current Uint8Array the Heap is using
        /// </summary>
        /// <returns></returns>
        public static Uint8Array GetHeap() => JS.Get<Uint8Array>(HeapName.Value);
        /// <summary>
        /// BlazorJSRuntime
        /// </summary>
        protected static BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Creates a copy of the data and returns it as an ArrayBuffer
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <returns></returns>
        public ArrayBuffer ToArrayBuffer(long byteOffset = 0) => ToArrayBuffer(byteOffset, ByteLength - byteOffset);
        /// <summary>
        /// Creates a copy of the data and returns it as an ArrayBuffer
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public ArrayBuffer ToArrayBuffer(long byteOffset, long byteLength)
        {
            using var heap = GetHeap();
            using var heapChunk = heap.Slice(Address + byteOffset, Address + byteOffset + byteLength);
            return heapChunk.Buffer;
        }
        /// <summary>
        /// Creates a copy of the data and returns it as an ArrayBuffer
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <returns></returns>
        public SharedArrayBuffer ToSharedArrayBuffer(long byteOffset = 0) => ToSharedArrayBuffer(byteOffset, ByteLength - byteOffset);
        /// <summary>
        /// Creates a copy of the data and returns it as an SharedArrayBuffer
        /// </summary>
        /// <param name="byteOffset"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        public SharedArrayBuffer ToSharedArrayBuffer(long byteOffset, long byteLength)
        {
            using var heap = GetHeap();
            using var heapChunk = heap.SubArray(Address + byteOffset, Address + byteOffset + byteLength);
            var sharedArrayBuffer = new SharedArrayBuffer(byteLength);
            using var uint8Array = new Uint8Array(sharedArrayBuffer);
            uint8Array.Set(heapChunk);
            return sharedArrayBuffer;
        }
        /// <summary>
        /// Creates a copy of the data and returns it as a TypedArray
        /// </summary>
        public TypedArray To(Type typedArrayType, long byteOffset = 0)
            => To(typedArrayType, byteOffset, (long)Math.Floor((float)(ByteLength - byteOffset) / (float)TypedArray.GetTypedArrayElementSize(typedArrayType)));
        /// <summary>
        /// Creates a copy of the data and returns it as a TypedArray
        /// </summary>
        public TypedArray To(Type typedArrayType, long byteOffset, long elementCount)
        {
            var byteLength = TypedArray.GetTypedArrayElementSize(typedArrayType) * elementCount;
            using var arrayBufferCopy = ToArrayBuffer(byteOffset, byteLength);
            var typedArray = (TypedArray)Activator.CreateInstance(typedArrayType, arrayBufferCopy)!;
            return typedArray;
        }
        /// <summary>
        /// Creates a copy of the data and returns it as a TypedArray
        /// </summary>
        public TTypedArray To<TTypedArray>(long byteOffset = 0) where TTypedArray : TypedArray
            => To<TTypedArray>(byteOffset, (long)Math.Floor((float)(ByteLength - byteOffset) / (float)TypedArray.GetTypedArrayElementSize<TTypedArray>()));
        /// <summary>
        /// Creates a copy of the data and returns it as a TypedArray
        /// </summary>
        public TTypedArray To<TTypedArray>(long byteOffset, long elementCount) where TTypedArray : TypedArray
        {
            var byteLength = TypedArray.GetTypedArrayElementSize<TTypedArray>() * elementCount;
            using var arrayBufferCopy = ToArrayBuffer(byteOffset, byteLength);
            var typedArray = (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), arrayBufferCopy)!;
            return typedArray;
        }
        /// <summary>
        /// Returns a TypedArray that points at the pinned data.
        /// </summary>
        public TTypedArray As<TTypedArray>(long byteOffset = 0) where TTypedArray : TypedArray
            => As<TTypedArray>(byteOffset, (long)Math.Floor((float)(ByteLength - byteOffset) / (float)TypedArray.GetTypedArrayElementSize<TTypedArray>()));
        /// <summary>
        /// Returns a TypedArray that points at the pinned data.
        /// </summary>
        public TTypedArray As<TTypedArray>(long byteOffset, long elementCount) where TTypedArray : TypedArray
        {
            using var heapBuffer = GetHeapBuffer();
            var typedArray = (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), heapBuffer, Address + byteOffset, elementCount)!;
            ToDispose(typedArray);
            return typedArray;
        }
        /// <summary>
        /// Returns a TypedArray that points at the pinned data.
        /// </summary>
        public TypedArray As(Type typedArrayType, long byteOffset = 0)
            => As(typedArrayType, byteOffset, (long)Math.Floor((float)(ByteLength - byteOffset) / (float)TypedArray.GetTypedArrayElementSize(typedArrayType)));
        /// <summary>
        /// Returns a TypedArray that points at the pinned data.
        /// </summary>
        public TypedArray As(Type typedArrayType, long byteOffset, long elementCount)
        {
            using var heapBuffer = GetHeapBuffer();
            var typedArray = (TypedArray)Activator.CreateInstance(typedArrayType, heapBuffer, Address + byteOffset, elementCount)!;
            ToDispose(typedArray);
            return typedArray;
        }
        /// <summary>
        /// Returns a DataView that points at the pinned data.
        /// </summary>
        public DataView AsDataView(long byteOffset = 0) => AsDataView(byteOffset, ByteLength - byteOffset);
        /// <summary>
        /// Returns a DataView that points at the pinned data.
        /// </summary>
        public DataView AsDataView(long byteOffset, long byteLength)
        {
            using var heapBuffer = GetHeapBuffer();
            var jsView = new DataView(heapBuffer, Address + byteOffset, byteLength)!;
            ToDispose(jsView);
            return jsView;
        }
        /// <summary>
        /// Returns a DataView that points at the pinned data.
        /// </summary>
        public DataView ToDataView(long byteOffset = 0) => ToDataView(byteOffset, ByteLength - byteOffset);
        /// <summary>
        /// Returns a DataView that points at the pinned data.
        /// </summary>
        public DataView ToDataView(long byteOffset, long byteLength)
        {
            using var arrayBuffer = ToArrayBuffer(byteOffset, byteLength);
            var jsView = new DataView(arrayBuffer)!;
            return jsView;
        }
        List<IDisposable> DisposableViews = new List<IDisposable>();
        T ToDispose<T>(T disposable) where T : IDisposable
        {
            DisposableViews.Add(disposable);
            return disposable;
        }
    }
    /// <summary>
    /// JsonConverter for SharedMemory types
    /// </summary>
    public class HeapViewConverter : JsonConverter<HeapView>
    {
        /// <summary>
        /// Returns true if the type can be converted with this converter
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            var ret = typeToConvert.IsAssignableTo(typeof(HeapView));
            return ret;
        }
        /// <summary>
        /// Read converter
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override HeapView Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("HeapView deserialization not supported.");
        }
        /// <summary>
        /// Write converter
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, HeapView value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object?)value?.AsNativeView(), options);
        }
    }
}

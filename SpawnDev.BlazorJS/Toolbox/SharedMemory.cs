using SpawnDev.BlazorJS.JSObjects;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Pins the byte[] in memory, and creates a Uint8Array, pointing at that byte[], that can be passed to Javascript.<br/>
    /// Javascript can modify the Blazor .Net byte[] directly by modifying the Uint8Array.<br/>
    /// When this object is disposed the memory will be unpinned.<br/>
    /// WARNING: The Uint8Array will point to a small region of the Blazor .Net memory heap ArrayBuffer.<br/>
    /// If using the Uint8Array.buffer, make sure to only use the region specified by the Uint8Array.byteOffset and length properties.
    /// </summary>
    [JsonConverter(typeof(SharedMemoryConverter))]
    public class SharedByteArray : SharedMemory<byte, Uint8Array>
    {
        /// <summary>
        /// Allows casting to SharedByteArray in situations where the Uint8Array will be immediately used
        /// </summary>
        /// <param name="data">source</param>
        public static explicit operator SharedByteArray(byte[] data) => new SharedByteArray(data);
        /// <summary>
        /// Implicit conversion to Uint8Array allows drop in use anywhere Uint8Array is used.
        /// </summary>
        /// <param name="memView"></param>
        public static implicit operator Uint8Array(SharedByteArray memView) => memView.JSView;
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        public SharedByteArray(byte[] data) : base(data) { }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="size"></param>
        public SharedByteArray(long size) : base(size) { }
    }
    /// <summary>
    /// Pins the byte[] in memory, and creates a Uint8ClampedArray, pointing at that byte[], that can be passed to Javascript.<br/>
    /// Javascript can modify the Blazor .Net byte[] directly by modifying the Uint8ClampedArray.<br/>
    /// When this object is disposed the memory will be unpinned.<br/>
    /// WARNING: The Uint8ClampedArray will point to a small region of the Blazor .Net memory heap ArrayBuffer.<br/>
    /// If using the Uint8ClampedArray.buffer, make sure to only use the region specified by the Uint8ClampedArray.byteOffset and length properties.
    /// </summary>
    [JsonConverter(typeof(SharedMemoryConverter))]
    public class SharedByteClampedArray : SharedMemory<byte, Uint8ClampedArray>
    {
        /// <summary>
        /// Allows casting to SharedByteArray in situations where the Uint8ClampedArray will be immediately used
        /// </summary>
        /// <param name="data">source</param>
        public static explicit operator SharedByteClampedArray(byte[] data) => new SharedByteClampedArray(data);
        /// <summary>
        /// Implicit conversion to Uint8ClampedArray allows drop in use anywhere Uint8ClampedArray is used.
        /// </summary>
        /// <param name="memView"></param>
        public static implicit operator Uint8ClampedArray(SharedByteClampedArray memView) => memView.JSView;
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        public SharedByteClampedArray(byte[] data) : base(data) { }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="size"></param>
        public SharedByteClampedArray(long size) : base(size) { }
    }

    /// <summary>
    /// Pins the float[] in memory, and creates a Float32Array, pointing at that float[], that can be passed to Javascript.<br/>
    /// Javascript can modify the Blazor .Net float[] directly by modifying the Float32Array.<br/>
    /// When this object is disposed the memory will be unpinned.<br/>
    /// WARNING: The Float32Array will point to a small region of the Blazor .Net memory heap ArrayBuffer.<br/>
    /// If using the Float32Array.buffer, make sure to only use the region specified by the Float32Array.byteOffset and length properties.
    /// </summary>
    [JsonConverter(typeof(SharedMemoryConverter))]
    public class SharedFloat32Array : SharedMemory<float, Float32Array>
    {
        /// <summary>
        /// Allows casting to SharedFloat32Array in situations where the Float32Array will be immediately used
        /// </summary>
        public static explicit operator SharedFloat32Array(float[] data) => new SharedFloat32Array(data);
        /// <summary>
        /// Implicit conversion to Float32Array allows drop in use anywhere Float32Array is used.
        /// </summary>
        public static implicit operator Float32Array(SharedFloat32Array memView) => memView.JSView;
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        public SharedFloat32Array(float[] data) : base(data) { }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="size"></param>
        public SharedFloat32Array(long size) : base(size) { }
    }
    /// <summary>
    /// Base class for SharedMemory
    /// </summary>
    public abstract class SharedMemory : IDisposable
    {
        /// <summary>
        /// True if the object has been disposed
        /// </summary>
        public bool Disposed { get; protected set; }
        /// <summary>
        /// Memory in address as a long
        /// </summary>
        public long Address { get; protected set; }
        internal TypedArray? TypedArray;
        /// <summary>
        /// GSHandle of the memory region
        /// </summary>
        protected GCHandle handle;
        /// <summary>
        /// Pointer to the memory region
        /// </summary>
        protected IntPtr ptr;
        /// <summary>
        /// Dispose resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            Disposed = true;
            Address = 0;
            handle.Free();
            ptr = IntPtr.Zero;
            TypedArray?.Dispose();
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
        ~SharedMemory()
        {
            Dispose(false);
        }
    }
    /// <summary>
    /// Base class typed for SharedMemory
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTypedArray"></typeparam>
    public abstract class SharedMemory<TSource, TTypedArray> : SharedMemory where TSource : unmanaged where TTypedArray : TypedArray
    {
        /// <summary>
        /// The Javascript TypedArray view of Data
        /// </summary>
        public TTypedArray JSView { get; private set; }
        /// <summary>
        /// The shared data
        /// </summary>
        public TSource[] Data { get; private set; }
        private BlazorJSRuntime JS => BlazorJSRuntime.JS;
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="data"></param>
        public SharedMemory(TSource[] data)
        {
            Data = data;
            handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
            ptr = handle.AddrOfPinnedObject();
            Address = ptr.ToInt64();
            using var arrayBuffer = JS.Get<ArrayBuffer>("Module.asm.memory.buffer"); // Module.asm.memory.buffer, Module.HEAP32.buffer
            JSView = (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), arrayBuffer, Address, data.Length)!;
            TypedArray = JSView;
        }
        /// <summary>
        /// Pin data in a region of Blazor memory to make it directly accessible by Javascript
        /// </summary>
        /// <param name="size"></param>
        public SharedMemory(long size)
        {
            Data = new TSource[size];
            handle = GCHandle.Alloc(Data, GCHandleType.Pinned);
            ptr = handle.AddrOfPinnedObject();
            Address = ptr.ToInt64();
            using var arrayBuffer = JS.Get<ArrayBuffer>("Module.asm.memory.buffer");
            JSView = (TTypedArray)Activator.CreateInstance(typeof(TTypedArray), arrayBuffer, Address, size)!;
            TypedArray = JSView;
        }
    }
    /// <summary>
    /// JsonConverter for SharedMemory types
    /// </summary>
    public class SharedMemoryConverter : JsonConverter<SharedByteArray>
    {
        /// <summary>
        /// Read converter
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override SharedByteArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("SharedMemory read not supported.");
        }
        /// <summary>
        /// Write converter
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, SharedByteArray value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value == null ? null : value.TypedArray, options);
        }
    }
}

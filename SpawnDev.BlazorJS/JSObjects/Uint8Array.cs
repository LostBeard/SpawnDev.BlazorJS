using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    /// <summary>
    /// The Uint8Array typed array represents an array of 8-bit unsigned integers. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// Uint8Array is a subclass of the hidden TypedArray class.<br />
    /// 
    /// </summary>
    public class Uint8Array : TypedArray
    {
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8Array() : base(JS.New(nameof(Uint8Array))) { }
        public Uint8Array(long length) : base(JS.New(nameof(Uint8Array), length)) { }
        public Uint8Array(TypedArray typedArray) : base(JS.New(nameof(Uint8Array), typedArray)) { }
        public Uint8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8Array), arrayBuffer)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset, length)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset, length)) { }
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        public override byte[] ReadBytes() => JS.ReturnMe<byte[]>(JSRef);
        public Uint8Array Slice() => JSRef.Call<Uint8Array>("slice");
        public Uint8Array Slice(long start) => JSRef.Call<Uint8Array>("slice", start);
        public Uint8Array Slice(long start, long end) => JSRef.Call<Uint8Array>("slice", start, end);
        public byte[] SliceBytes() => JSRef.Call<byte[]>("slice");
        public byte[] SliceBytes(long start) => JSRef.Call<byte[]>("slice", start);
        public byte[] SliceBytes(long start, long end) => JSRef.Call<byte[]>("slice", start, end);
        /// <summary>
        /// Returns a number value of the element size. 1 in the case of Uint8Array.
        /// </summary>
        public static int BYTES_PER_ELEMENT => JS.Get<int>($"{nameof(Uint8Array)}.BYTES_PER_ELEMENT");
        public byte this[long i]
        {
            get => JSRef.Get<byte>(i);
            set => JSRef.Set(i, value);
        }
    }
}

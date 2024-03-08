using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Float32Array : TypedArray
    {
        /// <summary>
        /// Returns a float value from the array at index<br />
        /// Limited performance due to 1 : 1 value to interop call ratio
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[long index] => JSRef.Get<float>(index);
        public Float32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float32Array(float[] data) : base(JS.New(nameof(Float32Array), data)) { }
        public Float32Array() : base(JS.New(nameof(Float32Array))) { }
        public Float32Array(long length) : base(JS.New(nameof(Float32Array), length)) { }
        public Float32Array(TypedArray typedArray) : base(JS.New(nameof(Float32Array), typedArray)) { }
        public Float32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Float32Array), arrayBuffer)) { }
        public Float32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Float32Array), arrayBuffer, byteOffset)) { }
        public Float32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float32Array), arrayBuffer, byteOffset, length)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Float32Array), sharedArrayBuffer)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Float32Array), sharedArrayBuffer, byteOffset)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float32Array), sharedArrayBuffer, byteOffset, length)) { }

        public void CopyTo(float[] dst, int dstOffset = 0)
        {
            var bytes = ReadBytes();
            System.Buffer.BlockCopy(bytes, 0, dst, dstOffset * sizeof(float), bytes.Length);
        }

        public float[] ToArray()
        {
            var bytes = ReadBytes();
            var pcmDataNet = new float[bytes.Length / sizeof(float)];
            System.Buffer.BlockCopy(bytes, 0, pcmDataNet, 0, bytes.Length);
            return pcmDataNet;
        }
    }
}
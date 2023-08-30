using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Float32Array : TypedArray
    {
        public Float32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float32Array(float[] data) : base(JS.New(nameof(Float32Array), data)) { }
        public Float32Array(long length) : base(JS.New(nameof(Float32Array), length)) { }
    }
}
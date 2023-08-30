using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Float64Array : TypedArray
    {
        public Float64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float64Array(double[] data) : base(JS.New(nameof(Float64Array), data)) { }
        public Float64Array(long length) : base(JS.New(nameof(Float64Array), length)) { }
    }
}
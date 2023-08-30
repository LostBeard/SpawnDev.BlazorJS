using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int32Array : TypedArray
    {
        public Int32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int32Array(long length) : base(JS.New(nameof(Int32Array), length)) { }
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int8Array : TypedArray
    {
        public Int8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int8Array(long length) : base(JS.New(nameof(Int8Array), length)) { }
    }
}

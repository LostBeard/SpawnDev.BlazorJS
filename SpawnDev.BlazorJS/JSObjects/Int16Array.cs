using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int16Array : TypedArray
    {
        public Int16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int16Array(long length) : base(JS.New(nameof(Int16Array), length)) { }
    }
}

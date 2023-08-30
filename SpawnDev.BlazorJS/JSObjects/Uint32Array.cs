using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint32Array : TypedArray
    {
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint32Array(long length) : base(JS.New(nameof(Uint32Array), length)) { }
    }
}

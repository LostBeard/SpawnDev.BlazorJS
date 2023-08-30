using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint16Array : TypedArray {
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint16Array(long length) : base(JS.New(nameof(Uint16Array), length)) { }
    }
}

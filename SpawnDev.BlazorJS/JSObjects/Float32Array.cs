using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Float32Array : JSObject {
        public Float32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float32Array(float[] data) : base(JS.New(nameof(Float32Array), data)) { }
    }
}
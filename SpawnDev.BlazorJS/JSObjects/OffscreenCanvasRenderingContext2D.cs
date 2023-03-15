using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D

    public class OffscreenCanvasRenderingContext2D : CanvasRenderingContext2D {
        public OffscreenCanvasRenderingContext2D(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void Commit() => JSRef.CallVoid("commit");
    }
}

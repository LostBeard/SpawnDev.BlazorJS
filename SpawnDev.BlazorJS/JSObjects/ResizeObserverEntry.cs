using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ResizeObserverSize {
        public double InlineSize { get; set; }
        public double BlockSize { get; set; }
    }

    public class ResizeObserverEntry : JSObject {
        public List<ResizeObserverSize> BorderBoxSize => JSRef.Get<List<ResizeObserverSize>>("borderBoxSize");
        public List<ResizeObserverSize> ContentBoxSize => JSRef.Get<List<ResizeObserverSize>>("contentBoxSize");
        public List<ResizeObserverSize> DevicePixelContentBoxSize => JSRef.Get<List<ResizeObserverSize>>("devicePixelContentBoxSize");
        public DOMRectReadOnly ContentRect => JSRef.Get<DOMRectReadOnly>("contentRect");
        public ResizeObserverEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

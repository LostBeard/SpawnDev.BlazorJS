using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ScreenDetailed : JSObject {
        public ScreenDetailed(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int AvailHeight => JSRef.Get<int>("availHeight");
        public int AvailLeft => JSRef.Get<int>("availLeft");
        public int AvailTop => JSRef.Get<int>("availTop");
        public int AvailWidth => JSRef.Get<int>("availWidth");
        public int ColorDepth => JSRef.Get<int>("colorDepth");
        public double DevicePixelRatio { get { var tmp = JSRef.Get<double>("devicePixelRatio"); return tmp > 0d ? tmp : 1d; } }
        public int Height => JSRef.Get<int>("height");
        public bool IsExtended => JSRef.Get<bool>("isExtended");
        public bool IsInternal => JSRef.Get<bool>("isInternal");
        public bool IsPrimary => JSRef.Get<bool>("isPrimary");
        public string Label => JSRef.Get<string>("label");
        public int Left => JSRef.Get<int>("left");
        public int PixelDepth => JSRef.Get<int>("pixelDepth");
        public int Top => JSRef.Get<int>("top");
        public int Width => JSRef.Get<int>("width");
        public ScreenOrientation Orientation => JSRef.Get<ScreenOrientation>("orientation");
    }
}

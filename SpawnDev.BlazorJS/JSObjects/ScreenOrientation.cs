using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ScreenOrientation : JSObject {
        public ScreenOrientation(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Type => JSRef!.Get<string>("type");
        public double Angle => JSRef!.Get<double>("angle");
    }
}

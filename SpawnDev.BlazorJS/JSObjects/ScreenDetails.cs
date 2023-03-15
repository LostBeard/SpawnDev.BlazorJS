using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ScreenDetails : JSObject {
        public ScreenDetails(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ScreenDetailed CurrentScreen => JSRef.Get<ScreenDetailed>("currentScreen");
        public ScreenDetailed[] Screens => JSRef.Get<ScreenDetailed[]>("screens");
    }
}

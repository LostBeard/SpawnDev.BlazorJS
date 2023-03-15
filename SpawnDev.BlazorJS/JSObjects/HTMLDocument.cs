using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class HTMLDocument : Document {
        public HTMLDocument(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class HTMLElement : Element {
        public HTMLElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");
    }
}
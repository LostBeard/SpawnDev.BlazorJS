using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class XMLHttpRequestEventTarget : EventTarget {
        public XMLHttpRequestEventTarget(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

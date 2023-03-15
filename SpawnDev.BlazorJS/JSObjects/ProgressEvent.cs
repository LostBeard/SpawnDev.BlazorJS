using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ProgressEvent : JSObject {
        public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long? Loaded => JSRef.Get<long?>("loaded");
        public long? Total => JSRef.Get<long?>("total");
    }
}

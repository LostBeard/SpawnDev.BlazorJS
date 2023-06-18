using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ProgressEvent : Event {
        public ProgressEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public long? Loaded => JSRef.Get<long?>("loaded");
        public long? Total => JSRef.Get<long?>("total");
        public bool? LengthComputable => JSRef.Get<bool?>("lengthComputable");
    }
}

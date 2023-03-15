using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class AbortSignal : EventTarget {
        public AbortSignal(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Aborted => JSRef.Get<bool>("aborted");
        public void Abort() => JSRef.CallVoid("abort");
    }
}

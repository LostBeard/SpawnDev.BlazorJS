using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ExtendableEvent : Event
    {
        public ExtendableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitUntil(Promise promise) => JSRef.CallVoid("waitUntil", promise);
        public void WaitUntil(Task promise) => JSRef.CallVoid("waitUntil", promise);
    }
}

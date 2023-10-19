using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PushMessageData : ExtendableEvent
    {
        public PushMessageData(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    public class PushEvent : ExtendableEvent
    {
        public PushEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public PushMessageData Data => JSRef.Get<PushMessageData>("data");
    }
    public class SyncEvent : ExtendableEvent
    {
        public SyncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool LastChance => JSRef.Get<bool>("lastChance");
        public string Tag => JSRef.Get<string>("tag");
    }
    public class ExtendableEvent : Event
    {
        public ExtendableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void WaitUntil(Promise promise) => JSRef.CallVoid("waitUntil", promise);
        public void WaitUntil(Task promise) => JSRef.CallVoid("waitUntil", promise);
    }
}

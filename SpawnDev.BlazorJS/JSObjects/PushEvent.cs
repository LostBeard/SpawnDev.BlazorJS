using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PushEvent : ExtendableEvent
    {
        public PushEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public PushMessageData Data => JSRef.Get<PushMessageData>("data");
    }
}

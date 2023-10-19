using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class SyncEvent : ExtendableEvent
    {
        public SyncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool LastChance => JSRef.Get<bool>("lastChance");
        public string Tag => JSRef.Get<string>("tag");
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class HashChangeEvent : Event
    {
        public HashChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string NewURL => JSRef!.Get<string>("newURL");
        public string OldURL => JSRef!.Get<string>("oldURL");
    }
}

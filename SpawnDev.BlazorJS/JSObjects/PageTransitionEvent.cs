using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PageTransitionEvent : Event
    {
        public PageTransitionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Persisted => JSRef!.Get<bool>("persisted");
    }
}

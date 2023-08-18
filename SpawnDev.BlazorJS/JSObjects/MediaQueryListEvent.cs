using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaQueryListEvent : Event
    {
        public MediaQueryListEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Matches => JSRef.Get<bool>("matches");
        public string Media => JSRef.Get<string>("media");
    }
}

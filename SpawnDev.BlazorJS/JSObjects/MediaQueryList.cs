using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaQueryList : JSObject
    {
        public MediaQueryList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Matches => JSRef.Get<bool>("matches");
        public string Media => JSRef.Get<string>("media");
    }
}

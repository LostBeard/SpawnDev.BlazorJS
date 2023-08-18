using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaQueryList : EventTarget
    {
        public MediaQueryList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Matches => JSRef.Get<bool>("matches");
        public string Media => JSRef.Get<string>("media");
        public JSEventCallback<MediaQueryListEvent> OnChange { get => new JSEventCallback<MediaQueryListEvent>(o => AddEventListener("change", o), o => RemoveEventListener("change", o)); set { } }
    }
}

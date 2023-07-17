using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class FocusEvent : UIEvent
    {
        public FocusEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public EventTarget? RelatedTarget => JSRef.Get<EventTarget?>("relatedTarget");
    }
}

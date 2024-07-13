using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class NotificationEvent : ExtendableEvent
    {
        public NotificationEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}

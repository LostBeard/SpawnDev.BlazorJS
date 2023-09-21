using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaRecorderErrorEvent : Event
    {
        public MediaRecorderErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

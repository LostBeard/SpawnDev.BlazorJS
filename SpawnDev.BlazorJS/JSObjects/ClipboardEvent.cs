using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ClipboardEvent : Event
    {
        public ClipboardEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DataTransfer ClipboardData => JSRef.Get<DataTransfer>("clipboardData");
    }
}

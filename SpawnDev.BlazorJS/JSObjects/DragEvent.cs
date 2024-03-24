using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/DragEvent
    public class DragEvent : MouseEvent
    {
        public DragEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
        public DataTransfer DataTransfer => JSRef.Get<DataTransfer>("dataTransfer");
    }
}

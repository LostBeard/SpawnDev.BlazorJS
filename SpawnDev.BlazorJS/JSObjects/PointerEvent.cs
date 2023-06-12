using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PointerEvent : MouseEvent
    {
        public PointerEvent(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PointerEvent interface represents the state of a DOM event produced by a pointer such as the geometry of the contact point, the device type that generated the event, the amount of pressure that was applied on the contact surface, etc.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent
    /// </summary>
    public class PointerEvent : MouseEvent
    {
        public PointerEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WheelEvent interface represents events that occur due to the user moving a mouse wheel or similar input device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WheelEvent
    /// </summary>
    public class WheelEvent : MouseEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WheelEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a double representing the horizontal scroll amount.
        /// </summary>
        public double DeltaX => JSRef!.Get<double>("deltaX");
        /// <summary>
        /// Returns a double representing the vertical scroll amount.
        /// </summary>
        public double DeltaY => JSRef!.Get<double>("deltaY");
        /// <summary>
        /// Returns a double representing the scroll amount for the z-axis.
        /// </summary>
        public double DeltaZ => JSRef!.Get<double>("deltaZ");
        /// <summary>
        /// Returns an unsigned long representing the unit of the delta* values' scroll amount. Permitted values are:
        /// </summary>
        public ulong DeltaMode => JSRef!.Get<ulong>("deltaMode");
    }
}

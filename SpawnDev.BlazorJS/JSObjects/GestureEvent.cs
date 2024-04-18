using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GestureEvent is a proprietary interface specific to WebKit which gives information regarding multi-touch gestures. Events using this interface include gesturestart, gesturechange, and gestureend.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GestureEvent
    /// </summary>
    public class GestureEvent : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public GestureEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

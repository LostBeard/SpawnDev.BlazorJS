using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The UIEvent interface represents simple user interface events.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/UIEvent
    /// </summary>
    public class UIEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public UIEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}

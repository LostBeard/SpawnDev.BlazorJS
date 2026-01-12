using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/InputEvent
    // TODO - finish
    /// <summary>
    /// The InputEvent interface represents an event notifying the user to input text.
    /// </summary>
    public class InputEvent : UIEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public InputEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
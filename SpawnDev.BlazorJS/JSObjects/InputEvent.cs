using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/InputEvent
    // TODO - finish
    public class InputEvent : UIEvent
    {
        public InputEvent(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
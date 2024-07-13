using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GamepadEvent
    /// </summary>
    public class GamepadEvent : Event
    {
        public GamepadEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Gamepad Gamepad => JSRef!.Get<Gamepad>("gamepad");
    }
}

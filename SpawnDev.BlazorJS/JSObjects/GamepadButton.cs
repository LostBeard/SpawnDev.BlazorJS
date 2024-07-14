using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GamepadButton interface defines an individual button of a gamepad or other controller, allowing access to the current state of different types of buttons available on the control device.<br/>
    /// GamepadButton, when serialized via JSON.stringify(), returns and empty object {} so a JSObject is used even though the values are static<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GamepadButton
    /// </summary>
    public class GamepadButton : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public GamepadButton(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean value indicating whether the button is currently pressed (true) or unpressed (false).
        /// </summary>
        public bool Pressed => JSRef!.Get<bool>("pressed");
        /// <summary>
        /// A boolean value indicating whether the button is currently touched (true) or not touched (false)
        /// </summary>
        public bool Touched => JSRef!.Get<bool>("touched");
        /// <summary>
        /// A double value used to represent the current state of analog buttons, such as the triggers on many modern gamepads. The values are normalized to the range 0.0 —1.0, with 0.0 representing a button that is not pressed, and 1.0 representing a button that is fully pressed.
        /// </summary>
        public double Value => JSRef!.Get<double>("value");
    }
}

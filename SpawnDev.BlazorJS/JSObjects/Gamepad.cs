using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Gamepad interface of the Gamepad API defines an individual gamepad or other controller, allowing access to information such as button presses, axis positions, and id.<br/>
    /// A Gamepad object can be returned in one of two ways: via the gamepad property of the gamepadconnected and gamepaddisconnected events, or by grabbing any position in the array returned by the Navigator.getGamepads() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Gamepad
    /// </summary>
    public class Gamepad : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Gamepad(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An array representing the controls with axes present on the device (e.g. analog thumb sticks).
        /// </summary>
        public double[] Axes => JSRef!.Get<double[]>("axes");
        /// <summary>
        /// An array of gamepadButton objects representing the buttons present on the device.
        /// </summary>
        public GamepadButton[] Buttons => JSRef!.Get<GamepadButton[]>("buttons");
        /// <summary>
        /// A boolean indicating whether the gamepad is still connected to the system.
        /// </summary>
        public bool Connected => JSRef!.Get<bool>("connected");
        /// <summary>
        /// An enum defining what hand the controller is being held in, or is most likely to be held in.<br/>
        /// </summary>
        public GamepadHand? Hand => JSRef!.Get<EnumString<GamepadHand>>("hand");
        /// <summary>
        /// An array containing GamepadHapticActuator objects, each of which represents haptic feedback hardware available on the controller.
        /// </summary>
        public GamepadHapticActuator[]? HapticActuators => JSRef!.Get<GamepadHapticActuator[]?>("hapticActuators");
        /// <summary>
        /// A GamepadHapticActuator object, which represents haptic feedback hardware available on the controller.<br/>
        /// ⚠ non-standard
        /// </summary>
        public GamepadHapticActuator? VibrationActuator => JSRef!.Get<GamepadHapticActuator?>("vibrationActuator");
        /// <summary>
        /// A string containing identifying information about the controller.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// An integer that is auto-incremented to be unique for each device currently connected to the system.
        /// </summary>
        public int Index => JSRef!.Get<int>("index");
        /// <summary>
        /// A string indicating whether the browser has remapped the controls on the device to a known layout.
        /// </summary>
        public string Mapping => JSRef!.Get<string>("mapping");
        /// <summary>
        /// A GamepadPose object representing the pose information associated with a WebVR controller (e.g. its position and orientation in 3D space).
        /// </summary>
        public GamepadPose Pose => JSRef!.Get<GamepadPose>("pose");
        /// <summary>
        /// A DOMHighResTimeStamp representing the last time the data for this gamepad was updated.
        /// </summary>
        public double TimeStamp => JSRef!.Get<double>("timeStamp");
    }
}

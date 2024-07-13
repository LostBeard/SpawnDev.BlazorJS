using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Gamepad : JSObject
    {
        public Gamepad(IJSInProcessObjectReference _ref) : base(_ref) { }
        public double[] Axes => JSRef!.Get<double[]>("axes");
        public GamepadButton[] Buttons => JSRef!.Get<GamepadButton[]>("buttons");
        public bool Connected => JSRef!.Get<bool>("connected");
        public string Id => JSRef!.Get<string>("id");
        public int Index => JSRef!.Get<int>("index");
        public string Mapping => JSRef!.Get<string>("mapping");
        public double TimeStamp => JSRef!.Get<double>("timeStamp");
        public GamepadHapticActuator[]? HapticActuators => JSRef!.Get<GamepadHapticActuator[]?>("hapticActuators");
        public GamepadHapticActuator? VibrationActuator => JSRef!.Get<GamepadHapticActuator?>("vibrationActuator");
    }
}

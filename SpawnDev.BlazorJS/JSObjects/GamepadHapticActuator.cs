using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public enum GamepadHapticActuatorType
    {
        [JsonPropertyName("vibration")]
        Vibration,
    }
    /// <summary>
    /// The GamepadHapticActuator interface of the Gamepad API represents hardware in the controller designed to provide haptic feedback to the user (if available), most commonly vibration hardware.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator
    /// </summary>
    public class GamepadHapticActuator : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public GamepadHapticActuator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an enum representing the type of the haptic hardware.
        /// </summary>
        public GamepadHapticActuatorType Type => JSRef!.Get<EnumString<GamepadHapticActuatorType>>("type");
        /// <summary>
        /// Returns true if PlayEffect is supported
        /// </summary>
        public bool PlayEffectSupported => !JSRef!.IsUndefined("playEffect");
        /// <summary>
        /// Returns true if Pulse is supported
        /// </summary>
        public bool PulseSupported => !JSRef!.IsUndefined("pulse");
        /// <summary>
        /// Returns true if Reset is supported
        /// </summary>
        public bool ResetSupported => !JSRef!.IsUndefined("reset");
        /// <summary>
        /// The pulse() method of the GamepadHapticActuator interface makes the hardware pulse at a certain intensity for a specified duration.<br/>
        /// May be Firefox and not Chrome
        /// </summary>
        /// <param name="value">A double representing the intensity of the pulse. This can vary depending on the hardware type, but generally takes a value between 0.0 (no intensity) and 1.0 (full intensity).</param>
        /// <param name="duration">A double representing the duration of the pulse, in milliseconds.</param>
        /// <returns></returns>
        public Task Pulse(double value, double duration) => JSRef!.CallVoidAsync("pulse", value, duration);
        /// <summary>
        /// The playEffect() method of the GamepadHapticActuator interface makes the hardware play a specific vibration pattern.<br/>
        /// May be Chrome and not Firefox
        /// </summary>
        /// <param name="type">A string representing the desired effect. This can vary depending on the hardware type. Possible values are "dual-rumble" or "vibration".</param>
        /// <param name="effectParams">An object to describe a desired haptic effect.</param>
        /// <returns></returns>
        public Task PlayEffect(string type, HapticEffectParams effectParams) => JSRef!.CallVoidAsync("playEffect", type, effectParams);
        /// <summary>
        /// Cancels the active Effect <br/>
        /// May be Chrome specific
        /// </summary>
        public void Reset() => JSRef!.CallVoidAsync("playEffect");
    }
}

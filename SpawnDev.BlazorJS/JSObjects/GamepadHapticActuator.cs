using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class GamepadHapticActuator : JSObject
    {
        public GamepadHapticActuator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Type => JSRef.Get<string>("type");
        public bool PlayEffectSupported => !JSRef.PropertyIsUndefined("playEffect");
        public bool PulseSupported => !JSRef.PropertyIsUndefined("pulse");
        public bool ResetSupported => !JSRef.PropertyIsUndefined("reset");
        /// <summary>
        /// The playEffect() method of the GamepadHapticActuator interface makes the hardware play a specific vibration pattern.<br />
        /// May be Chrome and not Firefox
        /// </summary>
        /// <param name="type">A string representing the desired effect. This can vary depending on the hardware type. Possible values are "dual-rumble" or "vibration".</param>
        /// <param name="effectParams">An object to describe a desired haptic effect.</param>
        /// <returns></returns>
        public Task PlayEffect(string type, HapticEffectParams effectParams) => JSRef.CallVoidAsync("playEffect", type, effectParams);
        /// <summary>
        /// The pulse() method of the GamepadHapticActuator interface makes the hardware pulse at a certain intensity for a specified duration.<br />
        /// May be Firefox and not Chrome
        /// </summary>
        /// <param name="value">A double representing the intensity of the pulse. This can vary depending on the hardware type, but generally takes a value between 0.0 (no intensity) and 1.0 (full intensity).</param>
        /// <param name="duration">A double representing the duration of the pulse, in milliseconds.</param>
        /// <returns></returns>
        public Task Pulse(double value, double duration) => JSRef.CallVoidAsync("pulse", value, duration);
        /// <summary>
        /// Cancels the active Effect <br />
        /// May be Chrome specific
        /// </summary>
        public void Reset() => JSRef.CallVoidAsync("playEffect");
    }
}

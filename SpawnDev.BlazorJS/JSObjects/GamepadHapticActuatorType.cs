using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An enumerated value representing the haptic hardware type.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GamepadHapticActuator/type#value
    /// </summary>
    public enum GamepadHapticActuatorType
    {
        /// <summary>
        /// Simple vibration hardware, which creates a rumbling effect.
        /// </summary>
        [JsonPropertyName("vibration")]
        Vibration,
        /// <summary>
        /// A controller with a vibration motor in each handle. Each motor can be vibrated independently to create positional rumbling effects.
        /// </summary>
        [JsonPropertyName("dual-rumble")]
        DualRumble,
    }
}

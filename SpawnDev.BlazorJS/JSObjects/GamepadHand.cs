using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Gamepad hand enum<br/>
    /// https://w3c.github.io/gamepad/extensions.html#gamepadhand-enum<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Gamepad/hand#value<br/>
    /// </summary>
    public enum GamepadHand
    {
        /// <summary>
        /// unknown, both hands, or not applicable
        /// </summary>
        [JsonPropertyName("")]
        Unknown,
        /// <summary>
        /// Left hand
        /// </summary>
        [JsonPropertyName("left")]
        Left,
        /// <summary>
        /// Right hand
        /// </summary>
        [JsonPropertyName("right")]
        Right,
    }
}

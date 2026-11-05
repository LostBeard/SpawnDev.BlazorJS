
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Which audio, if any, the user agent should offer to share with a WINDOW capture from getDisplayMedia()
    /// (<see cref="DisplayMediaStreamOptions.WindowAudio"/>). Chromium shipped it around Chrome 141 (Chrome 140+ in the extensions reference).<br/>
    /// https://groups.google.com/a/chromium.org/g/blink-dev/c/66dDyQoX3RI
    /// </summary>
    public enum WindowAudioPreferenceEnum
    {
        /// <summary>
        /// Offer no audio with a window capture.
        /// </summary>
        [JsonPropertyName("exclude")]
        Exclude,
        /// <summary>
        /// Offer the system audio (everything the machine is playing) with a window capture.
        /// </summary>
        [JsonPropertyName("system")]
        System,
        /// <summary>
        /// Offer only the audio of the captured window's own application, so other applications' sound (voice chat, music) is left out.
        /// </summary>
        [JsonPropertyName("window")]
        Window,
    }
}

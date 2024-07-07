using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes whether an application invoking setFocusBehavior() would like the user agent to focus the display surface associated with that CaptureController's capture-session.<br/>
    /// https://www.w3.org/TR/screen-capture/#dom-capturestartfocusbehavior
    /// </summary>
    public enum CaptureStartFocusBehavior
    {
        /// <summary>
        /// The application prefers to be focused.
        /// </summary>
        [JsonPropertyName("focus-capturing-application")]
        FocusCapturingApplication,
        /// <summary>
        /// The application prefers that the display surface associated with this CaptureController's capture-session be focused.
        /// </summary>
        [JsonPropertyName("focus-captured-surface")]
        FocusCapturedSurface,
        /// <summary>
        /// The application prefers that the user agent not change focus, leaving focus with whichever surface last had focus following the user's interaction with the user agent and/or operating system.
        /// </summary>
        [JsonPropertyName("no-focus-change")]
        NoFocusChange,
    }
}

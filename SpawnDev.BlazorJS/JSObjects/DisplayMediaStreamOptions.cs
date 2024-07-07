using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DisplayMediaStreamOptions dictionary is used to instruct the user agent what sort of MediaStreamTracks may be included in the MediaStream returned by getDisplayMedia.<br/>
    /// https://www.w3.org/TR/screen-capture/#displaymediastreamoptions<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia#options<br/>
    /// </summary>
    public class DisplayMediaStreamOptions : MediaStreamConstraints
    {
        /// <summary>
        /// A CaptureController object instance containing methods that can be used to further manipulate the capture session if included.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CaptureController? Controller { get; set; }
        /// <summary>
        /// An enumerated value specifying whether the browser should offer entire screens in the screen capture options presented to the user alongside tab and window options. This option is intended to protect companies from leakage of private information through employee error when using video conferencing apps. Possible values are include, which hints that the browser should include screen options, and exclude, which hints that they should be excluded. A default value is not mandated by the spec; see the Browser compatibility section for browser-specific defaults.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<MonitorTypeSurfacesEnum>? MonitorTypeSurfaces { get; set; }
        /// <summary>
        /// An enumerated value specifying whether the browser should allow the user to select the current tab for capture. This helps to avoid the "infinite hall of mirrors" effect experienced when a video conferencing app inadvertently shares its own display. Possible values are include, which hints that the browser should include the current tab in the choices offered for capture, and exclude, which hints that it should be excluded. A default value is not mandated by the spec; see the Browser compatibility section for browser-specific defaults.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<SelfCapturePreferenceEnum>? SelfBrowserSurface { get; set; }
        /// <summary>
        /// An enumerated value specifying whether the browser should display a control to allow the user to dynamically switch the shared tab during screen-sharing. This is much more convenient than having to go through the whole sharing process again each time a user wants to switch the shared tab. Possible values are include, which hints that the browser should include the control, and exclude, which hints that it should not be shown. A default value is not mandated by the spec; see the Browser compatibility section for browser-specific defaults.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<SurfaceSwitchingPreferenceEnum>? SurfaceSwitching { get; set; }
        /// <summary>
        /// An enumerated value specifying whether the browser should include the system audio among the possible audio sources offered to the user. Possible values are include, which hints that the browser should include the system audio in the list of choices, and exclude, which hints that it should be excluded. A default value is not mandated by the spec; see the Browser compatibility section for browser-specific defaults.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<SystemAudioPreferenceEnum>? SystemAudio { get; set; }
        /// <summary>
        /// A boolean; a value of true instructs the browser to offer the current tab as the most prominent capture source, i.e. as a separate "This Tab" option in the "Choose what to share" options presented to the user. This is useful as many app types generally just want to share the current tab. For example, a slide deck app might want to let the user stream the current tab containing the presentation to a virtual conference. A default value is not mandated by the spec; see the Browser compatibility section for browser-specific defaults.<br/>
        /// ⚠ Non-standard 🧪 Experimental
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreferCurrentTab { get; set; }
    }
}

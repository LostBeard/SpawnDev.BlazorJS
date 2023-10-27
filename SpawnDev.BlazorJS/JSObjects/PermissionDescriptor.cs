using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that sets options for the Permissions.query operation consisting of a comma-separated list of name-value pairs.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query
    /// </summary>
    public class PermissionDescriptor
    {
        /// <summary>
        /// The name of the API whose permissions you want to query. Each browser supports a different set of values.
        /// You'll find Firefox values <a href="https://searchfox.org/mozilla-central/source/dom/webidl/Permissions.webidl#10">here.</a>
        /// Chromium values <a href="https://chromium.googlesource.com/chromium/src/+/refs/heads/main/third_party/blink/renderer/modules/permissions/permission_descriptor.idl">here.</a>
        /// WebKit values <a href="https://github.com/WebKit/WebKit/blob/main/Source/WebCore/Modules/permissions/PermissionName.idl">here.</a>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// (Push only, not supported in Firefox — see the Browser Support section below) Indicates whether you want to show a notification for every message or be able to send silent push notifications. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? UserVisibleOnly { get; set; }
        /// <summary>
        /// Indicates whether you need and/or receive system exclusive messages. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Sysex { get; set; }
    }
}

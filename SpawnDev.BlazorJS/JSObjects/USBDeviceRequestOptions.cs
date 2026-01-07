using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// USB requestDevice options
    /// https://wicg.github.io/webusb/#dictdef-usbdevicerequestoptions
    /// </summary>
    public class USBDeviceRequestOptions
    {
        /// <summary>
        /// An array of filter objects for possible devices you would like to pair.
        /// </summary>
        public IEnumerable<USBDeviceFilter> Filters { get; set; }
        /// <summary>
        /// An array of filter objects for possible devices you would like to exclude.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<USBDeviceFilter>? ExclusionFilters { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// HID RequestDevice options
    /// </summary>
    public class HIDRequestDeviceOptions
    {
        /// <summary>
        /// An integer representing the vendorId of the requested HID device
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? VendorId { get; set; }
        /// <summary>
        /// An integer representing the productId of the requested HID device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProductId { get; set; }
        /// <summary>
        /// An integer representing the usage page component of the HID usage of the requested device. The usage for a top level collection is used to identify the device type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? UsagePage { get; set; }
        /// <summary>
        /// An integer representing the usage ID component of the HID usage of the requested device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Usage { get; set; }
    }
}

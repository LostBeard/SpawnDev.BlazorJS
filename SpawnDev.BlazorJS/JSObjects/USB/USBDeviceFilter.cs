using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// USB.requestDevice() filter dictionary to filter USB devices.<br/>
    /// 5. Device Enumeration 
    /// https://wicg.github.io/webusb/#enumeration
    /// https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice#filters
    /// </summary>
    public class USBDeviceFilter
    {
        /// <summary>
        /// Vendor ID of the USB device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? VendorId { get; set; }
        /// <summary>
        /// Product ID of the USB device.
        /// </summary>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProductId { get; set; }
        /// <summary>
        /// Class code of the USB device.
        /// </summary>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ClassCode { get; set; }
        /// <summary>
        /// Subclass code of the USB device.
        /// </summary>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SubclassCode { get; set; }
        /// <summary>
        /// Protocol code of the USB device.<br/>
        /// </summary>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ProtocolCode { get; set; }
        /// <summary>
        /// Serial number of the USB device.<br/>
        /// </summary>

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SerialNumber { get; set; }
    }
}

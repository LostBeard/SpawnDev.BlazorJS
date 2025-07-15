using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice#filters
    /// </summary>
    public class USBRequestDeviceFilter
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
        public int? SerialNumber { get; set; }
    }
}

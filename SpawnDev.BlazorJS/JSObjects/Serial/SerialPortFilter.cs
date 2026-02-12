using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USB Implementors Forum assigns IDs to specific companies. Each company assigns IDs to its products.
    /// </summary>
    public class SerialPortFilter
    {
        /// <summary>
        /// An unsigned short integer that identifies a USB device vendor.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("usbVendorId")]
        public ushort? UsbVendorId { get; set; }
        /// <summary>
        /// An unsigned short integer that identifies a USB device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("usbProductId")]
        public ushort? UsbProductId { get; set; }
    }
}

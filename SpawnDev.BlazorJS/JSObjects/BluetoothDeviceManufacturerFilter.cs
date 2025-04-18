using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice#manufacturerdata
    /// </summary>
    public class BluetoothDeviceManufacturerFilter
    {
        /// <summary>
        /// A mandatory number identifying the manufacturer of the device. Company identifiers are listed in the Bluetooth specification Assigned numbers, Section 7. For example, to match against devices manufactured by "Digianswer A/S", with assigned hex number 0x000C, you would specify 12.
        /// </summary>
        public int CompanyIdentifier { get; set; }
        /// <summary>
        /// The data prefix. A buffer containing values to match against the values at the start of the advertising manufacturer data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[]? DataPrefix { get; set; }
        /// <summary>
        /// This allows you to match against bytes within the manufacturer data, by masking some bytes of the service data dataPrefix.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[]? Mask { get; set; }
    }
}

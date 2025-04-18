using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice#options
    /// </summary>
    public class BluetoothDeviceOptions
    {
        /// <summary>
        /// An array of filter objects indicating the properties of devices that will be matched. To match a filter object, a device must match all the values of the filter: all its specified services, name, namePrefix, and so on.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<BluetoothDeviceFilter>? Filters { get; set; }
        /// <summary>
        /// An array of filter objects indicating the characteristics of devices that will be excluded from matching. The properties of the array elements are the same as for filters.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<BluetoothDeviceFilter>? ExclusionFilters { get; set; }
        /// <summary>
        /// An array of optional service identifiers.<br/>
        /// The identifiers take the same values as the elements of the services array (a GATT service name, service UUID, or UUID short 16-bit or 32-bit form).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string>? OptionalServices { get; set; }
        /// <summary>
        /// An optional array of integer manufacturer codes. This takes the same values as companyIdentifier.<br/>
        /// The data is not used for filtering the devices, but advertisements that match the specified set are still delivered in advertisementreceived events. This is useful because it allows code to specify an interest in data received from Bluetooth devices without constraining the filter controlling which devices are presented to the user in the permission prompt.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<int>? OptionalManufacturerData { get; set; }
        /// <summary>
        /// A boolean value indicating that the requesting script can accept all Bluetooth devices. The default is false.<br/>
        /// This option is appropriate when devices have not advertised enough information for filtering to be useful. When acceptAllDevices is set to true you should omit all filters and exclusionFilters, and you must set optionalServices to be able to use the returned device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AcceptAllDevices { get; set; }
    }
}

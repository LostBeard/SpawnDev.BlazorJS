using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothDeviceOptions interface of the Web Bluetooth API represents the options that can be passed to the requestDevice() method.<br/>
    /// </summary>
    public class BluetoothAdvertisingEvent : Event
    {
        /// <inheritdoc/>
        public BluetoothAdvertisingEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The BluetoothDevice object that is advertising.
        /// </summary>
        public BluetoothDevice Device => JSRef!.Get<BluetoothDevice>("device");
        /// <summary>
        /// The RSSI (Received Signal Strength Indicator) of the advertisement, in dBm. This is a measure of the power level that the device is receiving the advertisement at, and can be used to determine how far away the device is from the receiver.
        /// </summary>
        public float RSSI => JSRef!.Get<float>("rssi");
        /// <summary>
        /// The TxPower (Transmit Power) of the advertisement, in dBm. This is a measure of the power level that the device is transmitting the advertisement at, and can be used to determine how far away the device is from the receiver.
        /// </summary>
        public float TxPower => JSRef!.Get<float>("txPower");
        /// <summary>
        /// uuids
        /// </summary>
        public string[] UUIDS => JSRef!.Get<string[]>("uuids");

        /// <summary>
        /// Returns a Map containing the manufacturer specific data.
        /// </summary>
        public Map<ushort, DataView>? ManufacturerData => JSRef!.Get<Map<ushort, DataView>?>("manufacturerData");

        /// <summary>
        /// Returns a Map containing the service specific data.
        /// </summary>
        public Map<string, DataView>? ServiceData => JSRef!.Get<Map<string, DataView>?>("serviceData");
    }
}

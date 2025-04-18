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

        public JSObject? ManufacturerData => JSRef!.Get<JSObject?>("manufacturerData");

        public JSObject? ServiceData => JSRef!.Get<JSObject?>("serviceData");

        public string ManufacturerDataTypeOf => JSRef!.TypeOf("manufacturerData");
        public string ServiceDataTypeOf => JSRef!.TypeOf("serviceData");
    }
}

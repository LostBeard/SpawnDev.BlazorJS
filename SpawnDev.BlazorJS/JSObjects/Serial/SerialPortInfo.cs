using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Serial port information<br/>
    /// https://wicg.github.io/serial/#serialportinfo-dictionary<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/getInfo#return_value
    /// </summary>
    public class SerialPortInfo : JSObject
    {
        ///<inheritdoc/>
        public SerialPortInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// If the port is part of a USB device, this property is an unsigned short integer that identifies the device's vendor. If not, it is undefined.
        /// </summary>
        public ushort? UsbVendorId => JSRef!.Get<ushort?>("usbVendorId");
        /// <summary>
        /// If the port is part of a USB device, this property is an unsigned short integer that identifies the USB device. If not, it is undefined.
        /// </summary>
        public ushort? UsbProductId => JSRef!.Get<ushort?>("usbProductId");
        /// <summary>
        /// If the port is a Bluetooth RFCOMM service, this property is an unsigned long integer or string representing the device's Bluetooth service class ID. If not, it is undefined.
        /// </summary>
        public string? BluetoothServiceClassId => JSRef!.Get<string?>("bluetoothServiceClassId");
    }
}

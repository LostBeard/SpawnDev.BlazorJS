using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBDevice interface of the WebUSB API provides access to metadata about a paired USB device and methods for control<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBDevice<br/>
    /// </summary>
    public class USBDevice : JSObject
    {
        #region Constructors
        /// <inheritdoc/>
        public USBDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the USB device's configuration.
        /// </summary>
        public USBConfiguration? Configuration => JSRef!.Get<USBConfiguration?>("configuration");

        /// <summary>
        /// Returns the USB device's configurations.
        /// </summary>
        public Array<USBConfiguration> Configurations => JSRef!.Get<Array<USBConfiguration>>("configurations");

        /// <summary>
        /// One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceSubclass and USBDevice.deviceProtocol.
        /// </summary>
        public int DeviceClass => JSRef!.Get<int>("deviceClass");

        /// <summary>
        /// One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceProtocol.
        /// </summary>
        public int DeviceSubClass => JSRef!.Get<int>("deviceSubClass");

        /// <summary>
        /// One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceSubclass.
        /// </summary>
        public int DeviceProtocol => JSRef!.Get<int>("deviceProtocol");

        /// <summary>
        /// The major version number of the device in a semantic versioning scheme.
        /// </summary>
        public int DeviceVersionMajor => JSRef!.Get<int>("deviceVersionMajor");

        /// <summary>
        /// The minor version number of the device in a semantic versioning scheme.
        /// </summary>
        public int DeviceVersionMinor => JSRef!.Get<int>("deviceVersionMinor");

        /// <summary>
        /// The patch version number of the device in a semantic versioning scheme.
        /// </summary>
        public int DeviceVersionSubminor => JSRef!.Get<int>("deviceVersionSubminor");

        /// <summary>
        /// Returns the USB device's manufacturer name.
        /// </summary>
        public string ManufacturerName => JSRef!.Get<string>("manufacturerName");

        /// <summary>
        /// Indicates whether a session has been started with a paired USB device.
        /// </summary>
        public bool Opened => JSRef!.Get<bool>("opened");

        /// <summary>
        /// Returns the USB device's product ID.
        /// </summary>
        public int ProductId => JSRef!.Get<int>("productId");

        /// <summary>
        /// Returns the USB device's product name.
        /// </summary>
        public string ProductName => JSRef!.Get<string>("productName");

        /// <summary>
        /// Returns the USB device's serial number.
        /// </summary>
        public string SerialNumber => JSRef!.Get<string>("serialNumber");

        /// <summary>
        /// One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMinor and USBDevice.usbVersionSubminor.
        /// </summary>
        public int USBVersionMajor => JSRef!.Get<int>("usbVersionMajor");

        /// <summary>
        /// One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionSubminor.
        /// </summary>
        public int USBVersionMinor => JSRef!.Get<int>("usbVersionMinor");

        /// <summary>
        /// One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionMinor.
        /// </summary>
        public int USBVersionSubminor => JSRef!.Get<int>("usbVersionSubminor");

        /// <summary>
        /// Returns the USB device's vendor ID.
        /// </summary>
        public int VendorId => JSRef!.Get<int>("vendorId");
        #endregion

        #region Methods
        /// <summary>
        /// Claims an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to claim.</param>
        public Task ClaimInterface(int interfaceNumber) => JSRef!.CallVoidAsync("claimInterface", interfaceNumber);

        /// <summary>
        /// Clears a halt condition on an endpoint.
        /// </summary>
        /// <param name="direction">Indicates whether the devices input or output should be cleared. Valid values are 'in' or 'out'.</param>
        /// <param name="endpointNumber">The endpoint number to clear the halt condition on.</param>
        public Task ClearHalt(string direction, int endpointNumber) => JSRef!.CallVoidAsync("clearHalt", direction, endpointNumber);

        /// <summary>
        /// Controls a transfer to the USB device.
        /// </summary>
        /// <param name="setup">The setup packet for the control transfer.</param>
        /// <param name="length">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBInTransferResult> ControlTransferIn(USBControlTransferParameters setup, int length) => JSRef!.CallAsync<USBInTransferResult>("controlTransferIn", setup, length);

        /// <summary>
        /// Controls a transfer to the USB device.
        /// </summary>
        /// <param name="setup">The setup packet for the control transfer.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> ControlTransferOut(USBControlTransferParameters setup, TypedArray data) => JSRef!.CallAsync<USBOutTransferResult>("controlTransferOut", setup, data);

        /// <summary>
        /// Controls a transfer to the USB device.
        /// </summary>
        /// <param name="setup">The setup packet for the control transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> ControlTransferOut(USBControlTransferParameters setup) => JSRef!.CallAsync<USBOutTransferResult>("controlTransferOut", setup);

        /// <summary>
        /// Controls a transfer to the USB device.
        /// </summary>
        /// <param name="setup">The setup packet for the control transfer.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> ControlTransferOut(USBControlTransferParameters setup, byte[] data) => JSRef!.CallAsync<USBOutTransferResult>("controlTransferOut", setup, data);

        /// <summary>
        /// Closes the connection to the USB device.
        /// </summary>
        public Task Close() => JSRef!.CallVoidAsync("close");

        /// <summary>
        /// Returns a Promise that resolves after all open interfaces are released, the device session has ended, and the permission is reset.
        /// </summary>
        public Task Forget() => JSRef!.CallVoidAsync("forget");

        /// <summary>
        /// The isochronousTransferIn() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousInTransferResult when time sensitive information has been transmitted to (received by) the USB device.
        /// </summary>
        /// <param name="endpointNumber">The number of a device-specific endpoint (buffer).</param>
        /// <param name="packetLengths">An array of lengths for the packets being received.</param>
        /// <returns>A Promise that resolves with a USBIsochronousInTransferResult.</returns>
        public Task<USBIsochronousInTransferResult> IsochronousTransferIn(int endpointNumber, IEnumerable<IEnumerable<int>> packetLengths)
            => JSRef!.CallAsync<USBIsochronousInTransferResult>("isochronousTransferIn", endpointNumber, packetLengths);

        /// <summary>
        /// The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device.
        /// </summary>
        /// <param name="endpointNumber">The number of a device-specific endpoint (buffer).</param>
        /// <param name="data">A TypedArray containing the data to send to the device.</param>
        /// <param name="packetLengths">An array of lengths for the packets being transferred.</param>
        /// <returns>A Promise that resolves with a USBIsochronousOutTransferResult.</returns>
        public Task<USBIsochronousOutTransferResult> IsochronousTransferOut(int endpointNumber, TypedArray data, IEnumerable<IEnumerable<int>> packetLengths)
            => JSRef!.CallAsync<USBIsochronousOutTransferResult>("isochronousTransferOut", endpointNumber, data, packetLengths);

        /// <summary>
        /// The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device.
        /// </summary>
        /// <param name="endpointNumber">The number of a device-specific endpoint (buffer).</param>
        /// <param name="data">A TypedArray containing the data to send to the device.</param>
        /// <param name="packetLengths">An array of lengths for the packets being transferred.</param>
        /// <returns>A Promise that resolves with a USBIsochronousOutTransferResult.</returns>
        public Task<USBIsochronousOutTransferResult> IsochronousTransferOut(int endpointNumber, byte[] data, IEnumerable<IEnumerable<int>> packetLengths)
            => JSRef!.CallAsync<USBIsochronousOutTransferResult>("isochronousTransferOut", endpointNumber, data, packetLengths);

        /// <summary>
        /// Opens a connection to the USB device.
        /// </summary>
        public Task Open() => JSRef!.CallVoidAsync("open");

        /// <summary>
        /// Releases an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to release.</param>
        public Task ReleaseInterface(int interfaceNumber) => JSRef!.CallVoidAsync("releaseInterface", interfaceNumber);

        /// <summary>
        /// Returns a Promise that resolves when the device is reset and all app operations canceled and their promises rejected.
        /// </summary>
        /// <returns></returns>
        public Task Reset() => JSRef!.CallVoidAsync("reset");

        /// <summary>
        /// Selects an alternate setting for an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to select the alternate setting for.</param>
        /// <param name="alternateSetting">The alternate setting to select.</param>
        public Task SelectAlternateInterface(int interfaceNumber, int alternateSetting) => JSRef!.CallVoidAsync("selectAlternateInterface", interfaceNumber, alternateSetting);

        /// <summary>
        /// Selects a configuration for the USB device.
        /// </summary>
        /// <param name="configurationValue">The configuration value to select.</param>
        public Task SelectConfiguration(int configurationValue) => JSRef!.CallVoidAsync("selectConfiguration", configurationValue);

        /// <summary>
        /// Performs a transfer from the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer from.</param>
        /// <param name="length">The length of the data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBInTransferResult> TransferIn(int endpointNumber, int length) => JSRef!.CallAsync<USBInTransferResult>("transferIn", endpointNumber, length);

        /// <summary>
        /// Performs a transfer to the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer to.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> TransferOut(int endpointNumber, TypedArray data) => JSRef!.CallAsync<USBOutTransferResult>("transferOut", endpointNumber, data);

        /// <summary>
        /// Performs a transfer to the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer to.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> TransferOut(int endpointNumber, byte[] data) => JSRef!.CallAsync<USBOutTransferResult>("transferOut", endpointNumber, data);
        #endregion
    }
}

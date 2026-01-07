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
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public USBDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public bool Opened=> JSRef!.Get<bool>("opened");
        /// <summary>
        /// Returns the USB device's vendor ID.
        /// </summary>
        public int VendorId => JSRef!.Get<int>("vendorId");

        /// <summary>
        /// Returns the USB device's product ID.
        /// </summary>
        public int ProductId => JSRef!.Get<int>("productId");

        /// <summary>
        /// Returns the USB device's manufacturer name.
        /// </summary>
        public string ManufacturerName => JSRef!.Get<string>("manufacturerName");

        /// <summary>
        /// Returns the USB device's product name.
        /// </summary>
        public string ProductName => JSRef!.Get<string>("productName");

        /// <summary>
        /// Returns the USB device's serial number.
        /// </summary>
        public string SerialNumber => JSRef!.Get<string>("serialNumber");

        /// <summary>
        /// Returns the USB device's configuration.
        /// </summary>
        public USBConfiguration? Configuration => JSRef!.Get<USBConfiguration?>("configuration");

        /// <summary>
        /// Returns the USB device's configurations.
        /// </summary>
        public Array<USBConfiguration> Configurations => JSRef!.Get<Array<USBConfiguration>>("configurations");
        #endregion

        #region Methods
        /// <summary>
        /// Opens a connection to the USB device.
        /// </summary>
        public Task Open() => JSRef!.CallVoidAsync("open");

        /// <summary>
        /// Closes the connection to the USB device.
        /// </summary>
        public Task Close() => JSRef!.CallVoidAsync("close");

        /// <summary>
        /// Selects a configuration for the USB device.
        /// </summary>
        /// <param name="configurationValue">The configuration value to select.</param>
        public Task SelectConfiguration(int configurationValue) => JSRef!.CallVoidAsync("selectConfiguration", configurationValue);

        /// <summary>
        /// Claims an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to claim.</param>
        public Task ClaimInterface(int interfaceNumber) => JSRef!.CallVoidAsync("claimInterface", interfaceNumber);

        /// <summary>
        /// Releases an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to release.</param>
        public Task ReleaseInterface(int interfaceNumber) => JSRef!.CallVoidAsync("releaseInterface", interfaceNumber);

        /// <summary>
        /// Selects an alternate setting for an interface on the USB device.
        /// </summary>
        /// <param name="interfaceNumber">The interface number to select the alternate setting for.</param>
        /// <param name="alternateSetting">The alternate setting to select.</param>
        public Task SelectAlternateInterface(int interfaceNumber, int alternateSetting) => JSRef!.CallVoidAsync("selectAlternateInterface", interfaceNumber, alternateSetting);

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
        public Task<USBOutTransferResult> ControlTransferOut(USBControlTransferParameters setup, byte[] data) => JSRef!.CallAsync<USBOutTransferResult>("controlTransferOut", setup, data);

        /// <summary>
        /// Performs a transfer to the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer to.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> TransferOut(int endpointNumber, byte[] data) => JSRef!.CallAsync<USBOutTransferResult>("transferOut", endpointNumber, data);

        /// <summary>
        /// Controls a transfer to the USB device.
        /// </summary>
        /// <param name="setup">The setup packet for the control transfer.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> ControlTransferOut(USBControlTransferParameters setup, TypedArray data) => JSRef!.CallAsync<USBOutTransferResult>("controlTransferOut", setup, data);

        /// <summary>
        /// Performs a transfer to the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer to.</param>
        /// <param name="data">The data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBOutTransferResult> TransferOut(int endpointNumber, TypedArray data) => JSRef!.CallAsync<USBOutTransferResult>("transferOut", endpointNumber, data);

        /// <summary>
        /// Performs a transfer from the USB device.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to transfer from.</param>
        /// <param name="length">The length of the data to transfer.</param>
        /// <returns>A promise that resolves with the result of the transfer.</returns>
        public Task<USBInTransferResult> TransferIn(int endpointNumber, int length) => JSRef!.CallAsync<USBInTransferResult>("transferIn", endpointNumber, length);

        /// <summary>
        /// Clears a halt condition on an endpoint.
        /// </summary>
        /// <param name="endpointNumber">The endpoint number to clear the halt condition on.</param>
        public Task ClearHalt(int endpointNumber) => JSRef!.CallVoidAsync("clearHalt", endpointNumber);

        /// <summary>
        /// Resets the USB device.
        /// </summary>
        public Task Reset() => JSRef!.CallVoidAsync("reset");
        #endregion
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HIDDevice interface of the WebHID API represents a HID Device. It provides properties for accessing information about the device, methods for opening and closing the connection, and the sending and receiving of reports.
    /// https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice
    /// </summary>
    public class HIDDevice : EventTarget
    {
        #region Constructors

        public HIDDevice(IJSInProcessObjectReference _ref) : base(_ref)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns a boolean, true if the device has an open connection.
        /// </summary>
        public bool Opened => JSRef!.Get<bool>("opened");

        /// <summary>
        /// Returns the vendorId of the HID device.
        /// </summary>
        public int VendorId => JSRef!.Get<int>("vendorId");

        /// <summary>
        /// Returns the productId of the HID device.
        /// </summary>
        public int ProductId => JSRef!.Get<int>("productId");

        /// <summary>
        /// Returns a string containing the product name of the HID device.
        /// </summary>
        public string ProductName => JSRef!.Get<string>("productName");

        /// <summary>
        /// Returns an array of report formats for the HID device.
        /// </summary>
        public Array<HIDCollectionInfo> Collections => JSRef!.Get<Array<HIDCollectionInfo>>("collections");

        #endregion

        #region Methods

        /// <summary>
        /// Opens a connection to this HID device, and returns a Promise which resolves once the connection has been successful.
        /// </summary>
        public Task Open() => JSRef!.CallVoidAsync("open");

        /// <summary>
        /// Closes the connection to this HID device, and returns a Promise which resolves once the connection has been closed.
        /// </summary>

        public Task Close() => JSRef!.CallVoidAsync("close");

        /// <summary>
        /// Closes the connection to this HID device and resets access permission, and returns a Promise which resolves once the permission was reset.
        /// </summary>

        public Task Forget() => JSRef!.CallVoidAsync("forget");

        /// <summary>
        /// Sends an output report to this HID Device, and returns a Promise which resolves once the report has been sent.
        /// </summary>
        /// <param name="reportId">An 8-bit report ID. If the HID device does not use report IDs, send 0.</param>
        /// <param name="data">Bytes as an ArrayBuffer, a TypedArray, or a DataView.</param>
        public Task SendReport(byte reportId, byte[] data) => JSRef!.CallVoidAsync("sendReport", reportId, data);

        /// <summary>
        /// Sends a feature report to this HID device, and returns a Promise which resolves once the report has been sent.
        /// </summary>
        /// <param name="reportId">An 8-bit report ID. If the HID device does not use report IDs, send 0.</param>
        /// <param name="data">Bytes as an ArrayBuffer, a TypedArray, or a DataView.</param>
        public Task SendFeatureReport(byte reportId, byte[] data) => JSRef!.CallVoidAsync("sendFeatureReport", reportId, data);

        /// <summary>
        /// Receives a feature report from this HID device in the form of a Promise which resolves with a DataView. This allows typed access to the contents of this message.
        /// </summary>
        /// <param name="reportId">An 8-bit report ID. If the HID device does not use report IDs, send 0.</param>
        public Task<DataView> ReceiveFeatureReport(byte reportId) => JSRef!.CallAsync<DataView>("receiveFeatureReport", reportId);

        #endregion

        #region Events

        /// <summary>
        /// Fires when a report is sent from the device.
        /// </summary>
        public ActionEvent<HIDInputReportEvent> OnInputReport { get => new ActionEvent<HIDInputReportEvent>("inputreport", AddEventListener, RemoveEventListener); set { } }

        #endregion
    }
}
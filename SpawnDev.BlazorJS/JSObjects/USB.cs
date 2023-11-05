using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class USB : EventTarget
    {
        #region Constructors
        public USB(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region 
        /// <summary>
        /// Returns a Promise that resolves with an array of USBDevice objects for paired attached devices.
        /// </summary>
        /// <returns></returns>
        public Task<Array<USBDevice>> GetDevices() => JSRef.CallAsync<Array<USBDevice>>("getDevices");
        /// <summary>
        /// Returns a Promise that resolves with an instance of USBDevice if the specified device is found. Calling this function triggers the user agent's pairing flow.
        /// </summary>
        /// <returns></returns>
        public Task<USBDevice> RequestDevice(IEnumerable<USBRequestDeviceFilter> filters) => JSRef.CallAsync<USBDevice>("requestDevice", filters);
        #endregion

        #region Events
        /// <summary>
        /// The connect event of the USB interface is fired whenever a paired device is connected.
        /// </summary>
        public JSEventCallback<USBConnectionEvent> OnConnect { get => new JSEventCallback<USBConnectionEvent>(o => AddEventListener("connect", o), o => RemoveEventListener("connect", o)); set { /** required **/ } }
        /// <summary>
        /// The disconnect event of the USB interface is fired whenever a paired device is disconnected.
        /// </summary>
        public JSEventCallback<USBConnectionEvent> OnDisconnect { get => new JSEventCallback<USBConnectionEvent>(o => AddEventListener("disconnect", o), o => RemoveEventListener("disconnect", o)); set { /** required **/ } }
        #endregion
    }
}

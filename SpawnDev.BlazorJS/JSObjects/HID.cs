using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HID interface provides methods for connecting to HID devices, listing attached HID devices and event handlers for connected HID devices.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HID
    /// </summary>
    public class HID : EventTarget
    {
        #region Constructors
        public HID(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Promise that resolves with an array of connected HIDDevice objects.
        /// </summary>
        /// <returns></returns>
        public Task<Array<HIDDevice>> GetDevices() => JSRef.CallAsync<Array<HIDDevice>>("getDevices");
        /// <summary>
        /// Returns a Promise that resolves with an array of connected HIDDevice objects. Calling this function will trigger the user agent's permission flow in order to gain permission to access one selected device from the returned list of devices.
        /// </summary>
        public Task<Array<HIDDevice>> RequestDevice(HIDRequestDeviceOptions[] options) => JSRef.CallAsync<Array<HIDDevice>>("requestDevice", options);
        #endregion

        #region Events
        /// <summary>
        /// Fired when an HID device is connected.
        /// </summary>
        public JSEventCallback<HIDConnectionEvent> OnConnect { get => new JSEventCallback<HIDConnectionEvent>(o => AddEventListener("connect", o), o => RemoveEventListener("connect", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when an HID device is disconnected.
        /// </summary>
        public JSEventCallback<HIDConnectionEvent> OnDisconnect { get => new JSEventCallback<HIDConnectionEvent>(o => AddEventListener("disconnect", o), o => RemoveEventListener("disconnect", o)); set { /** required **/ } }
        #endregion
    }
}

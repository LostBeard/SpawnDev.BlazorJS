﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HID interface provides methods for connecting to HID devices, listing attached HID devices and event handlers for connected HID devices.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HID
    /// </summary>
    public class HID : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HID(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Promise that resolves with an array of connected HIDDevice objects.
        /// </summary>
        /// <returns></returns>
        public Task<Array<HIDDevice>> GetDevices() => JSRef!.CallAsync<Array<HIDDevice>>("getDevices");
        /// <summary>
        /// Returns a Promise that resolves with an array of connected HIDDevice objects. Calling this function will trigger the user agent's permission flow in order to gain permission to access one selected device from the returned list of devices.
        /// </summary>
        public Task<Array<HIDDevice>> RequestDevice(HIDRequestDeviceOptions[] options) => JSRef!.CallAsync<Array<HIDDevice>>("requestDevice", options);
        #endregion

        #region Events
        /// <summary>
        /// Fired when an HID device is connected.
        /// </summary>
        public ActionEvent<HIDConnectionEvent> OnConnect { get => new ActionEvent<HIDConnectionEvent>("connect", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an HID device is disconnected.
        /// </summary>
        public ActionEvent<HIDConnectionEvent> OnDisconnect { get => new ActionEvent<HIDConnectionEvent>("disconnect", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}

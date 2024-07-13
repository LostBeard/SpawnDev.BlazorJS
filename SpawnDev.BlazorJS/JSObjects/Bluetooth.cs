using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Bluetooth interface of the Web Bluetooth API provides methods to query Bluetooth availability and request access to devices.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth
    /// </summary>
    public class Bluetooth : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Bluetooth(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// The getAvailability() method of the Bluetooth interface returns true if the device has a Bluetooth adapter, and false otherwise (unless the user has configured the browser to not expose a real value).
        /// </summary>
        /// <returns></returns>
        public Task<bool> GetAvailability() => JSRef!.CallApplyAsync<bool>("getAvailability");
        /// <summary>
        /// Returns a Promise to a BluetoothDevice object with the specified options.
        /// </summary>
        /// <returns></returns>
        public Task<BluetoothDevice> RequestDevice() => JSRef!.CallAsync<BluetoothDevice>("requestDevice");
        /// <summary>
        /// Returns a Promise that resolves to an array of BluetoothDevices this origin is allowed to access. Permission is obtained via previous calls to Bluetooth.requestDevice().
        /// </summary>
        /// <returns></returns>
        public Task<Array<BluetoothDevice>> GetDevices() => JSRef!.CallAsync<Array<BluetoothDevice>>("getDevices");
        #endregion
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Bluetooth : EventTarget
    {
        #region Constructors
        public Bluetooth(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// The getAvailability() method of the Bluetooth interface returns true if the device has a Bluetooth adapter, and false otherwise (unless the user has configured the browser to not expose a real value).
        /// </summary>
        /// <returns></returns>
        public Task<bool> GetAvailability() => JSRef.CallApplyAsync<bool>("getAvailability");
        public Task<BluetoothDevice> RequestDevice() => JSRef.CallAsync<BluetoothDevice>("requestDevice");
        #endregion

        #region Events
        #endregion
    }
}

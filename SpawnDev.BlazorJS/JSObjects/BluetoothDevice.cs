using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothDevice interface of the Web Bluetooth API represents a Bluetooth device inside a particular script execution environment.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothDevice
    /// </summary>
    public class BluetoothDevice : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BluetoothDevice(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}

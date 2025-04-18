using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothRemoteGATTServer interface of the Web Bluetooth API represents a GATT Server on a remote device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTServer
    /// </summary>
    public class BluetoothRemoteGATTServer : JSObject
    {
        /// <inheritdoc/>
        public BluetoothRemoteGATTServer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean value that returns true while this script execution environment is connected to this.device. It can be false while the user agent is physically connected.
        /// </summary>
        public bool Connected => JSRef!.Get<bool>("connected");
        /// <summary>
        /// A reference to the BluetoothDevice running the server.
        /// </summary>
        public BluetoothDevice Device => JSRef!.Get<BluetoothDevice>("device");
        /// <summary>
        /// Causes the script execution environment to connect to this.device.
        /// </summary>
        /// <returns></returns>
        public Task<BluetoothRemoteGATTServer> Connect() => JSRef!.CallAsync<BluetoothRemoteGATTServer>("connect");
        /// <summary>
        /// Causes the script execution environment to disconnect from this.device.
        /// </summary>
        public void Disconnect() => JSRef!.CallVoid("disconnect");
        /// <summary>
        /// The BluetoothRemoteGATTServer.getPrimaryService() method returns a promise to the primary BluetoothRemoteGATTService offered by the Bluetooth device for a specified bluetooth service UUID.
        /// </summary>
        /// <param name="bluetoothServiceUUID">A Bluetooth service universally unique identifier for a specified device, that is either a 128-bit UUID, a 16-bit or 32-bit UUID alias, or a string from the list of GATT assigned services keys.</param>
        /// <returns>A Promise that resolves to a BluetoothRemoteGATTService object.</returns>
        public Task<BluetoothRemoteGATTService> GetPrimaryService(string bluetoothServiceUUID) => JSRef!.CallAsync<BluetoothRemoteGATTService>("getPrimaryService", bluetoothServiceUUID);
        /// <summary>
        /// The BluetoothRemoteGATTServer.getPrimaryServices() method returns a promise to a list of primary BluetoothRemoteGATTService objects offered by the Bluetooth device for a specified BluetoothServiceUUID.
        /// </summary>
        /// <param name="bluetoothServiceUUID">A Bluetooth service universally unique identifier for a specified device.</param>
        /// <returns>A Promise that resolves to a list of BluetoothRemoteGATTService objects.</returns>
        public Task<BluetoothRemoteGATTService[]> GetPrimaryServices(string bluetoothServiceUUID) => JSRef!.CallAsync<BluetoothRemoteGATTService[]>("getPrimaryServices", bluetoothServiceUUID);
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothRemoteGATTService interface of the Web Bluetooth API represents a service provided by a GATT server, including a device, a list of referenced services, and a list of the characteristics of this service.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTService
    /// </summary>
    public class BluetoothRemoteGATTService : EventTarget
    {
        /// <inheritdoc/>
        public BluetoothRemoteGATTService(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns information about a Bluetooth device through an instance of BluetoothDevice.
        /// </summary>
        public BluetoothDevice Device => JSRef!.Get<BluetoothDevice>("device");
        /// <summary>
        /// Returns a boolean value indicating whether this is a primary or secondary service.
        /// </summary>
        public bool IsPrimary => JSRef!.Get<bool>("isPrimary");
        /// <summary>
        /// Returns a string representing the UUID of this service.
        /// </summary>
        public string UUID => JSRef!.Get<string>("uuid");
        /// <summary>
        /// Returns a Promise to an instance of BluetoothRemoteGATTCharacteristic for a given universally unique identifier (UUID).
        /// </summary>
        /// <param name="characteristicUUID"></param>
        /// <returns></returns>
        public Task<BluetoothRemoteGATTCharacteristic> GetCharacteristic(string characteristicUUID) => JSRef!.CallAsync<BluetoothRemoteGATTCharacteristic>("getCharacteristic", characteristicUUID);
        /// <summary>
        /// Returns a Promise to an Array of BluetoothRemoteGATTCharacteristic instances for an optional universally unique identifier (UUID).
        /// </summary>
        /// <param name="characteristicUUID"></param>
        /// <returns></returns>
        public Task<BluetoothRemoteGATTCharacteristic[]> GetCharacteristics(string characteristicUUID) => JSRef!.CallAsync<BluetoothRemoteGATTCharacteristic[]>("getCharacteristics", characteristicUUID);
        /// <summary>
        /// Fired on a new BluetoothRemoteGATTService when it has been discovered on a remote device, just after it is added to the Bluetooth tree.
        /// </summary>
        public ActionEvent<Event> OnServiceAdded { get => new ActionEvent<Event>("serviceadded", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on a BluetoothRemoteGATTService when its state changes. This involves any characteristics and/or descriptors that get added or removed from the service, as well as Service Changed indications from the remote device.
        /// </summary>
        public ActionEvent<Event> OnServiceChanged { get => new ActionEvent<Event>("servicechanged", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired on a BluetoothRemoteGATTService when it has been removed from its device, just before it is removed from the Bluetooth tree.
        /// </summary>
        public ActionEvent<Event> OnServiceRemoved { get => new ActionEvent<Event>("serviceremoved", AddEventListener, RemoveEventListener); set { } }
    }
}

using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothCharacteristicProperties interface of the Web Bluetooth API provides the operations that are valid on the given BluetoothRemoteGATTCharacteristic.<br/>
    /// This interface is returned by calling BluetoothRemoteGATTCharacteristic.properties.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothCharacteristicProperties
    /// </summary>
    public class BluetoothCharacteristicProperties : JSObject
    {
        /// <inheritdoc/>
        public BluetoothCharacteristicProperties(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a boolean that is true if signed writing to the characteristic value is permitted.
        /// </summary>
        public bool AuthenticatedSignedWrites => JSRef!.Get<bool>("authenticatedSignedWrites");
        /// <summary>
        /// Returns a boolean that is true if the broadcast of the characteristic value is permitted using the Server Characteristic Configuration Descriptor.
        /// </summary>
        public bool Broadcast => JSRef!.Get<bool>("broadcast");
        /// <summary>
        /// Returns a boolean that is true if indications of the characteristic value with acknowledgement is permitted.
        /// </summary>
        public bool Indicate => JSRef!.Get<bool>("indicate");
        /// <summary>
        /// Returns a boolean that is true if notifications of the characteristic value without acknowledgement is permitted.
        /// </summary>
        public bool Notify => JSRef!.Get<bool>("notify");
        /// <summary>
        /// Returns a boolean that is true if the reading of the characteristic value is permitted.
        /// </summary>
        public bool Read => JSRef!.Get<bool>("read");
        /// <summary>
        /// Returns a boolean that is true if reliable writes to the characteristic is permitted.
        /// </summary>
        public bool ReliableWrite => JSRef!.Get<bool>("reliableWrite");
        /// <summary>
        /// Returns a boolean that is true if reliable writes to the characteristic descriptor is permitted.
        /// </summary>
        public bool WritableAuxilaries => JSRef!.Get<bool>("writableAuxiliaries");
        /// <summary>
        /// Returns a boolean that is true if the writing to the characteristic with response is permitted.
        /// </summary>
        public bool Write => JSRef!.Get<bool>("write");
        /// <summary>
        /// Returns a boolean that is true if the writing to the characteristic without response is permitted.
        /// </summary>
        public bool WriteWithoutResponse => JSRef!.Get<bool>("writeWithoutResponse");
    }
}

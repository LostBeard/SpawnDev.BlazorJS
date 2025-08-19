using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothRemoteGattCharacteristic interface of the Web Bluetooth API represents a GATT Characteristic, which is a basic data element that provides further information about a peripheral's service.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTCharacteristic
    /// </summary>
    public class BluetoothRemoteGATTCharacteristic : EventTarget
    {
        /// <inheritdoc/>
        public BluetoothRemoteGATTCharacteristic(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a reference to the BluetoothRemoteGATTService object that contains this characteristic.
        /// </summary>
        public BluetoothRemoteGATTService Service => JSRef!.Get<BluetoothRemoteGATTService>("service");
        /// <summary>
        /// Returns a string representing the UUID of this characteristic.
        /// </summary>
        public string UUID => JSRef!.Get<string>("uuid");
        /// <summary>
        /// Returns the properties of this characteristic.
        /// </summary>
        public BluetoothCharacteristicProperties Properties => JSRef!.Get<BluetoothCharacteristicProperties>("properties");
        /// <summary>
        /// The currently cached characteristic value. This value gets updated when the value of the characteristic is read or updated via a notification or indication.
        /// </summary>
        public DataView? Value => JSRef!.Get<DataView?>("value");
        /// <summary>
        /// Returns a Promise that resolves to the first BluetoothRemoteGATTDescriptor for a given descriptor UUID.
        /// </summary>
        /// <param name="bluetoothDescriptorUUID"></param>
        /// <returns></returns>
        public Task<BluetoothRemoteGATTDescriptor> GetDescriptor(string bluetoothDescriptorUUID) => JSRef!.CallAsync<BluetoothRemoteGATTDescriptor>("getDescriptor", bluetoothDescriptorUUID);
        /// <summary>
        /// Returns a Promise that resolves to an Array of all BluetoothRemoteGATTDescriptor objects for a given descriptor UUID.
        /// </summary>
        /// <returns></returns>
        public Task<BluetoothRemoteGATTDescriptor[]> GetDescriptors() => JSRef!.CallAsync<BluetoothRemoteGATTDescriptor[]>("getDescriptors");
        /// <summary>
        /// The BluetoothRemoteGATTCharacteristic.readValue() method returns a Promise that resolves to a DataView holding a duplicate of the value property if it is available and supported. Otherwise it throws an error.
        /// </summary>
        /// <returns></returns>
        public Task<DataView> ReadValue() => JSRef!.CallAsync<DataView>("readValue");
        /// <summary>
        /// Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WriteValueWithResponse(ArrayBuffer value) => JSRef!.CallVoidAsync("writeValueWithResponse", value);
        /// <summary>
        /// Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WriteValueWithResponse(byte[] value) => JSRef!.CallVoidAsync("writeValueWithResponse", (ArrayBuffer)value);
        /// <summary>
        /// Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WriteValueWithoutResponse(ArrayBuffer value) => JSRef!.CallVoidAsync("writeValueWithoutResponse", value);
        /// <summary>
        /// Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WriteValueWithoutResponse(byte[] value) => JSRef!.CallVoidAsync("writeValueWithoutResponse", (ArrayBuffer)value);
        /// <summary>
        /// Returns a Promise that resolves when navigator.bluetooth is added to the active notification context.
        /// </summary>
        /// <returns></returns>
        public Task StartNotifications() => JSRef!.CallVoidAsync("startNotifications");
        /// <summary>
        /// Returns a Promise that resolves when navigator.bluetooth is removed from the active notification context.
        /// </summary>
        /// <returns></returns>
        public Task StopNotifications() => JSRef!.CallVoidAsync("stopNotifications");
        /// <summary>
        /// Fired on a BluetoothRemoteGATTCharacteristic when its value changes.
        /// </summary>
        public ActionEvent<Event> OnCharacteristicValueChanged { get => new ActionEvent<Event>("characteristicvaluechanged", AddEventListener, RemoveEventListener); set { } }
    }
}

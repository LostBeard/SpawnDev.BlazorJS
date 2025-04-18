using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothRemoteGATTDescriptor interface of the Web Bluetooth API provides a GATT Descriptor, which provides further information about a characteristic's value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTDescriptor
    /// </summary>
    public class BluetoothRemoteGATTDescriptor : JSObject
    {
        /// <inheritdoc/>
        public BluetoothRemoteGATTDescriptor(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the BluetoothRemoteGATTCharacteristic this descriptor belongs to.
        /// </summary>
        public BluetoothRemoteGATTCharacteristic Characteristic => JSRef!.Get<BluetoothRemoteGATTCharacteristic>("characteristic");
        /// <summary>
        /// Returns the UUID of the characteristic descriptor, for example "00002902-0000-1000-8000-00805f9b34fb" for the Client Characteristic Configuration descriptor.
        /// </summary>
        public string UUID => JSRef!.Get<string>("uuid");
        /// <summary>
        /// Returns the currently cached descriptor value. This value gets updated when the value of the descriptor is read.
        /// </summary>
        public ArrayBuffer Value => JSRef!.Get<ArrayBuffer>("value");
        /// <summary>
        /// Returns a Promise that resolves to an ArrayBuffer holding a duplicate of the value property if it is available and supported. Otherwise it throws an error.
        /// </summary>
        /// <returns></returns>
        public Task<ArrayBuffer> ReadValue() => JSRef!.CallAsync<ArrayBuffer>("readValue");
        /// <summary>
        /// The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task WriteValue(ArrayBuffer value) => JSRef!.CallVoidAsync("writeValue", value);
        /// <summary>
        /// The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task WriteValue(byte[] value)
        {
            using var arrayBuffer = (ArrayBuffer)value!;
            await WriteValue(arrayBuffer);
        }
    }
}

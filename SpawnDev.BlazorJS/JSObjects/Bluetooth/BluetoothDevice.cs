using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BluetoothDevice interface of the Web Bluetooth API represents a Bluetooth device inside a particular script execution environment.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BluetoothDevice
    /// </summary>
    public class BluetoothDevice : EventTarget
    {
        /// <inheritdoc/>
        public BluetoothDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string that uniquely identifies a device.
        /// </summary>
        public string Id => JSRef!.Get<string>("id");
        /// <summary>
        /// A string that provides a human-readable name for the device.
        /// </summary>
        public string? Name => JSRef!.Get<string?>("name");
        /// <summary>
        /// A reference to the device's BluetoothRemoteGATTServer.
        /// </summary>
        public BluetoothRemoteGATTServer? GATT => JSRef!.Get<BluetoothRemoteGATTServer?>("gatt");
        /// <summary>
        /// Provides a way for the page to revoke access to a device the user has granted access to.
        /// </summary>
        /// <returns></returns>
        public Task Forget() => JSRef!.CallVoidAsync("forget");
        /// <summary>
        /// A Promise that resolves to undefined or is rejected with an error if advertisements can't be shown for any reason.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <summary>
        /// A Promise that resolves to undefined or is rejected with an error if advertisements can't be shown for any reason.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task WatchAdvertisements(WatchAdvertisementsOptions? options = null) => options == null ? JSRef!.CallVoidAsync("watchAdvertisements") : JSRef!.CallVoidAsync("watchAdvertisements", options);
        /// <summary>
        /// 
        /// </summary>
        public ActionEvent<Event> OnGATTServerDisconnected { get => new ActionEvent<Event>("gattserverdisconnected", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// 
        /// https://googlechrome.github.io/samples/web-bluetooth/watch-advertisements.html
        /// </summary>
        public ActionEvent<BluetoothAdvertisingEvent> OnAdvertisementReceived { get => new ActionEvent<BluetoothAdvertisingEvent>("advertisementreceived", AddEventListener, RemoveEventListener); set { } }
    }
}

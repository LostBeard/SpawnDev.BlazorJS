using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SerialPort interface of the Web Serial API provides access to a serial port on the host device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SerialPort<br/>
    /// TODO - finish interface
    /// </summary>
    public class SerialPort : EventTarget
    {
        #region Constructors
        ///<inheritdoc/>
        public SerialPort(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns a boolean value that indicates whether the port is logically connected to the device.
        /// </summary>
        public bool Connected => JSRef!.Get<bool>("connected");
        /// <summary>
        /// Returns a ReadableStream for receiving data from the device connected to the port.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");
        /// <summary>
        /// Returns a WritableStream for sending data to the device connected to the port.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
        #endregion

        #region Methods
        /// <summary>
        /// The SerialPort.forget() method of the SerialPort interface returns a Promise that resolves when access to the serial port is revoked.<br/>
        /// A website can clean up permissions to access a serial port it is no longer interested in retaining by calling SerialPort.forget(). Calling this "forgets" the device, resetting any previously-set permissions so the calling site can no longer communicate with the port.<br/>
        /// For example, for an educational web application used on a shared computer with many devices, a large number of accumulated user-generated permissions creates a poor user experience.
        /// </summary>
        /// <returns></returns>
        public Task Forget() => JSRef!.CallVoidAsync("forget");
        /// <summary>
        /// The getInfo() method of the SerialPort interface returns an object containing identifying information for the device available via the port.
        /// </summary>
        /// <returns></returns>
        public SerialPortInfo GetInfo() => JSRef!.Call<SerialPortInfo>("getInfo");
        /// <summary>
        /// The open() method of the SerialPort interface returns a Promise that resolves when the port is opened. By default the port is opened with 8 data bits, 1 stop bit and no parity checking. The baudRate parameter is required.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task Open(SerialOptions options) => JSRef!.CallVoidAsync("open");
        /// <summary>
        /// The setSignals() method of the SerialPort interface sets control signals on the port and returns a Promise that resolves when they are set.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task SetSignals(SerialOutputSignals options) => JSRef!.CallVoidAsync("setSignals", options);
        /// <summary>
        /// The setSignals() method of the SerialPort interface sets control signals on the port and returns a Promise that resolves when they are set.
        /// </summary>
        /// <returns></returns>
        public Task SetSignals() => JSRef!.CallVoidAsync("setSignals");
        /// <summary>
        /// The SerialPort.getSignals() method of the SerialPort interface returns a Promise that resolves with an object containing the current state of the port's control signals.
        /// </summary>
        /// <returns></returns>
        public Task<SerialInputSignals> GetSignals() => JSRef!.CallAsync<SerialInputSignals>("getSignals");
        /// <summary>
        /// The SerialPort.close() method of the SerialPort interface returns a Promise that resolves when the port closes.<br/>
        /// close() closes the serial port if previously-locked SerialPort.readable and SerialPort.writable members are unlocked, meaning the releaseLock() methods have been called for their respective reader and writer.<br/>
        /// However, when continuously reading data from a serial device using a loop, the associated readable stream will always be locked until the reader encounters an error. In this case, calling reader.cancel() will force reader.read() to resolve immediately with { value: undefined, done: true } allowing the loop to call reader.releaseLock().
        /// </summary>
        /// <returns></returns>
        public Task Close() => JSRef!.CallVoidAsync("close");
        #endregion

        #region Events
        /// <summary>
        /// Fired when the port connects to the device.
        /// </summary>
        public ActionEvent<Event> OnConnect { get => new ActionEvent<Event>("connect", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the port disconnects from the device.
        /// </summary>
        public ActionEvent<Event> OnDisconnect { get => new ActionEvent<Event>("disconnect", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}

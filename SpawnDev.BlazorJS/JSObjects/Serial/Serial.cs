using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Serial interface of the Web Serial API provides attributes and methods for finding and connecting to serial ports from a web page.
    /// </summary>
    public class Serial : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Serial(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Promise that resolves with an array of SerialPort objects representing serial ports connected to the host which the origin has permission to access.
        /// </summary>
        /// <returns></returns>
        public Task<Array<SerialPort>> GetPorts() => JSRef!.CallAsync<Array<SerialPort>>("getPorts");
        /// <summary>
        /// The Serial.requestPort() method of the Serial interface returns a Promise that resolves with an instance of SerialPort representing the device chosen by the user or rejects if no device was selected.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<SerialPort> RequestPort(SerialPortRequestOptions options) => JSRef!.CallAsync<SerialPort>("requestPort", options);
        /// <summary>
        /// The Serial.requestPort() method of the Serial interface returns a Promise that resolves with an instance of SerialPort representing the device chosen by the user or rejects if no device was selected.
        /// </summary>
        /// <returns></returns>
        public Task<SerialPort> RequestPort() => JSRef!.CallAsync<SerialPort>("requestPort");
        #endregion

        #region Events
        /// <summary>
        /// An event fired when a port has been connected to the device.
        /// </summary>
        public ActionEvent<Event> OnConnect { get => new ActionEvent<Event>("connect", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event fired when a port has been disconnected from the device.
        /// </summary>
        public ActionEvent<Event> OnDisconnect { get => new ActionEvent<Event>("disconnect", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}

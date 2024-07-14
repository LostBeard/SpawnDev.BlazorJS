using Microsoft.JSInterop;

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
        public SerialPort(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}

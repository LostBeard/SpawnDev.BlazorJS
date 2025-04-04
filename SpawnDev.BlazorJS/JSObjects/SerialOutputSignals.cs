using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Serial port set signals options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/setSignals#options<br/>
    /// https://wicg.github.io/serial/#serialoutputsignals-dictionary
    /// </summary>
    public class SerialOutputSignals
    {
        /// <summary>
        /// A boolean indicating whether to invoke the operating system to either assert (if true) or de-assert (if false) the "data terminal ready" or "DTR" signal on the serial port.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DataTerminalReady { get; set; }
        /// <summary>
        /// A boolean indicating whether to invoke the operating system to either assert (if true) or de-assert (if false) the "request to send" or "RTS" signal on the serial port.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequestToSend { get; set; }
        /// <summary>
        /// A boolean indicating whether to invoke the operating system to either assert (if true) or de-assert (if false) the "break" signal on the serial port.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Break { get; set; }
    }
}

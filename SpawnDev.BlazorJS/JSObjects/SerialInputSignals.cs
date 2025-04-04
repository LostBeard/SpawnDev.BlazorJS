﻿namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/getSignals#return_value<br/>
    /// https://wicg.github.io/serial/#serialinputsignals-dictionary
    /// </summary>
    public class SerialInputSignals
    {
        /// <summary>
        /// A boolean indicating to the other end of a serial connection that is clear to send data.
        /// </summary>
        public bool ClearToSend { get; set; }
        /// <summary>
        /// A boolean that toggles the control signal needed to communicate over a serial connection.
        /// </summary>
        public bool DataCarrierDetect { get; set; }
        /// <summary>
        /// A boolean indicating whether the device is ready to send and receive data.
        /// </summary>
        public bool DataSetReady { get; set; }
        /// <summary>
        /// A boolean indicating whether a ring signal should be sent down the serial connection.
        /// </summary>
        public bool RingIndicator { get; set; }
    }
}

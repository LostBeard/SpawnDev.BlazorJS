using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Serial port open options
    /// https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/open#options<br/>
    /// https://wicg.github.io/serial/#serialoptions-dictionary
    /// </summary>
    public class SerialOptions
    {
        /// <summary>
        /// A positive, non-zero value indicating the baud rate at which serial communication should be established.
        /// </summary>
        [JsonPropertyName("baudRate")]
        public int BaudRate { get; set; }
        /// <summary>
        /// An unsigned long integer indicating the size of the read and write buffers that are to be established. If not passed, defaults to 255.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("bufferSize")]
        public int? BufferSize { get; set; }
        /// <summary>
        /// An integer value of 7 or 8 indicating the number of data bits per frame. If not passed, defaults to 8.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("dataBits")]
        public byte? DataBits { get; set; }
        /// <summary>
        /// The flow control type, either "none" or "hardware". The default value is "none".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("flowControl")]
        public EnumString<FlowControlType>? FlowControl { get; set; }
        /// <summary>
        /// The parity mode, either "none", "even", or "odd". The default value is "none".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("parity")]
        public EnumString<ParityType>? Parity { get; set; }
        /// <summary>
        /// The number of stop bits at the end of a frame. Either 1 or 2.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("stopBits")]
        public int? StopBits { get; set; }
    }
}

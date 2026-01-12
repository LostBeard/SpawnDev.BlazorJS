using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportCloseInfo dictionary includes information about the error code and the reason for closing a WebTransport.
    /// </summary>
    public class WebTransportCloseInfo
    {
        /// <summary>
        /// The error code for closing the WebTransport.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CloseCode { get; set; }

        /// <summary>
        /// The reason for closing the WebTransport.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Reason { get; set; }
    }
}

using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCSessionDescription interface describes one end of a connection—or potential connection—and how it's configured. Each RTCSessionDescription consists of a description type indicating which part of the offer/answer negotiation process it describes and of the SDP descriptor of the session.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription
    /// </summary>
    public class RTCSessionDescription
    {
        /// <summary>
        /// An enum describing the session description's type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
        /// <summary>
        /// A string containing the SDP describing the session.
        /// </summary>
        [JsonPropertyName("sdp")]
        public string Sdp { get; set; } = "";
    }
}

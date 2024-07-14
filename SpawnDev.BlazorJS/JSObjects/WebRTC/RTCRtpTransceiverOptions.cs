using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Used in RTCPeerConnection.AddTransceiver
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/addTransceiver#init
    /// </summary>
    public class RTCRtpTransceiverOptions
    {
        /// <summary>
        /// The directionality indicates whether the transceiver will offer to send and/or receive RTP data, or whether it is inactive or stopped (terminated). When setting the transceiver's direction, the value is not applied immediately. The current direction is indicated by the currentDirection property.<br/>
        /// A string with one of the following values:<br/>
        /// "sendrecv" - Transceiver offers to send and receive RTP data:<br/>
        /// - RTCRtpSender: Offers to send RTP data, and will do so if the remote peer accepts the connection and at least one of the sender's encodings is active.<br/>
        /// - RTCRtpReceiver: Offers to receive RTP data, and does so if the remote peer accepts.<br/>
        /// "sendonly" - Transceiver offers to send but not receive RTP data:<br/>
        /// - RTCRtpSender: Offers to send RTP data, and will do so if the remote peer accepts the connection and at least one of the sender's encodings is active.<br/>
        /// - RTCRtpReceiver: Does not offer to receive RTP data and will not do so.<br/>
        /// "recvonly" - Transceiver offers to receive but not set RTP data:<br/>
        /// - RTCRtpSender: Does not offer to send RTP data, and will not do so.<br/>
        /// - RTCRtpReceiver: Offers to receive RTP data, and will do so if the remote peer offers.<br/>
        /// "inactive" - Transceiver is inactive:<br/>
        /// - RTCRtpSender: Does not offer to send RTP data, and will not do so.<br/>
        /// RTCRtpReceiver: Does not offer to receive RTP data and will not do so.<br/>
        /// "stopped" - This is the terminal state of the transceiver. The transceiver is stopped and will not send or receive RTP data or offer to do so. Setting this value when the transceiver is not already stopped raises a TypeError.<br/>
        /// - RTCRtpSender: Does not offer to send RTP data, and will not do so.<br/>
        /// RTCRtpReceiver: Does not offer to receive RTP data and will not do so.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("direction")]
        public string? Direction { get; set; }
        /// <summary>
        /// An array of encodings to allow when sending RTP media from the RTCRtpSender. This is the same as the parameter.encodings array passed to RTCRtpSender.setParameters().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sendEncodings")]
        public RTCMediaEncoding[]? SendEncodings { get; set; }
        /// <summary>
        /// A list of MediaStream objects to add to the transceiver's RTCRtpReceiver; when the remote peer's RTCPeerConnection's track event occurs, these are the streams that will be specified by that event.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("streams")]
        public MediaStream[]? Streams { get; set; }
    }
}

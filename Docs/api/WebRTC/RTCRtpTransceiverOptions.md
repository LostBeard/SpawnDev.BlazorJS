# RTCRtpTransceiverOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCRtpTransceiverOptions.cs`  
**MDN Reference:** [RTCRtpTransceiverOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/addTransceiver#init)

> Used in RTCPeerConnection.AddTransceiver https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/addTransceiver#init

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCRtpTransceiverOptions` | `class` | get | Used in RTCPeerConnection.AddTransceiver https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/addTransceiver#init |
| `SendEncodings` | `RTCMediaEncoding[]?` | get |  |
| `Streams` | `MediaStream[]?` | get |  |
| `Direction` | `string?` | get/set | The directionality indicates whether the transceiver will offer to send and/or receive RTP data, or whether it is inactive or stopped (terminated). When setting the transceiver's direction, the value is not applied immediately. The current direction is indicated by the currentDirection property. A string with one of the following values: "sendrecv" - Transceiver offers to send and receive RTP data: - RTCRtpSender: Offers to send RTP data, and will do so if the remote peer accepts the connection and at least one of the sender's encodings is active. - RTCRtpReceiver: Offers to receive RTP data, and does so if the remote peer accepts. "sendonly" - Transceiver offers to send but not receive RTP data: - RTCRtpSender: Offers to send RTP data, and will do so if the remote peer accepts the connection and at least one of the sender's encodings is active. - RTCRtpReceiver: Does not offer to receive RTP data and will not do so. "recvonly" - Transceiver offers to receive but not set RTP data: - RTCRtpSender: Does not offer to send RTP data, and will not do so. - RTCRtpReceiver: Offers to receive RTP data, and will do so if the remote peer offers. "inactive" - Transceiver is inactive: - RTCRtpSender: Does not offer to send RTP data, and will not do so. RTCRtpReceiver: Does not offer to receive RTP data and will not do so. "stopped" - This is the terminal state of the transceiver. The transceiver is stopped and will not send or receive RTP data or offer to do so. Setting this value when the transceiver is not already stopped raises a TypeError. - RTCRtpSender: Does not offer to send RTP data, and will not do so. RTCRtpReceiver: Does not offer to receive RTP data and will not do so. |


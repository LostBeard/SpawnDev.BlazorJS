# RTCRtpTransceiver

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCRtpTransceiver.cs`  
**MDN Reference:** [RTCRtpTransceiver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver)

> The WebRTC interface RTCRtpTransceiver describes a permanent pairing of an RTCRtpSender and an RTCRtpReceiver, along with some shared state. https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver

## Constructors

| Signature | Description |
|---|---|
| `RTCRtpTransceiver(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CurrentDirection` | `string` | get | A read-only string which indicates the transceiver's current negotiated directionality, or null if the transceiver has never participated in an exchange of offers and answers. To change the transceiver's directionality, set the value of the direction property. |
| `Direction` | `string` | get | The RTCRtpTransceiver property direction is a string which indicates the transceiver's preferred directionality. |
| `Mid` | `string?` | get | The media ID of the m-line associated with this transceiver. This association is established, when possible, whenever either a local or remote description is applied. This field is null if neither a local or remote description has been applied, or if its associated m-line is rejected by either a remote offer or any answer. |
| `Receiver` | `RTCRtpReceiver` | get | The RTCRtpReceiver object that handles receiving and decoding incoming media. |
| `Sender` | `RTCRtpSender` | get | The RTCRtpSender object responsible for encoding and sending data to the remote peer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Stop()` | `void` | Permanently stops the RTCRtpTransceiver. The associated sender stops sending data, and the associated receiver likewise stops receiving and decoding incoming data. |
| `SetCodecPreferences(RTCRtpTransceiverCodec[] codecs)` | `void` | A list of RTCRtpCodecParameters objects which override the default preferences used by the user agent for the transceiver's codecs. |


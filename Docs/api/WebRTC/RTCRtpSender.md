# RTCRtpSender

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCRtpSender.cs`  

> The RTCRtpSender interface provides the ability to control and obtain details about how a particular MediaStreamTrack is encoded and sent to a remote peer.

## Constructors

| Signature | Description |
|---|---|
| `RTCRtpSender(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Track` | `MediaStreamTrack` | get | The track read-only property of the RTCRtpSender interface returns the MediaStreamTrack which is being handled by the RTCRtpSender. |
| `Transport` | `RTCDtlsTransport` | get | The transport read-only property of the RTCRtpSender interface returns the RTCDtlsTransport used by the sender to transmit networked packets of media data to the remote peer. |
| `DTMF` | `RTCDTMFSender` | get | The dtmf read-only property of the RTCRtpSender interface returns an RTCDTMFSender which can be used to send DTMF tones over the PeerConnection. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCapabilities(string kind)` | `RTCRtpSenderCapabilities` | The static method RTCRtpSender.getCapabilities() returns an object describing the codec and header extension capabilities supported by the RTCRtpSender. A string indicating the type of media for which the browser's send capabilities are requested. The supported media kinds are: audio and video. A new object that indicates what capabilities the browser has for sending the specified media kind over an RTCPeerConnection. If the browser doesn't have any support for the given media kind, the returned value is null. |
| `ReplaceTrack(MediaStreamTrack newTrack)` | `Task` | The RTCRtpSender.replaceTrack() method replaces the track currently being used as the sender's source with a new MediaStreamTrack. A MediaStreamTrack specifying the track with which to replace the existing one. The new track must be of the same media kind (audio or video) as the old one. If this parameter is null, the sender's current track is removed without being replaced by a new one. A Promise which is fulfilled once the track has been successfully replaced. The promise is rejected if the track cannot be replaced for any reason. The fulfillment handler receives no input parameters. |
| `SetStreams()` | `void` | The setStreams() method of the RTCRtpSender interface sets the streams associated with this sender's track. |
| `SetStreams(params MediaStream[] mediaStreams)` | `void` | The setStreams() method of the RTCRtpSender interface sets the streams associated with this sender's track. An array of MediaStream objects (or a single MediaStream) which identify the streams to which the sender's track should belong. |
| `GetParameters()` | `JSObject` | Returns an object describing the current configuration for the encoding and transmission of media on the sender's track. |
| `SetParameters(JSObject parameters)` | `Task` | Applies changes to parameters which configure how the sender's track is encoded and transmitted to the remote peer. |
| `GetStats()` | `Task<RTCStatsReport>` | Returns a Promise that resolves with an RTCStatsReport which provides statistics data for the sender. |


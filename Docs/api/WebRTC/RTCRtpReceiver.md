# RTCRtpReceiver

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCRtpReceiver.cs`  

> The RTCRtpReceiver interface manages the reception and decoding of data for a MediaStreamTrack on an RTCPeerConnection.

## Constructors

| Signature | Description |
|---|---|
| `RTCRtpReceiver(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Track` | `MediaStreamTrack` | get | The MediaStreamTrack which is being received and decoded by the RTCRtpReceiver. |
| `Transport` | `RTCDtlsTransport` | get | The RTCDtlsTransport instance that is used for receiving the media. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCapabilities(string kind)` | `RTCRtpSenderCapabilities` | The static method RTCRtpReceiver.getCapabilities() returns an object describing the codec and header extension capabilities supported by RTCRtpReceiver objects on the current device. A string indicating the type of media for which the browser's receiver capabilities are requested. The supported media kinds are: audio and video. A new object that indicates what capabilities the browser has for receiving the specified media kind over an RTCPeerConnection. If the browser doesn't have any support for the given media kind, the returned value is null. |


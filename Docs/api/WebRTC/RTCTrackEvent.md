# RTCTrackEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebRTC/RTCTrackEvent.cs`  

> The RTCTrackEvent interface, part of the WebRTC API, represents an event which is sent when a new MediaStreamTrack has been added to an RTCRtpReceiver which is part of an RTCPeerConnection.

## Constructors

| Signature | Description |
|---|---|
| `RTCTrackEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Receiver` | `RTCRtpReceiver` | get | The RTCRtpReceiver used by the track that is indicated by the event. |
| `Streams` | `MediaStream[]` | get | An array of MediaStream objects, each representing one of the media streams that include the event's track. |
| `Track` | `MediaStreamTrack` | get | The MediaStreamTrack which has been added to the connection. |
| `Transceiver` | `RTCRtpTransceiver` | get | The RTCRtpTransceiver being used by the new track. |


# RTCPeerConnection

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inheritance:** `JSObject` -> `EventTarget` -> `RTCPeerConnection`  
**MDN Reference:** [RTCPeerConnection](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection)

> The `RTCPeerConnection` class represents a WebRTC connection between the local device and a remote peer. It handles the complete lifecycle of a peer-to-peer connection - ICE candidate gathering, SDP offer/answer exchange, media track management, and data channel creation. In SpawnDev projects, `SpawnDev.RTLink` uses SipSorcery for desktop peers, while browser peers use this native WebRTC wrapper.

## Constructors

| Signature | Description |
|-----------|-------------|
| `RTCPeerConnection()` | Creates a new peer connection with default configuration. |
| `RTCPeerConnection(RTCConfiguration config)` | Creates a peer connection with ICE servers, bundling policy, etc. |
| `RTCPeerConnection(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `LocalDescription` | `RTCSessionDescription?` | The local SDP description (offer or answer). |
| `RemoteDescription` | `RTCSessionDescription?` | The remote SDP description. |
| `CurrentLocalDescription` | `RTCSessionDescription?` | The current local description (after ICE). |
| `CurrentRemoteDescription` | `RTCSessionDescription?` | The current remote description (after ICE). |
| `PendingLocalDescription` | `RTCSessionDescription?` | The pending local description (during renegotiation). |
| `PendingRemoteDescription` | `RTCSessionDescription?` | The pending remote description. |
| `SignalingState` | `string` | Current signaling state: `"stable"`, `"have-local-offer"`, `"have-remote-offer"`, etc. |
| `IceGatheringState` | `string` | ICE gathering state: `"new"`, `"gathering"`, `"complete"`. |
| `IceConnectionState` | `string` | ICE connection state: `"new"`, `"checking"`, `"connected"`, `"completed"`, `"failed"`, `"disconnected"`, `"closed"`. |
| `ConnectionState` | `string` | Overall connection state: `"new"`, `"connecting"`, `"connected"`, `"disconnected"`, `"failed"`, `"closed"`. |

## Methods

### SDP Negotiation

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateOffer()` | `Task<RTCSessionDescription>` | Creates an SDP offer. |
| `CreateOffer(RTCOfferOptions options)` | `Task<RTCSessionDescription>` | Creates an offer with options (e.g., `OfferToReceiveAudio`). |
| `CreateAnswer()` | `Task<RTCSessionDescription>` | Creates an SDP answer (after setting remote offer). |
| `CreateAnswer(RTCAnswerOptions options)` | `Task<RTCSessionDescription>` | Creates an answer with options. |
| `SetLocalDescription(RTCSessionDescription description)` | `Task` | Sets the local SDP description. |
| `SetRemoteDescription(RTCSessionDescription description)` | `Task` | Sets the remote SDP description. |

### ICE

| Method | Return Type | Description |
|--------|-------------|-------------|
| `AddIceCandidate(RTCIceCandidate candidate)` | `Task` | Adds a remote ICE candidate. |
| `AddIceCandidate(RTCIceCandidateInfo candidate)` | `Task` | Adds a candidate from serialized info. |

### Media Tracks

| Method | Return Type | Description |
|--------|-------------|-------------|
| `AddTrack(MediaStreamTrack track, MediaStream stream)` | `RTCRtpSender` | Adds a media track to the connection. |
| `RemoveTrack(RTCRtpSender sender)` | `void` | Removes a media track. |
| `AddTransceiver(string kind)` | `RTCRtpTransceiver` | Adds a transceiver for `"audio"` or `"video"`. |
| `AddTransceiver(string kind, RTCRtpTransceiverOptions options)` | `RTCRtpTransceiver` | Adds a transceiver with options. |
| `AddTransceiver(MediaStreamTrack track)` | `RTCRtpTransceiver` | Adds a transceiver for a specific track. |
| `GetSenders()` | `RTCRtpSender[]` | Returns all RTP senders. |
| `GetReceivers()` | `RTCRtpReceiver[]` | Returns all RTP receivers. |
| `GetTransceivers()` | `RTCRtpTransceiver[]` | Returns all transceivers. |

### Data Channels

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateDataChannel(string label)` | `RTCDataChannel` | Creates a data channel with the given label. |
| `CreateDataChannel(string label, RTCDataChannelOptions options)` | `RTCDataChannel` | Creates a data channel with options (ordered, maxRetransmits, protocol, etc.). |

### Statistics and Lifecycle

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetStats()` | `Task<RTCStatsReport>` | Returns connection statistics. |
| `Close()` | `void` | Closes the peer connection. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnIceCandidate` | `ActionEvent<RTCPeerConnectionIceEvent>` | Fired when a new ICE candidate is available. |
| `OnIceConnectionStateChange` | `ActionEvent<Event>` | Fired when the ICE connection state changes. |
| `OnConnectionStateChange` | `ActionEvent<Event>` | Fired when the overall connection state changes. |
| `OnSignalingStateChange` | `ActionEvent<Event>` | Fired when the signaling state changes. |
| `OnTrack` | `ActionEvent<RTCTrackEvent>` | Fired when a remote track is added. |
| `OnDataChannel` | `ActionEvent<RTCDataChannelEvent>` | Fired when the remote peer creates a data channel. |
| `OnNegotiationNeeded` | `ActionEvent<Event>` | Fired when renegotiation is needed. |
| `OnIceGatheringStateChange` | `ActionEvent<Event>` | Fired when the ICE gathering state changes. |

## Example

```csharp
// Create a peer connection with STUN/TURN servers
using var pc = new RTCPeerConnection(new RTCConfiguration
{
    IceServers = new RTCIceServer[]
    {
        new RTCIceServer { Urls = "stun:stun.l.google.com:19302" }
    }
});

// Handle ICE candidates
pc.OnIceCandidate += (evt) =>
{
    var candidate = evt.Candidate;
    if (candidate != null)
    {
        // Send candidate to remote peer via signaling
        SendToRemotePeer(candidate);
    }
    evt.Dispose();
};

// Handle incoming data channels
pc.OnDataChannel += (evt) =>
{
    using var channel = evt.Channel;
    Console.WriteLine($"Remote data channel: {channel.Label}");
    evt.Dispose();
};

// Handle connection state
pc.OnConnectionStateChange += (evt) =>
{
    Console.WriteLine($"Connection state: {pc.ConnectionState}");
    evt.Dispose();
};

// Create a data channel
using var dataChannel = pc.CreateDataChannel("chat", new RTCDataChannelOptions
{
    Ordered = true
});

// Create and set local offer
using var offer = await pc.CreateOffer();
await pc.SetLocalDescription(offer);

// Send offer to remote peer via signaling...
// Receive answer from remote peer...

// Set remote answer
await pc.SetRemoteDescription(new RTCSessionDescription
{
    Type = "answer",
    Sdp = remoteSdp
});

// Add remote ICE candidates as they arrive
await pc.AddIceCandidate(new RTCIceCandidateInfo
{
    Candidate = candidateString,
    SdpMid = sdpMid,
    SdpMLineIndex = sdpMLineIndex
});
```

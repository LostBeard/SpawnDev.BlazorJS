# RTCSctpTransport

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebRTC/RTCSctpTransport.cs`  

> The RTCSctpTransport interface provides information which describes a Stream Control Transmission Protocol (SCTP) transport. This also provides a way to access the underlying Datagram Transport Layer Security (DTLS) transport over which SCTP packets for all of an RTCPeerConnection's data channels are sent and received.<br/> https://developer.mozilla.org/en-US/docs/Web/API/RTCSctpTransport

## Constructors

| Signature | Description |
|---|---|
| `RTCSctpTransport(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Transport` | `RTCDtlsTransport?` | get | An RTCDtlsTransport object representing the DTLS transport over which the SCTP packets for all of this SCTP transport's data channels are sent and received. |
| `State` | `string` | get | The current state of the SCTP transport: "connecting", "connected", or "closed". |
| `MaxMessageSize` | `double` | get | An integer indicating the maximum size, in bytes, of a message which can be sent using the RTCDataChannel.send() method. Chromium-based browsers typically report 262144 (256 KiB - 1), Firefox reports larger values. May be Infinity. |
| `MaxChannels` | `int?` | get | An integer indicating the maximum number of RTCDataChannels that can be open on this SCTP transport simultaneously, or null if the implementation doesn't know the number of SCTP streams the remote peer supports (e.g. before connection). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnStateChange` | `ActionEvent<Event>` | The statechange event is sent when the value of the state property changes on an RTCSctpTransport. |

# RTCPeerConnectionIceErrorEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebRTC/RTCPeerConnectionIceErrorEvent.cs`  

> The RTCPeerConnectionIceErrorEvent interface represents an error that occurred during the ICE candidate gathering or connection process.

## Constructors

| Signature | Description |
|---|---|
| `RTCPeerConnectionIceErrorEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Address` | `string?` | get | A string providing the local IP address used to communicate with the STUN or TURN server being used to negotiate the connection. |
| `Port` | `uint?` | get | An unsigned integer value giving the port number over which the communication with the STUN or TURN server is taking place. |
| `ErrorCode` | `uint` | get | An unsigned integer value stating the numeric STUN error code returned by the STUN or TURN server. |
| `ErrorText` | `string` | get | A string containing the STUN error text returned by the STUN or TURN server. |
| `Url` | `string` | get | A string giving the URL of the STUN or TURN server which it was attempting to reach when the error occurred. |


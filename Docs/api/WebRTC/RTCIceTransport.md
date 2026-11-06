# RTCIceTransport

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebRTC/RTCDtlsTransport.cs`  

> The RTCIceTransport interface provides access to information about the ICE transport layer over which the data is being sent and received. This is particularly useful if you need to access state information about the connection. https://developer.mozilla.org/en-US/docs/Web/API/RTCIceTransport

## Constructors

| Signature | Description |
|---|---|
| `RTCIceTransport(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Component` | `string` | get | The ICE component being used by the transport. The value is one of the strings from the RTCIceTransport enumerated type: "RTP" or "RTSP". |
| `GatheringState` | `string` | get | A string indicating which current gathering state of the ICE agent: "new", "gathering", or "complete". |
| `Role` | `string` | get | Returns a string whose value is either "controlling" or "controlled"; this indicates whether the ICE agent is the one that makes the final decision as to the candidate pair to use or not. |
| `State` | `string` | get | A string indicating what the current state of the ICE agent is. The value of state can be used to determine whether the ICE agent has made an initial connection using a viable candidate pair ("connected"), made its final selection of candidate pairs ("completed"), or in an error state ("failed"), among other states. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetLocalCandidates()` | `Array<RTCIceCandidate>` | Returns an array of RTCIceCandidate objects, each describing one of the ICE candidates that have been gathered so far for the local device. These are the same candidates which have already been sent to the remote peer by sending an icecandidate event to the RTCPeerConnection for transmission. |

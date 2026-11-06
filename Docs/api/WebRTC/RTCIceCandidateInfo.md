# RTCIceCandidateInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCIceCandidateInfo.cs`  

> The RTCIceCandidateInfo interface of the WebRTC API represents a candidate Internet Connectivity Establishment (ICE) configuration which may be used to establish an RTCPeerConnection.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCIceCandidateInfo` | `class` | get | The RTCIceCandidateInfo interface of the WebRTC API represents a candidate Internet Connectivity Establishment (ICE) configuration which may be used to establish an RTCPeerConnection. |
| `SdpMid` | `string?` | get |  |
| `SdpMLineIndex` | `int?` | get |  |
| `UsernameFragment` | `string?` | get |  |
| `Candidate` | `string?` | get/set | A string describing the properties of the candidate, taken directly from the SDP attribute "candidate". The candidate string specifies the network connectivity information for the candidate. If the candidate is an empty string (""), the end of the candidate list has been reached; this candidate is known as the "end-of-candidates" marker. The syntax of the candidate string is described in RFC 5245, section 15.1. For an a-line (attribute line) that looks like this: a=candidate:4234997325 1 udp 2043278322 192.168.0.56 44323 typ host |


# RTCIceCandidate

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCIceCandidate.cs`  
**MDN Reference:** [RTCIceCandidate on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidate)

> The RTCIceCandidate interface-part of the WebRTC API-represents a candidate Interactive Connectivity Establishment (ICE) configuration which may be used to establish an RTCPeerConnection. An ICE candidate describes the protocols and routing needed for WebRTC to be able to communicate with a remote device. When starting a WebRTC peer connection, typically a number of candidates are proposed by each end of the connection, until they mutually agree upon one which describes the connection they decide will be best. WebRTC then uses that candidate's details to initiate the connection. https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidate

## Constructors

| Signature | Description |
|---|---|
| `RTCIceCandidate(RTCIceCandidateInfo candidate)` | The RTCIceCandidate() constructor creates and returns a new RTCIceCandidate object, which can be configured to represent a single ICE candidate. |
| `RTCIceCandidate(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Address` | `string` | get | A string containing the IP address of the candidate. |
| `Candidate` | `string` | get | A string representing the transport address for the candidate that can be used for connectivity checks. The format of this address is a candidate-attribute as defined in RFC 5245. This string is empty ("") if the RTCIceCandidate is an "end of candidates" indicator. |
| `Component` | `string` | get | A string which indicates whether the candidate is an RTP or an RTCP candidate; its value is either rtp or rtcp, and is derived from the "component-id" field in the candidate a-line string. |
| `Foundation` | `string` | get/set | Returns a string containing a unique identifier that is the same for any candidates of the same type, share the same base (the address from which the ICE agent sent the candidate), and come from the same STUN server. This is used to help optimize ICE performance while prioritizing and correlating candidates that appear on multiple RTCIceTransport objects. |
| `Port` | `int?` | get/set | An integer value indicating the candidate's port number. |
| `Priority` | `int?` | get | A long integer value indicating the candidate's priority. |
| `Protocol` | `string` | get | A string indicating whether the candidate's protocol is "tcp" or "udp" |
| `RelatedAddress` | `string?` | get | If the candidate is derived from another candidate, relatedAddress is a string containing that host candidate's IP address. For host candidates, this value is nul |
| `RelatedPort` | `int?` | get | For a candidate that is derived from another, such as a relay or reflexive candidate, the relatedPort is a number indicating the port number of the candidate from which this candidate is derived. For host candidates, the relatedPort property is null. |
| `SdpMid` | `string` | get | A string specifying the candidate's media stream identification tag which uniquely identifies the media stream within the component with which the candidate is associated, or null if no such association exists. |
| `SdpMLineIndex` | `int?` | get | If not null, sdpMLineIndex indicates the zero-based index number of the media description (as defined in RFC 4566) in the SDP with which the candidate is associated. |
| `TcpType` | `string` | get | If protocol is "tcp", tcpType represents the type of TCP candidate. Otherwise, tcpType is null |
| `Type` | `string` | get | A string indicating the type of candidate as one of the strings listed on RTCIceCandidate.type. |
| `UsernameFragment` | `string` | get | A string containing a randomly-generated username fragment ("ice-ufrag") which ICE uses for message integrity along with a randomly-generated password ("ice-pwd"). You can use this string to verify generations of ICE generation; each generation of the same ICE process will use the same usernameFragment, even across ICE restarts. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToJSON()` | `RTCIceCandidateInfo` | Returns a JSON representation of the RTCIceCandidate's current configuration. The format of the representation is the same as the candidateInfo object that can optionally be passed to the RTCIceCandidate() constructor to configure a candidate. |


# RTCIceCandidateStats

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `RTCStats`  
**Source:** `JSObjects/WebRTC/RTCIceCandidateStats.cs`  
**MDN Reference:** [RTCIceCandidateStats on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidateStats)

> The RTCIceCandidateStats dictionary of the WebRTC API is used to report statistics related to an RTCIceCandidate. https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidateStats

## Constructors

| Signature | Description |
|---|---|
| `RTCIceCandidateStats(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Address` | `string?` | get | A string containing the address of the candidate. This value may be an IPv4 address, an IPv6 address, or a fully-qualified domain name. This property was previously named ip and only accepted IP addresses. |
| `CandidateType` | `string` | get | A string matching one of the values in RTCIceCandidate.type, indicating what kind of candidate the object provides statistics for. |
| `Deleted` | `bool?` | get | A Boolean value indicating whether or not the candidate has been released or deleted; the default value is false. For local candidates, its value is true if the candidate has been deleted or released. For host candidates, true means that any network resources (usually a network socket) associated with the candidate have already been released. For TURN candidates, the TURN allocation is no longer active for deleted candidates. This property is not present for remote candidates. |
| `Port` | `Union<ushort, string>?` | get | The network port number used by the candidate. |
| `Priority` | `ulong?` | get | The candidate's priority, corresponding to RTCIceCandidate.priority. |
| `Protocol` | `string?` | get | A string specifying the protocol (tcp or udp) used to transmit data on the port. |
| `RelayProtocol` | `string?` | get | A string identifying the protocol used by the endpoint for communicating with the TURN server; valid values are tcp, udp, and tls. Only present for local candidates. |
| `TransportId` | `string` | get | A string uniquely identifying the transport object that was inspected in order to obtain the RTCTransportStats associated with the candidate corresponding to these statistics. |
| `Url` | `string?` | get | For local candidates, the url property is the URL of the ICE server from which the candidate was received. This URL matches the one included in the RTCPeerConnectionIceEvent object representing the icecandidate event that delivered the candidate to the local peer. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCIceCandidateStats>(...)` or constructor `new RTCIceCandidateStats(...)`

```js
const stats = await myPeerConnection.getStats();

stats.forEach((report) => {
  if (report.type === "local-candidate") {
    // Log the ICE candidate information
    console.log(report);
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidateStats)*


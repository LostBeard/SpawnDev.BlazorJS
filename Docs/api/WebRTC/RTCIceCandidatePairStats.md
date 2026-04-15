# RTCIceCandidatePairStats

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `RTCStats`  
**Source:** `JSObjects/WebRTC/RTCIceCandidatePairStats.cs`  
**MDN Reference:** [RTCIceCandidatePairStats on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidatePairStats)

> The RTCIceCandidatePairStats dictionary of the WebRTC API is used to report statistics that provide insight into the quality and performance of an RTCPeerConnection while connected and configured as described by the specified pair of ICE candidates. https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidatePairStats

## Constructors

| Signature | Description |
|---|---|
| `RTCIceCandidatePairStats(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AvailableIncomingBitrate` | `long?` | get | Provides a value representing the available inbound capacity of the network by reporting the total number of bits per second available for all of the candidate pair's incoming RTP streams. This does not take into account the size of the IP overhead, nor any other transport layers such as TCP or UDP. |
| `AvailableOutgoingBitrate` | `long?` | get | Provides an informative value representing the available outbound capacity of the network by reporting the total number of bits per second available for all of the candidate pair's outgoing RTP streams. This does not take into account the size of the IP overhead, nor any other transport layers such as TCP or UDP. |
| `BytesReceived` | `long?` | get | The total number of payload bytes received (that is, the total number of bytes received minus any headers, padding, or other administrative overhead) on this candidate pair so far. |
| `BytesSent` | `long?` | get | The total number of payload bytes sent (that is, the total number of bytes sent minus any headers, padding, or other administrative overhead) so far on this candidate pair. |
| `CurrentRoundTripTime` | `float?` | get | A floating-point value indicating the total time, in seconds, that elapsed between the most recently-sent STUN request and the response being received. This may be based upon requests that were involved in confirming permission to open the connection. |
| `LastPacketReceivedTimestamp` | `double?` | get | A DOMHighResTimeStamp value indicating the time at which the last packet was received by the local peer from the remote peer for this candidate pair. Timestamps are not recorded for STUN packets. |
| `LastPacketSentTimestamp` | `double?` | get | A DOMHighResTimeStamp value indicating the time at which the last packet was sent from the local peer to the remote peer for this candidate pair. Timestamps are not recorded for STUN packets. |
| `LocalCandidateId` | `string?` | get | The unique ID string corresponding to the RTCIceCandidate from the data included in the RTCIceCandidateStats object providing statistics for the candidate pair's local candidate. |
| `Nominated` | `bool?` | get | A Boolean value which, if true, indicates that the candidate pair described by this object is one which has been proposed for use, and will be (or was) used if its priority is the highest among the nominated candidate pairs. See RFC 5245, section 7.1.3.2.4 for details. |
| `RemoteCandidateId` | `string?` | get | The unique ID string corresponding to the remote candidate from which data was taken to construct the RTCIceCandidateStats object describing the remote end of the connection. |
| `RequestsReceived` | `int?` | get | The total number of connectivity check requests that have been received, including retransmissions. This value includes both connectivity checks and STUN consent checks. |
| `RequestsSent` | `int?` | get | The total number of connectivity check requests that have been sent, not including retransmissions. |
| `ResponsesSent` | `int?` | get | The total number of connectivity check responses that have been sent. This includes both connectivity check requests and STUN consent requests. |
| `ResponsesReceived` | `int?` | get | The total number of connectivity check responses that have been received. |
| `State` | `string?` | get | A string which indicates the state of the connection between the two candidates. |
| `TotalRoundTripTime` | `float?` | get | A floating-point value indicating the total time, in seconds, that has elapsed between sending STUN requests and receiving responses to them, for all such requests made to date on this candidate pair. This includes both connectivity check and consent check requests. You can compute the average round trip time (RTT) by dividing this value by responsesReceived. |
| `TransportId` | `string?` | get | A string that uniquely identifies the RTCIceTransport that was inspected to obtain the transport-related statistics (as found in RTCTransportStats) used in generating this object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCIceCandidatePairStats>(...)` or constructor `new RTCIceCandidatePairStats(...)`

```js
if (rtcStats && rtcStats.type === "candidate-pair") {
  let elapsed =
    (rtcStats.lastRequestTimestamp - rtcStats.firstRequestTimestamp) /
    rtcStats.requestsSent;

  console.log(`Average time between ICE connectivity checks: ${elapsed} ms.`);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidatePairStats)*


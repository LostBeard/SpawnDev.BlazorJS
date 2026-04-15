# RTCDtlsTransport

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebRTC/RTCDtlsTransport.cs`  
**MDN Reference:** [RTCDtlsTransport on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCDtlsTransport)

> The RTCDtlsTransport interface provides access to information about the Datagram Transport Layer Security (DTLS) transport over which a RTCPeerConnection's RTP and RTCP packets are sent and received by its RTCRtpSender and RTCRtpReceiver objects. https://developer.mozilla.org/en-US/docs/Web/API/RTCDtlsTransport

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IceTransport` | `RTCIceTransport` | get | Returns a reference to the underlying RTCIceTransport object. |
| `State` | `string` | get | Returns a string which describes the underlying Datagram Transport Layer Security (DTLS) transport state. It can be one of the following values: new, connecting, connected, closed, or failed. |
| `Component` | `string` | get | The ICE component being used by the transport. The value is one of the strings from the RTCIceTransport enumerated type: "RTP" or "RTSP". |
| `GatheringState` | `string` | get | A string indicating which current gathering state of the ICE agent: "new", "gathering", or "complete". |
| `Role` | `string` | get | Returns a string whose value is either "controlling" or "controlled"; this indicates whether the ICE agent is the one that makes the final decision as to the candidate pair to use or not. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetLocalCandidates()` | `Array<RTCIceCandidate>` | Returns an array of RTCIceCandidate objects, each describing one of the ICE candidates that have been gathered so far for the local device. These are the same candidates which have already been sent to the remote peer by sending an icecandidate event to the RTCPeerConnection for transmission. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnError` | `ActionEvent<RTCErrorEvent>` | Sent when a transport-level error occurs on the RTCPeerConnection. |
| `OnStateChange` | `ActionEvent<Event>` | Sent when the state of the DTLS transport changes. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCDtlsTransport>(...)` or constructor `new RTCDtlsTransport(...)`

```js
let pc = new RTCPeerConnection({ bundlePolicy: "max-bundle" });

// …

function tallySenders(pc) {
  let results = {
    transportMissing: 0,
    connectionPending: 0,
    connected: 0,
    closed: 0,
    failed: 0,
    unknown: 0,
  };

  let senderList = pc.getSenders();
  senderList.forEach((sender) => {
    let transport = sender.transport;

    if (!transport) {
      results.transportMissing++;
    } else {
      switch (transport.state) {
        case "new":
        case "connecting":
          results.connectionPending++;
          break;
        case "connected":
          results.connected++;
          break;
        case "closed":
          results.closed++;
          break;
        case "failed":
          results.failed++;
          break;
        default:
          results.unknown++;
          break;
      }
    }
  });
  return results;
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCDtlsTransport)*


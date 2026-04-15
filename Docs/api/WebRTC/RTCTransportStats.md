# RTCTransportStats

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `RTCStats`  
**Source:** `JSObjects/WebRTC/RTCTransportStats.cs`  
**MDN Reference:** [RTCTransportStats on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCTransportStats)

> The RTCTransportStats dictionary of the WebRTC API provides information about the transport (RTCDtlsTransport and its underlying RTCIceTransport) used by a particular candidate pair. https://developer.mozilla.org/en-US/docs/Web/API/RTCTransportStats

## Constructors

| Signature | Description |
|---|---|
| `RTCTransportStats(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SelectedCandidatePairId` | `string?` | get | A string containing the unique identifier for the object that was inspected to produce the RTCIceCandidatePairStats associated with this transport. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCTransportStats>(...)` or constructor `new RTCTransportStats(...)`

```js
async function numberOpenConnections (peerConnection) {
  const stats = await peerConnection.getStats();
  let transportStats = null;

  stats.forEach((report) => {
    if (report.type === "transport") {
      transportStats = report;
      break;
    }
  });

return transportStats
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCTransportStats)*


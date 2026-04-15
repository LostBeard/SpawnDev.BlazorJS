# RTCStatsReport

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCStatsReport.cs`  
**MDN Reference:** [RTCStatsReport on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport)

> The RTCStatsReport interface of the WebRTC API provides a statistics report for a RTCPeerConnection, RTCRtpSender, or RTCRtpReceiver. https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport TODO - verify return values

## Constructors

| Signature | Description |
|---|---|
| `RTCStatsReport(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Size` | `int` | get | Returns the number of items in the RTCStatsReport object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Get(string id)` | `RTCStats?` | Returns the statistics dictionary associated with the passed id, or undefined if there is none. |
| `Has(string id)` | `bool` | Returns a boolean indicating whether the RTCStatsReport contains a statistics dictionary associated with the specified id. |
| `Keys()` | `string[]` | Returns a new Iterator object that contains the keys (IDs) for each element in the RTCStatsReport object, in insertion order. |
| `Values()` | `RTCStats[]` | Returns a new Iterator object that contains the values (statistics object) for each element in the RTCStatsReport object, in insertion order. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCStatsReport>(...)` or constructor `new RTCStatsReport(...)`

### Iterate report from an RTCPeerConnection using forEach loop

```js
const stats = await myPeerConnection.getStats();

stats.forEach((report) => {
  if (report.type === "inbound-rtp" && report.kind === "video") {
    // Log the frame rate
    console.log(report.framesPerSecond);
  }
});
```

### Iterate report from an RTCRtpSender using a for...of loop

```js
const stats = await sender.getStats();

for (const stat of stats.values()) {
  if (stat.type !== "outbound-rtp") continue;
  Object.keys(stat).forEach((statName) => {
    console.log(`${statName}: ${stat[statName]}`);
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport)*


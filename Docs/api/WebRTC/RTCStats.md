# RTCStats

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebRTC/RTCStats.cs`  
**MDN Reference:** [RTCStats on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport#the_statistic_types)

> Base class for RTC stats objects https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport#the_statistic_types

## Constructors

| Signature | Description |
|---|---|
| `RTCStats(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string that uniquely identifies the object was monitored to produce the set of statistics. This value persists across reports for (at least) the lifetime of the connection. Note however that for some statistics the ID may vary between browsers and for subsequent connections, even to the same peer. |
| `Type` | `string` | get | A string with a value that indicates the type of statistics that the object contains, such as candidate-pair, inbound-rtp, certificate, and so on. The types of statistics and their corresponding objects are listed below. |
| `Timestamp` | `double` | get | A DOMHighResTimeStamp object indicating the time at which the sample was taken for this statistics object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Typed()` | `RTCStats` | Returns the statistics object cast to its most specific type based on the value of the Type property. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCStats>(...)` or constructor `new RTCStats(...)`

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


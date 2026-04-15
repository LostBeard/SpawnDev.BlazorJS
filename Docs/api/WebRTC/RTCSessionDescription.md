# RTCSessionDescription

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCSessionDescription.cs`  
**MDN Reference:** [RTCSessionDescription on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription)

> The RTCSessionDescription interface describes one end of a connection-or potential connection-and how it's configured. Each RTCSessionDescription consists of a description type indicating which part of the offer/answer negotiation process it describes and of the SDP descriptor of the session. https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCSessionDescription` | `class` | get/set | The RTCSessionDescription interface describes one end of a connection-or potential connection-and how it's configured. Each RTCSessionDescription consists of a description type indicating which part of the offer/answer negotiation process it describes and of the SDP descriptor of the session. https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription |
| `Sdp` | `string` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCSessionDescription>(...)` or constructor `new RTCSessionDescription(...)`

```js
signalingChannel.onmessage = (evt) => {
  if (!pc) start(false);

  const message = JSON.parse(evt.data);
  if (message.type && message.sdp) {
    pc.setRemoteDescription(
      new RTCSessionDescription(message),
      () => {
        // if we received an offer, we need to answer
        if (pc.remoteDescription.type === "offer") {
          pc.createAnswer(localDescCreated, logError);
        }
      },
      logError,
    );
  } else {
    pc.addIceCandidate(
      new RTCIceCandidate(message.candidate),
      () => {},
      logError,
    );
  }
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription)*


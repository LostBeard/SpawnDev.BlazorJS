# RTCOfferOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCOfferOptions.cs`  
**MDN Reference:** [RTCOfferOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createOffer#options)

> Options used for RTCPeerConnection.CreateOffer() https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createOffer#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCOfferOptions` | `class` | get | Options used for RTCPeerConnection.CreateOffer() https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createOffer#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCOfferOptions>(...)` or constructor `new RTCOfferOptions(...)`

```js
myPeerConnection
  .createOffer()
  .then((offer) => myPeerConnection.setLocalDescription(offer))
  .then(() => {
    sendToServer({
      name: myUsername,
      target: targetUsername,
      type: "video-offer",
      sdp: myPeerConnection.localDescription,
    });
  })
  .catch((reason) => {
    // An error occurred, so handle the failure to connect
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createOffer)*


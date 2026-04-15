# RTCAnswerOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCAnswerOptions.cs`  
**MDN Reference:** [RTCAnswerOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createAnswer#options)

> Options used for RTCPeerConnection.CreateSnwer() https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createAnswer#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCAnswerOptions` | `class` | get | Options used for RTCPeerConnection.CreateSnwer() https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createAnswer#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCAnswerOptions>(...)` or constructor `new RTCAnswerOptions(...)`

```js
pc.createAnswer()
  .then((answer) => pc.setLocalDescription(answer))
  .then(() => {
    // Send the answer to the remote peer through the signaling server.
  })
  .catch(handleGetUserMediaError);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/createAnswer)*


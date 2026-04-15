# RTCError

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `DOMException`  
**Source:** `JSObjects/WebRTC/RTCError.cs`  
**MDN Reference:** [RTCError on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCError)

> The RTCError interface describes an error which has occurred while handling WebRTC operations. It's based upon the standard DOMException interface that describes general DOM errors. https://developer.mozilla.org/en-US/docs/Web/API/RTCError

## Constructors

| Signature | Description |
|---|---|
| `RTCError(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ErrorDetail` | `string` | get | A string specifying the WebRTC-specific error code identifying the type of error that occurred. |
| `ReceivedAlert` | `ulong` | get | An unsigned long integer value indicating the fatal DTLS error which was received from the network. Only valid if the errorDetail string is dtls-failure. If null, no DTLS error was received. |
| `SctpCauseCode` | `long` | get | If errorDetail is sctp-failure, this property is a long integer specifying the SCTP cause code indicating the cause of the failed SCTP negotiation. null if the error isn't an SCTP error. |
| `SdpLineNumber` | `long` | get | If errorDetail is sdp-syntax-error, this property is a long integer identifying the line number of the SDP on which the syntax error occurred. null if the error isn't an SDP syntax error. |
| `SentAlert` | `ulong` | get | If errorDetail is dtls-failure, this property is an unsigned long integer indicating the fatal DTLS error that was sent out by this device. If null, no DTLS error was transmitted. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCError>(...)` or constructor `new RTCError(...)`

```js
dataChannel.addEventListener("error", (event) => {
  let error = event.error; // event.error is an RTCError

  if (error.errorDetail === "sdp-syntax-error") {
    let errLine = error.sdpLineNumber;
    let errMessage = error.message;

    let alertMessage = `A syntax error occurred interpreting line ${errLine} of the SDP: ${errMessage}`;
    showMyAlertMessage("Data Channel Error", alertMessage);
  } else {
    terminateMyConnection();
  }
});
```

```js
dataChannel.onerror = (event) => {
  let error = event.error;

  /* and so forth */
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCError)*


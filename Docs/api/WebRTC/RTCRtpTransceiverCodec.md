# RTCRtpTransceiverCodec

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCRtpTransceiverCodec.cs`  
**MDN Reference:** [RTCRtpTransceiverCodec on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver/setCodecPreferences#channels)

> RTCRtpTransceiverCodec https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver/setCodecPreferences#channels

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCRtpTransceiverCodec` | `class` | get | RTCRtpTransceiverCodec https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver/setCodecPreferences#channels |
| `ClockRate` | `int` | get | A positive integer specifying the codec's clock rate in Hertz (Hz). The IANA maintains a list of codecs and their parameters, including their clock rates. |
| `MimeType` | `string` | get | A string indicating the codec's MIME media type and subtype. The MIME type strings used by RTP differ from those used elsewhere. See RFC 3555, section 4 for the complete IANA registry of these types. Also see Codecs used by WebRTC for details about potential codecs that might be referenced here. |
| `SdpFmtpLine` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCRtpTransceiverCodec>(...)` or constructor `new RTCRtpTransceiverCodec(...)`

### Creating the array of preferred codecs

```js
const availReceiveCodecs = transceiver.receiver.getCapabilities("video").codecs;
```

### Creating the array of preferred codecs

```js
function sortByMimeTypes(codecs, preferredOrder) {
  return codecs.sort((a, b) => {
    const indexA = preferredOrder.indexOf(a.mimeType);
    const indexB = preferredOrder.indexOf(b.mimeType);
    const orderA = indexA >= 0 ? indexA : Number.MAX_VALUE;
    const orderB = indexB >= 0 ? indexB : Number.MAX_VALUE;
    return orderA - orderB;
  });
}
```

### Creating the array of preferred codecs

```js
// Get supported codecs the sort using preferred codecs
const supportedCodecs = RTCRtpReceiver.getCapabilities("video").codecs;
const preferredCodecs = ["video/H264", "video/VP8", "video/VP9"];
const sortedCodecs = sortByMimeTypes(supportedCodecs, preferredCodecs);

// Get transceiver for connection and set the preferences
const [transceiver] = peerConnection.getTransceivers();
transceiver.setCodecPreferences(sortedCodecs); // <---
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver/setCodecPreferences)*


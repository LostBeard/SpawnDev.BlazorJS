# RTCRtpSendParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `RTCRtpParameters`  
**Source:** `JSObjects/WebRTC/RTCRtpSendParameters.cs`  

> Parameters for the send side of an RTP stream, returned by GetParameters and passed back (possibly modified) to SetParameters. The simulcast knobs are in Encodings - one encoding per simulcast layer, each with its own RID, bitrate cap, and resolution scale. https://www.w3.org/TR/webrtc/#dom-rtcrtpsendparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `TransactionId` | `string?` | get/set | Opaque token the browser generates on getParameters. Pass back unchanged on setParameters - setParameters rejects any call where transactionId doesn't match the value from the last getParameters (prevents lost-update races). Don't try to synthesize this value yourself. |
| `Encodings` | `RTCRtpEncodingParameters[]?` | get/set | Per-encoding parameters. A single-encoding array is the default (no simulcast); a multi-encoding array turns on simulcast with one layer per entry. Non-simulcast SVC layering uses a single encoding with ScalabilityMode set. |

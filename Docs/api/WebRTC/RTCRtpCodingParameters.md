# RTCRtpCodingParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebRTC/RTCRtpCodingParameters.cs`  

> Base dictionary for encoding/decoding parameters. Provides the per-encoding restriction identifier (RID) used by simulcast to distinguish encodings in the same m= section. https://www.w3.org/TR/webrtc/#dom-rtcrtpcodingparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Rid` | `string?` | get/set | RTP stream identifier (RID) for this encoding. Max 16 alphanumeric / `-` / `_` characters. Lets simulcast signal multiple encodings in one m= line so the receiver can tell them apart in the SDP a=rid and RTP header extension. Read-only after the initial createOffer (browsers reject RID changes at setParameters time per RFC 8853). |

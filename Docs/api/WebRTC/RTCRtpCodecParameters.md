# RTCRtpCodecParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebRTC/RTCRtpCodecParameters.cs`  

> One codec's negotiated parameters inside RTCRtpParameters. Populated from the negotiated SDP m= section; consumers round-trip these through setParameters rather than editing them (setCodecPreferences is the right knob for choosing codecs). https://www.w3.org/TR/webrtc/#dom-rtcrtpcodecparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PayloadType` | `int` | get/set | RTP payload type (SDP `a=rtpmap` first field, e.g. 96, 111). |
| `MimeType` | `string` | get/set | Codec MIME type (e.g. `"video/VP8"`, `"audio/opus"`). |
| `ClockRate` | `int` | get/set | Codec clock rate in Hz (e.g. 90000 for video, 48000 for Opus). |
| `Channels` | `int?` | get/set | Audio channel count. Present for audio codecs; omitted for video. |
| `SdpFmtpLine` | `string?` | get/set | Codec-specific format parameters from SDP `a=fmtp` (e.g. H.264 profile-level-id, Opus maxaveragebitrate). |

# RTCRtpEncodingParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `RTCRtpCodingParameters`  
**Source:** `JSObjects/WebRTC/RTCRtpEncodingParameters.cs`  

> Per-encoding parameters for an RTCRtpSender. The array-of-these field `encodings` on RTCRtpSendParameters is what simulcast is built on: pass 2+ encodings (each with its own Rid, bitrate cap, resolution scale) to emit multiple parallel encodings of the same track. https://www.w3.org/TR/webrtc/#dom-rtcrtpencodingparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Active` | `bool?` | get/set | Whether this encoding is currently being sent. Default true. Set false to temporarily mute an encoding without removing it from the parameters. |
| `MaxBitrate` | `uint?` | get/set | Maximum bitrate the encoder may use for this encoding, in bits per second. Not present = browser default (typically ~2.5 Mbps for video). Typical simulcast layering: 180p = 150_000, 360p = 500_000, 720p = 2_500_000. |
| `MaxFramerate` | `double?` | get/set | Maximum frame rate in frames per second. Omit for the encoder's default. |
| `ScaleResolutionDownBy` | `double?` | get/set | Factor by which to scale the source resolution down before encoding this layer. 1.0 = full, 2.0 = half-dimensions, 4.0 = quarter-dimensions. Simulcast layering typically uses 1.0 / 2.0 / 4.0 in the same `encodings` array to produce 720p + 360p + 180p from a 720p source. |
| `ScalabilityMode` | `string?` | get/set | Scalability mode identifier per the Scalable Video Coding spec (e.g. `"L1T1"`, `"L1T3"`, `"L3T3_KEY"`). Non-simulcast SVC layering uses this instead of multiple encodings. |
| `Priority` | `string?` | get/set | Application-level priority hint: `"very-low"`, `"low"`, `"medium"` (default), `"high"`. |
| `NetworkPriority` | `string?` | get/set | Network-level DSCP priority hint, same set as Priority. |

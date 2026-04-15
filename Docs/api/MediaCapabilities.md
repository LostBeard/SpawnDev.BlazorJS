# MediaCapabilities

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaCapabilities.cs`  
**MDN Reference:** [MediaCapabilities on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilities)

> The MediaCapabilities interface of the Media Capabilities API provides information about the decoding abilities of the device, system and browser. The API can be used to query the browser about the decoding abilities of the device based on codecs, profile, resolution, and bitrates. The information can be used to serve optimal media streams to the user and determine if playback should be smooth and power efficient. https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilities

## Constructors

| Signature | Description |
|---|---|
| `MediaCapabilities(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `DecodingInfo(DecodingConfiguration configuration)` | `Task<MediaCapabilitiesInfo>` | When passed a valid media configuration, it returns a promise with information as to whether the media type is supported, and whether decoding such media would be smooth and power efficient. |
| `EncodingInfo(EncodingConfiguration configuration)` | `Task<MediaCapabilitiesInfo>` | When passed a valid media configuration, it returns a promise with information as to whether the media type is supported, and whether encoding such media would be smooth and power efficient. |


# MediaCapabilitiesInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaCapabilitiesInfo.cs`  
**MDN Reference:** [MediaCapabilitiesInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilitiesInfo)

> The MediaCapabilitiesInfo interface of the Media Capabilities API is returned when MediaCapabilities.decodingInfo() or MediaCapabilities.encodingInfo() is called. It contains information about whether the media configuration is supported, and if so, whether decoding/encoding will be smooth and power efficient. https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilitiesInfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaCapabilitiesInfo` | `class` | get/set | The MediaCapabilitiesInfo interface of the Media Capabilities API is returned when MediaCapabilities.decodingInfo() or MediaCapabilities.encodingInfo() is called. It contains information about whether the media configuration is supported, and if so, whether decoding/encoding will be smooth and power efficient. https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilitiesInfo |
| `Smooth` | `bool` | get/set | true if playback of the media will be smooth (of high quality). Otherwise it is false. |
| `PowerEfficient` | `bool` | get | true if playback of the media will be power efficient. Otherwise, it is false. |


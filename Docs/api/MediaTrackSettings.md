# MediaTrackSettings

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaTrackSettings.cs`  
**MDN Reference:** [MediaTrackSettings on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings)

> MediaTrackSettings represents the Settings of a MediaStreamTrack object. Future specifications can extend the MediaTrackSettings dictionary by defining a partial dictionary with dictionary members of appropriate type. https://www.w3.org/TR/mediacapture-streams/#media-track-settings https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaTrackSettings` | `class` | get | MediaTrackSettings represents the Settings of a MediaStreamTrack object. Future specifications can extend the MediaTrackSettings dictionary by defining a partial dictionary with dictionary members of appropriate type. https://www.w3.org/TR/mediacapture-streams/#media-track-settings https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings |
| `GroupId` | `string` | get |  |
| `AutoGainControl` | `bool?` | get |  |
| `ChannelCount` | `double?` | get |  |
| `EchoCancellation` | `bool?` | get |  |
| `Latency` | `double?` | get |  |
| `NoiseSuppression` | `bool?` | get |  |
| `SampleRate` | `uint?` | get |  |
| `SampleSize` | `uint?` | get |  |
| `AspectRatio` | `double?` | get |  |
| `FacingMode` | `string?` | get |  |
| `FrameRate` | `double?` | get |  |
| `Height` | `uint?` | get |  |
| `Width` | `uint?` | get |  |
| `ResizeMode` | `string?` | get |  |
| `Cursor` | `string?` | get |  |
| `DisplaySurface` | `string?` | get |  |
| `LogicalSurface` | `bool?` | get |  |
| `BackgroundBlur` | `bool?` | get/set |  |
| `Brightness` | `double?` | get |  |
| `ColorTemperature` | `double?` | get/set |  |
| `Contrast` | `double?` | get |  |
| `ExposureCompensation` | `double?` | get/set |  |
| `ExposureTime` | `double?` | get/set |  |
| `Saturation` | `double?` | get/set |  |
| `Sharpness` | `double?` | get |  |
| `WhiteBalanceMode` | `EnumString<WhiteBalanceModeEnum>?` | get |  |
| `DeviceId` | `string` | get/set | A string indicating the current value of the deviceId property. The device ID is an origin-unique string identifying the source of the track; this is usually a GUID. This value is specific to the source of the track's data and is not usable for setting constraints; it can, however, be used for initially selecting media when calling MediaDevices.getUserMedia(). |


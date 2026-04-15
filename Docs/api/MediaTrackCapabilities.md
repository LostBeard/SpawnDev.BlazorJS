# MediaTrackCapabilities

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaTrackCapabilities.cs`  
**MDN Reference:** [MediaTrackCapabilities on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getCapabilities#return_value)

> Object which specifies the value or range of values which are supported for each of the user agent's supported constrainable properties https://www.w3.org/TR/mediacapture-streams/#media-track-capabilities https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getCapabilities#return_value https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo/getCapabilities#return_value Example: aspectRatio: {max: 1280, min: 0.001388888888888889}, deviceId: "a5b30cd91182cbd9ab169188e4f3508bc627922980f2e665dec7bcb2f092252b", facingMode: [], frameRate: { max: 60.000240325927734, min: 1}, groupId: "c6bef31820797c3cabe2b45b135ae2a8eb8f0b564d214942b6ca70bc45e2fdc4", height: { max: 720, min: 1}, resizeMode: ['none', 'crop-and-scale'], width: { max: 1280, min: 1},

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaTrackCapabilities` | `class` | get/set | Object which specifies the value or range of values which are supported for each of the user agent's supported constrainable properties https://www.w3.org/TR/mediacapture-streams/#media-track-capabilities https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getCapabilities#return_value https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo/getCapabilities#return_value Example: aspectRatio: {max: 1280, min: 0.001388888888888889}, deviceId: "a5b30cd91182cbd9ab169188e4f3508bc627922980f2e665dec7bcb2f092252b", facingMode: [], frameRate: { max: 60.000240325927734, min: 1}, groupId: "c6bef31820797c3cabe2b45b135ae2a8eb8f0b564d214942b6ca70bc45e2fdc4", height: { max: 720, min: 1}, resizeMode: ['none', 'crop-and-scale'], width: { max: 1280, min: 1}, |
| `Sharpness` | `DoubleRange?` | get/set |  |
| `Saturation` | `DoubleRange?` | get |  |
| `ExposureCompensation` | `DoubleRange?` | get/set |  |
| `Contrast` | `DoubleRange?` | get |  |
| `ColorTemperature` | `DoubleRange?` | get/set |  |
| `Brightness` | `DoubleRange?` | get/set |  |
| `Width` | `ULongRange?` | get/set |  |
| `Height` | `ULongRange?` | get |  |
| `AspectRatio` | `DoubleRange?` | get/set |  |
| `FrameRate` | `DoubleRange?` | get |  |
| `FacingMode` | `EnumString<VideoFacingModeEnum>[]?` | get |  |
| `ResizeMode` | `EnumString<VideoResizeModeEnum>[]?` | get |  |
| `SampleRate` | `ULongRange?` | get |  |
| `SampleSize` | `ULongRange?` | get |  |
| `EchoCancellation` | `bool[]?` | get |  |
| `AutoGainControl` | `bool[]?` | get |  |
| `NoiseSuppression` | `bool[]?` | get |  |
| `Latency` | `DoubleRange?` | get |  |
| `ChannelCount` | `ULongRange?` | get |  |
| `DeviceId` | `string?` | get |  |
| `GroupId` | `string?` | get |  |
| `BackgroundBlur` | `bool[]?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaTrackCapabilities>(...)` or constructor `new MediaTrackCapabilities(...)`

```js
navigator.mediaDevices
  .getUserMedia({ video: true, audio: true })
  .then((stream) => {
    const tracks = stream.getTracks();
    tracks.map((t) => console.log(t.getCapabilities()));
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getCapabilities)*


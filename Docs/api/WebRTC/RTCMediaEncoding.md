# RTCMediaEncoding

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCMediaEncoding.cs`  
**MDN Reference:** [RTCMediaEncoding on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpSender/setParameters#encodings)

> Parameters for a single codec that could be used to encode the track's media. https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpSender/setParameters#encodings

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCMediaEncoding` | `class` | get | Parameters for a single codec that could be used to encode the track's media. https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpSender/setParameters#encodings |
| `MaxBitrate` | `int?` | get |  |
| `MaxFramerate` | `int?` | get |  |
| `Priority` | `string?` | get/set |  |
| `Rid` | `string?` | get |  |
| `ScaleResolutionDownBy` | `float?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<RTCMediaEncoding>(...)` or constructor `new RTCMediaEncoding(...)`

### By the specification

```js
async function setVideoParams(sender, height, bitrate) {
  const scaleRatio = sender.track.getSettings().height / height;
  const params = sender.getParameters();

  params.encodings[0].scaleResolutionDownBy = Math.max(scaleRatio, 1);
  params.encodings[0].maxBitrate = bitrate;
  await sender.setParameters(params);
}
```

### Currently compatible implementation

```js
async function setVideoParams(sender, height, bitrate) {
  const scaleRatio = sender.track.getSettings().height / height;
  const params = sender.getParameters();

  // If encodings is null, create it
  params.encodings ??= [{}];
  params.encodings[0].scaleResolutionDownBy = Math.max(scaleRatio, 1);
  params.encodings[0].maxBitrate = bitrate;
  await sender.setParameters(params);

  // If the newly changed value of scaleResolutionDownBy is 1,
  // use applyConstraints() to be sure the height is constrained,
  // since scaleResolutionDownBy may not be implemented

  if (sender.getParameters().encodings[0].scaleResolutionDownBy === 1) {
    await sender.track.applyConstraints({ height });
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpSender/setParameters)*


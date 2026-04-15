# DisplayMediaStreamOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MediaStreamConstraints`  
**Source:** `JSObjects/DisplayMediaStreamOptions.cs`  
**MDN Reference:** [DisplayMediaStreamOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia#options)

> The DisplayMediaStreamOptions dictionary is used to instruct the user agent what sort of MediaStreamTracks may be included in the MediaStream returned by getDisplayMedia. https://www.w3.org/TR/screen-capture/#displaymediastreamoptions https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Controller` | `CaptureController?` | get |  |
| `MonitorTypeSurfaces` | `EnumString<MonitorTypeSurfacesEnum>?` | get |  |
| `SelfBrowserSurface` | `EnumString<SelfCapturePreferenceEnum>?` | get |  |
| `SurfaceSwitching` | `EnumString<SurfaceSwitchingPreferenceEnum>?` | get |  |
| `SystemAudio` | `EnumString<SystemAudioPreferenceEnum>?` | get |  |
| `PreferCurrentTab` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DisplayMediaStreamOptions>(...)` or constructor `new DisplayMediaStreamOptions(...)`

```js
const displayMediaOptions = {
  video: {
    displaySurface: "browser",
  },
  audio: {
    suppressLocalAudioPlayback: false,
  },
  preferCurrentTab: false,
  selfBrowserSurface: "exclude",
  systemAudio: "include",
  surfaceSwitching: "include",
  monitorTypeSurfaces: "include",
};

async function startCapture(displayMediaOptions) {
  let captureStream;

  try {
    captureStream =
      await navigator.mediaDevices.getDisplayMedia(displayMediaOptions);
  } catch (err) {
    console.error(`Error: ${err}`);
  }
  return captureStream;
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getDisplayMedia)*

## Examples

**JavaScript (MDN):**

```js
const displayMediaOptions = {
  video: {
    displaySurface: "browser",
  },
  audio: {
    suppressLocalAudioPlayback: false,
  },
  preferCurrentTab: false,
  selfBrowserSurface: "exclude",
  systemAudio: "include",
  surfaceSwitching: "include",
  monitorTypeSurfaces: "include",
};

async function startCapture(displayMediaOptions) {
  let captureStream;

  try {
    captureStream =
      await navigator.mediaDevices.getDisplayMedia(displayMediaOptions);
  } catch (err) {
    console.error(`Error: ${err}`);
  }
  return captureStream;
}
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

var displayMediaOptions = {
video: {
displaySurface: "browser",
},
audio: {
suppressLocalAudioPlayback: false,
},
preferCurrentTab: false,
selfBrowserSurface: "exclude",
systemAudio: "include",
surfaceSwitching: "include",
monitorTypeSurfaces: "include",
};

async Task startCapture(displayMediaOptions)
{
var captureStream;

try {
captureStream =
await JS.Get<Navigator>("navigator").MediaDevices.getDisplayMedia(displayMediaOptions);
} catch (err) {
Console.Error.WriteLine($"Error: {err}");
}
return captureStream;
}
```


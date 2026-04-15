# HTMLVideoElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Element -> HTMLElement -> HTMLMediaElement -> HTMLVideoElement  
**MDN Reference:** [HTMLVideoElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/HTMLVideoElement.cs`

> The HTMLVideoElement interface provides properties and methods for manipulating video objects. It inherits from HTMLMediaElement which provides playback controls (play, pause, volume, seeking), and adds video-specific properties like width/height and poster.

## Constructor

```csharp
public HTMLVideoElement(IJSInProcessObjectReference _ref)
```

## Properties (Video-Specific)

| Property | Type | Description |
|---|---|---|
| `VideoWidth` | `int` | The intrinsic width of the video in CSS pixels. |
| `VideoHeight` | `int` | The intrinsic height of the video in CSS pixels. |
| `Width` | `int` | Get/set the width attribute (display width). |
| `Height` | `int` | Get/set the height attribute (display height). |
| `Poster` | `string` | Get/set the poster image URL. |
| `PlaysInline` | `bool` | Get/set whether to play inline (not fullscreen on mobile). |

## Properties (Inherited from HTMLMediaElement)

| Property | Type | Description |
|---|---|---|
| `Src` | `string` | Get/set the media source URL. |
| `CurrentSrc` | `string` | The current media source URL being used. |
| `CurrentTime` | `double` | Get/set the current playback position in seconds. |
| `Duration` | `double` | The total duration in seconds. NaN if unknown. |
| `Volume` | `double` | Get/set the volume (0.0 to 1.0). |
| `Muted` | `bool` | Get/set the muted state. |
| `Paused` | `bool` | Whether playback is paused. |
| `Ended` | `bool` | Whether playback has ended. |
| `ReadyState` | `ushort` | The readiness state (0-4). |
| `Controls` | `bool` | Get/set whether playback controls are shown. |
| `Autoplay` | `bool` | Get/set the autoplay attribute. |
| `Loop` | `bool` | Get/set the loop attribute. |
| `PlaybackRate` | `double` | Get/set the playback speed (1.0 = normal). |
| `DefaultPlaybackRate` | `double` | Get/set the default playback rate. |
| `Seeking` | `bool` | Whether the media is currently seeking. |
| `NetworkState` | `ushort` | The network state (0-3). |
| `Preload` | `string` | Get/set the preload hint ("none"/"metadata"/"auto"). |
| `CrossOrigin` | `string?` | Get/set the CORS setting. |
| `SrcObject` | `MediaStream?` | Get/set the media source as a MediaStream. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Play()` | `Task` | Start playback. Returns a Promise. |
| `Pause()` | `void` | Pause playback. |
| `Load()` | `void` | Reset and reload the media resource. |
| `CanPlayType(string mediaType)` | `string` | Check codec support ("", "maybe", "probably"). |
| `RequestPictureInPicture()` | `Task` | Request Picture-in-Picture mode. |
| `GetVideoPlaybackQuality()` | `VideoPlaybackQuality` | Get playback quality statistics. |
| `CaptureStream()` | `MediaStream` | Capture the video as a MediaStream. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnPlay` | `ActionEvent<Event>` | Fired when playback starts. |
| `OnPause` | `ActionEvent<Event>` | Fired when playback pauses. |
| `OnEnded` | `ActionEvent<Event>` | Fired when playback reaches the end. |
| `OnTimeUpdate` | `ActionEvent<Event>` | Fired as currentTime updates during playback. |
| `OnLoadedMetadata` | `ActionEvent<Event>` | Fired when metadata (duration, dimensions) is loaded. |
| `OnLoadedData` | `ActionEvent<Event>` | Fired when the first frame is loaded. |
| `OnCanPlay` | `ActionEvent<Event>` | Fired when enough data to start playback. |
| `OnCanPlayThrough` | `ActionEvent<Event>` | Fired when enough data to play without buffering. |
| `OnVolumeChange` | `ActionEvent<Event>` | Fired when volume or muted changes. |
| `OnSeeking` | `ActionEvent<Event>` | Fired when a seek operation begins. |
| `OnSeeked` | `ActionEvent<Event>` | Fired when a seek operation completes. |
| `OnWaiting` | `ActionEvent<Event>` | Fired when playback stops due to lack of data. |
| `OnPlaying` | `ActionEvent<Event>` | Fired when playback starts after being paused/delayed. |
| `OnProgress` | `ActionEvent<Event>` | Fired as media data is being downloaded. |
| `OnError` | `ActionEvent<Event>` | Fired when an error occurs. |
| `OnAbort` | `ActionEvent<Event>` | Fired when loading is aborted. |
| `OnStalled` | `ActionEvent<Event>` | Fired when the browser is trying to fetch but data is unavailable. |
| `OnRateChange` | `ActionEvent<Event>` | Fired when playback rate changes. |
| `OnDurationChange` | `ActionEvent<Event>` | Fired when duration changes. |
| `OnEmptied` | `ActionEvent<Event>` | Fired when the media becomes empty. |
| `OnSuspend` | `ActionEvent<Event>` | Fired when loading is suspended. |

## Example - From SpawnDev.BlazorJS README

```csharp
@inject BlazorJSRuntime JS

// Create a video element
using var video = JS.DocumentCreateElement<HTMLVideoElement>("video");
video.Controls = true;
video.Muted = true;
video.Width = 640;
video.Height = 480;

// Set source
video.Src = "https://example.com/video.mp4";

// Add to document
JS.DocumentBodyAppendChild(video);

// Wait for metadata
void OnMetadata(Event e)
{
    Console.WriteLine($"Video: {video.VideoWidth}x{video.VideoHeight}");
    Console.WriteLine($"Duration: {video.Duration}s");
    video.OnLoadedMetadata -= OnMetadata;
}
video.OnLoadedMetadata += OnMetadata;

// Play
await video.Play();
```

## Example - MediaStream Source

```csharp
// Use with getUserMedia for camera/mic
using var stream = await navigator.MediaDevices.GetUserMedia(
    new MediaStreamConstraints { Video = true });
video.SrcObject = stream;
await video.Play();
```

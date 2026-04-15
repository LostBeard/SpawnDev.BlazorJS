# HTMLVideoElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLMediaElement`  
**Source:** `JSObjects/DOM/HTMLVideoElement.cs`  
**MDN Reference:** [HTMLVideoElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement)

> Implemented by the video element, the HTMLVideoElement interface provides special properties and methods for manipulating video objects. It also inherits properties and methods of HTMLMediaElement and HTMLElement. https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLVideoElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLVideoElement(ElementReference elementReference)` | Get an instance from an ElementReference |
| `HTMLVideoElement()` | Create a new instance of HTMLVideoElement |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoWidth` | `int` | get | Returns an unsigned integer value indicating the intrinsic height of the resource in CSS pixels, or 0 if no media is available yet. |
| `VideoHeight` | `int` | get | Returns an unsigned integer value indicating the intrinsic width of the resource in CSS pixels, or 0 if no media is available yet. |
| `SupportsRequestVideoFrameCallback` | `bool` | get | Returns true if RequestVideoFrameCallback is defined |
| `Preload` | `string` | get | This enumerated attribute is intended to provide a hint to the browser about what the author thinks will lead to the best user experience regarding what content is loaded before the video is played. It may have one of the following values: none: Indicates that the video should not be preloaded. metadata: Indicates that only video metadata (e.g. length) is fetched. auto: Indicates that the whole video file can be downloaded, even if the user is not expected to use it. empty string: Synonym of the auto value. |
| `PlaysInline` | `bool` | get | A Boolean attribute indicating that the video is to be played "inline", that is within the element's playback area. Note that the absence of this attribute does not imply that the video will always be played in fullscreen. |
| `Poster` | `string` | get | A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing is displayed until the first frame is available, then the first frame is shown as the poster frame. |
| `DisablePictureInPicture` | `bool` | get | Indicates if the user agent should suggest the picture-in-picture to users, or not. |
| `Width` | `int` | get | A string that reflects the width HTML attribute, which specifies the width of the display area, in CSS pixels. |
| `Height` | `int` | get | An unsigned long that reflects the height HTML attribute, which specifies the height of the display area, in CSS pixels. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestVideoFrameCallback(ActionCallback callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestVideoFrameCallback(ActionCallback<double> callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestVideoFrameCallback(ActionCallback<double, VideoFrameMetadata> callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestVideoFrameCallback(Action callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestVideoFrameCallback(Action<double> callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestVideoFrameCallback(Action<double, VideoFrameMetadata> callback)` | `void` | The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources. |
| `RequestPictureInPicture()` | `Task<PictureInPictureWindow>` | The HTMLVideoElement.requestPictureInPicture() method issues an asynchronous request to display the video in a "picture-in-picture" mode. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResize` | `ActionEvent<Event>` | Fired when one or both of the videoWidth and videoHeight properties have just been updated. |
| `OnEnterPictureInPicture` | `ActionEvent<PictureInPictureEvent>` | Fired when the HTMLVideoElement enters picture-in-picture mode successfully. |
| `OnLeavePictureInPicture` | `ActionEvent<PictureInPictureEvent>` | Fired when the HTMLVideoElement leaves picture-in-picture mode successfully. |

## Example

```csharp
// Create a video element from a Blazor ElementReference
using var video = new HTMLVideoElement(videoRef);

// Or create a video element programmatically
using var video2 = new HTMLVideoElement();
video2.Src = "https://example.com/video.mp4";
video2.Controls = true;
video2.Muted = true;
video2.AutoPlay = true;

// Listen for metadata loaded to get video dimensions
video.OnLoadedMetadata += (e) =>
{
    int width = video.VideoWidth;
    int height = video.VideoHeight;
    double? duration = video.Duration;
    Console.WriteLine($"Video: {width}x{height}, {duration}s");
};

// Play and pause
await video.Play();
video.Pause();

// Seek to a specific time (seconds)
video.CurrentTime = 30.5;

// Set playback rate
video.PlaybackRate = 2.0;

// Set volume (0.0 to 1.0)
video.Volume = 0.5;

// Listen for playback events (inherited from HTMLMediaElement)
video.OnPlay += (e) => Console.WriteLine("Playing");
video.OnPause += (e) => Console.WriteLine("Paused");
video.OnEnded += (e) => Console.WriteLine("Playback ended");
video.OnTimeUpdate += (e) => Console.WriteLine($"Time: {video.CurrentTime}");

// Use a MediaStream as source (e.g. from getUserMedia)
video.SrcObject = mediaStream;

// Capture the video as a MediaStream
using var capturedStream = video.CaptureStream();

// Request picture-in-picture
using var pipWindow = await video.RequestPictureInPicture();
```


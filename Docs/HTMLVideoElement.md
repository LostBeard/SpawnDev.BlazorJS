# HTMLVideoElement - Proper Usage Guide

SpawnDev.BlazorJS provides a fully typed `HTMLVideoElement` wrapper for the browser's `<video>` element. This document covers the correct patterns for creating, configuring, and using video elements in Blazor WebAssembly applications.

## Class Hierarchy

```
JSObject
  -> EventTarget
    -> Node
      -> Element
        -> HTMLElement
          -> HTMLMediaElement    (SrcObject, Play, Pause, Volume, events)
            -> HTMLVideoElement  (VideoWidth, VideoHeight, RequestVideoFrameCallback)
```

## Creating an HTMLVideoElement

### From a Blazor @ref ElementReference (most common)

When you have a `<video>` element rendered by Blazor, use `@ref` to get an `ElementReference`, then pass it to the constructor:

```razor
<video @ref="_videoRef" autoplay muted playsinline></video>

@code {
    private ElementReference _videoRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        using var video = new HTMLVideoElement(_videoRef);
        // video is now a typed wrapper around the DOM element
    }
}
```

The constructor `HTMLVideoElement(ElementReference)` internally calls `JS.ToJSRef(elementReference)` to convert the Blazor reference into a JavaScript object reference. You never need to call `ToJSRef` yourself.

### Using the explicit cast operator

HTMLVideoElement defines an explicit cast from ElementReference:

```csharp
HTMLVideoElement? video = (HTMLVideoElement?)_videoRef;
// or for non-nullable:
HTMLVideoElement video = (HTMLVideoElement)_videoRef!;
```

### Creating a detached (offscreen) video element

For offscreen processing (frame capture, ML inference, etc.) where no visible `<video>` element exists in the DOM:

```csharp
using var video = new HTMLVideoElement();
// Creates document.createElement("video") internally
// Not attached to the DOM - invisible, no rendering
```

## Attaching a MediaStream (Camera, WebRTC, etc.)

The `SrcObject` property on `HTMLMediaElement` (parent class) attaches media sources:

```csharp
// Attach a camera stream
using var video = new HTMLVideoElement(_videoRef);
video.SrcObject = mediaStream;       // Union<MediaStream, File, Blob, MediaSource>?
await video.Play();

// Detach
video.SrcObject = null;
```

The `SrcObject` setter accepts:
- `MediaStream` - webcam, screen capture, WebRTC remote stream
- `File` - local video file
- `Blob` - video data blob
- `MediaSource` - Media Source Extensions (MSE) for adaptive streaming

To read back the attached stream:

```csharp
using var stream = video.GetSrcObject<MediaStream>();
```

## Reading Video Properties

```csharp
int width = video.VideoWidth;       // Native video resolution width
int height = video.VideoHeight;     // Native video resolution height
double duration = video.Duration;   // Total duration in seconds
double current = video.CurrentTime; // Current playback position
bool paused = video.Paused;
bool ended = video.Ended;
bool muted = video.Muted;
```

## Playback Control

```csharp
await video.Play();       // Start playback (async - returns Promise)
video.Pause();            // Pause playback (sync)
video.Load();             // Reload the media resource
video.CurrentTime = 5.0;  // Seek to 5 seconds
video.Volume = 0.5f;      // 50% volume
video.PlaybackRate = 2.0; // 2x speed
video.Loop = true;        // Loop playback
video.Muted = true;       // Mute audio
```

## Events

HTMLVideoElement inherits all HTMLMediaElement events and adds its own:

```csharp
// Media events (from HTMLMediaElement)
video.OnLoadedMetadata += (e) => { /* metadata loaded, dimensions available */ };
video.OnCanPlay += (e) => { /* enough data to start playback */ };
video.OnPlay += (e) => { /* playback started */ };
video.OnPause += (e) => { /* playback paused */ };
video.OnEnded += (e) => { /* playback reached the end */ };
video.OnTimeUpdate += (e) => { /* currentTime changed during playback */ };
video.OnError += (e) => { /* error occurred */ };
video.OnVolumeChange += (e) => { /* volume or muted changed */ };

// Video-specific events
video.OnResize += (e) => { /* video dimensions changed */ };
video.OnEnterPictureInPicture += (e) => { /* entered PiP mode */ };
video.OnLeavePictureInPicture += (e) => { /* left PiP mode */ };

// IMPORTANT: Always remove event handlers before disposing
video.OnLoadedMetadata -= handler;
```

## Capturing Video Frames

Draw the video to a canvas to extract pixel data:

```csharp
using var video = new HTMLVideoElement(_videoRef);
using var canvas = new HTMLCanvasElement();
canvas.Width = video.VideoWidth;
canvas.Height = video.VideoHeight;
using var ctx = canvas.GetContext2D();
ctx.DrawImage(video, 0, 0, canvas.Width, canvas.Height);
using var imageData = ctx.GetImageData(0, 0, canvas.Width, canvas.Height);
byte[] pixels = imageData.Data.ReadBytes();
```

## RequestVideoFrameCallback

For frame-accurate video processing (newer browsers):

```csharp
video.RequestVideoFrameCallback((double now, VideoFrameCallbackMetadata metadata) =>
{
    // Called once per video frame
    // now = DOMHighResTimeStamp
    // metadata = frame timing, dimensions, etc.
});
```

## Picture-in-Picture

```csharp
using var pipWindow = await video.RequestPictureInPicture();
// pipWindow has Width, Height, OnResize
```

## Common Patterns

### WebRTC Remote Video

```razor
<video @ref="_remoteVideoRef" autoplay playsinline></video>

@code {
    private ElementReference _remoteVideoRef;

    private void HandleRemoteTrack(MediaStreamTrack track)
    {
        using var video = new HTMLVideoElement(_remoteVideoRef);
        using var stream = new MediaStream();
        stream.AddTrack(track);
        video.SrcObject = stream;
    }
}
```

### Webcam Preview

```razor
<video @ref="_previewRef" autoplay muted playsinline></video>

@code {
    private ElementReference _previewRef;

    private async Task StartCamera()
    {
        using var navigator = JS.Get<Navigator>("navigator");
        using var mediaDevices = navigator.MediaDevices;
        var stream = await mediaDevices.GetUserMedia(new { video = true, audio = false });

        using var video = new HTMLVideoElement(_previewRef);
        video.SrcObject = stream;
    }
}
```

### ML Inference from Camera

```csharp
// Create offscreen video for ML processing
using var video = new HTMLVideoElement();
video.SrcObject = cameraStream;
await video.Play();

// Capture frame for inference
using var canvas = new HTMLCanvasElement();
canvas.Width = targetWidth;
canvas.Height = targetHeight;
using var ctx = canvas.GetContext2D();
ctx.DrawImage(video, 0, 0, targetWidth, targetHeight);
using var imageData = ctx.GetImageData(0, 0, targetWidth, targetHeight);
// Feed imageData to model...
```

## What NOT To Do

```csharp
// WRONG: Using document.getElementById to find video elements
JS.Call<HTMLVideoElement>("document.getElementById", "my-video");
// Use @ref and the constructor instead

// WRONG: Using ToJSRef<T> generic (doesn't exist)
JS.ToJSRef<HTMLVideoElement>(_videoRef);
// Use new HTMLVideoElement(_videoRef) instead

// WRONG: Creating duplicate BlazorJSRuntime variables
var JS = BlazorJSRuntime.JS;
var JS2 = BlazorJSRuntime.JS;  // Why?
// Inject once via @inject or use the static once

// WRONG: Using raw IJSInProcessObjectReference for typed wrappers
var jsRef = JS.ToJSRef(_videoRef);
jsRef.Set("srcObject", stream);  // Bypasses typed API
// Use new HTMLVideoElement(_videoRef) which gives you typed properties
```

## Disposal

HTMLVideoElement wraps a JavaScript object reference. Always dispose when done:

```csharp
// Option 1: using statement (preferred)
using var video = new HTMLVideoElement(_videoRef);

// Option 2: manual dispose
var video = new HTMLVideoElement(_videoRef);
try { /* use video */ }
finally { video.Dispose(); }

// Option 3: persistent reference (component-level)
// Dispose in component's Dispose() method
private HTMLVideoElement? _video;

public void Dispose()
{
    _video?.Dispose();
}
```

## References

- [MDN: HTMLVideoElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement)
- [MDN: HTMLMediaElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement)
- SpawnDev.BlazorJS source: `SpawnDev.BlazorJS/JSObjects/DOM/HTMLVideoElement.cs`
- SpawnDev.BlazorJS source: `SpawnDev.BlazorJS/JSObjects/DOM/HTMLMediaElement.cs`

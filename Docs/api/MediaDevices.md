# MediaDevices

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MediaDevices.cs`  
**MDN Reference:** [MediaDevices on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices)

> The MediaDevices interface provides access to connected media input devices like cameras and microphones, as well as screen sharing. In essence, it lets you obtain access to any hardware source of media data. https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices

## Constructors

| Signature | Description |
|---|---|
| `MediaDevices(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Supported` | `bool` | get | Returns true if the MediaDevices interface is supported. |
| `GetDisplayMediaSupported` | `bool` | get | Returns true if getDisplayMedia is supported. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDisplayMedia(object options)` | `Task<MediaStream?>` | Prompts the user to select a display or portion of a display (such as a window) to capture as a MediaStream for sharing or recording purposes. Returns a promise that resolves to a MediaStream. |
| `GetDisplayMedia(DisplayMediaStreamOptions options)` | `Task<MediaStream?>` | The getDisplayMedia() method of the MediaDevices interface prompts the user to select and grant permission to capture the contents of a display or portion thereof (such as a window) as a MediaStream. An optional object specifying requirements for the returned MediaStream. The options for getDisplayMedia() work in the same as the constraints for the MediaDevices.getUserMedia() method, although in that case only audio and video can be specified. A Promise that resolves to a MediaStream containing a video track whose contents come from a user-selected screen area, as well as an optional audio track. |
| `GetDisplayMedia()` | `Task<MediaStream?>` | Prompts the user to select a display or portion of a display (such as a window) to capture as a MediaStream for sharing or recording purposes. Returns a promise that resolves to a MediaStream. |
| `AreDevicesHidden()` | `Task<bool>` | Returns true if there is at least 1 device enumerated with an empty or null label or deviceId |
| `EnumerateDevices()` | `Task<MediaDeviceInfo[]>` | Obtains an array of information about the media input and output devices available on the system. |
| `GetUserMedia(object constraints)` | `Task<MediaStream?>` | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input. An object specifying the types of media to request, along with any requirements for each type. The constraints parameter is an object with two members: video and audio, describing the media types requested. Either or both must be specified. If the browser cannot find all media tracks with the specified types that meet the constraints given, then the returned promise is rejected with NotFoundError DOMException. |
| `GetUserMedia(MediaStreamConstraints constraints)` | `Task<MediaStream?>` | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input. An object specifying the types of media to request, along with any requirements for each type. The constraints parameter is an object with two members: video and audio, describing the media types requested. Either or both must be specified. If the browser cannot find all media tracks with the specified types that meet the constraints given, then the returned promise is rejected with NotFoundError DOMException. |
| `GetUserMedia(bool video, bool audio)` | `Task<MediaStream?>` | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input. A Task whose fulfillment handler receives a MediaStream object when the requested media has successfully been obtained. |
| `GetMediaDeviceStream(string? deviceIdVideo, string? deviceIdAudio)` | `Task<MediaStream?>` | With the user's permission through a prompt, turns on a camera and/or a microphone on the system and provides a MediaStream containing a video track and/or an audio track with the input. |
| `GetSupportedConstraints()` | `Dictionary<string, bool>` | Returns an object conforming to MediaTrackSupportedConstraints indicating which constrainable properties are supported on the MediaStreamTrack interface. See Media Streams API to learn more about constraints and how to use them. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDeviceChange` | `ActionEvent<Event>` | Fired when a media input or output device is attached to or removed from the user's computer. |

## Example

```csharp
// Check if MediaDevices is supported
if (!MediaDevices.Supported)
{
    Console.WriteLine("MediaDevices API not available");
    return;
}

// Get the MediaDevices object from Navigator
using var navigator = new Navigator();
using var mediaDevices = navigator.MediaDevices;

// Enumerate all available media devices
var devices = await mediaDevices.EnumerateDevices();
foreach (var device in devices)
{
    Console.WriteLine($"  {device.Kind}: {device.Label} (id: {device.DeviceId})");
    device.Dispose();
}

// Request camera and microphone access with the simple bool overload
using var stream = await mediaDevices.GetUserMedia(video: true, audio: true);
if (stream != null)
{
    Console.WriteLine($"Got stream with {stream.GetVideoTracks().Length} video tracks");
}

// Request with detailed constraints
using var constrainedStream = await mediaDevices.GetUserMedia(new MediaStreamConstraints
{
    Video = new MediaTrackConstraints
    {
        Width = new ConstrainULongRange { Ideal = 1920 },
        Height = new ConstrainULongRange { Ideal = 1080 }
    },
    Audio = new MediaTrackConstraints()
});

// Screen sharing (if supported)
if (MediaDevices.GetDisplayMediaSupported)
{
    using var displayStream = await mediaDevices.GetDisplayMedia();
    if (displayStream != null)
    {
        Console.WriteLine("Screen capture started");
    }
}

// Listen for device changes (e.g., USB camera plugged in)
Action<Event> onDeviceChange = (Event e) =>
{
    Console.WriteLine("Media devices changed!");
    e.Dispose();
};
mediaDevices.OnDeviceChange += onDeviceChange;

// Check what constraints are supported
var supported = mediaDevices.GetSupportedConstraints();
foreach (var kvp in supported)
{
    if (kvp.Value) Console.WriteLine($"  Supported: {kvp.Key}");
}

// Clean up event handler
mediaDevices.OnDeviceChange -= onDeviceChange;
```


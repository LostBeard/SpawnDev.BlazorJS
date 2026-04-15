# MediaRecorder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MediaRecorder.cs`  
**MDN Reference:** [MediaRecorder on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaRecorder)

> The MediaRecorder interface of the MediaStream Recording API provides functionality to easily record media. It is created using the MediaRecorder() constructor. https://developer.mozilla.org/en-US/docs/Web/API/MediaRecorder

## Constructors

| Signature | Description |
|---|---|
| `MediaRecorder(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MediaRecorder(MediaStream stream)` | Creates a new MediaRecorder object, given a MediaStream to record. Options are available to do things like set the container's MIME type (such as "video/webm" or "video/mp4") and the bit rates of the audio and video tracks or a single overall bit rate. The MediaStream that will be recorded. This source media can come from a stream created using navigator.MediaDevices.getUserMedia() or from an audio, video or canvas element. |
| `MediaRecorder(MediaStream stream, MediaRecorderOptions options)` | Creates a new MediaRecorder object, given a MediaStream to record. Options are available to do things like set the container's MIME type (such as "video/webm" or "video/mp4") and the bit rates of the audio and video tracks or a single overall bit rate. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MimeType` | `string` | get | Returns the MIME type that was selected as the recording container for the MediaRecorder object when it was created. |
| `State` | `string` | get | Returns the current state of the MediaRecorder object (inactive, recording, or paused.) |
| `Stream` | `MediaStream` | get | Returns the stream that was passed into the constructor when the MediaRecorder was created. |
| `VideoBitsPerSecond` | `long` | get | Returns the video encoding bit rate in use. This may differ from the bit rate specified in the constructor (if it was provided). |
| `AudioBitsPerSecond` | `long` | get | Returns the audio encoding bit rate in use. This may differ from the bit rate specified in the constructor (if it was provided). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `IsTypeSupported(string mimeType)` | `bool` | A static method which returns a true or false value indicating if the given MIME media type is supported by the current user agent. |
| `Pause()` | `void` | Pauses the recording of media. |
| `RequestData()` | `void` | Used to raise a dataavailable event containing a Blob object of the captured media as it was when the method was called. This can then be grabbed and manipulated as you wish. |
| `Resume()` | `void` | Resumes recording of media after having been paused. |
| `Start()` | `void` | Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk. |
| `Start(double timeslice)` | `void` | Begins recording media; this method can optionally be passed a timeslice argument with a value in milliseconds. If this is specified, the media will be captured in separate chunks of that duration, rather than the default behavior of recording the media in a single large chunk. The number of milliseconds to record into each Blob. If this parameter isn't included, the entire media duration is recorded into a single Blob unless the requestData() method is called to obtain the Blob and trigger the creation of a new Blob into which the media continues to be recorded. |
| `Stop()` | `void` | Stops recording, at which point a dataavailable event containing the final Blob of saved data is fired. No more recording occurs. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDataAvailable` | `ActionEvent<BlobEvent>` | Fires periodically each time timeslice milliseconds of media have been recorded (or when the entire media has been recorded, if timeslice wasn't specified). The event, of type BlobEvent, contains the recorded media in its data property. |
| `OnError` | `ActionEvent<MediaRecorderErrorEvent>` | Fired when there are fatal errors that stop recording. The received event is based on the MediaRecorderErrorEvent interface, whose error property contains a DOMException that describes the actual error that occurred. |
| `OnPause` | `ActionEvent<Event>` | Fired when media recording is paused. |
| `OnResume` | `ActionEvent<Event>` | Fired when media recording resumes after being paused. |
| `OnStart` | `ActionEvent<Event>` | Fired when media recording starts. |
| `OnStop` | `ActionEvent<Event>` | Fired when media recording ends, either when the MediaStream ends, or after the MediaRecorder.stop() method is called. |

## Example

```csharp
// Check if a MIME type is supported before recording
bool webmSupported = MediaRecorder.IsTypeSupported("video/webm;codecs=vp9");
bool oggSupported = MediaRecorder.IsTypeSupported("audio/ogg;codecs=opus");

// Get a media stream from the user's microphone
using var navigator = JS.Get<Navigator>("navigator");
using var mediaDevices = navigator.MediaDevices;
using var stream = await mediaDevices.GetUserMedia(new { audio = true });

// Create a MediaRecorder with options
using var recorder = new MediaRecorder(stream, new MediaRecorderOptions
{
    MimeType = "audio/webm;codecs=opus"
});

// Collect recorded chunks via the OnDataAvailable event
var chunks = new List<Blob>();
recorder.OnDataAvailable += (BlobEvent e) =>
{
    using (e)
    {
        using var data = e.Data;
        if (data != null)
        {
            chunks.Add(data);
        }
    }
};

// Handle recording stop - combine chunks into a final Blob
recorder.OnStop += (Event e) =>
{
    using (e)
    {
        using var blob = new Blob(chunks.ToArray(), new BlobOptions { Type = "audio/webm" });
        foreach (var chunk in chunks) chunk.Dispose();
        chunks.Clear();

        // Create an object URL for playback
        string audioUrl = URL.CreateObjectURL(blob);
        Console.WriteLine($"Recording available at: {audioUrl}");
    }
};

// Monitor recording state changes
recorder.OnStart += (Event e) =>
{
    using (e)
    Console.WriteLine($"Recording started - state: {recorder.State}");
};

recorder.OnPause += (Event e) =>
{
    using (e)
    Console.WriteLine("Recording paused");
};

recorder.OnResume += (Event e) =>
{
    using (e)
    Console.WriteLine("Recording resumed");
};

// Start recording (optionally with a timeslice in ms)
recorder.Start(1000); // fire OnDataAvailable every 1000ms

// Check properties during recording
string mimeType = recorder.MimeType;
string state = recorder.State; // "recording"
long videoBps = recorder.VideoBitsPerSecond;
long audioBps = recorder.AudioBitsPerSecond;

// Pause and resume
recorder.Pause();
recorder.Resume();

// Request data immediately (triggers OnDataAvailable)
recorder.RequestData();

// Stop recording (triggers final OnDataAvailable then OnStop)
recorder.Stop();
```


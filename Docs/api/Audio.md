# Audio

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLAudioElement`  
**Source:** `JSObjects/Audio.cs`  
**MDN Reference:** [Audio on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/audio)

> The audio HTML element is used to embed sound content in documents. It may contain one or more audio sources, represented using the src attribute or the source element: the browser will choose the most suitable one. It can also be the destination for streamed media, using a MediaStream. https://developer.mozilla.org/en-US/docs/Web/HTML/Element/audio https://developer.mozilla.org/en-US/docs/Web/API/HTMLAudioElement/Audio

## Constructors

| Signature | Description |
|---|---|
| `Audio(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Audio(string url)` | The Audio() constructor creates and returns a new HTMLAudioElement which can be either attached to a document for the user to interact with and/or listen to, or can be used offscreen to manage and play audio. |

## Example

```csharp
// Create an Audio element from a URL (inherits all HTMLMediaElement members)
using var audio = new Audio("/sounds/notification.mp3");

// Set volume (0.0 to 1.0)
audio.Volume = 0.5;

// Enable looping
audio.Loop = true;

// Set playback rate (1.0 = normal, 2.0 = double speed)
audio.PlaybackRate = 1.0;

// Mute/unmute
audio.Muted = false;

// Start playback (returns a Task - browser may require user gesture)
await audio.Play();

// Check playback state
Console.WriteLine($"Paused: {audio.Paused}");
Console.WriteLine($"Current time: {audio.CurrentTime}s");
Console.WriteLine($"Duration: {audio.Duration}s");
Console.WriteLine($"Ended: {audio.Ended}");

// Seek to a specific time
audio.CurrentTime = 30.0;

// Pause playback
audio.Pause();

// Handle events
Action<Event> onEnded = (Event e) =>
{
    Console.WriteLine("Audio playback finished");
    e.Dispose();
};
audio.OnEnded += onEnded;

Action<Event> onCanPlay = (Event e) =>
{
    Console.WriteLine("Audio is ready to play");
    e.Dispose();
};
audio.OnCanPlay += onCanPlay;

Action<Event> onTimeUpdate = (Event e) =>
{
    Console.WriteLine($"Time: {audio.CurrentTime:F1}s");
    e.Dispose();
};
audio.OnTimeUpdate += onTimeUpdate;

// Check if a format is supported
var canPlay = audio.CanPlayType("audio/ogg; codecs=vorbis");
Console.WriteLine($"OGG support: {canPlay}"); // "probably", "maybe", or ""

// Clean up events before disposal
audio.OnEnded -= onEnded;
audio.OnCanPlay -= onCanPlay;
audio.OnTimeUpdate -= onTimeUpdate;
```


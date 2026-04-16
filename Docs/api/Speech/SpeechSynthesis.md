# SpeechSynthesis

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Speech/SpeechSynthesis.cs`  

> The SpeechSynthesis interface of the Web Speech API is the controller interface for the speech service; this can be used to retrieve information about the synthesis voices available on the device, start and pause speech, and other commands besides.

## Constructors

| Signature | Description |
|---|---|
| `SpeechSynthesis(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Paused` | `bool` | get | Returns a boolean value that returns true if the SpeechSynthesis object is in a paused state. |
| `Pending` | `bool` | get | Returns a boolean value that returns true if the utterance queue contains as-yet-unspoken utterances. |
| `Speaking` | `bool` | get | Returns a boolean value that returns true if an utterance is currently in the process of being spoken - even if SpeechSynthesis is in a paused state. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Cancel()` | `void` | Removes all utterances from the utterance queue. |
| `GetVoices()` | `List<SpeechSynthesisVoice>` | Returns a list of SpeechSynthesisVoice objects representing all the available voices on the current device. |
| `Pause()` | `void` | Puts the SpeechSynthesis object into a paused state. |
| `Resume()` | `void` | Puts the SpeechSynthesis object into a non-paused state: resumes it if it was previously paused. |
| `Speak(SpeechSynthesisUtterance utterance)` | `void` | Adds an utterance to the utterance queue; it will be spoken when any other utterances queued before it have been spoken. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnVoicesChanged` | `ActionEvent<Event>` | Fired when the list of available voices has changed. |

## Example

```csharp
// Access SpeechSynthesis from the window object
using var speechSynthesis = JS.Get<SpeechSynthesis>("speechSynthesis");

// Get available voices
var voices = speechSynthesis.GetVoices();
Console.WriteLine($"Available voices: {voices.Count}");
foreach (var voice in voices)
{
    Console.WriteLine($"  {voice.Name} ({voice.Lang}) - default: {voice.Default}");
    voice.Dispose();
}

// Create an utterance to speak
using var utterance = new SpeechSynthesisUtterance("Hello from Blazor WebAssembly!");
utterance.Lang = "en-US";
utterance.Rate = 1.0f;    // Speed: 0.1 to 10
utterance.Pitch = 1.0f;   // Pitch: 0 to 2
utterance.Volume = 1.0f;  // Volume: 0 to 1

// Optionally set a specific voice
var englishVoices = speechSynthesis.GetVoices().Where(v => v.Lang.StartsWith("en")).ToList();
if (englishVoices.Count > 0)
{
    utterance.Voice = englishVoices[0];
    foreach (var v in englishVoices) v.Dispose();
}

// Listen for speech events (named method for proper cleanup)
utterance.OnEnd += Utterance_OnEnd;

// Speak the utterance
speechSynthesis.Speak(utterance);
Console.WriteLine($"Speaking: {speechSynthesis.Speaking}");

// Pause and resume
// speechSynthesis.Pause();
// speechSynthesis.Resume();

// Cancel all queued utterances
// speechSynthesis.Cancel();

// Clean up event handler before disposal
utterance.OnEnd -= Utterance_OnEnd;

void Utterance_OnEnd(SpeechSynthesisEvent e)
{
    Console.WriteLine("Finished speaking");
}
```


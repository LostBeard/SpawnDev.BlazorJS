# SpeechRecognition

**Namespace:** `SpawnDev.BlazorJS.JSObjects.Speech`  
**Inheritance:** `JSObject` -> `EventTarget` -> `SpeechRecognition`  
**MDN Reference:** [SpeechRecognition - MDN](https://developer.mozilla.org/en-US/docs/Web/API/SpeechRecognition)

> The `SpeechRecognition` interface of the Web Speech API is the controller for the recognition service. It handles the `SpeechRecognitionEvent` sent from the recognition service. Use it to transcribe speech from the user's microphone.

## Constructors

| Signature | Description |
|---|---|
| `SpeechRecognition()` | Creates a new `SpeechRecognition` instance. |
| `SpeechRecognition(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Continuous` | `bool` | get/set | If `true`, results are returned continuously (not just once). |
| `InterimResults` | `bool` | get/set | If `true`, interim (non-final) results are returned. |
| `Lang` | `string` | get/set | The language for recognition (BCP 47, e.g., `"en-US"`). |
| `MaxAlternatives` | `int` | get/set | Maximum number of alternative transcriptions. Default: 1. |
| `Grammars` | `SpeechGrammarList` | get/set | The grammars for the recognizer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start()` | `void` | Starts the recognition service. |
| `Stop()` | `void` | Stops and returns the final result. |
| `Abort()` | `void` | Stops without returning a result. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResult` | `ActionEvent<SpeechRecognitionEvent>` | Fired when a result is available. |
| `OnEnd` | `ActionEvent<Event>` | Fired when the service disconnects. |
| `OnStart` | `ActionEvent<Event>` | Fired when recognition starts. |
| `OnError` | `ActionEvent<SpeechRecognitionErrorEvent>` | Fired on error. |
| `OnNoMatch` | `ActionEvent<SpeechRecognitionEvent>` | Fired when no match is found. |
| `OnAudioStart` | `ActionEvent<Event>` | Fired when audio capture starts. |
| `OnAudioEnd` | `ActionEvent<Event>` | Fired when audio capture ends. |
| `OnSoundStart` | `ActionEvent<Event>` | Fired when sound is detected. |
| `OnSoundEnd` | `ActionEvent<Event>` | Fired when sound stops. |
| `OnSpeechStart` | `ActionEvent<Event>` | Fired when speech is detected. |
| `OnSpeechEnd` | `ActionEvent<Event>` | Fired when speech stops. |

## Example

```csharp
using var recognition = new SpeechRecognition();
recognition.Lang = "en-US";
recognition.Continuous = true;
recognition.InterimResults = true;

// Subscribe using named methods (required for proper cleanup)
recognition.OnResult += Recognition_OnResult;
recognition.OnError += Recognition_OnError;

recognition.Start();

// Clean up event handlers before disposal
recognition.OnResult -= Recognition_OnResult;
recognition.OnError -= Recognition_OnError;

void Recognition_OnResult(SpeechRecognitionEvent e)
{
    // Process results
    Console.WriteLine("Speech recognized");
}

void Recognition_OnError(SpeechRecognitionErrorEvent e)
{
    Console.WriteLine($"Error: {e.Error}");
}
```

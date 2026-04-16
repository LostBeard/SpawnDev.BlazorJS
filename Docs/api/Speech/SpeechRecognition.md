# SpeechRecognition

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Speech/SpeechRecognition.cs`  

> The SpeechRecognition interface of the Web Speech API is the controller interface for the recognition service; this also handles the SpeechRecognitionEvent sent from the recognition service.

## Constructors

| Signature | Description |
|---|---|
| `SpeechRecognition(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `SpeechRecognition()` | Creates a new SpeechRecognition. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Grammars` | `SpeechGrammarList` | get | Returns and sets a collection of SpeechGrammar objects that represent the grammars that will be understood by the current SpeechRecognition. |
| `Lang` | `string` | get | Returns and sets the language of the current SpeechRecognition. If not specified, this defaults to the HTML lang attribute value, or the user agent's language setting if that isn't set either. |
| `Continuous` | `bool` | get | Returns and sets whether continuous results are returned for each recognition, or only a single result. Defaults to false (single result). |
| `InterimResults` | `bool` | get | Returns and sets whether interim results should be returned (true) or not (false). Interim results are results that are not yet final (e.g. the SpeechRecognitionResult.isFinal property is false). |
| `MaxAlternatives` | `int` | get | Returns and sets the maximum number of SpeechRecognitionAlternative objects provided per result. The default value is 1. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start()` | `void` | Starts the speech recognition service listening to incoming audio with intent to recognize grammars associated with the current SpeechRecognition. |
| `Stop()` | `void` | Stops the speech recognition service from listening to incoming audio, and attempts to return a SpeechRecognitionResult using the audio captured so far. |
| `Abort()` | `void` | Stops the speech recognition service from listening to incoming audio, and doesn't attempt to return a SpeechRecognitionResult. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAudioEnd` | `ActionEvent<Event>` | Fired when the speech recognition service has detached from a stream or some other reason. |
| `OnAudioStart` | `ActionEvent<Event>` | Fired when the user agent has started to capture audio. |
| `OnEnd` | `ActionEvent<Event>` | Fired when the speech recognition service has finished listening to incoming audio. |
| `OnError` | `ActionEvent<SpeechRecognitionErrorEvent>` | Fired when a speech recognition error occurs. |
| `OnNoMatch` | `ActionEvent<SpeechRecognitionEvent>` | Fired when the speech recognition service returns a final result with no significant recognition. This may involve some degree of recognition, which doesn't meet or exceed the confidence threshold. |
| `OnResult` | `ActionEvent<SpeechRecognitionEvent>` | Fired when the speech recognition service returns a result - a word or phrase has been positively recognized and this has been communicated back to the app. |
| `OnSoundEnd` | `ActionEvent<Event>` | Fired when the sound that is being recognized has stopped being detected. |
| `OnSoundStart` | `ActionEvent<Event>` | Fired when any sound - recognisable speech or not - has been detected. |
| `OnSpeechEnd` | `ActionEvent<Event>` | Fired when the speech recognition service has stopped being detected. |
| `OnSpeechStart` | `ActionEvent<Event>` | Fired when sound that is recognized by the speech recognition service as speech has been detected. |
| `OnStart` | `ActionEvent<Event>` | Fired when the speech recognition service has begun listening to incoming audio with intent to recognize grammars associated with the current SpeechRecognition. |

## Example

```csharp
// Create a speech recognition instance
using var recognition = new SpeechRecognition();

// Configure recognition settings
recognition.Lang = "en-US";
recognition.Continuous = true;
recognition.InterimResults = true;
recognition.MaxAlternatives = 1;

// Subscribe to events using named methods (required for proper cleanup)
recognition.OnResult += Recognition_OnResult;
recognition.OnError += Recognition_OnError;
recognition.OnEnd += Recognition_OnEnd;
recognition.OnStart += Recognition_OnStart;

// Start listening (requires microphone permission)
recognition.Start();

// Stop listening and get final result
// recognition.Stop();

// Or abort without returning results
// recognition.Abort();

// Clean up event handlers before disposal
recognition.OnResult -= Recognition_OnResult;
recognition.OnError -= Recognition_OnError;
recognition.OnEnd -= Recognition_OnEnd;
recognition.OnStart -= Recognition_OnStart;

void Recognition_OnResult(SpeechRecognitionEvent e)
{
    using var results = e.Results;
    var index = e.ResultIndex;
    using var result = results[index];
    using var alternative = result[0];
    Console.WriteLine($"Recognized: {alternative.Transcript} (confidence: {alternative.Confidence})");
}

void Recognition_OnError(SpeechRecognitionErrorEvent e)
{
    Console.WriteLine($"Speech recognition error: {e.Error}");
}

void Recognition_OnEnd(Event e)
{
    Console.WriteLine("Speech recognition ended");
    // Restart if continuous listening is desired
}

void Recognition_OnStart(Event e)
{
    Console.WriteLine("Listening for speech...");
}
```


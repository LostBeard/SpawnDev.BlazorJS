# OfflineAudioCompletionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/OfflineAudioCompletionEvent.cs`  
**MDN Reference:** [OfflineAudioCompletionEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioCompletionEvent)

> The Web Audio API OfflineAudioCompletionEvent interface represents events that occur when the processing of an OfflineAudioContext is terminated. The complete event uses this interface. https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioCompletionEvent

## Constructors

| Signature | Description |
|---|---|
| `OfflineAudioCompletionEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RenderedBuffer` | `AudioBuffer` | get | An AudioBuffer containing the result of the audio processing. |


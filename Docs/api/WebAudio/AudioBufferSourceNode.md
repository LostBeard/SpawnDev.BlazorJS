# AudioBufferSourceNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioScheduledSourceNode`  
**Source:** `JSObjects/WebAudio/AudioBufferSourceNode.cs`  
**MDN Reference:** [AudioBufferSourceNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioBufferSourceNode)

> https://developer.mozilla.org/en-US/docs/Web/API/AudioBufferSourceNode

## Constructors

| Signature | Description |
|---|---|
| `AudioBufferSourceNode(AudioContext context, AudioBufferSourceNodeOptions? options)` | The AudioBufferSourceNode() constructor creates a new AudioBufferSourceNode object instance. A reference to an AudioContext. Optional |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Buffer` | `AudioBuffer?` | get | An AudioBuffer that defines the audio asset to be played, or when set to the value null, defines a single channel of silence (in which every sample is 0.0). |
| `Detune` | `AudioParam?` | get | A k-rate AudioParam representing detuning of playback in cents. This value is compounded with playbackRate to determine the speed at which the sound is played. Its default value is 0 (meaning no detuning), and its nominal range is -∞ to ∞. |
| `Loop` | `bool` | get | A Boolean attribute indicating if the audio asset must be replayed when the end of the AudioBuffer is reached. Its default value is false. |
| `LoopStart` | `float` | get | A floating-point value indicating the time, in seconds, at which playback of the AudioBuffer must begin when loop is true. Its default value is 0 (meaning that at the beginning of each loop, playback begins at the start of the audio buffer). |
| `LoopEnd` | `float` | get | A floating-point number indicating the time, in seconds, at which playback of the AudioBuffer stops and loops back to the time indicated by loopStart, if loop is true. The default value is 0. |
| `PlaybackRate` | `AudioParam?` | get | A k-rate AudioParam that defines the speed factor at which the audio asset will be played, where a value of 1.0 is the sound's natural sampling rate. Since no pitch correction is applied on the output, this can be used to change the pitch of the sample. This value is compounded with detune to determine the final playback rate. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start(float when, float offset)` | `void` | The start() method of the AudioBufferSourceNode Interface is used to schedule playback of the audio data contained in the buffer, or to begin playback immediately. The time, in seconds, at which the sound should begin to play, in the same time coordinate system used by the AudioContext. If when is less than (AudioContext.currentTime, or if it's 0, the sound begins to play at once. The default value is 0. An offset, specified as the number of seconds in the same time coordinate system as the AudioContext, to the time within the audio buffer that playback should begin. For example, to start playback halfway through a 10-second audio clip, offset should be 5. The default value, 0, will begin playback at the beginning of the audio buffer, and offsets past the end of the audio which will be played (based on the audio buffer's duration and/or the loopEnd property) are silently clamped to the maximum value allowed. The computation of the offset into the sound is performed using the sound buffer's natural sample rate, rather than the current playback rate, so even if the sound is playing at twice its normal speed, the midway point through a 10-second audio buffer is still 5. |
| `Start(float when, float offset, float duration)` | `void` | The start() method of the AudioBufferSourceNode Interface is used to schedule playback of the audio data contained in the buffer, or to begin playback immediately. The time, in seconds, at which the sound should begin to play, in the same time coordinate system used by the AudioContext. If when is less than (AudioContext.currentTime, or if it's 0, the sound begins to play at once. The default value is 0. An offset, specified as the number of seconds in the same time coordinate system as the AudioContext, to the time within the audio buffer that playback should begin. For example, to start playback halfway through a 10-second audio clip, offset should be 5. The default value, 0, will begin playback at the beginning of the audio buffer, and offsets past the end of the audio which will be played (based on the audio buffer's duration and/or the loopEnd property) are silently clamped to the maximum value allowed. The computation of the offset into the sound is performed using the sound buffer's natural sample rate, rather than the current playback rate, so even if the sound is playing at twice its normal speed, the midway point through a 10-second audio buffer is still 5. The duration of the sound to be played, specified in seconds. If this parameter isn't specified, the sound plays until it reaches its natural conclusion or is stopped using the stop() method. Using this parameter is functionally identical to calling start(when, offset) and then calling stop(when+duration). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioBufferSourceNode>(...)` or constructor `new AudioBufferSourceNode(...)`

```js
const audioCtx = new AudioContext();

// Create an empty three-second stereo buffer at the sample rate of the AudioContext
const myArrayBuffer = audioCtx.createBuffer(
  2,
  audioCtx.sampleRate * 3,
  audioCtx.sampleRate,
);

// Fill the buffer with white noise;
// just random values between -1.0 and 1.0
for (let channel = 0; channel < myArrayBuffer.numberOfChannels; channel++) {
  // This gives us the actual ArrayBuffer that contains the data
  const nowBuffering = myArrayBuffer.getChannelData(channel);
  for (let i = 0; i < myArrayBuffer.length; i++) {
    // Math.random() is in [0; 1.0]
    // audio needs to be in [-1.0; 1.0]
    nowBuffering[i] = Math.random() * 2 - 1;
  }
}

// Get an AudioBufferSourceNode.
// This is the AudioNode to use when we want to play an AudioBuffer
const source = audioCtx.createBufferSource();
// set the buffer in the AudioBufferSourceNode
source.buffer = myArrayBuffer;
// connect the AudioBufferSourceNode to the
// destination so we can hear the sound
source.connect(audioCtx.destination);
// start the source playing
source.start();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioBufferSourceNode)*


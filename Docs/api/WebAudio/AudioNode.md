# AudioNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebAudio/AudioNode.cs`  
**MDN Reference:** [AudioNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioNode)

> The AudioNode interface is a generic interface for representing an audio processing module. https://developer.mozilla.org/en-US/docs/Web/API/AudioNode

## Constructors

| Signature | Description |
|---|---|
| `AudioNode(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Context` | `BaseAudioContext` | get | Returns the associated BaseAudioContext. |
| `NumberOfInputs` | `int` | get | Returns the number of inputs feeding the node. |
| `NumberOfOutputs` | `int` | get | Returns the number of outputs coming out of the node. |
| `ChannelCount` | `int` | get | Represents an integer used to determine how many channels are used when up-mixing and down-mixing connections to any inputs to the node. |
| `ChannelCountMode` | `string` | get | Represents an enumerated value describing the way channels must be matched between the node's inputs and outputs. Possible values: "max", "clamped-max", "explicit". |
| `ChannelInterpretation` | `string` | get | Represents an enumerated value describing the meaning of the channels. Possible values: "speakers", "discrete". |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Connect(AudioNode audioNode)` | `AudioNode` | The connect() method of the AudioNode interface lets you connect one of the node's outputs to a target, which may be either another AudioNode (thereby directing the sound data to the specified node) or an AudioParam, so that the node's output data is automatically used to change the value of that parameter over time. |
| `Connect(AudioParam audioParam)` | `void` | The connect() method of the AudioNode interface lets you connect one of the node's outputs to a target, which may be either another AudioNode (thereby directing the sound data to the specified node) or an AudioParam, so that the node's output data is automatically used to change the value of that parameter over time. |
| `Disconnect()` | `void` | Allows us to disconnect the current node from another one it is already connected to. |
| `Disconnect(AudioNode audioNode)` | `void` | Allows us to disconnect the current node from another one it is already connected to. |
| `Disconnect(AudioParam audioParam)` | `void` | Allows us to disconnect the current node from another one it is already connected to. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioNode>(...)` or constructor `new AudioNode(...)`

```js
const audioCtx = new AudioContext();

const oscillator = new OscillatorNode(audioCtx);
const gainNode = new GainNode(audioCtx);

oscillator.connect(gainNode).connect(audioCtx.destination);

oscillator.context;
oscillator.numberOfInputs;
oscillator.numberOfOutputs;
oscillator.channelCount;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioNode)*


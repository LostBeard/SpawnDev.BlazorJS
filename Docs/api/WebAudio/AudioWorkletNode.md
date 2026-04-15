# AudioWorkletNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/AudioWorkletNode.cs`  
**MDN Reference:** [AudioWorkletNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioWorkletNode)

> The AudioWorkletNode interface of the Web Audio API represents a base class for a user-defined AudioNode, which can be connected to an audio routing graph along with other nodes. https://developer.mozilla.org/en-US/docs/Web/API/AudioWorkletNode

## Constructors

| Signature | Description |
|---|---|
| `AudioWorkletNode(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AudioWorkletNode(BaseAudioContext context, string name)` | Creates a new AudioWorkletNode object. The BaseAudioContext instance this node will be associated with. A string that represents the name of the AudioWorkletProcessor this node will be based on. |
| `AudioWorkletNode(BaseAudioContext context, string name, AudioWorkletNodeOptions options)` | Creates a new AudioWorkletNode object. The BaseAudioContext instance this node will be associated with. A string that represents the name of the AudioWorkletProcessor this node will be based on. An object containing options for the AudioWorkletNode. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Port` | `MessagePort` | get | Returns a MessagePort used for bidirectional communication between the node and its associated AudioWorkletProcessor. |
| `Parameters` | `JSObject` | get | Returns an object containing AudioParam objects for each of the custom parameters defined in the processor. |
| `AudioWorkletNodeOptions` | `class` | get/set | Options for creating an AudioWorkletNode. |
| `NumberOfOutputs` | `int?` | get/set | The value to initialize the numberOfOutputs property. Defaults to 1. |
| `OutputChannelCount` | `int[]?` | get | An array defining the number of channels for each output. |
| `ParameterData` | `Dictionary<string, double>?` | get | An object containing the initial values of custom AudioParam objects on this node (as defined in the processor's parameterDescriptors static getter). |
| `ProcessorOptions` | `object?` | get | Any additional data that can be used for custom initialization of the underlying AudioWorkletProcessor. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnProcessorError` | `ActionEvent<Event>` | Fired when the AudioWorkletProcessor behind the node throws an error. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioWorkletNode>(...)` or constructor `new AudioWorkletNode(...)`

```js
// random-noise-processor.js
class RandomNoiseProcessor extends AudioWorkletProcessor {
  process(inputs, outputs, parameters) {
    const output = outputs[0];
    output.forEach((channel) => {
      for (let i = 0; i < channel.length; i++) {
        channel[i] = Math.random() * 2 - 1;
      }
    });
    return true;
  }
}

registerProcessor("random-noise-processor", RandomNoiseProcessor);
```

```js
const audioContext = new AudioContext();
await audioContext.audioWorklet.addModule("random-noise-processor.js");
const randomNoiseNode = new AudioWorkletNode(
  audioContext,
  "random-noise-processor",
);
randomNoiseNode.connect(audioContext.destination);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioWorkletNode)*


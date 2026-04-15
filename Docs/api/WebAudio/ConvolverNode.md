# ConvolverNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/ConvolverNode.cs`  
**MDN Reference:** [ConvolverNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ConvolverNode)

> The ConvolverNode interface is an AudioNode that performs a Linear Convolution on a given AudioBuffer, often used to achieve a reverb effect. A ConvolverNode always has exactly one input and one output. https://developer.mozilla.org/en-US/docs/Web/API/ConvolverNode

## Constructors

| Signature | Description |
|---|---|
| `ConvolverNode(BaseAudioContext context, ConvolverNodeOptions? options)` | Crates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Buffer` | `AudioBuffer` | get/set | A mono, stereo, or 4-channel AudioBuffer containing the (possibly multichannel) impulse response used by the ConvolverNode to create the reverb effect. |
| `Normalize` | `bool` | get | A boolean that controls whether the impulse response from the buffer will be scaled by an equal-power normalization when the buffer attribute is set, or not. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ConvolverNode>(...)` or constructor `new ConvolverNode(...)`

```js
let audioCtx = new window.AudioContext();

async function createReverb() {
  let convolver = audioCtx.createConvolver();

  // load impulse response from file
  let response = await fetch("path/to/impulse-response.wav");
  let arraybuffer = await response.arrayBuffer();
  convolver.buffer = await audioCtx.decodeAudioData(arraybuffer);

  return convolver;
}

// …

let reverb = await createReverb();

// someOtherAudioNode -> reverb -> destination
someOtherAudioNode.connect(reverb);
reverb.connect(audioCtx.destination);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ConvolverNode)*


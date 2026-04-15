# DelayNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/DelayNode.cs`  
**MDN Reference:** [DelayNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext/createDelay)

> https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext/createDelay

## Constructors

| Signature | Description |
|---|---|
| `DelayNode(BaseAudioContext context, DelayNodeOptions? options)` | Crates a new instance |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DelayTime` | `AudioParam` | get | An a-rate AudioParam representing the amount of delay to apply, specified in seconds. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DelayNode>(...)` or constructor `new DelayNode(...)`

```js
const audioCtx = new AudioContext();

const synthDelay = audioCtx.createDelay(5.0);

// …

let synthSource;

playSynth.onclick = () => {
  synthSource = audioCtx.createBufferSource();
  synthSource.buffer = buffers[2];
  synthSource.loop = true;
  synthSource.start();
  synthSource.connect(synthDelay);
  synthDelay.connect(destination);
  this.setAttribute("disabled", "disabled");
};

stopSynth.onclick = () => {
  synthSource.disconnect(synthDelay);
  synthDelay.disconnect(destination);
  synthSource.stop();
  playSynth.removeAttribute("disabled");
};

// …

let delay1;
rangeSynth.oninput = () => {
  delay1 = rangeSynth.value;
  synthDelay.delayTime.setValueAtTime(delay1, audioCtx.currentTime);
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext/createDelay)*


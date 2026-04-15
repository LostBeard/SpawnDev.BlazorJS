# AudioDestinationNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/AudioDestinationNode.cs`  
**MDN Reference:** [AudioDestinationNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioDestinationNode)

> https://developer.mozilla.org/en-US/docs/Web/API/AudioDestinationNode

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MaxChannelCount` | `long` | get | An unsigned long defining the maximum number of channels that the physical device can handle. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioDestinationNode>(...)` or constructor `new AudioDestinationNode(...)`

```js
const audioCtx = new AudioContext();
const source = audioCtx.createMediaElementSource(myMediaElement);
source.connect(gainNode);
gainNode.connect(audioCtx.destination);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioDestinationNode)*


# DelayNodeOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebAudio/DelayNodeOptions.cs`  
**MDN Reference:** [DelayNodeOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DelayNode/DelayNode#options)

> https://developer.mozilla.org/en-US/docs/Web/API/DelayNode/DelayNode#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DelayNodeOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/DelayNode/DelayNode#options |
| `MaxDelayTime` | `float?` | get |  |
| `ChannelCount` | `int?` | get |  |
| `ChannelCountMode` | `string?` | get |  |
| `ChannelInterpretation` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DelayNodeOptions>(...)` or constructor `new DelayNodeOptions(...)`

```js
const audioCtx = new AudioContext();
const delayNode = new DelayNode(audioCtx, {
  delayTime: 0.5,
  maxDelayTime: 2,
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DelayNode/DelayNode)*


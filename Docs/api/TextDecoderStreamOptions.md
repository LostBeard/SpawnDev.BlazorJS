# TextDecoderStreamOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/TextDecoderStreamOptions.cs`  
**MDN Reference:** [TextDecoderStreamOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream/TextDecoderStream#options)

> TextDecoderStream options https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream/TextDecoderStream#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `TextDecoderStreamOptions` | `class` | get | TextDecoderStream options https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream/TextDecoderStream#options |
| `IgnoreBOM` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<TextDecoderStreamOptions>(...)` or constructor `new TextDecoderStreamOptions(...)`

```js
const response = await fetch("https://example.com");
const stream = response.body.pipeThrough(new TextDecoderStream());
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream/TextDecoderStream)*


# TextDecoderOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/TextDecoderOptions.cs`  
**MDN Reference:** [TextDecoderOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder/TextDecoder#options)

> https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder/TextDecoder#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `TextDecoderOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder/TextDecoder#options |
| `Fatal` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<TextDecoderOptions>(...)` or constructor `new TextDecoderOptions(...)`

```js
const textDecoder1 = new TextDecoder("iso-8859-2");

const textDecoder2 = new TextDecoder();

const textDecoder3 = new TextDecoder("csiso2022kr", { fatal: true });
// Allows TypeError exception to be thrown.

const textDecoder4 = new TextDecoder("iso-2022-cn");
// Throws a RangeError exception.
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder/TextDecoder)*


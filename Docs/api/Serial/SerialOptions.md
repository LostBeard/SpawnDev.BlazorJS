# SerialOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/Serial/SerialOptions.cs`  
**MDN Reference:** [SerialOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/open#options)

> Serial port open options https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/open#options https://wicg.github.io/serial/#serialoptions-dictionary

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SerialOptions` | `class` | get | Serial port open options https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/open#options https://wicg.github.io/serial/#serialoptions-dictionary |
| `BufferSize` | `int?` | get |  |
| `DataBits` | `byte?` | get |  |
| `FlowControl` | `EnumString<FlowControlType>?` | get |  |
| `Parity` | `EnumString<ParityType>?` | get |  |
| `StopBits` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SerialOptions>(...)` or constructor `new SerialOptions(...)`

```js
await port.open({ baudRate: 9600 /* pick your baud rate */ });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/open)*


# MIDIInput

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MIDIPort`  
**Source:** `JSObjects/MIDIInput.cs`  
**MDN Reference:** [MIDIInput on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIInput)

> The MIDIInput interface of the Web MIDI API receives messages from a MIDI input port. https://developer.mozilla.org/en-US/docs/Web/API/MIDIInput

## Constructors

| Signature | Description |
|---|---|
| `MIDIInput(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Events

| Event | Type | Description |
|---|---|---|
| `OnMIDIMessage` | `ActionEvent<MIDIMessageEvent>` | Fired when the current port receives a MIDI message. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MIDIInput>(...)` or constructor `new MIDIInput(...)`

```js
inputs.forEach((input) => {
  console.log(input.name); /* inherited property from MIDIPort */
  input.onmidimessage = (message) => {
    console.log(message.data);
  };
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MIDIInput)*

